using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SOFT262.TabbedPages.Creation
{
    public interface ICreationPageHelper : IPage
    {
        Task<String> AskForString(string questionTitle, string question); //Type task as required due to being await
    }
}
