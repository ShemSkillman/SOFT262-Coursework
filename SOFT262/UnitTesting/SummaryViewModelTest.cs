using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOFT262.Summary;
using SOFT262;
using SOFT262.Model;
using System.Collections.ObjectModel;

namespace UnitTesting
{
    [TestClass]
    public class SummaryViewModelTest
    {
        [TestMethod]

        //1 IN 25 CHANCE THAT SHUFFLE IS UNSUCCESSFUL
        //AS ITS POSSIBLE FOR NONE OF THE CARDS TO BE REARRANGED
        //AFTER A SHUFFLE
        public void TestingShuffleFunc()
        {
            SummaryViewModel testModel = new SummaryViewModel();

            //Initialise cards
            ObservableCollection<RevisionCardSQL> testCards = new ObservableCollection<RevisionCardSQL>
            {
                new RevisionCardSQL() { Question = "test", Answer = "test", ID = 1 },
                new RevisionCardSQL() { Question = "test", Answer = "test", ID = 2 },
                new RevisionCardSQL() { Question = "test", Answer = "test", ID = 3 },
                new RevisionCardSQL() { Question = "test", Answer = "test", ID = 4 },
                new RevisionCardSQL() { Question = "test", Answer = "test", ID = 5 }
            };

            //Start order
            int[] order = { 1, 2, 3, 4, 5 };

            //Run 5 tests on shuffle, assertion completed in the test
            ShuffleTest(testCards, order, testModel);
            ShuffleTest(testCards, order, testModel);
            ShuffleTest(testCards, order, testModel);
            ShuffleTest(testCards, order, testModel);
            ShuffleTest(testCards, order, testModel);
        }

        private void ShuffleTest(ObservableCollection<RevisionCardSQL> testCards, int[] order, SummaryViewModel testModel)
        {
            testModel.Shuffle(testCards);

            bool isShuffled = false;

            //Check if at least one card is arranged differently in collection
            for (int i = 0; i < testCards.Count; i++)
            {
                if (testCards[i].ID != order[i])
                {
                    isShuffled = true;
                }

                order[i] = testCards[i].ID;
            }
            //Assert
            Assert.IsTrue(isShuffled);
        }
    }
}
