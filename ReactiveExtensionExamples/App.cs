namespace ReactiveExtensionExamples
{
    using Refit;
    using Splat;
    using Xamarin.Forms;

    public class App : Application
    {
        public App()
        {
            Values.Styles.Initialize();
            MainPage = new Features.Main.DetailPage();
        }

        protected override void OnStart()
        {
            Locator.CurrentMutable
                   .RegisterLazySingleton(
                        () => RestService.For<Services.Api.IDuckDuckGoApi>("https://api.duckduckgo.com"),
                        typeof(Services.Api.IDuckDuckGoApi));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

