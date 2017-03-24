using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace DWGui
{
    public partial class Form1 : Form
    {

        DebugWire.DebugWire dw;

        public Form1()
        {
            InitializeComponent();
        }

        private void combo_ports_Click(object sender, EventArgs e)
        { 
            foreach(string port in SerialPort.GetPortNames())
            {
                combo_ports.Items.Add(port);
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            dw = new DebugWire.DebugWire(combo_ports.SelectedItem.ToString(), 1200000);
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            dw.halt();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            dw.resume();
        }

        private async void btn_signature_Click(object sender, EventArgs e)
        {
            var r = await dw.getSignature();
            MessageBox.Show("The fuse bytes are " + r);
            MessageBox.Show("So it is a " + r.Name);
        }
    }
}
