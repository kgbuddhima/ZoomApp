using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZoomApp.Common;
using ZoomApp.Services;

namespace ZoomApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        IZoomService zoomService;
        public MainPage()
        {
            InitializeComponent();
            zoomService = DependencyService.Get<IZoomService>();
            zoomService.InitZoomLib(Constants.AppKey, Constants.AppSecret);
        }

        private void btnStart_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!zoomService.IsInitialized())
                {
                    return;
                }

                zoomService.JoinMeeting(txtMeetingId.Text, txtPssword.Text, txtDisplayName.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void btnEnd_Clicked(object sender, EventArgs e)
        {
            try
            {
                zoomService.LeaveMeeting();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
