namespace ReactiveExtensionExamples.Features.Main
{
    using ReactiveExtensionExamples.Enums;
    using ReactiveUI;
    using System;
    using System.Reactive.Linq;
    using Xamarin.Forms;

    public class DetailPage : MasterDetailPage
    {
        readonly MasterPage navListPage = new MasterPage();

        public DetailPage()
        {
            NavigationPage primaryNavPage = new NavigationPage(this.navListPage)
            {
                Title = "Reactive Examples",
                BarTextColor = Values.Styles.BlueAccent
            };

            Master = primaryNavPage;

            MasterBehavior = MasterBehavior.Popover;
            IsPresented = true;

            this.navListPage
                .SelectedNavigation
                .ObserveOn(RxApp.MainThreadScheduler)
                .StartWith(NavigationPages.Delay)
                .Subscribe(navPage =>
                {

                    Page selectedPage = null;
                    switch (navPage)
                    {
                        case NavigationPages.Async:
                            selectedPage = new Pages.Async();
                            break;
                        case NavigationPages.AsyncEvents:
                            selectedPage = new Pages.AsyncEvent();
                            break;
                        case NavigationPages.Delay:
                            selectedPage = new Samples.DelayView();
                            break;
                        case NavigationPages.Throttle:
                            selectedPage = new Samples.ThrottleView();
                            break;
                        case NavigationPages.Buffer:
                            selectedPage = new Samples.BufferView();
                            break;
                        case NavigationPages.BufferWithWhere:
                            selectedPage = new Samples.BufferWithWhereView();
                            break;
                        case NavigationPages.Merge:
                            selectedPage = new Samples.MergeView();
                            break;
                        //case NavigationPages.Sample:
                        //    selectedPage = new Pages.Sample();
                        //    break;
                        //case NavigationPages.Scan:
                        //    selectedPage = new Pages.Scan();
                        //    break;
                        case NavigationPages.AsyncToObservable:
                            selectedPage = new Pages.AsyncToObservable();
                            break;
                        case NavigationPages.CombineLatest:
                            selectedPage = new Samples.CombineLatestView();
                            break;
                        //case NavigationPages.StandardSearch:
                        //    selectedPage = new Pages.StandardSearch();
                        //    break;
                        //case NavigationPages.SearchWithReactiveExtensions:
                        //    selectedPage = new Pages.SearchWithReactiveExtensions();
                        //    break;
                        //case NavigationPages.RxUiSearch:
                        //    selectedPage = new Pages.ReactiveUiSearch();
                        //    break;
                        //case NavigationPages.RxUiColorSlider:
                        //    selectedPage = new Pages.ReactiveUiColorSlider();
                        //    break;
                        //case NavigationPages.RxUiLogin:
                        //    selectedPage = new Pages.ReactiveUiLogin();
                        //    break;
                        //case NavigationPages.RxUiXamarinEssentials:
                        //    selectedPage = new Pages.ReactiveUiEssentials();
                        //    break;
                        default:
                            break;
                    }

                    if (selectedPage != null)
                    {
                        NavigationPage detailNavPage = new NavigationPage(selectedPage) { };
                        detailNavPage.BarTextColor = Values.Styles.BlueAccent;
                        Detail = detailNavPage;
                    }

                    IsPresented = false;
                });
        }
    }
}

