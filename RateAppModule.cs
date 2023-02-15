using Build1.PostMVC.Core.Modules;
using Build1.PostMVC.Core.MVCS.Injection;

namespace Build1.PostMVC.Unity.RateApp
{
    public sealed class RateAppModule : Module
    {
        [Inject] public IInjectionBinder InjectionBinder { get; set; }

        [PostConstruct]
        public void PostConstruct()
        {
            #if UNITY_EDITOR
            InjectionBinder.Bind<IRateAppController, Impl.RateAppControllerEditor>().AsSingleton();
            #elif UNITY_IOS
            InjectionBinder.Bind<IRateAppController, Impl.RateAppControllerIOS>().AsSingleton();
            #elif UNITY_ANDROID
            InjectionBinder.Bind<IRateAppController, Impl.RateAppControllerAndroid>().AsSingleton();
            #endif
        }
    }
}