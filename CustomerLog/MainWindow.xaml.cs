using CustomerLog.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
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

namespace CustomerLog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private ObservableCollection<Customer> Customers = new ObservableCollection<Customer>();
        private ObservableCollection<Log> Logs = new ObservableCollection<Log>();
        private ObservableCollection<VoicemailLog> VoicemailLogs = new ObservableCollection<VoicemailLog>();
        private ObservableCollection<EmailLog> EmailLogs = new ObservableCollection<EmailLog>();
        //Intial value for Id
        private int _lastCustomerId = 0;
        private int _lastLogId = 0;
        public MainWindow()
        {
            InitializeComponent();

            CustomerList.ItemsSource = Customers;

            //Set null for Logs ItemsSource before a customer is selected otherwise all the log items will be display
            VoicemailLog.ItemsSource = null;
            EmailLog.ItemsSource = null;

        }

        private void CustomerSave_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer { Id = GenerateCustomerId(), Name = Name.Text, Address = Address.Text, PurchaseDate = DateTime.Parse(PurchaseDate.ToString()) };
            Customers.Add(customer);

            //Refresh and update the view after new customer is added
            CollectionViewSource.GetDefaultView(Customers).Refresh();
            SelectedCustomer1.ItemsSource = Customers;
            SelectedCustomer2.ItemsSource = Customers;
            SelectedCustomer.ItemsSource = Customers;

            MessageBox.Show("Add New Customer Successfully");
        }

        
        private void CreateVoicemailLog_Click(object sender, RoutedEventArgs e)
        {
            var voicemailLog = new VoicemailLog { Id = GenerateLogId(), ContactName = ContactName.Text, CustomerId = int.Parse(SelectedCustomer1.SelectedValue.ToString()), IsResponded = (bool)IsReponded.IsChecked, MessageSummary = MessageSummary.Text, PhoneNumber = PhoneNumber.Text, ReceivedTime = DateTime.Parse(ReceivedTime.Text)};
            Logs.Add(voicemailLog);
            MessageBox.Show("Create New Voicemail Log Successfully");
        }

        private void CreateEmailLog_Click(object sender, RoutedEventArgs e)
        {
            var emailLog = new EmailLog { Id = GenerateLogId(), ContactName = ContactName2.Text, CustomerId = int.Parse(SelectedCustomer2.SelectedValue.ToString()), IsResponded = (bool)IsReponded2.IsChecked, Email = Email.Text, Subject = Subject.Text, Text = Text.Text, ReceivedTime = DateTime.Parse(ReceivedTime2.Text) };
            Logs.Add(emailLog);
            MessageBox.Show("Create New Email Log Successfully");
        }

        private void SelectedCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var seletedCustomerId = int.Parse(SelectedCustomer.SelectedValue.ToString());

            //Get Voicemail logs and Email logs by CustomerId
            VoicemailLogs = GetVoicemailLogByCustomerId(seletedCustomerId);
            EmailLogs = GetEmailLogByCustomerId(seletedCustomerId);

            //Set these logs as ItemsSource for the view
            VoicemailLog.ItemsSource = VoicemailLogs;
            EmailLog.ItemsSource = EmailLogs;

            //Replace elements in Logs with updated elements in case there are data changes
            foreach (var element in VoicemailLogs)
                Logs[element.Id - 1] = element;
            foreach (var element in EmailLogs)
                Logs[element.Id - 1] = element;
        }

        private ObservableCollection<VoicemailLog> GetVoicemailLogByCustomerId(int id)
        {
            var Collection = new ObservableCollection<VoicemailLog>();
            var VoicemailLogs = Logs.OfType<VoicemailLog>().Where(l => l.CustomerId == id).ToList();
            foreach (var e in VoicemailLogs)
                Collection.Add(e);
            return Collection;
        }

        private ObservableCollection<EmailLog> GetEmailLogByCustomerId(int id)
        {
            var Collection = new ObservableCollection<EmailLog>();
            var EmailLogss = Logs.OfType<EmailLog>().Where(l => l.CustomerId == id).ToList();
            foreach (var e in EmailLogss)
                Collection.Add(e);
            return Collection;
        }

        //Keep track and generate Id for customers and logs
        private int GenerateCustomerId()
        {
            return ++_lastCustomerId;
        }

        private int GenerateLogId()
        {
            return ++_lastLogId;
        }

    }
}
