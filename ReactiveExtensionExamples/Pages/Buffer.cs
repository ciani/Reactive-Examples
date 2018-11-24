namespace ReactiveExtensionExamples.Pages
{
    using System;
    using System.Linq;
    using System.Reactive.Concurrency;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using Xamarin.Forms;

    public class Buffer : PageBase
    {
        Entry textEntry;
        StackLayout lastEntries;

        protected override void SetupUserInterface()
        {
            Title = "Rx - Buffer";

            Content = new StackLayout
            {
                Padding = new Thickness(8d),
                Spacing = 16d,
                Children = {
                    (this.textEntry = new Entry{ Placeholder = "Enter Some Text" }),
                     new ScrollView {
                        VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand,
                        Content = (this.lastEntries = new StackLayout{
                            VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand
                        })
                    }
                }
            };
        }

        protected override void SetupReactiveExtensions()
        {
            Observable
                .FromEventPattern<EventHandler<TextChangedEventArgs>, TextChangedEventArgs>(
                    x => this.textEntry.TextChanged += x,
                    x => this.textEntry.TextChanged -= x)
                .Buffer(TimeSpan.FromSeconds(3), TaskPoolScheduler.Default)
                .Select(argsList =>
                    string.Join(
                        Environment.NewLine,
                        argsList.Select(args => args.EventArgs.NewTextValue).Reverse().ToList()
                    )
                )
                .Subscribe(text =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        this.lastEntries.Children.Insert(
                            0,
                            new Label { Text = text }
                        );

                        this.lastEntries.Children
                            .Insert(
                                1,
                                new Label
                                {
                                    Text = string.Format("Received at {0:H:mm:ss}", DateTime.Now),
                                    FontAttributes = FontAttributes.Italic,
                                    FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                                    TextColor = Color.Gray
                                });

                        this.lastEntries.Children
                            .Insert(
                                2,
                                new BoxView { BackgroundColor = Color.Gray, HeightRequest = 2d });
                    });
                })
                .DisposeWith(this.SubscriptionDisposables);
        }
    }
}


