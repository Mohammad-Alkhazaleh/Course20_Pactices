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
    public partial class ucBattryTracker : UserControl
    {
        public ucBattryTracker()
        {
            InitializeComponent();
        }
        public class BatteryChangedEventArgs : EventArgs
        {
            public int BatteryCharge { get; }
            public BatteryChangedEventArgs(int batteryCharge)
            {
                BatteryCharge = batteryCharge;
            }
        }
        public event EventHandler<BatteryChangedEventArgs> OnLowBatteryCharge;
        public event Action<int> OnBatteryChargeChanged;

        private void tbBattery_Scroll(object sender, EventArgs e)
        {
            if (tbBattery.Value==20 || tbBattery.Value == 1)
            {
                OnLowBatteryCharge(this,new BatteryChangedEventArgs(tbBattery.Value));
            }
            OnBatteryChargeChanged(tbBattery.Value);
        }
    }
}
