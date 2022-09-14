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
	public sealed partial class CurrencyConversion : Page
	{
		public CurrencyConversion()
		{
			this.InitializeComponent();
		}

		const double USD_RATE = 1, EURO_RATE = 1, BRITISH_RATE = 1, INDIAN_RATE = 1,
		   USD_TO_EURO = 0.85189982, USD_TO_BRITISH = 0.72872436, USD_TO_INDIAN = 74.257327,
		   EURO_TO_USD = 1.1739732, EURO_TO_BRITISH = 0.8556672, EURO_TO_INDIAN = 87.00755,
		   BRITISH_TO_USD = 1.371907, BRITISH_TO_EURO = 1.1686692, BRITISH_TO_INDIAN = 101.68635,
		   INDIAN_TO_USD = 0.011492628, INDIAN_TO_EURO = 0.013492774, INDIAN_TO_BRITISH = 0.0098339397;

		private void calcCurrency(double money)
		{
			double result = 0;

			//FOR CONVERTION FOR USD
			if (fromComboBox.SelectedIndex == 0 && toComboBox.SelectedIndex == 0)
			{
				result = money * USD_RATE;
				howmuchTextBlock.Text = money.ToString() + " Us Dollar = ";
				answerTextBlock.Text = result.ToString("C") + " Us Dollar ";
				currencyamountTextBlock.Text = "1 US Dollar = " + USD_RATE.ToString() + " Us Dollar";
				currencyresiprocateTextBlock.Text = "1 US Dollar = " + USD_RATE.ToString() + " Us Dollar";
			}
			else if (fromComboBox.SelectedIndex == 0 && toComboBox.SelectedIndex == 1)
			{
				result = money * USD_TO_EURO;
				howmuchTextBlock.Text = money.ToString() + " Us Dollar = ";
				answerTextBlock.Text = result.ToString("C") + " EURO ";
				currencyamountTextBlock.Text = "1 US Dollar = " + USD_TO_EURO.ToString() + " EURO";
				currencyresiprocateTextBlock.Text = "1 EURO = " + EURO_TO_USD.ToString() + " Us Dollar";
			}
			else if (fromComboBox.SelectedIndex == 0 && toComboBox.SelectedIndex == 2)
			{
				result = money * USD_TO_BRITISH;
				howmuchTextBlock.Text = money.ToString() + " Us Dollar = ";
				answerTextBlock.Text = result.ToString("C") + " BRITISH POUND ";
				currencyamountTextBlock.Text = "1 US Dollar = " + USD_TO_BRITISH.ToString() + " BRITISH POUND";
				currencyresiprocateTextBlock.Text = "1 BRITISH POUND = " + BRITISH_TO_USD.ToString() + " Us Dollar";
			}
			else if (fromComboBox.SelectedIndex == 0 && toComboBox.SelectedIndex == 3)
			{
				result = money * USD_TO_INDIAN;
				howmuchTextBlock.Text = money.ToString() + " Us Dollar = ";
				answerTextBlock.Text = result.ToString("C") + " INDIAN RUPEE ";
				currencyamountTextBlock.Text = "1 US Dollar = " + USD_TO_INDIAN.ToString() + " INDIAN RUPEE";
				currencyresiprocateTextBlock.Text = "1 INDIAN RUPEE = " + INDIAN_TO_USD.ToString() + " Us Dollar";
			}

			//CONVERTION FOR EURO
			else if (fromComboBox.SelectedIndex == 1 && toComboBox.SelectedIndex == 0)
			{
				result = money * EURO_TO_USD;
				howmuchTextBlock.Text = money.ToString() + " EURO = ";
				answerTextBlock.Text = result.ToString("C") + " USD ";
				currencyamountTextBlock.Text = "1 EURO= " + EURO_TO_USD.ToString() + " US DOLLAR";
				currencyresiprocateTextBlock.Text = "1 US DOLLAR = " + USD_TO_EURO.ToString() + " EURO";
			}
			else if (fromComboBox.SelectedIndex == 1 && toComboBox.SelectedIndex == 1)
			{
				result = money * EURO_RATE;
				howmuchTextBlock.Text = money.ToString() + " EURO = ";
				answerTextBlock.Text = result.ToString("C") + " EURO ";
				currencyamountTextBlock.Text = "1 EURO= " + EURO_RATE.ToString() + " EURO";
				currencyresiprocateTextBlock.Text = "1 EURO = " + EURO_RATE.ToString() + " EURO";
			}
			else if (fromComboBox.SelectedIndex == 1 && toComboBox.SelectedIndex == 2)
			{
				result = money * EURO_TO_BRITISH;
				howmuchTextBlock.Text = money.ToString() + " EURO = ";
				answerTextBlock.Text = result.ToString("C") + " BRITISH POUND  ";
				currencyamountTextBlock.Text = "1 EURO= " + EURO_TO_BRITISH.ToString() + " BRITISH POUND";
				currencyresiprocateTextBlock.Text = "1 BRITISH POUND = " + BRITISH_TO_EURO.ToString() + " EURO";
			}
			else if (fromComboBox.SelectedIndex == 1 && toComboBox.SelectedIndex == 3)
			{
				result = money * EURO_TO_INDIAN;
				howmuchTextBlock.Text = money.ToString() + " EURO = ";
				answerTextBlock.Text = result.ToString("C") + " INDIAN RUPEE  ";
				currencyamountTextBlock.Text = "1 EURO= " + EURO_TO_INDIAN.ToString() + " INDIAN RUPEE";
				currencyresiprocateTextBlock.Text = "1 INDIAN RUPEE = " + INDIAN_TO_EURO.ToString() + " EURO";
			}

			//CONVERTION FOR BRITISH
			else if (fromComboBox.SelectedIndex == 2 && toComboBox.SelectedIndex == 0)
			{
				result = money * BRITISH_TO_USD;
				howmuchTextBlock.Text = money.ToString() + " BRITISH POUND = ";
				answerTextBlock.Text = result.ToString("C") + " US DOLLAR  ";
				currencyamountTextBlock.Text = "1 BRITISH POUND = " + BRITISH_TO_USD.ToString() + " US DOLLAR";
				currencyresiprocateTextBlock.Text = "1 US DOLLAR = " + USD_TO_BRITISH.ToString() + " BRITISH POUND";
			}
			else if (fromComboBox.SelectedIndex == 2 && toComboBox.SelectedIndex == 1)
			{
				result = money * BRITISH_TO_EURO;
				howmuchTextBlock.Text = money.ToString() + " BRITISH POUND = ";
				answerTextBlock.Text = result.ToString("C") + " EURO ";
				currencyamountTextBlock.Text = "1 BRITISH POUND = " + BRITISH_TO_EURO.ToString() + " EURO";
				currencyresiprocateTextBlock.Text = "1 EURO = " + EURO_TO_BRITISH.ToString() + " BRITISH POUND";
			}
			else if (fromComboBox.SelectedIndex == 2 && toComboBox.SelectedIndex == 2)
			{
				result = money * BRITISH_RATE;
				howmuchTextBlock.Text = money.ToString() + " BRITISH POUND = ";
				answerTextBlock.Text = result.ToString("C") + " BRITISH POUND ";
				currencyamountTextBlock.Text = "1 BRITISH POUND = " + BRITISH_RATE.ToString() + " BRITISH POUND";
				currencyresiprocateTextBlock.Text = "1 BRITISH POUND = " + BRITISH_RATE.ToString() + " BRITISH POUND";
			}
			else if (fromComboBox.SelectedIndex == 2 && toComboBox.SelectedIndex == 3)
			{
				result = money * BRITISH_TO_INDIAN;
				howmuchTextBlock.Text = money.ToString() + " BRITISH POUND = ";
				answerTextBlock.Text = result.ToString("C") + " INDIAN RUPEE ";
				currencyamountTextBlock.Text = "1 BRITISH POUND = " + BRITISH_TO_INDIAN.ToString() + " INDIAN RUPEE";
				currencyresiprocateTextBlock.Text = "1 INDIAN RUPEE = " + INDIAN_TO_BRITISH.ToString() + " BRITISH POUND";
			}

			//CONVERTION FOR INDIAN RUPEE
			else if (fromComboBox.SelectedIndex == 3 && toComboBox.SelectedIndex == 0)
			{
				result = money * INDIAN_TO_USD;
				howmuchTextBlock.Text = money.ToString() + " INDIAN RUPEE = ";
				answerTextBlock.Text = result.ToString("C") + " US DOLLAR ";
				currencyamountTextBlock.Text = "1 INDIAN RUPEE = " + INDIAN_TO_USD.ToString() + " US DOLLAR";
				currencyresiprocateTextBlock.Text = "1 US DOLLAR = " + USD_TO_INDIAN.ToString() + " INDIAN RUPEE";
			}
			else if (fromComboBox.SelectedIndex == 3 && toComboBox.SelectedIndex == 1)
			{
				result = money * INDIAN_TO_EURO;
				howmuchTextBlock.Text = money.ToString() + " INDIAN RUPEE = ";
				answerTextBlock.Text = result.ToString("C") + " EURO ";
				currencyamountTextBlock.Text = "1 INDIAN RUPEE = " + INDIAN_TO_EURO.ToString() + " EURO";
				currencyresiprocateTextBlock.Text = "1 EURO = " + EURO_TO_INDIAN.ToString() + " INDIAN RUPEE";
			}
			else if (fromComboBox.SelectedIndex == 3 && toComboBox.SelectedIndex == 2)
			{
				result = money * INDIAN_TO_BRITISH;
				howmuchTextBlock.Text = money.ToString() + " INDIAN RUPEE = ";
				answerTextBlock.Text = result.ToString("C") + " BRITISH POUND ";
				currencyamountTextBlock.Text = "1 INDIAN RUPEE = " + INDIAN_TO_BRITISH.ToString() + " BRITISH POUND";
				currencyresiprocateTextBlock.Text = "1 BRITISH POUND = " + BRITISH_TO_INDIAN.ToString() + " INDIAN RUPEE";
			}
			else if (fromComboBox.SelectedIndex == 3 && toComboBox.SelectedIndex == 3)
			{
				result = money * INDIAN_RATE;
				howmuchTextBlock.Text = money.ToString() + " INDIAN RUPEE = ";
				answerTextBlock.Text = result.ToString("C") + " INDIAN RUPEE ";
				currencyamountTextBlock.Text = "1 INDIAN RUPEE = " + INDIAN_RATE.ToString() + " INDIAN RUPEE";
				currencyresiprocateTextBlock.Text = "1 INDIAN RUPEE = " + INDIAN_RATE.ToString() + " INDIAN RUPEE";
			}

		}



		private async void currencyButton_Click(object sender, RoutedEventArgs e)
		{
			double money = 0;

			//not left blank
			if (String.IsNullOrEmpty(amountTextBox.Text))
			{
				amountTextBox.Text = "0";
			}

			try
			{
				money = double.Parse(amountTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("TRY AGAIN!!" + ex.Message);
				await dialogMessage.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();

			}

			calcCurrency(money);

		}

		private void exitcurrency_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}

	}
}
