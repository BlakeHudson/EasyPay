﻿using System;
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
       
        SmtpSender sender = new SmtpSender(() => new SmtpClient(host: "Smtp.gmail.com")
        {
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("easypay0710@gmail.com", "P@55ward"),
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
        });
        
               

        public void SendEmail()
        {
            sender.Send(Email
                .From(emailAddress: "noReply@noReply.com")
                .To(emailAddress: recepient.Email, name: recepient.Name)
                .Subject(subject: "Service Invoice")
                .Body(body: "This is an email to inform you of a requested payment from Company A")
               );
        }
    }
}