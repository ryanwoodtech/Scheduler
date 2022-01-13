using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    public class Report : Form
    {
        public Report() { }

        public void AppendDateTime(TextBox textBox)
        {
            textBox.AppendText("Report Date:   " + DateTime.Now + ".");
            textBox.AppendText(Environment.NewLine);
            textBox.AppendText(Environment.NewLine);
            textBox.AppendText(Environment.NewLine);
        }
    }
}
