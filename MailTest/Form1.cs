using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailTest
{
    public partial class Form1 : Form
    {
        Global g = new Global(); 
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String address = textBox1.Text;
            String title = textBox2.Text;
            String content = textBox3.Text;
            String fromaddress = textBox5.Text; 
            String toaddress = textBox4.Text;
            MailAddress fromaddress2 = null;
            MailAddress toaddress2 = null;
            SmtpClient stmp = null;
            MailMessage message = new MailMessage(); 
            try
            {
                fromaddress2 = new MailAddress(fromaddress);
                toaddress2 = new MailAddress(toaddress);
                message.From = fromaddress2;
                message.To.Add(toaddress2);
                message.Subject = title;
                message.Body = content;
                message.SubjectEncoding = Encoding.UTF8;
                message.BodyEncoding = Encoding.UTF8;
                stmp = new SmtpClient
                {
                    Host = address,
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential("ID", "Password"),
                    Timeout = 20000
                };
                stmp.Send(message);
                g.informationmessage("Success!");
                stmp.Dispose();
                message.Dispose();
            }catch(Exception ex)
            {
                g.errormessage(ex.Message);
            }
        }
    }
}
