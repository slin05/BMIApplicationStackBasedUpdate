using Microsoft.Maui.Controls;
//Test
namespace BMIApplication
{
    public partial class BMICalculator : ContentPage
    {
        private string? selectedGender;

        public BMICalculator()
        {
            InitializeComponent();
            MaleFrame.BorderColor = Colors.LightGray;
            FemaleFrame.BorderColor = Colors.LightGray;
        }

        private void OnMaleSelected(object sender, TappedEventArgs e)
        {
            selectedGender = "Male";
            MaleFrame.BorderColor = Colors.Gray;
            FemaleFrame.BorderColor = Colors.LightGray;
        }

        private void OnFemaleSelected(object sender, TappedEventArgs e)
        {
            selectedGender = "Female";
            FemaleFrame.BorderColor = Colors.Gray;
            MaleFrame.BorderColor = Colors.LightGray;
        }

        private async void OnCalculateClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedGender))
            {
                await DisplayAlert("Error", "Please select a gender", "OK");
                return;
            }

            double height = HeightSlider.Value;
            double weight = WeightSlider.Value;

            if (height <= 0 || weight <= 0)
            {
                await DisplayAlert("Error", "Height and weight must be greater than 0", "OK");
                return;
            }

            double bmi = (weight * 703) / (height * height);
            string status = GetHealthStatus(bmi);
            string recommendation = GetRecommendation(status);

            string message = $"Your calculated BMI results are:\n\n" +
                           $"Gender: {selectedGender}\n" +
                           $"BMI: {bmi:F1}\n" +
                           $"Health Status: {status}\n" +
                           $"Recommendations:\n{recommendation}";

            await DisplayAlert("Results", message, "Ok");
        }

        private string GetHealthStatus(double bmi)
        {
            if (selectedGender == "Male")
            {
                if (bmi < 18.5) return "Underweight";
                if (bmi < 25) return "Normal weight";
                if (bmi < 30) return "Overweight";
                return "Obese";
            }
            else 
            {
                if (bmi < 18) return "Underweight";
                if (bmi < 24) return "Normal weight";
                if (bmi < 29) return "Overweight";
                return "Obese";
            }
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
    }
    }