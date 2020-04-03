using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SOFT262.TabbedPages.Creation
{
    public interface IPage
    {
        INavigation NavigationProxy { get; }
    }
}
