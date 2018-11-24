﻿namespace ReactiveExtensionExamples.Pages
{
    using System.Reactive.Disposables;
    using Xamarin.Forms;

    public class PageBase : ContentPage
	{
		protected readonly CompositeDisposable SubscriptionDisposables = new CompositeDisposable ();

		public PageBase ()
		{
			SetupUserInterface ();
		}

		protected virtual void SetupUserInterface () {}

		protected virtual void SetupReactiveExtensions () {}

		protected override void OnAppearing ()
		{
			SetupReactiveExtensions ();

			base.OnAppearing ();
		}

		protected override void OnDisappearing ()
		{
			SubscriptionDisposables.Clear ();

			base.OnDisappearing ();
		}
	}
}

