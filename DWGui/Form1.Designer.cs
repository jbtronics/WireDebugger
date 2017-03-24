namespace DWGui
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.combo_ports = new System.Windows.Forms.ComboBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_signature = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_ss = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numeric_fcpu = new System.Windows.Forms.NumericUpDown();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tab_general = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.check_reset_restart = new System.Windows.Forms.CheckBox();
            this.btn_reset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label_sig_chip = new System.Windows.Forms.Label();
            this.txt_signature = new System.Windows.Forms.TextBox();
            this.label_signature = new System.Windows.Forms.Label();
            this.tab_infos = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_instr_read = new System.Windows.Forms.Button();
            this.btn_instr_write = new System.Windows.Forms.Button();
            this.txt_instr = new System.Windows.Forms.TextBox();
            this.group_hwbp = new System.Windows.Forms.GroupBox();
            this.btn_bp_read = new System.Windows.Forms.Button();
            this.btn_bp_write = new System.Windows.Forms.Button();
            this.txt_BP = new System.Windows.Forms.TextBox();
            this.group_pc = new System.Windows.Forms.GroupBox();
            this.btn_pc_read = new System.Windows.Forms.Button();
            this.btn_pc_write = new System.Windows.Forms.Button();
            this.txt_pc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_fcpu)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tab_general.SuspendLayout();
            this.tab_infos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.group_hwbp.SuspendLayout();
            this.group_pc.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_stop
            // 
            this.btn_stop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_stop.Enabled = false;
            this.btn_stop.Location = new System.Drawing.Point(582, 12);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 0;
            this.btn_stop.Text = "RESUME";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_start
            // 
            this.btn_start.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_start.Enabled = false;
            this.btn_start.Location = new System.Drawing.Point(501, 13);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "BREAK";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // combo_ports
            // 
            this.combo_ports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_ports.FormattingEnabled = true;
            this.combo_ports.Location = new System.Drawing.Point(54, 15);
            this.combo_ports.Name = "combo_ports";
            this.combo_ports.Size = new System.Drawing.Size(117, 21);
            this.combo_ports.TabIndex = 2;
            this.combo_ports.Click += new System.EventHandler(this.combo_ports_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_connect.Location = new System.Drawing.Point(394, 14);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(72, 22);
            this.btn_connect.TabIndex = 3;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_signature
            // 
            this.btn_signature.Location = new System.Drawing.Point(229, 12);
            this.btn_signature.Name = "btn_signature";
            this.btn_signature.Size = new System.Drawing.Size(92, 23);
            this.btn_signature.TabIndex = 5;
            this.btn_signature.Text = " Read Signature";
            this.btn_signature.UseVisualStyleBackColor = true;
            this.btn_signature.Click += new System.EventHandler(this.btn_signature_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(229, 166);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Deactivate DW";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_ss
            // 
            this.btn_ss.Location = new System.Drawing.Point(229, 116);
            this.btn_ss.Name = "btn_ss";
            this.btn_ss.Size = new System.Drawing.Size(92, 23);
            this.btn_ss.TabIndex = 8;
            this.btn_ss.Text = "Single Step";
            this.btn_ss.UseVisualStyleBackColor = true;
            this.btn_ss.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Serial:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Target F_CPU (Hz):";
            // 
            // numeric_fcpu
            // 
            this.numeric_fcpu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numeric_fcpu.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numeric_fcpu.Location = new System.Drawing.Point(300, 16);
            this.numeric_fcpu.Maximum = new decimal(new int[] {
            60000000,
            0,
            0,
            0});
            this.numeric_fcpu.Name = "numeric_fcpu";
            this.numeric_fcpu.Size = new System.Drawing.Size(78, 20);
            this.numeric_fcpu.TabIndex = 11;
            this.numeric_fcpu.Value = new decimal(new int[] {
            1200000,
            0,
            0,
            0});
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tab_general);
            this.tabControl.Controls.Add(this.tab_infos);
            this.tabControl.Enabled = false;
            this.tabControl.Location = new System.Drawing.Point(12, 42);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(645, 316);
            this.tabControl.TabIndex = 12;
            // 
            // tab_general
            // 
            this.tab_general.Controls.Add(this.label6);
            this.tab_general.Controls.Add(this.label5);
            this.tab_general.Controls.Add(this.label4);
            this.tab_general.Controls.Add(this.check_reset_restart);
            this.tab_general.Controls.Add(this.btn_reset);
            this.tab_general.Controls.Add(this.label3);
            this.tab_general.Controls.Add(this.label_sig_chip);
            this.tab_general.Controls.Add(this.txt_signature);
            this.tab_general.Controls.Add(this.label_signature);
            this.tab_general.Controls.Add(this.btn_signature);
            this.tab_general.Controls.Add(this.btn_ss);
            this.tab_general.Controls.Add(this.button2);
            this.tab_general.Location = new System.Drawing.Point(4, 22);
            this.tab_general.Name = "tab_general";
            this.tab_general.Padding = new System.Windows.Forms.Padding(3);
            this.tab_general.Size = new System.Drawing.Size(637, 290);
            this.tab_general.TabIndex = 0;
            this.tab_general.Text = "General";
            this.tab_general.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(349, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(257, 39);
            this.label6.TabIndex = 17;
            this.label6.Text = "Note: After DW was deactivated you can reflash the \r\ntarget via ISP again, but if" +
    " you want to use DW \r\nagain you has to recycle power!\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Deactivate Debugwire:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Single Step:";
            // 
            // check_reset_restart
            // 
            this.check_reset_restart.AutoSize = true;
            this.check_reset_restart.Checked = true;
            this.check_reset_restart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_reset_restart.Location = new System.Drawing.Point(352, 72);
            this.check_reset_restart.Name = "check_reset_restart";
            this.check_reset_restart.Size = new System.Drawing.Size(121, 17);
            this.check_reset_restart.TabIndex = 14;
            this.check_reset_restart.Text = "Restart after Reset?";
            this.check_reset_restart.UseVisualStyleBackColor = true;
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(229, 68);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(92, 23);
            this.btn_reset.TabIndex = 13;
            this.btn_reset.Text = "Reset Target";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Reset target:";
            // 
            // label_sig_chip
            // 
            this.label_sig_chip.AutoSize = true;
            this.label_sig_chip.Location = new System.Drawing.Point(349, 17);
            this.label_sig_chip.Name = "label_sig_chip";
            this.label_sig_chip.Size = new System.Drawing.Size(31, 13);
            this.label_sig_chip.TabIndex = 11;
            this.label_sig_chip.Text = "Chip:";
            // 
            // txt_signature
            // 
            this.txt_signature.Location = new System.Drawing.Point(112, 14);
            this.txt_signature.Name = "txt_signature";
            this.txt_signature.ReadOnly = true;
            this.txt_signature.Size = new System.Drawing.Size(100, 20);
            this.txt_signature.TabIndex = 10;
            // 
            // label_signature
            // 
            this.label_signature.AutoSize = true;
            this.label_signature.Location = new System.Drawing.Point(35, 17);
            this.label_signature.Name = "label_signature";
            this.label_signature.Size = new System.Drawing.Size(55, 13);
            this.label_signature.TabIndex = 9;
            this.label_signature.Text = "Signature:";
            // 
            // tab_infos
            // 
            this.tab_infos.Controls.Add(this.groupBox1);
            this.tab_infos.Controls.Add(this.group_hwbp);
            this.tab_infos.Controls.Add(this.group_pc);
            this.tab_infos.Location = new System.Drawing.Point(4, 22);
            this.tab_infos.Name = "tab_infos";
            this.tab_infos.Padding = new System.Windows.Forms.Padding(3);
            this.tab_infos.Size = new System.Drawing.Size(637, 290);
            this.tab_infos.TabIndex = 1;
            this.tab_infos.Text = "Data";
            this.tab_infos.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_instr_read);
            this.groupBox1.Controls.Add(this.btn_instr_write);
            this.groupBox1.Controls.Add(this.txt_instr);
            this.groupBox1.Location = new System.Drawing.Point(6, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 50);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instruction";
            // 
            // btn_instr_read
            // 
            this.btn_instr_read.Location = new System.Drawing.Point(175, 17);
            this.btn_instr_read.Name = "btn_instr_read";
            this.btn_instr_read.Size = new System.Drawing.Size(75, 23);
            this.btn_instr_read.TabIndex = 7;
            this.btn_instr_read.Text = "Read Instr.";
            this.btn_instr_read.UseVisualStyleBackColor = true;
            this.btn_instr_read.Click += new System.EventHandler(this.btn_instr_read_Click);
            // 
            // btn_instr_write
            // 
            this.btn_instr_write.Location = new System.Drawing.Point(278, 17);
            this.btn_instr_write.Name = "btn_instr_write";
            this.btn_instr_write.Size = new System.Drawing.Size(75, 23);
            this.btn_instr_write.TabIndex = 1;
            this.btn_instr_write.Text = "Run Instr.";
            this.btn_instr_write.UseVisualStyleBackColor = true;
            this.btn_instr_write.Click += new System.EventHandler(this.btn_instr_write_Click);
            // 
            // txt_instr
            // 
            this.txt_instr.Location = new System.Drawing.Point(6, 19);
            this.txt_instr.Name = "txt_instr";
            this.txt_instr.Size = new System.Drawing.Size(143, 20);
            this.txt_instr.TabIndex = 0;
            // 
            // group_hwbp
            // 
            this.group_hwbp.Controls.Add(this.btn_bp_read);
            this.group_hwbp.Controls.Add(this.btn_bp_write);
            this.group_hwbp.Controls.Add(this.txt_BP);
            this.group_hwbp.Location = new System.Drawing.Point(6, 62);
            this.group_hwbp.Name = "group_hwbp";
            this.group_hwbp.Size = new System.Drawing.Size(625, 50);
            this.group_hwbp.TabIndex = 1;
            this.group_hwbp.TabStop = false;
            this.group_hwbp.Text = "Hardware Breakpoint";
            // 
            // btn_bp_read
            // 
            this.btn_bp_read.Location = new System.Drawing.Point(175, 17);
            this.btn_bp_read.Name = "btn_bp_read";
            this.btn_bp_read.Size = new System.Drawing.Size(75, 23);
            this.btn_bp_read.TabIndex = 7;
            this.btn_bp_read.Text = "Read BP";
            this.btn_bp_read.UseVisualStyleBackColor = true;
            this.btn_bp_read.Click += new System.EventHandler(this.btn_bp_read_Click);
            // 
            // btn_bp_write
            // 
            this.btn_bp_write.Location = new System.Drawing.Point(278, 17);
            this.btn_bp_write.Name = "btn_bp_write";
            this.btn_bp_write.Size = new System.Drawing.Size(75, 23);
            this.btn_bp_write.TabIndex = 1;
            this.btn_bp_write.Text = "Write BP";
            this.btn_bp_write.UseVisualStyleBackColor = true;
            this.btn_bp_write.Click += new System.EventHandler(this.btn_bp_write_Click);
            // 
            // txt_BP
            // 
            this.txt_BP.Location = new System.Drawing.Point(6, 19);
            this.txt_BP.Name = "txt_BP";
            this.txt_BP.Size = new System.Drawing.Size(143, 20);
            this.txt_BP.TabIndex = 0;
            // 
            // group_pc
            // 
            this.group_pc.Controls.Add(this.btn_pc_read);
            this.group_pc.Controls.Add(this.btn_pc_write);
            this.group_pc.Controls.Add(this.txt_pc);
            this.group_pc.Location = new System.Drawing.Point(6, 6);
            this.group_pc.Name = "group_pc";
            this.group_pc.Size = new System.Drawing.Size(625, 50);
            this.group_pc.TabIndex = 0;
            this.group_pc.TabStop = false;
            this.group_pc.Text = "Program Counter";
            // 
            // btn_pc_read
            // 
            this.btn_pc_read.Location = new System.Drawing.Point(175, 17);
            this.btn_pc_read.Name = "btn_pc_read";
            this.btn_pc_read.Size = new System.Drawing.Size(75, 23);
            this.btn_pc_read.TabIndex = 7;
            this.btn_pc_read.Text = "Read PC";
            this.btn_pc_read.UseVisualStyleBackColor = true;
            this.btn_pc_read.Click += new System.EventHandler(this.btn_pc_read_Click);
            // 
            // btn_pc_write
            // 
            this.btn_pc_write.Location = new System.Drawing.Point(278, 17);
            this.btn_pc_write.Name = "btn_pc_write";
            this.btn_pc_write.Size = new System.Drawing.Size(75, 23);
            this.btn_pc_write.TabIndex = 1;
            this.btn_pc_write.Text = "Write PC";
            this.btn_pc_write.UseVisualStyleBackColor = true;
            this.btn_pc_write.Click += new System.EventHandler(this.btn_pc_write_Click);
            // 
            // txt_pc
            // 
            this.txt_pc.Location = new System.Drawing.Point(6, 19);
            this.txt_pc.Name = "txt_pc";
            this.txt_pc.Size = new System.Drawing.Size(143, 20);
            this.txt_pc.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 370);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.numeric_fcpu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.combo_ports);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_stop);
            this.Name = "Form1";
            this.Text = "DebugWire GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numeric_fcpu)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tab_general.ResumeLayout(false);
            this.tab_general.PerformLayout();
            this.tab_infos.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.group_hwbp.ResumeLayout(false);
            this.group_hwbp.PerformLayout();
            this.group_pc.ResumeLayout(false);
            this.group_pc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.ComboBox combo_ports;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_signature;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_ss;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numeric_fcpu;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tab_general;
        private System.Windows.Forms.TabPage tab_infos;
        private System.Windows.Forms.TextBox txt_signature;
        private System.Windows.Forms.Label label_signature;
        private System.Windows.Forms.Label label_sig_chip;
        private System.Windows.Forms.CheckBox check_reset_restart;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox group_pc;
        private System.Windows.Forms.TextBox txt_pc;
        private System.Windows.Forms.Button btn_pc_read;
        private System.Windows.Forms.Button btn_pc_write;
        private System.Windows.Forms.GroupBox group_hwbp;
        private System.Windows.Forms.Button btn_bp_read;
        private System.Windows.Forms.Button btn_bp_write;
        private System.Windows.Forms.TextBox txt_BP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_instr_read;
        private System.Windows.Forms.Button btn_instr_write;
        private System.Windows.Forms.TextBox txt_instr;
    }
}

