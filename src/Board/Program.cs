using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Board
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> list = new HashSet<int>();

            list.Add(1);
            list.Add(1);
            list.Add(1);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        static string TakeLongTime()
        {
            Thread.Sleep(3000);
            return "...";
        }

        static void SendEmail()
        {
            var client = new SmtpClient("smtp.mxhichina.com", 25);

            client.EnableSsl = false;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("service01@chemmerce.com", "2015Chem");

            var from = new MailAddress("service01@chemmerce.com", "化商网");
            var to = new MailAddress("346994217@qq.com");

            var email = new MailMessage(from, to);
            email.Body = "<a href=\"javascript:;\">http://www.chemmerce.com?param1=1&param2=2</a>";
            email.BodyEncoding = Encoding.UTF8;
            client.Send(email);
        }
    }
}
