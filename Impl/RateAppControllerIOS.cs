#if UNITY_IOS || UNITY_EDITOR

using Build1.PostMVC.Core.MVCS.Events;
using Build1.PostMVC.Core.MVCS.Injection;
using UnityEngine.iOS;

namespace Build1.PostMVC.Unity.RateApp.Impl
{
    public sealed class RateAppControllerIOS : IRateAppController
    {
        [Inject] public IEventDispatcher Dispatcher { get; set; }

        public bool StoreReviewRequested { get; private set; }
        
        public void RequestStoreReview()
        {
            if (StoreReviewRequested)
                return;

            StoreReviewRequested = true;
            
            var success = Device.RequestStoreReview();
            if (success)
                Dispatcher.Dispatch(RateAppEvent.Success);
            else
                Dispatcher.Dispatch(RateAppEvent.Fail, RateAppFailReason.IOSVersionNotCompatibleOrStoreKitNotLinked);
        }
    }
}
#endif