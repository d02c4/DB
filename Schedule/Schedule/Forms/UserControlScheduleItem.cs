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
    public partial class UserControlScheduleItem : UserControl
    {
        public UserControlScheduleItem()
        {
            InitializeComponent();
        }

        private void UserControlScheduleItem_Load(object sender, EventArgs e)
        {

        }


        public void SetDataText(string str)
        {
            lbData.Text = str;
        }
    }
}
