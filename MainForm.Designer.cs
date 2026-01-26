using System.ComponentModel;
using System.Windows.Forms;

namespace KeepAwakeApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            ShowInTaskbar = false;
            e.Cancel = true;
            Hide();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.nudTick = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ckbScroll = new System.Windows.Forms.CheckBox();
            this.ckbClick = new System.Windows.Forms.CheckBox();
            this.ckbMouseMove = new System.Windows.Forms.CheckBox();
            this.ckbLocation = new System.Windows.Forms.CheckBox();
            this.tbX = new KeepAwakeApp.ITextBox();
            this.tbY = new KeepAwakeApp.ITextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudTick)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Keep awake app";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // nudTick
            // 
            this.nudTick.Location = new System.Drawing.Point(68, 13);
            this.nudTick.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudTick.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nudTick.Name = "nudTick";
            this.nudTick.Size = new System.Drawing.Size(140, 22);
            this.nudTick.TabIndex = 0;
            this.nudTick.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tick";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(78, 182);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(209, 182);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ckbScroll
            // 
            this.ckbScroll.AutoSize = true;
            this.ckbScroll.Checked = true;
            this.ckbScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbScroll.Location = new System.Drawing.Point(25, 82);
            this.ckbScroll.Name = "ckbScroll";
            this.ckbScroll.Size = new System.Drawing.Size(92, 18);
            this.ckbScroll.TabIndex = 4;
            this.ckbScroll.Text = "Enable scroll";
            this.ckbScroll.UseVisualStyleBackColor = true;
            // 
            // ckbClick
            // 
            this.ckbClick.AutoSize = true;
            this.ckbClick.Location = new System.Drawing.Point(25, 112);
            this.ckbClick.Name = "ckbClick";
            this.ckbClick.Size = new System.Drawing.Size(110, 18);
            this.ckbClick.TabIndex = 5;
            this.ckbClick.Text = "Enable left click";
            this.ckbClick.UseVisualStyleBackColor = true;
            // 
            // ckbMouseMove
            // 
            this.ckbMouseMove.AutoSize = true;
            this.ckbMouseMove.Checked = true;
            this.ckbMouseMove.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbMouseMove.Location = new System.Drawing.Point(25, 142);
            this.ckbMouseMove.Name = "ckbMouseMove";
            this.ckbMouseMove.Size = new System.Drawing.Size(136, 18);
            this.ckbMouseMove.TabIndex = 6;
            this.ckbMouseMove.Text = "Enable mouse move";
            this.ckbMouseMove.UseVisualStyleBackColor = true;
            // 
            // ckbLocation
            // 
            this.ckbLocation.AutoSize = true;
            this.ckbLocation.Location = new System.Drawing.Point(25, 52);
            this.ckbLocation.Name = "ckbLocation";
            this.ckbLocation.Size = new System.Drawing.Size(117, 18);
            this.ckbLocation.TabIndex = 7;
            this.ckbLocation.Text = "Move to location";
            this.ckbLocation.UseVisualStyleBackColor = true;
            this.ckbLocation.CheckedChanged += new System.EventHandler(this.ckbLocation_CheckedChanged);
            // 
            // tbX
            // 
            this.tbX.AllowTextChanged = true;
            this.tbX.Enabled = false;
            this.tbX.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tbX.ForeColor = System.Drawing.Color.Black;
            this.tbX.Location = new System.Drawing.Point(148, 50);
            this.tbX.Name = "tbX";
            this.tbX.NumberModeOnly = true;
            this.tbX.Size = new System.Drawing.Size(50, 22);
            this.tbX.SuggestText = "1150";
            this.tbX.SuggestType = KeepAwakeApp.SuggestType.PlaceHolder;
            this.tbX.TabIndex = 8;
            // 
            // tbY
            // 
            this.tbY.AllowTextChanged = true;
            this.tbY.Enabled = false;
            this.tbY.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tbY.ForeColor = System.Drawing.Color.Black;
            this.tbY.Location = new System.Drawing.Point(223, 50);
            this.tbY.Name = "tbY";
            this.tbY.NumberModeOnly = true;
            this.tbY.Size = new System.Drawing.Size(50, 22);
            this.tbY.SuggestText = "380";
            this.tbY.SuggestType = KeepAwakeApp.SuggestType.PlaceHolder;
            this.tbY.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 226);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.ckbLocation);
            this.Controls.Add(this.ckbMouseMove);
            this.Controls.Add(this.ckbClick);
            this.Controls.Add(this.ckbScroll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudTick);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "KeepAwakeApp";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudTick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private ContextMenu menu;
        private MenuItem openMI;
        private MenuItem sepMI;
        private MenuItem exitMI;
        #endregion

        private NumericUpDown nudTick;
        private Label label1;
        private Button btnOK;
        private Button btnCancel;
        private CheckBox ckbScroll;
        private CheckBox ckbClick;
        private CheckBox ckbMouseMove;
        private CheckBox ckbLocation;
        private ITextBox tbX;
        private ITextBox tbY;
    }
}

