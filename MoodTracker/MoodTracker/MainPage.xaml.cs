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
        {
            moodEntry = moodText.Text;

        }

    }
}
