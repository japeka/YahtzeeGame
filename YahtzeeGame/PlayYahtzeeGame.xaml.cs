using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using Microsoft.WindowsAzure.MobileServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace YahtzeeGame {
    /// <summary>nt
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
   public sealed partial class PlayYahtzeeGame : YahtzeeGame.Common.LayoutAwarePage {
       
        //roundCounter
        private int roundCounter = 0;

        //upperLevel Score components
        private int UpperOne=0;
        private bool bUpperOne = false;
        private int UpperTwo=0;
        private bool bUpperTwo = false;
        private int UpperThree = 0;
        private bool bUpperThree = false; 
        private int UpperFour = 0;
        private bool bUpperFour = false;
        private int UpperFive = 0;
        private bool bUpperFive = false;
        private int UpperSix = 0;
        private bool bUpperSix = false;

        //lower score section
        private int LowerTotalSum=0;
        private bool bThreeOfKind = false;
        private bool bFourOfKind = false;
        private bool bFullHouse = false;
        private bool bSmallStraight = false;
        private bool bLargeStraight = false;
        private bool bYahtzee = false;
        private bool bChance = false;

        public PlayYahtzeeGame() {
            this.InitializeComponent();
           // setTheLowestTopTenScore();
            //init the game
            initializeGame();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState) {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)  {
        }

        //disable all the buttons & textboxes when the game is started
        private void initializeGame(){
            disableButtons();
            disableOutputButtons();
        }


        //disable all the buttons & textboxes when the game is started
        private void enableControls() {
            enableButtons();
            enableOutputButtons();
        }

        //To do next 
        //1 btns
        //2 scramble the diceor
        //3 roll the dice three times and make user have to choose placeholder (disableing the 
        //btns and etc
        private void btnDiceClicked(object sender, RoutedEventArgs e)  {
            Button btn=(Button)sender;
            string s = ((Button)sender).Name;
            //apply the rules below to rest of the btns
            if (s.Equals("btnDiceOne")) {
                //Margin="113,93,0,0"
                //New Margin = 5,93,0,0" When button disabled
                if (btn.Margin.Left == 5) {
                    btn.Margin = new Thickness(113, 93, 0, 0);
                }  else {
                    btn.Margin = new Thickness(5, 93, 0, 0);
                }
            } else if (s.Equals("btnDiceTwo")) {
                //113,169,0,0
                //5,169,0,0
                if (btn.Margin.Left == 5) {
                    btn.Margin = new Thickness(113, 169, 0, 0);
                } else {
                    btn.Margin = new Thickness(5, 169, 0, 0);
                }
            } else if (s.Equals("btnDiceThree")){
                //113,244,0,0
                if (btn.Margin.Left == 5){
                    btn.Margin = new Thickness(113, 244, 0, 0);
                } else  {
                    btn.Margin = new Thickness(5, 244, 0, 0);
                }
            } else if (s.Equals("btnDiceFour")) {
                //113,319,0,0
                if (btn.Margin.Left == 5) {
                    btn.Margin = new Thickness(113, 319, 0, 0);
                } else {
                    btn.Margin = new Thickness(5, 319, 0, 0);
                }
            } else if (s.Equals("btnDiceFive")) {
                //113,394,0,0
                if (btn.Margin.Left == 5){
                    btn.Margin = new Thickness(113, 394, 0, 0);
                } else {
                    btn.Margin = new Thickness(5, 394, 0, 0);
                }
            }
      }
        
        private void btnRollDiceEvent(object sender, RoutedEventArgs e) {
                enableButtons(); //enables the dice buttons
                scrambleDices(); //scrambles the dices with random values for correctly positioned buttons
                enableOutputButtons(); //enables output buttons right after the roll dice's been clicked 
                roundCounter++; //increment counter
                if (roundCounter == 3)
                { //User must choose something 
                    //disable all the buttons
                    disableButtons();
                    btnRollDice.IsEnabled = false;
                }
        }

        private bool checkGameOverStatus() {
            if (bUpperOne && bUpperTwo && bUpperThree && bUpperFour && bUpperFive && bUpperSix && bThreeOfKind && bFourOfKind && bFullHouse && bSmallStraight && bLargeStraight && bYahtzee && bChance) {
                return true;
            } else
                return false;
        }

       private void scrambleDices() {
           Random r = new Random();
           if (btnDiceOne.Margin.Left==113) {
               btnDiceOne.Content = r.Next(1, 7).ToString();
           }
           if (btnDiceTwo.Margin.Left == 113) {
               btnDiceTwo.Content = r.Next(1, 7).ToString();
           }
           if (btnDiceThree.Margin.Left == 113) {
               btnDiceThree.Content = r.Next(1, 7).ToString();
           }
           if (btnDiceFour.Margin.Left == 113) {
               btnDiceFour.Content = r.Next(1, 7).ToString();
           }
           if (btnDiceFive.Margin.Left == 113) {
               btnDiceFive.Content = r.Next(1, 7).ToString();
           }
       }

        private void enableButtons()  {
            btnDiceOne.IsEnabled=true;
            btnDiceTwo.IsEnabled=true;
            btnDiceThree.IsEnabled=true;
            btnDiceFour.IsEnabled=true;
            btnDiceFive.IsEnabled=true;
        }
        
        private void disableButtons() {
            btnDiceOne.IsEnabled = false;
            btnDiceTwo.IsEnabled = false;
            btnDiceThree.IsEnabled = false;
            btnDiceFour.IsEnabled = false;
            btnDiceFive.IsEnabled = false;
        }

        private void disableOutputButtons() { 
            btnOutputOne.IsEnabled = false;
            btnOutputTwo.IsEnabled = false;
            btnOutputThree.IsEnabled = false;
            btnOutputFour.IsEnabled = false;
            btnOutputFive.IsEnabled = false;
            btnOutputSix.IsEnabled = false;
 
            btn_LowerSection_ThreeOfAKind.IsEnabled = false;
            btn_LowerSection_FourOfAKind.IsEnabled = false;
            btn_LowerSection_FullHouse.IsEnabled = false;
            btn_LowerSection_SmallStraight.IsEnabled = false;
            btn_LowerSection_LargeStraight.IsEnabled = false;
            btn_LowerSection_Yahtzee.IsEnabled = false;
            btn_LowerSection_Chance.IsEnabled = false;
        }

        private void enableOutputButtons() {
            if(!bUpperOne)
                btnOutputOne.IsEnabled = true;
            if(!bUpperTwo)
                btnOutputTwo.IsEnabled = true;
            if(!bUpperThree)
                btnOutputThree.IsEnabled = true;
            if (!bUpperFour)
                btnOutputFour.IsEnabled = true;
            if(!bUpperFive)
                btnOutputFive.IsEnabled = true;
            if(!bUpperSix)
                btnOutputSix.IsEnabled = true;
            if(!bThreeOfKind)
                btn_LowerSection_ThreeOfAKind.IsEnabled = true;
            if(!bFourOfKind)
                btn_LowerSection_FourOfAKind.IsEnabled = true;
            if (!bFullHouse)
                btn_LowerSection_FullHouse.IsEnabled = true;
            if (!bSmallStraight)
                btn_LowerSection_SmallStraight.IsEnabled = true;
            if(!bLargeStraight)
                btn_LowerSection_LargeStraight.IsEnabled = true;
            if(!bYahtzee)
                btn_LowerSection_Yahtzee.IsEnabled = true;
            if (!bChance)
                btn_LowerSection_Chance.IsEnabled = true;
        }


        private int countDiceValues(int diceValue) {
            int sum = 0;
            if (int.Parse(btnDiceOne.Content.ToString()) == diceValue) {
                sum += diceValue;
            }
            if (int.Parse(btnDiceTwo.Content.ToString()) == diceValue) {
                sum += diceValue;
            }
            if (int.Parse(btnDiceThree.Content.ToString()) == diceValue){
                sum += diceValue;
            }
            if (int.Parse(btnDiceFour.Content.ToString()) == diceValue) {
                sum += diceValue;
            }
            if (int.Parse(btnDiceFive.Content.ToString()) == diceValue) {
                sum += diceValue;
            }
            return sum;
        }

        //after the round enable buttons, disable textboxes and reset roundcounter to 0
        private void restoreGameState() {
            btnRollDice.IsEnabled = true;
            restoreDicesOriginalStateAndPlace();
            disableButtons();
            disableOutputButtons();
            roundCounter = 0;
        }

        private void restoreDicesOriginalStateAndPlace() {
            btnDiceOne.Margin = new Thickness(113, 93, 0, 0);
            btnDiceOne.Content = "1";
            btnDiceTwo.Margin = new Thickness(113, 169, 0, 0);
            btnDiceTwo.Content = "2";
            btnDiceThree.Margin = new Thickness(113, 244, 0, 0);
            btnDiceThree.Content = "3";
            btnDiceFour.Margin = new Thickness(113, 319, 0, 0);
            btnDiceFour.Content = "4";
            btnDiceFive.Margin = new Thickness(113, 394, 0, 0);
            btnDiceFive.Content = "5";
        }

        public int calculateSumOfUpperButtons(string btn) {
            int sum=0;
            if (btn.Equals("btnOutputOne")) {
                if (btnOutputOne.Content.ToString().Length != 0) {
                    UpperOne = int.Parse(btnOutputOne.Content.ToString());
                    bUpperOne = true;
                    sum = UpperOne + UpperTwo + UpperThree + UpperFour + UpperFive + UpperSix; 
                }
            }
            if (btn.Equals("btnOutputTwo")) {
                if (btnOutputTwo.Content.ToString().Length != 0){
                    UpperTwo = int.Parse(btnOutputTwo.Content.ToString());
                    bUpperTwo = true;
                    sum = UpperOne + UpperTwo + UpperThree + UpperFour + UpperFive + UpperSix; 
                }
             }
            if (btn.Equals("btnOutputThree")) {
                if (btnOutputThree.Content.ToString().Length != 0) {
                    UpperThree = int.Parse(btnOutputThree.Content.ToString());
                    bUpperThree = true;
                    sum = UpperOne + UpperTwo + UpperThree + UpperFour + UpperFive + UpperSix; 
                }
            }
            if (btn.Equals("btnOutputFour")) {
                if (btnOutputFour.Content.ToString().Length != 0){
                    UpperFour = int.Parse(btnOutputFour.Content.ToString());
                    bUpperFour = true;
                    sum = UpperOne + UpperTwo + UpperThree + UpperFour + UpperFive + UpperSix;
                }
            }
            if (btn.Equals("btnOutputFive")) {
                if (btnOutputFive.Content.ToString().Length != 0) {
                    UpperFive = int.Parse(btnOutputFive.Content.ToString());
                    bUpperFive = true;
                    sum = UpperOne + UpperTwo + UpperThree + UpperFour + UpperFive + UpperSix;
                }
            }
            if (btn.Equals("btnOutputSix")) {
                if (btnOutputSix.Content.ToString().Length != 0) {
                    UpperSix = int.Parse(btnOutputSix.Content.ToString());
                    bUpperSix = true;
                    sum = UpperOne + UpperTwo + UpperThree + UpperFour + UpperFive + UpperSix;
                }
            }
            return sum;
        }

        private void updateUpperScoreBonusTotal(string btn) {
            int sum = calculateSumOfUpperButtons(btn);
            tb_UpperSection_UpperScore.Text = sum.ToString();
            if (sum >= 63) {
                tb_UpperSection_Bonus.Text = "35"; //jos upperscore > 63 35 lisäpojoa
            } else {
                tb_UpperSection_Bonus.Text = "0"; //jos upperscore > 63 35 lisäpojoa
            }
            int UpperTotal = int.Parse(tb_UpperSection_UpperScore.Text) + int.Parse(tb_UpperSection_Bonus.Text);
            tb_UpperSection_UpperTotal.Text = UpperTotal.ToString();

            //calculations for lower total    
            int LowerTotal=int.Parse(tb_LowerSection_LowerTotal.Text);
            //grand total
            int GrandTotal = UpperTotal + LowerTotal;
            tb_LowerSection_GrandTotal.Text = GrandTotal.ToString();
        }
       
        //try to fetch the min result of top ten list
        private async void gameIsOver(Button btn) {
            this.Frame.Navigate(typeof(ResultClass), tb_LowerSection_GrandTotal.Text);
        }


        private void gameOverSettings(Button btn) {
            btn.IsEnabled = false;
            //to disable other controls
            btnRollDice.IsEnabled = false;
            btnDiceOne.Visibility = Visibility.Collapsed;
            btnDiceTwo.Visibility = Visibility.Collapsed;
            btnDiceThree.Visibility = Visibility.Collapsed;
            btnDiceFour.Visibility = Visibility.Collapsed;
            btnDiceFive.Visibility = Visibility.Collapsed;
        }
        
        private void btnUpperClickedEvent(object sender, RoutedEventArgs e) {
            if ( ((Button)sender).Name.Equals("btnOutputOne")) {
                int cOnes = countDiceValues(1);
                ((Button)sender).Content = cOnes.ToString();
                updateUpperScoreBonusTotal("btnOutputOne");//upper score, bonus, total,grand total
                if (checkGameOverStatus() == false) {
                    restoreGameState();
                } else {
                    gameIsOver(((Button)sender));
                }                   
            }
            if (((Button)sender).Name.Equals("btnOutputTwo")) {
                int cTwos = countDiceValues(2);
                ((Button)sender).Content = cTwos.ToString();
                updateUpperScoreBonusTotal("btnOutputTwo");//upper score, bonus, total,grand total
                if (checkGameOverStatus() == false) {
                    restoreGameState();
                } else {
                    gameIsOver(((Button)sender));
                }
            }
            if (((Button)sender).Name.Equals("btnOutputThree")){
                int cThrees = countDiceValues(3);
                ((Button)sender).Content = cThrees.ToString();
                updateUpperScoreBonusTotal("btnOutputThree");//upper score, bonus, total,grand total
                if (checkGameOverStatus() == false) {
                    restoreGameState();
                } else  {
                    gameIsOver(((Button)sender));
                }
            }
            if (((Button)sender).Name.Equals("btnOutputFour")) {
                int cFours = countDiceValues(4);
                ((Button)sender).Content = cFours.ToString();
                updateUpperScoreBonusTotal("btnOutputFour");//upper score, bonus, total,grand total
                if (checkGameOverStatus() == false) {
                    restoreGameState();
                } else {
                    gameIsOver(((Button)sender));
                }
            }
            if (((Button)sender).Name.Equals("btnOutputFive")){
                int cFives = countDiceValues(5);
                ((Button)sender).Content = cFives.ToString();
                updateUpperScoreBonusTotal("btnOutputFive");//upper score, bonus, total,grand total
                if (checkGameOverStatus() == false) {
                    restoreGameState();
                } else {
                    gameIsOver(((Button)sender));
                }
            }
            if (((Button)sender).Name.Equals("btnOutputSix")) {
                int cSixes = countDiceValues(6);
                ((Button)sender).Content = cSixes.ToString();
                updateUpperScoreBonusTotal("btnOutputSix");//upper score, bonus, total,grand total
                if (checkGameOverStatus() == false){
                    restoreGameState();
                } else {
                    gameIsOver(((Button)sender));
                }
            }
        }

        //lower section part
        private void btnLowerClickedEvent(object sender, RoutedEventArgs e) {
            if (((Button)sender).Name.Equals("btn_LowerSection_ThreeOfAKind"))
            {
                int iThreeKind = checkNOfAKindCondition(3);
                ((Button)sender).Content = iThreeKind.ToString();
                updateLowerScoreTotal("btn_LowerSection_ThreeOfAKind", iThreeKind);
                bThreeOfKind = true;
                if (checkGameOverStatus() == false)
                {
                    restoreGameState();
                }
                else
                {
                    gameIsOver(((Button)sender));
                }
            }
            if (((Button)sender).Name.Equals("btn_LowerSection_FourOfAKind"))
            {
                int iFourThreeKind = checkNOfAKindCondition(4);
                ((Button)sender).Content = iFourThreeKind.ToString();
                updateLowerScoreTotal("btn_LowerSection_FourOfAKind", iFourThreeKind);
                bFourOfKind = true;
                if (checkGameOverStatus() == false)
                {
                    restoreGameState();
                }
                else
                {
                    gameIsOver(((Button)sender));
                }
            }

            //full house => 25 otherwise 0
            if (((Button)sender).Name.Equals("btn_LowerSection_FullHouse")) {
                if (checkFullHouseStatus()) {
                    ((Button)sender).Content = "25";
                    updateLowerScoreTotal("btn_LowerSection_FullHouse", 25);
                } else {
                    ((Button)sender).Content = "0";
                    updateLowerScoreTotal("btn_LowerSection_FullHouse", 0);
                }
                bFullHouse = true;
                if (checkGameOverStatus() == false) {
                    restoreGameState();
                } else {
                    gameIsOver(((Button)sender));
                }
            }

            //small straight
            if (((Button)sender).Name.Equals("btn_LowerSection_SmallStraight"))
            {
                if (checkSmallStraightStatus()) {
                    ((Button)sender).Content = "30";
                    updateLowerScoreTotal("btn_LowerSection_SmallStraight", 30);
                } else {
                    ((Button)sender).Content = "0";
                    updateLowerScoreTotal("btn_LowerSection_SmallStraight", 0);
                }
                bSmallStraight = true;
                if (checkGameOverStatus() == false) {
                    restoreGameState();
                } else {
                    gameIsOver(((Button)sender));
                }
            }

            //large straight
            if (((Button)sender).Name.Equals("btn_LowerSection_LargeStraight"))
            {
                if (checkLargeStraightStatus())
                {
                    ((Button)sender).Content = "40";
                    updateLowerScoreTotal("btn_LowerSection_LargeStraight", 40);
                }
                else
                {
                    ((Button)sender).Content = "0";
                    updateLowerScoreTotal("btn_LowerSection_LargeStraight", 0);
                }
                bLargeStraight = true;
                if (checkGameOverStatus() == false)
                {
                    restoreGameState();
                }
                else
                {
                    gameIsOver(((Button)sender));
                }
            }

            //yahtzee
            if (((Button)sender).Name.Equals("btn_LowerSection_Yahtzee"))
            {
                if (checkYahtzeeStatus())
                {
                    ((Button)sender).Content = "50";
                    updateLowerScoreTotal("btn_LowerSection_Yahtzee", 50);
                }
                else
                {
                    ((Button)sender).Content = "0";
                    updateLowerScoreTotal("btn_LowerSection_Yahtzee", 0);
                }
                bYahtzee = true;
                if (checkGameOverStatus() == false)
                {
                    restoreGameState();
                }
                else
                {
                    gameIsOver(((Button)sender));
                }
            }

            //chance
            if (((Button)sender).Name.Equals("btn_LowerSection_Chance"))
            {
                int sum = countChance();
                ((Button)sender).Content = sum.ToString();
                updateLowerScoreTotal("btn_LowerSection_Chance", sum);
                bChance = true;
                if (checkGameOverStatus() == false)
                {
                    restoreGameState();
                }
                else
                {
                    gameIsOver(((Button)sender));
                }
            }
        }

       private void updateLowerScoreTotal(string btn,int sum){
           LowerTotalSum += sum;
           tb_LowerSection_LowerTotal.Text = LowerTotalSum.ToString();
           int UpperTotal = int.Parse(tb_UpperSection_UpperTotal.Text);
           //grand total
           int GrandTotal = UpperTotal + LowerTotalSum;
           tb_LowerSection_GrandTotal.Text = GrandTotal.ToString();
       }

       //chance 
       private int countChance() {
           return (int.Parse(btnDiceOne.Content.ToString()) + int.Parse(btnDiceTwo.Content.ToString()) + int.Parse(btnDiceThree.Content.ToString()) + int.Parse(btnDiceFour.Content.ToString()) + int.Parse(btnDiceFive.Content.ToString()));
       }
        
       //1 1 1 1 1  yahtzee
       private bool checkYahtzeeStatus() {
           int[] taulukko = new int[5];
           taulukko[0] = int.Parse(btnDiceOne.Content.ToString());
           taulukko[1] = int.Parse(btnDiceTwo.Content.ToString());
           taulukko[2] = int.Parse(btnDiceThree.Content.ToString());
           taulukko[3] = int.Parse(btnDiceFour.Content.ToString());
           taulukko[4] = int.Parse(btnDiceFive.Content.ToString());
           if (taulukko[0] == taulukko[1] && taulukko[0] == taulukko[2] && taulukko[0] == taulukko[3] && taulukko[0] == taulukko[4])
               return true;
           else
               return false;

       }

       //1 2 3 4 5  or 2 3 4 5 6  Large straight
       private bool checkLargeStraightStatus() {
           List<int> l = new List<int>();
           l.Add(int.Parse(btnDiceOne.Content.ToString()));
           l.Add(int.Parse(btnDiceTwo.Content.ToString()));
           l.Add(int.Parse(btnDiceThree.Content.ToString()));
           l.Add(int.Parse(btnDiceFour.Content.ToString()));
           l.Add(int.Parse(btnDiceFive.Content.ToString()));
           l.Sort();
            if(((l.ElementAt(0) == 1) &&
               (l.ElementAt(1) == 2) &&
               (l.ElementAt(2) == 3) &&
               (l.ElementAt(3) == 4) &&
               (l.ElementAt(4) == 5)) ||
              ((l.ElementAt(0) == 2) &&
               (l.ElementAt(1) == 3) &&
               (l.ElementAt(2) == 4) &&
               (l.ElementAt(3) == 5) &&
               (l.ElementAt(4) == 6)) ){
                     return true;
            } else {
                     return false;
            }

       }

       //1 2 3 4 x  or 2 3 4 5 x  or 3 4 5 6 x  Small straight
       //x 1 2 3 4  or x 2 3 4 5  or x 3 4 5 6 Small straight
       private bool checkSmallStraightStatus() {
           List<int> l = new List<int>();
           l.Add(int.Parse(btnDiceOne.Content.ToString()));
           l.Add(int.Parse(btnDiceTwo.Content.ToString()));
           l.Add(int.Parse(btnDiceThree.Content.ToString()));
           l.Add(int.Parse(btnDiceFour.Content.ToString()));
           l.Add(int.Parse(btnDiceFive.Content.ToString()));
           l.Sort();
           int[] i = new int[5];
           for (int v = 0; v < i.Length; v++) {
               i[v] = l.ElementAt(v);
           }

           for (int j = 0; j < 4; j++){
               int temp = 0;
               if (i[j] == i[j + 1]) {
                   temp = i[j];
                   for (int k = j; k < 4; k++){
                       i[k] = i[k + 1];
                   }
                   i[4] = temp;
               }
           }
           if (((i[0] == 1) && (i[1] == 2) && (i[2] == 3) && (i[3] == 4)) ||
               ((i[0] == 2) && (i[1] == 3) && (i[2] == 4) && (i[3] == 5)) ||
               ((i[0] == 3) && (i[1] == 4) && (i[2] == 5) && (i[3] == 6)) ||
               ((i[1] == 1) && (i[2] == 2) && (i[3] == 3) && (i[4] == 4)) ||
               ((i[1] == 2) && (i[2] == 3) && (i[3] == 4) && (i[4] == 5)) ||
               ((i[1] == 3) && (i[2] == 4) && (i[3] == 5) && (i[4] == 6)))
           {
               return true;
           } else
               return false;

       }

       private bool checkFullHouseStatus()
       {
           int[] taulukko = new int[5];
           taulukko[0] = int.Parse(btnDiceOne.Content.ToString());
           taulukko[1] = int.Parse(btnDiceTwo.Content.ToString());
           taulukko[2] = int.Parse(btnDiceThree.Content.ToString());
           taulukko[3] = int.Parse(btnDiceFour.Content.ToString());
           taulukko[4] = int.Parse(btnDiceFive.Content.ToString());
           
           int tmp = 0; int cCounter = 0; 
           for (int i = 0; i < taulukko.Length; i++) {
               if (taulukko[0] == taulukko[i]) {
                   cCounter++;
               } else {
                   tmp = taulukko[i];
               }
           }
           int dCounter = 0;
           if (tmp == 0 || cCounter<2)  {
               return false;
           } else {
               for (int i = 0; i < taulukko.Length; i++) {
                   if (tmp == taulukko[i]) {
                       dCounter++;
                   } 
               }
               if (cCounter == 2) {
                   if (dCounter == 3) {
                       return true;
                   } else {
                       return false;
                   }
               } else if (cCounter == 3)  {
                   if (dCounter == 2) {
                       return true;
                   }
                   else {
                       return false;
                   }
               } else {
                   return false;
               }
           }
       }

        private int checkNOfAKindCondition(int kind) {
            int[] taulukko = new int[5];
            bool bLoytyi = false;
            taulukko[0] = int.Parse(btnDiceOne.Content.ToString());
            taulukko[1] = int.Parse(btnDiceTwo.Content.ToString());
            taulukko[2] = int.Parse(btnDiceThree.Content.ToString());
            taulukko[3] = int.Parse(btnDiceFour.Content.ToString());
            taulukko[4] = int.Parse(btnDiceFive.Content.ToString());
            if (kind == 3) {  //3 same variants
                if (
                 (taulukko[0] == taulukko[1] && taulukko[0] == taulukko[2]) ||
                 (taulukko[0] == taulukko[2] && taulukko[0] == taulukko[3]) ||
                 (taulukko[0] == taulukko[3] && taulukko[0] == taulukko[4]) ||
                 (taulukko[0] == taulukko[2] && taulukko[0] == taulukko[4]) ||
                 (taulukko[0] == taulukko[1] && taulukko[0] == taulukko[3]) ||
                 (taulukko[0] == taulukko[1] && taulukko[0] == taulukko[4])) {
                    bLoytyi = true;
                }
                if (
                 (taulukko[1] == taulukko[2] && taulukko[1] == taulukko[3]) ||
                 (taulukko[1] == taulukko[3] && taulukko[1] == taulukko[4]) ||
                 (taulukko[1] == taulukko[0] && taulukko[1] == taulukko[4]) ||
                 (taulukko[1] == taulukko[0] && taulukko[1] == taulukko[2]) ||
                 (taulukko[1] == taulukko[0] && taulukko[1] == taulukko[3]) ||
                 (taulukko[1] == taulukko[2] && taulukko[1] == taulukko[4])) {
                    bLoytyi = true;
                }
                if (
                 (taulukko[2] == taulukko[3] && taulukko[2] == taulukko[4]) ||
                 (taulukko[2] == taulukko[0] && taulukko[2] == taulukko[4]) ||
                 (taulukko[2] == taulukko[0] && taulukko[2] == taulukko[1]) ||
                 (taulukko[2] == taulukko[0] && taulukko[2] == taulukko[3]) ||
                 (taulukko[2] == taulukko[1] && taulukko[2] == taulukko[3]) ||
                 (taulukko[2] == taulukko[1] && taulukko[2] == taulukko[4])) {
                    bLoytyi = true;
                }
            }

            if(kind==4) { //4 same variants
               if(
                (taulukko[0]==taulukko[1]  && taulukko[0]==taulukko[2] && taulukko[0]==taulukko[3]) || 
                (taulukko[0]==taulukko[2]  && taulukko[0]==taulukko[3] && taulukko[0]==taulukko[4]) ||
                (taulukko[0] == taulukko[1] && taulukko[0] == taulukko[3] && taulukko[0] == taulukko[4])||
                (taulukko[0] == taulukko[1] && taulukko[0] == taulukko[2] && taulukko[0] == taulukko[4])) {
                    bLoytyi = true;
                }
               if (
                (taulukko[1] == taulukko[2] && taulukko[1] == taulukko[3] && taulukko[1] == taulukko[4]) ||
                (taulukko[1] == taulukko[0] && taulukko[1] == taulukko[3] && taulukko[1] == taulukko[4]) ||
                (taulukko[1] == taulukko[0] && taulukko[1] == taulukko[2] && taulukko[1] == taulukko[3]) ||
                 (taulukko[1] == taulukko[0] && taulukko[1] == taulukko[2] && taulukko[1] == taulukko[4])){
                    bLoytyi = true;
                }
               if (
                 (taulukko[2] == taulukko[0] && taulukko[2] == taulukko[3] && taulukko[2] == taulukko[4]) ||
                 (taulukko[2] == taulukko[0] && taulukko[2] == taulukko[1] && taulukko[2] == taulukko[4]) ||
                 (taulukko[2] == taulukko[0] && taulukko[2] == taulukko[1] && taulukko[2] == taulukko[3]) ||
                 (taulukko[2] == taulukko[1] && taulukko[2] == taulukko[3] && taulukko[2] == taulukko[4])) {
                     bLoytyi = true;
               }
            }
            int sum = 0;
            if (bLoytyi) {
                sum += taulukko[0];
                sum += taulukko[1];
                sum += taulukko[2];
                sum += taulukko[3];
                sum += taulukko[4];
            } 
         return sum;
        }

        private void btnNewGameClicked(object sender, RoutedEventArgs e) {

        //upperLevel Score components
        UpperOne=0;
        bUpperOne = false;
        UpperTwo=0;
        bUpperTwo = false;
        UpperThree = 0;
        bUpperThree = false; 
        UpperFour = 0;
        bUpperFour = false;
        UpperFive = 0;
        bUpperFive = false;
        UpperSix = 0;
        bUpperSix = false;
        //lower score section
        LowerTotalSum=0;
        bThreeOfKind = false;
        bFourOfKind = false;
        bFullHouse = false;
        bSmallStraight = false;
        bLargeStraight = false;
        bYahtzee = false;
        bChance = false;
        restoreGameState();
        btnOutputOne.Content = "";
        btnOutputTwo.Content = "";
        btnOutputThree.Content = "";
        btnOutputFour.Content = "";
        btnOutputFive.Content = "";
        btnOutputSix.Content = "";
        btn_LowerSection_ThreeOfAKind.Content = "";
        btn_LowerSection_FourOfAKind.Content = "";
        btn_LowerSection_FullHouse.Content = "";
        btn_LowerSection_SmallStraight.Content = "";
        btn_LowerSection_LargeStraight.Content = "";
        btn_LowerSection_Yahtzee.Content = "";
        btn_LowerSection_Chance.Content = "";
        tb_UpperSection_UpperScore.Text="0";
        tb_UpperSection_Bonus.Text="0";
        tb_UpperSection_UpperTotal.Text="0";
        tb_LowerSection_LowerTotal.Text="0";
        tb_LowerSection_GrandTotal.Text = "0";
        tbGameOver.Text = "";

        btnDiceOne.Visibility = Visibility.Visible;
        btnDiceTwo.Visibility = Visibility.Visible;
        btnDiceThree.Visibility = Visibility.Visible;
        btnDiceFour.Visibility = Visibility.Visible;
        btnDiceFive.Visibility = Visibility.Visible;
        }

    }
}