namespace BMIApplication
{
    public partial class BMIResultPage : ContentPage
    {
        private readonly string healthStatus;
        private readonly string gender;

        public BMIResultPage(string gender, double bmi, string status)
        {
            InitializeComponent();
            this.gender = gender;
            this.healthStatus = status;

            ResultsLabel.Text = $"Gender: {gender}\nBMI: {bmi:F1}\nHealth Status: {status}";
        }

        private async void OnViewRecommendationsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecommendationsPage(healthStatus));
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}