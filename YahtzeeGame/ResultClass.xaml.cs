using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Microsoft.WindowsAzure.MobileServices;
using System.Runtime.Serialization;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

/**
 Item db
id min max level description
1  0     50  1   You're a poor player
2  51    100  2  You're getting there. Keep on practing and you'll get better!
3  101   150  3  Not bad. You're at intermediate level.
4  151   200  4  Very good. You are at very good level.
5  201   250  5  Excellent. You are on the top of this game.
6  250   500  6  Super, super! You are the best!
 */
namespace YahtzeeGame {
    public class Item {
        public int Id { get; set; }
        [DataMember(Name = "min")]
        public int Min { get; set; }
        [DataMember(Name = "max")]
        public int Max { get; set; }
        [DataMember(Name = "level")]
        public int Level { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
    }

    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class ResultClass : YahtzeeGame.Common.LayoutAwarePage {

        private IMobileServiceTable<Item> itemTable = App.MobileService.GetTable<Item>();
        private int score;
        private int level;
        private String desc;

        public ResultClass() {
            this.InitializeComponent();
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
            if (navigationParameter != null) {
                //score comes to yahtzeegame screen
                tbScoreLevelDesriptions.Visibility = Visibility.Collapsed;
                score = int.Parse(navigationParameter.ToString());
                tbScore.Text = "Score: " + navigationParameter.ToString();
                getLevelAndDesc();
            } else {
                tbScoreLevelDesriptions.Visibility = Visibility.Visible;
                tbScore.Visibility = Visibility.Collapsed;
                tbLevel.Visibility = Visibility.Collapsed;
                tbDesription.Visibility = Visibility.Collapsed;
                getClassificationData();

            }
        }

        private async void getLevelAndDesc() {
            if (score != 0) {
                try {
                    MobileServiceTableQuery<Item> query = itemTable.
                        Where(p => (score >= p.Min) && (score <= p.Max))
                        .OrderBy(Item => Item.Level)
                        .IncludeTotalCount();

                    IEnumerable<Item> item = await query.ToEnumerableAsync();
                    ITotalCountProvider prov = (ITotalCountProvider)item;
                    long count = ((ITotalCountProvider)item).TotalCount;
                    foreach (var it in item){
                        tbLevel.Text = "Level: " + it.Level;
                        tbDesription.Text = "Description: " + it.Description;
                    }
                }
                catch (Exception e){
                    tbOffline.Text = "You are offline. It is not possible to display score classifications!";
                }
            }
        }

        private async void getClassificationData() {
            try {
                MobileServiceTableQuery<Item> query = itemTable.
                    Where(p => p.Id > 0)
                    .OrderBy(Item => Item.Level)
                    .IncludeTotalCount();

                IEnumerable<Item> item = await query.ToEnumerableAsync();
                ITotalCountProvider prov = (ITotalCountProvider)item;
                long count = ((ITotalCountProvider)item).TotalCount;
                int counter = 1;
                foreach (var it in item) {
                    if (counter == 1) {
                        tbScoreLevelDesriptions.Text += "Level" + "\t" + "Score" + "\t" + "Description" + "\n";
                    }
                    tbScoreLevelDesriptions.Text +=it.Level +"\t" + it.Min + "-"  + it.Max + "\t" + it.Description + "\n";
                    counter++;
                }
            } catch (Exception e){
                tbOffline.Text = "You are offline. It is not possible to display score classifications!";
            }
        }


        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState) {
        }
    }
}
