namespace ReactiveExtensionExamples.Pages
{
    using System;
    using System.Linq;
    using System.Reactive.Concurrency;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using Xamarin.Forms;

    public class Sample : PageBase
    {
        Entry textEntry;
        WebView webView;

        protected override void SetupUserInterface()
        {
            Title = "Rx - Sample";

            Content = new StackLayout
            {
                Padding = new Thickness(8d),
                Children = {
                    (this.textEntry = new Entry{ Placeholder = "Enter Search Terms" }),
                    (this.webView = new WebView {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                    })
                }
            };
        }

        protected override void SetupReactiveExtensions()
        {
            Observable
                .FromEventPattern<EventHandler<TextChangedEventArgs>, TextChangedEventArgs>(
                    x => this.textEntry.TextChanged += x,
                    x => this.textEntry.TextChanged -= x)
                .Sample(TimeSpan.FromSeconds(3), TaskPoolScheduler.Default)
                .Select(args =>
                    string.Format("https://frinkiac.com/?q={0}", args.EventArgs.NewTextValue.Replace(" ", "+")))
                .Subscribe(
                    searchUrl => Device.BeginInvokeOnMainThread(() => this.webView.Source = searchUrl),
                    ex => Device.BeginInvokeOnMainThread(() => this.webView.Source = "https://frinkiac.com/caption/S04E05/1135500"))
                .DisposeWith(this.SubscriptionDisposables);
        }
    }
}


