namespace Build1.PostMVC.Unity.RateApp
{
    public enum RateAppFailReason
    {
        UserCancelled = 1,

        IOSVersionNotCompatibleOrStoreKitNotLinked = 10,

        AndroidReviewFlowRequestFail = 20,
        AndroidReviewFlowLaunchFail  = 21
    }
}