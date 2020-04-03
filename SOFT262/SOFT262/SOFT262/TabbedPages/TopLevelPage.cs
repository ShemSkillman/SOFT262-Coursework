using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SOFT262.Creation;
using SOFT262.Manage;
using SOFT262.Summary;
using SOFT262.Model;
using SOFT262.TabbedPages.Creation;

namespace SOFT262
{
    //Similar code structure given in SOFT262 Mobile Dev practicals
    public class TopLevelPage : TabbedPage
    {
        public TopLevelPage(MainModel model)
        {
            Title = "Revision Card App";

            Children.Add(new SummaryPage());
            Children.Add(new CreationPage());
            Children.Add(new ManagePage());

            if (Device.RuntimePlatform == Device.Android)
            {
                Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetToolbarPlacement(this, Xamarin.Forms.PlatformConfiguration.AndroidSpecific.ToolbarPlacement.Bottom);
            }

        }


    }
}
