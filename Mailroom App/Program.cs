using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mailroom_App
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MailroomForm()); 
        }
    }
 }













































































namespace Mailroom_App
{
    public partial class MailroomForm : Form
    {
        //Show a Version Info message box when you click the secret info box button.
        //All info displayed in the box is dynamically grabbed from the Application Properties.
        private void secretInfoBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Application.ProductName + Environment.NewLine + "Version " + Application.ProductVersion + Environment.NewLine + Environment.NewLine + "Developed by " + Application.CompanyName + Environment.NewLine, Application.ProductName + " Information", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        /* Show the classic FizzBuzz puzzle results from 0 to limit!
         * 
         * This is just a simple test to ensure everything is working,
         * including clicking on elements, showing MessageBoxes correctly,
         * and doing basic math operations :D */
        private void secretFizzBuzzBox_Click(object sender, EventArgs e)
        {
            int limit = 100;
            string output = "FizzBuzz, limit " + limit.ToString() + ":\n\n0";
            for (int i = 1; i < limit; i++)
            {
                if ((i % 3) == 0 && (i % 5) == 0)
                {
                    output += ", FizzBuzz";
                }
                else if ((i % 3) == 0)
                {
                    output += ", Fizz";
                }
                else if ((i % 5) == 0)
                {
                    output += ", Buzz";
                }
                else
                {
                    output += ", " + i;
                }
            }
            MessageBox.Show(output, "FizzBuzz!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
