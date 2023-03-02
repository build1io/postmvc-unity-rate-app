namespace Build1.PostMVC.Unity.RateApp
{
    public interface IRateAppController
    {
        bool StoreReviewRequested { get; }

        void RequestStoreReview();
    }
}