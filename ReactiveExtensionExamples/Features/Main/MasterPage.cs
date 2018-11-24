namespace ReactiveExtensionExamples.Features.Main
{
    using ReactiveExtensionExamples.Enums;
    using System;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using Xamarin.Forms;

    public class MasterPage : ContentPage
    {
        readonly Subject<NavigationPages> selectedNavigation = new Subject<NavigationPages>();
        public IObservable<NavigationPages> SelectedNavigation { get { return this.selectedNavigation.AsObservable(); } }

        public MasterPage()
        {
            Title = "Reactive Examples";

            ScrollView scrollContainer = new ScrollView
            {
                BackgroundColor = Values.Styles.GreenAccent
            };

            StackLayout navigationContainer = new StackLayout
            {
                Spacing = 8d
            };

            scrollContainer.Content = navigationContainer;

            Button delay = new Button
            {
                Text = "Delay",
                Command = new Command(() => this.selectedNavigation.OnNext(NavigationPages.Delay)),
            };
            navigationContainer.Children.Add(delay);

            Button throttle = new Button
            {
                Text = "Throttle",
                Command = new Command(() => this.selectedNavigation.OnNext(NavigationPages.Throttle)),
            };
            navigationContainer.Children.Add(throttle);

            Button buffer = new Button
            {
                Text = "Buffer",
                Command = new Command(() => this.selectedNavigation.OnNext(NavigationPages.Buffer)),
            };
            navigationContainer.Children.Add(buffer);

            Button bufferWithWhere = new Button
            {
                Text = "Buffer with Where",
                Command = new Command(() => this.selectedNavigation.OnNext(NavigationPages.BufferWithWhere)),
            };
            navigationContainer.Children.Add(bufferWithWhere);

            Button sample = new Button
            {
                Text = "Sample",
                Command = new Command(() => this.selectedNavigation.OnNext(NavigationPages.Sample)),
            };
            navigationContainer.Children.Add(sample);

            Button scan = new Button
            {
                Text = "Scan",
                Command = new Command(() => this.selectedNavigation.OnNext(NavigationPages.Scan)),
            };
            navigationContainer.Children.Add(scan);

            Button merge = new Button
            {
                Text = "Merge",
                Command = new Command(() => this.selectedNavigation.OnNext(NavigationPages.Merge)),
            };
            navigationContainer.Children.Add(merge);

            Button combineLatest = new Button
            {
                Text = "Combine Latest",
                Command = new Command(() => this.selectedNavigation.OnNext(NavigationPages.CombineLatest)),
            };
            navigationContainer.Children.Add(combineLatest);

            Button asyncToObservable = new Button
            {
                Text = "Mix Async With Observables",
                Command = new Command(() => this.selectedNavigation.OnNext(NavigationPages.AsyncToObservable)),
            };
            navigationContainer.Children.Add(asyncToObservable);

            Button reactiveAsync = new Button
            {
                Text = "Async",
                Command = new Command(() => this.selectedNavigation.OnNext(NavigationPages.Async)),
            };
            navigationContainer.Children.Add(reactiveAsync);

            Button asyncEvents = new Button
            {
                Text = "Async Events",
                Command = new Command(() => this.selectedNavigation.OnNext(NavigationPages.AsyncEvents)),
            };
            navigationContainer.Children.Add(asyncEvents);

            Button standardSearch = new Button
            {
                Text = "Standard Search",
                Command = new Command(() => this.selectedNavigation.OnNext(NavigationPages.StandardSearch)),
            };
            navigationContainer.Children.Add(standardSearch);

            Button searchWithReactiveExtensions = new Button
            {
                Text = "Search with Reactive Extensions",
                Command = new Command(() => this.selectedNavigation.OnNext(NavigationPages.SearchWithReactiveExtensions)),
            };
            navigationContainer.Children.Add(searchWithReactiveExtensions);

            Button rxuiSearch = new Button
            {
                Text = "RxUI - Search",
                Command = new Command(() => this.selectedNavigation.OnNext(NavigationPages.RxUiSearch)),
            };
            navigationContainer.Children.Add(rxuiSearch);

            Button rxuiColorSlider = new Button
            {
                Text = "RxUI - Color Slider",
                Command = new Command(() => this.selectedNavigation.OnNext(NavigationPages.RxUiColorSlider)),
            };
            navigationContainer.Children.Add(rxuiColorSlider);

            Button rxuiLogin = new Button
            {
                Text = "RxUI - Login",
                Command = new Command(() => this.selectedNavigation.OnNext(NavigationPages.RxUiLogin)),
            };
            navigationContainer.Children.Add(rxuiLogin);

            Button rxuiEssentials = new Button
            {
                Text = "RxUI - Xamarin Essentials",
                Command = new Command(() => this.selectedNavigation.OnNext(NavigationPages.RxUiXamarinEssentials)),
            };
            navigationContainer.Children.Add(rxuiEssentials);

            Image reactiveLogo = new Image
            {
                Source = "reactive_logo.png",
                Aspect = Aspect.AspectFit,
                Margin = new Thickness(50d)
            };
            navigationContainer.Children.Add(reactiveLogo);

            Content = scrollContainer;
        }
    }
}
