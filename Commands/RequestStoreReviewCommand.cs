using Build1.PostMVC.Core.MVCS.Commands;
using Build1.PostMVC.Core.MVCS.Injection;

namespace Build1.PostMVC.Unity.RateApp.Commands
{
    public sealed class RequestStoreReviewCommand : Command
    {
        [Inject] public IRateAppController RateAppController { get; set; }
        
        public override void Execute()
        {
            if (!RateAppController.StoreReviewRequested)
                RateAppController.RequestStoreReview();
        }
    }
}