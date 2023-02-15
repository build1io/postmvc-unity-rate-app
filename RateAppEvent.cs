using Build1.PostMVC.Core.MVCS.Events;

namespace Build1.PostMVC.Unity.RateApp
{
    public static class RateAppEvent
    {
        public static readonly Event                    Success = new(typeof(RateAppEvent), nameof(Success));
        public static readonly Event<RateAppFailReason> Fail    = new(typeof(RateAppEvent), nameof(Fail));
    }
}