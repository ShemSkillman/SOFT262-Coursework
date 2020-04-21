using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SOFT262.MVVM
{
    public interface IPageHelper
    {
        Task MessagePopup(string messageTitle, string message); //Type task as required due to being await
    }
}
