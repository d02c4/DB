using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule.Forms
{
    public partial class TeacherElement : UserControl
    {
        public TeacherElement()
        {
            InitializeComponent();
        }

        public void SetText(string str)
        {
            label1.Text = str;
        }
        private void TeacherElement_Load(object sender, EventArgs e)
        {

        }
    }
}
