using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace RoundMouseChecker
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

        }

        private void roundMouseContainer_onRoundMouse(object sender, EventArgs e)
        {
            MessageBox.Show("Hey, you've drawn a circle!");
        }
    }
}
