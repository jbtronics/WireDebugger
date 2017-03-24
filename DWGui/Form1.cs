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

        private void update_ports()
        {
            combo_ports.Items.Clear();
            foreach (string port in SerialPort.GetPortNames())
            {
                combo_ports.Items.Add(port);
            }
        }


        private void combo_ports_Click(object sender, EventArgs e)
        {
            update_ports();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if(dw == null)
            {
                dw = new DebugWire.DebugWire(combo_ports.SelectedItem.ToString(), Convert.ToInt32(numeric_fcpu.Value));
                btn_connect.Text = "Disconnect";
                tabControl.Enabled = true;
                btn_start.Enabled = true;
                btn_stop.Enabled = true;
            }
            
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
            txt_signature.Text = r.ToString();
            label_sig_chip.Text = "Chip: " + r.Name;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            dw.disableDW();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dw.singleStep();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            update_ports();
            if (combo_ports.Items.Count > 0)
                combo_ports.SelectedIndex = 0;
        }

        private async void btn_reset_Click(object sender, EventArgs e)
        {
            await dw.reset(check_reset_restart.Checked);
        }


        private async void btn_pc_read_Click(object sender, EventArgs e)
        {
            var res = await dw.getPC();
            txt_pc.Text = res.ToString();
        }

        private async void btn_bp_read_Click(object sender, EventArgs e)
        {
            var res = await dw.getHWBP();
            txt_BP.Text = res.ToString();
        }

        private async void btn_instr_read_Click(object sender, EventArgs e)
        {
            var res = await dw.getInstruction();
            txt_instr.Text = res.ToString();
        }
    }
}
