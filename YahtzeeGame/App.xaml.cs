using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;
using Windows.System;
// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227
namespace YahtzeeGame {
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application {
        public static MobileServiceClient MobileService = new MobileServiceClient(
"https://yahtzeegame.azure-mobile.net/",
"kGkaHuWvjesalUkpXgNStjuzYEptJV77"
);

        bool isEventRegistered;
     //   private IMobileServiceTable<Item> itemTable = MobileService.GetTable<Item>();

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainPage), args.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        protected override void OnWindowCreated(WindowCreatedEventArgs args) {
            SettingsPane.GetForCurrentView().CommandsRequested += onCommandsRequested;
            this.isEventRegistered = true;
            // Place your CommandsRequested handler here to ensure your settings are available at all times in your app
        }

        void onCommandsRequested(SettingsPane settingsPane, SettingsPaneCommandsRequestedEventArgs eventArgs){
            UICommandInvokedHandler handler = new UICommandInvokedHandler(onSettingsCommand);
            SettingsCommand generalCommand = new SettingsCommand("privacypolicySettings", "Privacy Policy", handler);
            eventArgs.Request.ApplicationCommands.Add(generalCommand);
        }

        void onSettingsCommand(IUICommand command) {
            SettingsCommand settingsCommand = (SettingsCommand)command;
            displaySettings(command);
        }

        private async void displaySettings(IUICommand command){
            if (command.Id.ToString().Equals("privacypolicySettings")) {
               // try {
              //      MobileServiceTableQuery<Item> query = itemTable.
               //     Where(p => p.Id > 0)
                //    .OrderByDescending(Item => Item.Score)
        //            .IncludeTotalCount();
          //      IEnumerable<Item> item = await query.ToEnumerableAsync();
          //      int s = item.Count();
           //    } catch (Exception e) {
             //      bOnline = false;    
                // }
                //if (bOnline){
                   Launcher.LaunchUriAsync(new Uri("http://yahtzeegameprivacypolicy.azurewebsites.net"));
                //} else {
                    //MessageDialog d = new MessageDialog("Privacy Policy");
                  //  d.Content = "Privacy Policy\n\nIn English\nYahtzeeGame -application uses Internet-connection to upload the topten results of the game through a mobile service from the YahtzeeGame-server. Whether the score reached by the player is good enough in order to be among the top ten scores, the player is provided a chance to save his/her name with the actual score onto the database table on the server.\n\nSuomeksi\nYahtzeeGame -sovellus käyttää internet-yhteyttä top ten -tulosten lataamiseksi YahtzeeGame-palvelimelta mobiilipalvelun kautta. Mikäli pelaajan saavuttama pistemäärä pelissä yltää top ten -listalle, tarjotaan hänelle mahdollisuus tallentaa tulos ja syöttää nimensä palvelimella olevaan tietokantaan.\n\nCopyright © 2013, JK";
                    //d.ShowAsync();
                //}
            }
        }

    }
}
