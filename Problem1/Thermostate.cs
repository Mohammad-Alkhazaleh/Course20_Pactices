using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course20.TermostateProject
{
    public partial class Thermostate : UserControl
    {
        
        public class ChangeTemperatureEventArgs : EventArgs
        {
            public decimal OldTemp { get; }
            public decimal NewTemp { get; }
            public decimal DiffTemp { get; }
            public ChangeTemperatureEventArgs(decimal oldTemp , decimal newTemp , decimal diffTemp)
            {
                OldTemp = oldTemp;
                NewTemp= newTemp;
                DiffTemp = diffTemp;
            }
        }
        public event EventHandler<ChangeTemperatureEventArgs> OnTemperatureChanged;
        public Thermostate()
        {
            InitializeComponent();
        }

        private static int Counter=0;
        private bool IsTempChanged(decimal Temp1 , decimal Temp2)
        {
            return Temp1 != Temp2;
        }
        private struct Temps
        {
            public decimal Temp1;
            public decimal Temp2;
            public decimal TemproryTemperature;
        }
        private Temps temps;
        private void btnChangeTemp_Click(object sender, EventArgs e)
        {
        
            if (txtbNewTemp.Text==null || txtbNewTemp.Text==string.Empty)
            {
                MessageBox.Show($"Please enter a tempreature in the text box...");
            }
            decimal OldTemp = decimal.Parse(lblOldTemp.Text);
            decimal NewTemp = decimal.Parse(txtbNewTemp.Text);
            if (!IsTempChanged(OldTemp, NewTemp))
            {
                MessageBox.Show($"Tempreature didn't change...");
                return;
            }
           
                lblOldTemp.Text = txtbNewTemp.Text;


           
            decimal DiffTemp = NewTemp- OldTemp;
            OnTemperatureChanged(this,new ChangeTemperatureEventArgs(OldTemp,NewTemp,DiffTemp));
        }
    }
}
