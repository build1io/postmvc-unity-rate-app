#if UNITY_EDITOR

using Build1.PostMVC.Core.MVCS.Events;
using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Unity.App.Modules.Logging;
using UnityEditor;
using UnityEngine;

namespace Build1.PostMVC.Unity.RateApp.Impl
{
    public sealed class RateAppControllerEditor : IRateAppController
    {
        [Log(LogLevel.Warning)] public ILog             Log        { get; set; }
        [Inject]                public IEventDispatcher Dispatcher { get; set; }

        public void RequestStoreReview()
        {
            Log.Debug("Simulating RateApp in Editor...");
            
            var success = EditorUtility.DisplayDialog("Rate App", $"Would you like to rate {Application.productName}?", "Rate", "Not Now");
            if (success)
            {
                Log.Debug("Success");
                Dispatcher.Dispatch(RateAppEvent.Success);
            }
            else
            {
                Log.Debug($"Fail: {RateAppFailReason.UserCancelled}");
                Dispatcher.Dispatch(RateAppEvent.Fail, RateAppFailReason.UserCancelled);
            }
        }
    }
}

#endif