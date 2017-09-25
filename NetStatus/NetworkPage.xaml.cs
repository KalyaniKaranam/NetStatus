using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Connectivity.Abstractions;

namespace NetStatus
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NetworkPage : ContentPage
	{
		public NetworkPage ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lblConnectiondetails.Text = CrossConnectivity.Current.ConnectionTypes.First().ToString();
            CrossConnectivity.Current.ConnectivityChanged += UpdateNetworkInfo;
        }

        private void UpdateNetworkInfo(object sender, ConnectivityChangedEventArgs e)
        {
            if(CrossConnectivity.Current!=null&&CrossConnectivity.Current.ConnectionTypes!=null)
            {
                var ConnectionType = CrossConnectivity.Current.ConnectionTypes;
                lblConnectiondetails.Text = ConnectionType.ToString();
            }
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (CrossConnectivity.Current != null)
                CrossConnectivity.Current.ConnectivityChanged -= UpdateNetworkInfo;
        }
        
    }
}
