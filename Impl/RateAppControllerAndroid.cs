#if UNITY_ANDROID || UNITY_EDITOR

using System.Collections;
using Build1.PostMVC.Core.MVCS.Events;
using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Unity.App.Modules.Coroutines;
using Google.Play.Review;
using UnityEngine;

namespace Build1.PostMVC.Unity.RateApp.Impl
{
    public sealed class RateAppControllerAndroid : IRateAppController
    {
        [Inject] public IEventDispatcher   Dispatcher        { get; set; }
        [Inject] public ICoroutineProvider CoroutineProvider { get; set; }

        private Coroutine _coroutine;

        [PreDestroy]
        public void PreDestroy()
        {
            CoroutineProvider.StopCoroutine(ref _coroutine);
        }

        /*
         * Protected.
         */

        public void RequestStoreReview()
        {
            CoroutineProvider.StartCoroutine(OpenReviewDialogImpl(), out _coroutine);
        }

        /*
         * Private.
         */

        private IEnumerator OpenReviewDialogImpl()
        {
            var reviewManager = new ReviewManager();
            var requestFlowOperation = reviewManager.RequestReviewFlow();

            yield return requestFlowOperation;

            if (requestFlowOperation.Error != ReviewErrorCode.NoError)
            {
                Dispatcher.Dispatch(RateAppEvent.Fail, RateAppFailReason.PlatformError);
                yield break;
            }

            var playReviewInfo = requestFlowOperation.GetResult();
            var launchFlowOperation = reviewManager.LaunchReviewFlow(playReviewInfo);

            yield return launchFlowOperation;

            if (launchFlowOperation.Error != ReviewErrorCode.NoError)
                Dispatcher.Dispatch(RateAppEvent.Fail, RateAppFailReason.PlatformError);
            else
                Dispatcher.Dispatch(RateAppEvent.Success);
        }
    }
}
#endif