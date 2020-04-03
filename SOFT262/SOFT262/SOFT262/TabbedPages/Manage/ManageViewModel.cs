using SOFT262.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOFT262.Manage
{
    public class ManageViewModel
    {
        MainModel model;

        public ManageViewModel()
        {
            model = MainModel.Instance;
        }
    }
}
