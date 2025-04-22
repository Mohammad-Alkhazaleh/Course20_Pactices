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
    public partial class Display : Form
    {
        public Display()
        {
            InitializeComponent();
            pictureBox1.Visible = false;
            Subscribe(thermostate1);
        }

        private void thermostate1_OnTemperatureChanged(object sender, Thermostate.ChangeTemperatureEventArgs e)
        {
            MessageBox.Show($"OldTemp : {e.OldTemp}\nNewTemp : {e.NewTemp}\nDiffTemp : {e.DiffTemp}");
        }
        public void Subscribe(Thermostate thermostate)
        {
            thermostate.OnTemperatureChanged += ShowGif;
        }
        private void ShowGif(object sender , Thermostate.ChangeTemperatureEventArgs e)
        {
            pictureBox1.Visible = true;
        }
    }
}
