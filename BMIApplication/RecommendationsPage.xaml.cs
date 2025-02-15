namespace BMIApplication
{
    public partial class RecommendationsPage : ContentPage
    {
        public RecommendationsPage(string healthStatus)
        {
            InitializeComponent();
            RecommendationsLabel.Text = GetRecommendation(healthStatus);
        }

        private string GetRecommendation(string status)
        {
            switch (status)
            {
                case "Underweight":
                    return "- Increase calorie intake with nutrient-rich foods (e.g., nuts, lean protein, whole grains)\n" +
                           "- Incorporate strength training to build muscle mass\n" +
                           "- Consult a nutritionist if needed";
                case "Normal weight":
                    return "- Maintain a balanced diet with proteins, healthy fats, and fiber\n" +
                           "- Stay physically active with at least 150 minutes of exercise per week\n" +
                           "- Keep regular check-ups to monitor overall health";
                case "Overweight":
                    return "- Reduce processed foods and focus on portion control\n" +
                           "- Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training\n" +
                           "- Drink plenty of water and track your progress";
                case "Obese":
                    return "- Consult a doctor for personalized guidance\n" +
                           "- Start with low-impact exercises (e.g., walking, cycling)\n" +
                           "- Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes\n" +
                           "- Avoid sugary drinks and maintain a consistent sleep schedule";
                default:
                    return "Invalid status";
            }
        }

        private async void OnBackToResultsClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnStartOverClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}