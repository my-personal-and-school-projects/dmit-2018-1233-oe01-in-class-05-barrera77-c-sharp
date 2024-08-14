#nullable disable
using FSISSystem.BAL;
using FSISSystem.Entities;
using FSISSystem.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace FSISWebApp.Pages.AssessmentPages
{
    public partial class GameScheduler
    {
        /****************************  DO NOT ALTER THE FOLLOWING CODE BLOCKS  *****************************/
        #region Services DO NOT ALTER
        /// <summary>
        /// Gets or sets the customer service.
        /// </summary>
        /// <value>The customer service.</value>
        [Inject]
        protected TeamService TeamService { get; set; }

        /// <summary>
        /// Gets or sets the navigation manager.
        /// </summary>
        /// <value>The navigation manager.</value>
        [Inject]
        protected GameService GameService { get; set; }
        #endregion

        #region Messaging and Error Handling DO NOT ALTER
        private string feedBackMessage { get; set; }

        private string errorMessage { get; set; }

        //a get property that returns the result of the lamda action
        private bool hasError => !string.IsNullOrWhiteSpace(errorMessage);
        private bool hasFeedBack => !string.IsNullOrWhiteSpace(feedBackMessage);

        // error details
        private List<string> errorDetails = new();
        #endregion

        #region Fields and Properties DO NOT ALTER

        //use for dropdown list: Home Team
        private List<SelectionListView> homeTeamList { get; set; }
        //use for dropdown list: Visiting Team
        private List<SelectionListView> visitingTeamList { get; set; }

        //variables used to collect data from the web page form

        // Game Date
        private DateTime gameDate { get; set; } = DateTime.Today;

        //Home Team dropdown list value
        private int homeID { get; set; }

        //Visiting Team dropdown list value
        private int visitingID { get; set; }

        // collection to hold game for scheduling
        private List<ScheduleView> gamesToSchedule { get; set; } = new();

        //Remove button value        
        private int CurrentMaxGameID { get; set; }
        #endregion

        #region Given Initialization and Helper Code DO NOT ALTER

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            homeTeamList = TeamService.GetTeamList();
            visitingTeamList = TeamService.GetTeamList();
            CurrentMaxGameID = GameService.GameServices_GetList().Max(game => game.GameID);
        }

        private Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }

        public void Clear()
        {
            gamesToSchedule.Clear();
        }
        #endregion
        /**************************  END DO NOT ALTER THE FOLLOWING CODE BLOCKS  ***************************/

        //	TODO: ACTIVITY 1 - Create web page table code - 4 MARKS
        //        Open the .razor page and add the code to handle the table for game scheduling
        //        Look for the code description section in the .razor page

        public void AddToSchedule()
        {
            //  TODO: ACTIVITY 2 - Implement AddToSchedule() - 4 MARKS total (see rubric)
            //  a) You shall check that the selected date is on or after today.
            //  b) You must ensure that both home and visiting teams have been selected.
            //  c) If data validations pass, then add a ScheduleView object to gamesToSchedule.
            //  d) Issue success or failure messages.

            //  YOUR CODE HERE

            // Reset feedback and error messages
            feedBackMessage = string.Empty;
            errorMessage = string.Empty;
            errorDetails.Clear();

            if (gameDate < DateTime.Today)
            {
                errorMessage = "The game date must be today or in the future.";
               
            }

            if (homeID == 0 || visitingID == 0)
            {
                errorMessage = "Please select both teams for the game.";                
            }

            if (homeID == visitingID)
            {
                errorMessage = "A team cannot play against itself.";                
            }

            if (!hasError)
            {
                gamesToSchedule.Add(new ScheduleView
                {
                    HomeTeamID = homeID,
                    VisitingTeamID = visitingID
                });


                feedBackMessage = "Game successfully added to the schedule.";
                errorMessage = null;
            }
                  
        }

        public void Remove(int gameID)
        {
            //	TODO: ACTIVITY 3 - Implement Remove(int gameID) - 2 MARKS
            //  a) Check that the game ID provided exists in the gamesToSchedule collection.
            //  b) Find the selected instance within the ScheduleView collection.
            //  c) Remove that instance.
            //  d) Issue success or failure messages.

            //  YOUR CODE HERE
            



        }

        public void Save()
        {
            //	TODO: ACTIVITY 4 - Implement Save() 
            //  a) Call the GameServices_ScheduleGames(....) method, passing in the required data.
            //  b) Issue success or failure messages.

            //  YOUR CODE HERE
            



        }
    }
}