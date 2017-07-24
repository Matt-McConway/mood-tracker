using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoodTracker
{
    public partial class MainPage : ContentPage
    {
        string moodEntry;
        public MainPage()
        {
            InitializeComponent();
        }

        void OnMoodEntry(object sender, EventArgs e)
        {   // Stores mood text in moodEntry. 
            // TODO: implement send to cognitive services on tap of a button.
            //       Implement Analysis Indicator
            if (moodText != null)
            {
                moodEntry = moodText.Text;
                App.PastMoods.Add(moodEntry);
                // Implementation of cognitive services goes here!
            }
        }

        async void OnMoodHistory(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MoodHistoryPage());
        }

    }
}
