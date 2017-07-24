using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoodTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoodHistoryPage : ContentPage
    {
        public MoodHistoryPage()
        {
            InitializeComponent();
        }

        async void OnReturnClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}