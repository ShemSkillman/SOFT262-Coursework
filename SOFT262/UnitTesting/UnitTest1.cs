using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOFT262.Summary;
using SOFT262;
using SOFT262.Model;
using System.Collections.ObjectModel;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SummaryViewModel testModel = new SummaryViewModel(null);
            ObservableCollection<RevisionCardSQL> testCards = new ObservableCollection<RevisionCardSQL>();

            testCards.Add(new RevisionCardSQL(){ Question = "test", Answer = "test", ID = 1});
            testCards.Add(new RevisionCardSQL() { Question = "test", Answer = "test", ID = 2 });
            testCards.Add(new RevisionCardSQL() { Question = "test", Answer = "test", ID = 3 });
            testCards.Add(new RevisionCardSQL() { Question = "test", Answer = "test", ID = 4 });
            testCards.Add(new RevisionCardSQL() { Question = "test", Answer = "test", ID = 5 });

            testModel.Shuffle(testCards);
            int id = 1;
            bool isShuffled = false;
            for (int i = 0; i < testCards.Count; i++)
            {
                if (testCards[i].ID == id)
                {
                    id = id + 1;
                    continue;
                    
                }
                else
                {
                    isShuffled = true;
                    break;
                }
            }
            Assert.IsTrue(isShuffled);


        }
    }
}
