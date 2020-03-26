using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SOFT262.Creation;
using SOFT262.Manage;
using SOFT262.Summary;
using SOFT262.Model;

namespace SOFT262
{
    //Similar code structure given in SOFT262 Mobile Dev practicals
    public class TopLevelPage : TabbedPage
    {        
        public TopLevelPage(MainModel model)
        {
            Title = "Revision Card App";

            //Initialise 'Revise' tab
            var summaryVM = new SummaryViewModel(model);
            Children.Add(new SummaryPage(summaryVM));

            //Initialise 'Create' tab
            var creationVM = new CreationViewModel(model);
            Children.Add(new CreationPage(creationVM));

            //Initialise 'Manage' tab
            var manageVM = new ManageViewModel(model);
            Children.Add(new ManagePage(manageVM));

            if (Device.RuntimePlatform == Device.Android)
            {
                Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetToolbarPlacement(this, Xamarin.Forms.PlatformConfiguration.AndroidSpecific.ToolbarPlacement.Bottom);
            }

        }


    }
}
