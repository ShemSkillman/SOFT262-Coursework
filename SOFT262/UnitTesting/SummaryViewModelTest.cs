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

        [TestMethod]
        public void TestingFlipCommand()
        {
            SummaryViewModel testModel = new SummaryViewModel();

            //Setup
            ObservableCollection<RevisionCardSQL> testCards = new ObservableCollection<RevisionCardSQL>
            {
                new RevisionCardSQL() { Question = "q1", Answer = "a1", ID = 1 },
                new RevisionCardSQL() { Question = "q2", Answer = "a2", ID = 2 },
                new RevisionCardSQL() { Question = "q3", Answer = "a3", ID = 3 },
                new RevisionCardSQL() { Question = "q4", Answer = "a4", ID = 4 },
                new RevisionCardSQL() { Question = "q5", Answer = "a5", ID = 5 }
            };

            testModel.SetCommands(testCards);
            string originalDisplayText;
            string newDisplayText;
            for (int i = 0; i < testCards.Count; i++)
            {
                //Setup
                testModel.CardIndex = i;
                originalDisplayText = testModel.DisplayText; //Save for later
                
                //Test
                testModel.FlipCardCommand.Execute(null); //Execute card flip

                //Assert
                newDisplayText = testModel.DisplayText;
                Assert.AreNotEqual(originalDisplayText, newDisplayText);
            }


        }

        [TestMethod]
        public void TestingNextIndexCommand()
        {
            SummaryViewModel testModel = new SummaryViewModel();

            //Setup
            ObservableCollection<RevisionCardSQL> testCards = new ObservableCollection<RevisionCardSQL>
            {
                new RevisionCardSQL() { Question = "q1", Answer = "a1", ID = 1 },
                new RevisionCardSQL() { Question = "q2", Answer = "a2", ID = 2 },
                new RevisionCardSQL() { Question = "q3", Answer = "a3", ID = 3 },
                new RevisionCardSQL() { Question = "q4", Answer = "a4", ID = 4 },
                new RevisionCardSQL() { Question = "q5", Answer = "a5", ID = 5 }
            };

            testModel.SetCommands(testCards);

            testModel.CardIndex = 0; //Start at beginning of collection

            for (int i = 1; i < testCards.Count; i++)
            {
                testModel.NextIndexCommand.Execute(null);
                Assert.AreEqual(testModel.DisplayText, testCards[i].Question);
            }

            //Check that index loops back to 0 when
            //end of collection is reached
            testModel.NextIndexCommand.Execute(null);
            Assert.AreEqual(testModel.DisplayText, "q1");

        }

        [TestMethod]
        public void TestingLastIndexCommand()
        {
            SummaryViewModel testModel = new SummaryViewModel();
            
            //Setup
            ObservableCollection<RevisionCardSQL> testCards = new ObservableCollection<RevisionCardSQL>
            {
                new RevisionCardSQL() { Question = "q1", Answer = "a1", ID = 1 },
                new RevisionCardSQL() { Question = "q2", Answer = "a2", ID = 2 },
                new RevisionCardSQL() { Question = "q3", Answer = "a3", ID = 3 },
                new RevisionCardSQL() { Question = "q4", Answer = "a4", ID = 4 },
                new RevisionCardSQL() { Question = "q5", Answer = "a5", ID = 5 }
            };

            testModel.SetCommands(testCards);

            testModel.CardIndex = testCards.Count - 1; //Start at end of colletion

            for (int i = testCards.Count - 2; i >= 0; i--)
            {
                testModel.LastIndexCommand.Execute(null);
                Assert.AreEqual(testModel.DisplayText, testCards[i].Question);
            }

            //Check that index loops back to end when
            //start of collection is reached
            testModel.LastIndexCommand.Execute(null);
            Assert.AreEqual("q5", testModel.DisplayText);
        }
    }
}
