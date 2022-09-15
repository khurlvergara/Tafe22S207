using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Mortgage_Calculator : Page
	{
		public Mortgage_Calculator()
		{
			this.InitializeComponent();
		}


		private async void calculatorButton_Click(object sender, RoutedEventArgs e)
		{
			double principleLoanAmount;
			double interestRate;
			double monthlyInterestRate;
			double monthlyRepayment;
			int duration;
			int durationInMonths;

			//principle loan Amount

			try
			{
				principleLoanAmount = double.Parse(principleInputTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Error Please enter an integer number. " + ex.Message);
				await dialogMessage.ShowAsync();
				principleInputTextBox.Focus(FocusState.Programmatic);
				principleInputTextBox.SelectAll();
				return;
			}
			if (String.IsNullOrEmpty(principleInputTextBox.Text))
			{
				var dialogMessage = new MessageDialog("Field cannot be left blank - Enter loan amount");
				await dialogMessage.ShowAsync();
				principleInputTextBox.Focus(FocusState.Programmatic);
				principleInputTextBox.SelectAll();
				return;
			}

			/// Interest Rate
			try
			{
				interestRate = double.Parse(yearlyIntRateInputTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Error! Please enter an integer number." + ex.Message);
				await dialogMessage.ShowAsync();
				yearlyIntRateInputTextBox.Focus(FocusState.Programmatic);
				yearlyIntRateInputTextBox.SelectAll();
				return;

			}

			if (string.IsNullOrEmpty(yearlyIntRateInputTextBox.Text))
			{
				var dialogMessage = new MessageDialog("Field cannot be left blank, please Enter a interest rate");
				await dialogMessage.ShowAsync();
				yearlyIntRateInputTextBox.Focus(FocusState.Programmatic);
				yearlyIntRateInputTextBox.SelectAll();
				return;
			}

			// Loan Duration
			try
			{
				duration = int.Parse(yearsInputTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Error! Please enter a integer number. " + ex.Message);
				await dialogMessage.ShowAsync();
				yearsInputTextBox.Focus(FocusState.Programmatic);
				yearsInputTextBox.SelectAll();
				return;
			}
			if (string.IsNullOrEmpty(yearsInputTextBox.Text))
			{
				var dialogMessage = new MessageDialog("Field cannot be left Blank, Please Enter a loan duration period. ");
				await dialogMessage.ShowAsync();
				yearsInputTextBox.Focus(FocusState.Programmatic);
				yearsInputTextBox.SelectAll();
				return;
			}

			// and Months
			try
			{
				durationInMonths = int.Parse(monthsInputextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Error! Please enter an integer number. " + ex.Message);
				await dialogMessage.ShowAsync();
				monthsInputextBox.Focus(FocusState.Programmatic);
				monthsInputextBox.SelectAll();
				return;
			}
			if (String.IsNullOrEmpty(monthsInputextBox.Text))
			{
				var dialogMessage = new MessageDialog("Field cannot be left blank - Enter months. ");
				await dialogMessage.ShowAsync();
				monthsInputextBox.Focus(FocusState.Programmatic);
				monthsInputextBox.SelectAll();
				return;
			}


			durationInMonths = duration * 12;
			monthlyInterestRate = interestRate / 100 / 12;
			monthlyRepayment = principleLoanAmount * monthlyInterestRate / (1 - (Math.Pow(1 + monthlyInterestRate, -durationInMonths)));

			//Output
			monthlyIntRateInputTextBox.Text = monthlyInterestRate.ToString();
			monthlyRepaymentOutputTextBox.Text = monthlyRepayment.ToString("C");
		}




		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}
