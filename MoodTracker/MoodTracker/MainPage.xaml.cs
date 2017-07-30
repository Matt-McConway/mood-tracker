using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Net.Http.Headers;
using MoodTracker.Model;

namespace MoodTracker
{
    public partial class MainPage : ContentPage
    {
        string moodEntry;
        string moodScore;
        string moodFinal;
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnMoodEntry(object sender, EventArgs e)
        {   // Stores mood text in moodEntry. 
            // TODO: implement send to cognitive services on tap of a button.
            //       Implement Analysis Indicator
            if (moodText != null)
            {
                moodEntry = moodText.Text;
                await AnalyseMood(moodEntry);

                //
                // Implementation of cognitive services goes here!
            }
        }

        async void OnMoodHistory(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MoodHistoryPage());
        }

        static async Task AnalyseMood(string moodContent)
        {
            // Prepare the request headers
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "aa411a4666ff4bbfbb4267db4b4ca8b8");

            HttpResponseMessage response;
            string url = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment";

            var postData = @"{""documents"":[{""id"":""1"", ""language"":""en"", ""text"":""@Text""}]}".Replace("@Text", moodContent);

            byte[] byteData = Encoding.UTF8.GetBytes(postData);

            using (var content = new ByteArrayContent(byteData))
            {

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");  
                response = await client.PostAsync(url, content);
             
                var responseString = await response.Content.ReadAsStringAsync();

                var sentimentStr = new Regex(@"""score"":([\d.]+)").Match(responseString).Groups[1].Value;

                //SentimentModel responseModel = JsonConvert.DeserializeObject<SentimentModel>(responseString);


                string moodFinal = moodContent + " : " + sentimentStr;
                App.PastMoods.Add(moodFinal); 
            }
        }
    }
}
