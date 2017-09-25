using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NetStatus
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            MainPage = CrossConnectivity.Current.IsConnected ? (Page)new NetworkPage(): new NoNetworkPage();
           
		}

		protected override void OnStart ()
		{
            // Handle when your app starts
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
		}

        private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            Type currentPage = this.MainPage.GetType();
            if (e.IsConnected && currentPage != typeof(NetworkPage))
                this.MainPage = new NetworkPage();
            else if (!e.IsConnected && currentPage != typeof(NoNetworkPage))
                this.MainPage = new NoNetworkPage();
        }

        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
