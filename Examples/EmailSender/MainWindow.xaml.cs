using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
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

namespace EmailSender
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void AddEmail(object sender, RoutedEventArgs e)
		{
			ListBoxItem item = new ListBoxItem();
			item.Content = tbNewEmail.Text;
			lbEmails.Items.Add(item);
		}

		private void SendEmeil(object sender, RoutedEventArgs e)
		{
			if (String.IsNullOrWhiteSpace(tbSubject.Text) ||
				String.IsNullOrWhiteSpace(tbText.Text))
			{
				MessageBox.Show("Заповніть тему та текст листа");
				return;
			}

			if (lbEmails.SelectedItems.Count == 0)
			{
				MessageBox.Show("Не вибрано відправника");
				return;
			}

			foreach (ListBoxItem item in lbEmails.SelectedItems)
			{
				MyEmailSender.ToEmail = item.Content.ToString();
				MyEmailSender.Subject = tbSubject.Text;
				MyEmailSender.Body = tbText.Text;
				MyEmailSender.SendEmail();
				//Thread.Sleep(2000);
			}


		}

	}
}
