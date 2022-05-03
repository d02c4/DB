using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule
{
    public partial class UserNotControlDays : UserControl
    {
        public UserNotControlDays()
        {
            InitializeComponent();
        }

        public void days(int numday)
        {
            lbdays.Text = numday + "";
        }

        private void UserNotControlDays_Load(object sender, EventArgs e)
        {

        }
    }
}
