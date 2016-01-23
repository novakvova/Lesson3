using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmailSender
{
	class MyEmailSender
	{
		static public string ToEmail {set; get;}
		static public string Subject {set; get;}
		static public string Body {set; get;}

		public static void SendEmail()
		{

				var fromAddress = new MailAddress("oleksandr.pastukhov@gmail.com", "From Oleksandr Pastukhov");
				var toAddress = new MailAddress(ToEmail);
				#region MyPassword
				const string fromPassword = ")cy0dybq%fh0km";
			
				#endregion
				string subject = Subject;
				string body = Body;

				var smtp = new SmtpClient
				{
					Host = "smtp.gmail.com",
					Port = 587,
					EnableSsl = true,
					DeliveryMethod = SmtpDeliveryMethod.Network,
					UseDefaultCredentials = false,
					Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
				};
				try
				{
					using (var message = new MailMessage(fromAddress, toAddress)
					{
						Subject = subject,
						Body = body
					})
					{
						smtp.Send(message);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
		}

		
	}
}
