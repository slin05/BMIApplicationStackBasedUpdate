using Microsoft.Maui.Controls;

namespace BMIApplication
{
    public partial class UserInputPage : ContentPage
    {
        private string? selectedGender;

        public UserInputPage()
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
            await Navigation.PushAsync(new BMIResultPage(selectedGender, bmi, status));
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
    }
}