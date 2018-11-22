using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompareLoggingCode
{
    public partial class DateSelect : Form
    {
        public DateTime beginDate, endDate;

        private void dateTimePickBegin_ValueChanged(object sender, EventArgs e)
        {
            beginDate = dateTimePickBegin.Value;
            endDate = dateTimePickEnd.Value;
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public DateSelect()
        {
            InitializeComponent();
            beginDate = dateTimePickBegin.Value;
            endDate = dateTimePickEnd.Value;
        }
    }
}
