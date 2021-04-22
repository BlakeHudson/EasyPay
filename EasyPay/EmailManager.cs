using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentEmail.Core;
using FluentEmail.Smtp;
using System.Net.Mail;
using System.Net;

namespace EasyPay
{
    class EmailManager
    {
        public Customer recepient;
        public Order receipt;
        String body;

        public EmailManager(Customer a, Order b)
        {
            recepient = a;
            receipt = b;
            for(int i=0;i<receipt.size() ;i++)
            {
                body += receipt.getProductAtIndex(i).ToString();
            }
        }

        public EmailManager(Customer a)
        {
            recepient = a;
            this.body = "";
        }


        //builds credentials to send email
        SmtpSender sender = new SmtpSender(() => new SmtpClient(host: "Smtp.gmail.com", 587)
        {
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("easypay0710@gmail.com", "P@55ward"),
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
        });
        
               
        //Builds initial order email and sends it
        public void SendEmail()
        {
            sender.Send(Email
                .From(emailAddress: "noReply@noReply.com")
                .To(emailAddress: recepient.Email, name: recepient.Last_Name + ", " + recepient.First_Name)
                .Subject(subject: "Service Invoice")
                .Body(body: "This is an email to inform you of a requested payment from Company A \n" + body)
               );
        }

        //Builds reminderemail and sends it
        public void SendReminder()
        {
            sender.Send(Email
                .From(emailAddress: "noReply@noReply.com")
                .To(emailAddress: recepient.Email, name: recepient.Last_Name + ", " + recepient.First_Name)
                .Subject(subject: "Payment Reminder")
                .Body(body: "This is to remind you of a requested payment from Company A \n" +
                " Please contact a representative for more details\n")
               );
        }
    }
}
