using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using SOFT262.Model;

namespace SOFT262.Summary
{
    class SummaryPageViewModel : INotifyPropertyChanged
    {
        private Model.Model model;
        public event PropertyChangedEventHandler PropertyChanged;

        

        public SummaryPageViewModel()
        {
            ////Bindings here
            //revisionTopics = new List<String>
            //{
            //    "Mobile Development",
            //    "Mathematics",
            //    "Chemistry",
            //    "English Language"
            //}
        }


        public SummaryPageViewModel(Model.Model model)
        {
            this.model = model;
        }

        public List<Model.RevisionGroup> revisionTopics
        {
            get => model.RevisionGroups;
        }
    }
}
