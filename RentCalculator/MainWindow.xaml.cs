using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RentCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User user1 = new User();
        User user2 = new User();
        TotalDue allBills = new TotalDue();

        public MainWindow()
        {
            InitializeComponent();
        }
        #region RENT
        private void RentCheckUser1Checked(object sender, RoutedEventArgs e)
        {
            int rentBill = Convert.ToInt32(RentAmountText.Text);
            user1.AddBill(rentBill);
            //AnswerLabel.Content = user1.AmountPaid;
        }

        private void RentCheckUser1Unchecked(object sender, RoutedEventArgs e)
        {
            int rentBill = Convert.ToInt32(RentAmountText.Text);
            user1.RemoveBill(rentBill);
            //AnswerLabel.Content = user1.AmountPaid;
        }

        private void RentCheckUser2Checked(object sender, RoutedEventArgs e)
        {
            int rentBill = Convert.ToInt32(RentAmountText.Text);
            user2.AddBill(rentBill);
        }

        private void RentCheckUser2Unchecked(object sender, RoutedEventArgs e)
        {
            int rentBill = Convert.ToInt32(RentAmountText.Text);
            user2.RemoveBill(rentBill);
        }
        #endregion
        #region INTERNET
        private void InternetCheckUser1Checked(object sender, RoutedEventArgs e)
        {
            int internetBill = Convert.ToInt32(InternetAmountText.Text);
            user1.AddBill(internetBill);
            //AnswerLabel.Content = user1.AmountPaid;
        }

        private void InternetCheckUser1Unchecked(object sender, RoutedEventArgs e)
        {
            int internetBill = Convert.ToInt32(InternetAmountText.Text);
            user1.RemoveBill(internetBill);
            //AnswerLabel.Content = user1.AmountPaid;
        }

        private void InternetCheckUser2Checked(object sender, RoutedEventArgs e)
        {
            int internetBill = Convert.ToInt32(InternetAmountText.Text);
            user2.AddBill(internetBill);
        }

        private void InternetCheckUser2Unchecked(object sender, RoutedEventArgs e)
        {
            int internetBill = Convert.ToInt32(InternetAmountText.Text);
            user2.RemoveBill(internetBill);
        }
        #endregion
        #region ELECTRICITY
        private void ElectricityCheckUser1Checked(object sender, RoutedEventArgs e)
        {
            int electricityBill = Convert.ToInt32(ElectricityAmountText.Text);
            user1.AddBill(electricityBill);
            //AnswerLabel.Content = user1.AmountPaid;
        }

        private void ElectricityCheckUser1Unchecked(object sender, RoutedEventArgs e)
        {
            int electricityBill = Convert.ToInt32(ElectricityAmountText.Text);
            user1.RemoveBill(electricityBill);
            //AnswerLabel.Content = user1.AmountPaid;
        }

        private void ElectricityCheckUser2Checked(object sender, RoutedEventArgs e)
        {
            int electricityBill = Convert.ToInt32(ElectricityAmountText.Text);
            user2.AddBill(electricityBill);
        }

        private void ElectricityCheckUser2Unchecked(object sender, RoutedEventArgs e)
        {
            int electricityBill = Convert.ToInt32(ElectricityAmountText.Text);
            user2.RemoveBill(electricityBill);
        }
        #endregion

        private void CalculateButtonClicked(object sender, RoutedEventArgs e)
        {
            // set usernames
            user1.Name = User1Label.Content.ToString();
            user2.Name = User2Label.Content.ToString();

            // calc bill totals
            allBills.TotalOfAllBills(
                RentAmountText.Text,
                InternetAmountText.Text,
                ElectricityAmountText.Text);

            // get answer
            Answer();
        }

        public void Answer()
        {
            List<User> users = new List<User>() { user1, user2 };

            foreach (var user in users)
            {
                int diff = user.AmountPaid - allBills.TotalPerUser;

                if (diff > 0)
                {
                    user.AmountOwed = diff;
                    AnswerLabel.Content = user.Name + " is owed " + user.AmountOwed;
                }
                if (diff == 0)
                {
                    AnswerLabel.Content = "Nothing is owed!";
                }
            }


        }
    }

    public class User
    {
        public string Name { get; set; }
        public int AmountPaid { get; set; }
        public int AmountOwed { get; set; }

        public int AddBill(int bill)
        {
            AmountPaid = AmountPaid + bill;
            return AmountPaid;
        }

        public int RemoveBill(int bill)
        {
            AmountPaid = AmountPaid - bill;
            return AmountPaid;
        }
    }
    public class TotalDue
    {
        public int Total { get; set; }
        public int TotalPerUser { get; set; }

        public int TotalOfAllBills(string bill1, string bill2, string bill3)
        {
            try
            {
                Total = Convert.ToInt32(bill1) + Convert.ToInt32(bill2) + Convert.ToInt32(bill3);
            }
            catch (FormatException)
            {
                System.Windows.Forms.MessageBox.Show("Enter values for all bills.", "Error");
            }
            TotalPerUser = Total / 2;
            return Total;
        }
    }

}
