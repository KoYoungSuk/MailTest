using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MailTest
{
    class Global
    {

        public void errormessage(String message)
        {
            MessageBox.Show(message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void informationmessage(String message)
        {
            MessageBox.Show(message, "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
