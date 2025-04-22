using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course20.BatterySensor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void ucBattryTracker1_OnBatteryChargeChanged(int obj)
        {
             label1.Text = obj.ToString() + "%";
        }

        private void ucBattryTracker1_OnLowBatteryCharge(object sender, ucBattryTracker.BatteryChangedEventArgs e)
        {
            MessageBox.Show($"Batter charge is {e.BatteryCharge.ToString()}%\nDo you want to active safe mode ?");
            
        }
    }
}
