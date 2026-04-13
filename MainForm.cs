using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeepAwakeApp
{
    public partial class MainForm : Form
    {
        private System.Timers.Timer activityTimer;
        private System.Timers.Timer shutdownTimer;

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);
        private int TimeTicked = 60;
        private bool LocationEnable = false;
        private bool ScrollEnable = false;
        private bool ClickEnable = false;
        private bool MouseMoveEnable = true;
        private static uint ScrollDirection = NativeInput.WHEEL_DELTA;

        private void InitContextMenu()
        {
            menu = new ContextMenu();
            openMI = new MenuItem
            {
                Text = "&Open",
                DefaultItem = true
            };
            openMI.Click += (obj, e) => ShowWindow();
            sepMI = new MenuItem
            {
                Text = "-"
            };
            exitMI = new MenuItem
            {
                Text = "E&xit"
            };
            exitMI.Click += (obj, e) => Application.Exit();
            menu.MenuItems.AddRange(new MenuItem [] { openMI, sepMI, exitMI });
            notifyIcon1.ContextMenu = menu;
        }

        public MainForm()
        {
            InitializeComponent();
            InitContextMenu();
            notifyIcon1.Visible = true;

            activityTimer = new System.Timers.Timer(TimeTicked * 1000);
            activityTimer.Elapsed += (source, e) =>
            {
                MoveLocation();
                ScrollSlightUp();
                LeftClick();
                NudgeMouse();
            };
            activityTimer.AutoReset = true;
            activityTimer.Enabled = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ckbLocation.Checked = LocationEnable;
            ckbClick.Checked = ClickEnable;
            ckbMouseMove.Checked = MouseMoveEnable;
            ckbScroll.Checked = ScrollEnable;
        }

        private void ScrollSlightUp()
        {
            if (!ScrollEnable) return;
            var input = new NativeInput.INPUT
            {
                type = NativeInput.INPUT_MOUSE,
                mi = new NativeInput.MOUSEINPUT
                {
                    dx = 0,
                    dy = 0,
                    mouseData = ScrollDirection, // +120 scroll up
                    dwFlags = NativeInput.MOUSEEVENTF_WHEEL,
                    time = 0,
                    dwExtraInfo = IntPtr.Zero
                }
            };

            var inputs = new[] { input };
            NativeInput.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(NativeInput.INPUT)));
            ScrollDirection = (uint)-ScrollDirection;
        }

        private void MoveLocation()
        {
            if (!LocationEnable) return;
            var x = int.Parse(tbX.Text);
            var y = int.Parse(tbY.Text);

            Cursor.Position = new System.Drawing.Point(x, y);
        }

        private void LeftClick()
        {
            if (!ClickEnable) return;
            var down = new NativeInput.INPUT
            {
                type = NativeInput.INPUT_MOUSE,
                mi = new NativeInput.MOUSEINPUT
                {
                    dwFlags = NativeInput.MOUSEEVENTF_LEFTDOWN
                }
            };

            var up = new NativeInput.INPUT
            {
                type = NativeInput.INPUT_MOUSE,
                mi = new NativeInput.MOUSEINPUT
                {
                    dwFlags = NativeInput.MOUSEEVENTF_LEFTUP
                }
            };

            var inputs = new[] { down, up };
            NativeInput.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(NativeInput.INPUT)));
        }

        private void NudgeMouse()
        {
            if (!MouseMoveEnable) return;
            // Move +1 pixel
            var moveRight = new NativeInput.INPUT
            {
                type = NativeInput.INPUT_MOUSE,
                mi = new NativeInput.MOUSEINPUT
                {
                    dx = 1,
                    dy = 0,
                    dwFlags = NativeInput.MOUSEEVENTF_MOVE
                }
            };
            // Move -1 pixel
            var moveLeft = new NativeInput.INPUT
            {
                type = NativeInput.INPUT_MOUSE,
                mi = new NativeInput.MOUSEINPUT
                {
                    dx = -1,
                    dy = 0,
                    dwFlags = NativeInput.MOUSEEVENTF_MOVE
                }
            };

            var inputs = new[] { moveRight, moveLeft };
            NativeInput.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(NativeInput.INPUT)));
        }

        private void ShowWindow()
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Show();
        }

        public void NotifyAlreadyRunning()
        {
            if (IsDisposed)
            {
                return;
            }

            if (InvokeRequired)
            {
                BeginInvoke((Action)NotifyAlreadyRunning);
                return;
            }

            notifyIcon1.BalloonTipTitle = "KeepAwakeApp";
            notifyIcon1.BalloonTipText = "Application is already running.";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
            notifyIcon1.ShowBalloonTip(3000);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowWindow();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TimeTicked = (int)nudTick.Value;
            LocationEnable = ckbLocation.Checked;
            ScrollEnable = ckbScroll.Checked;
            ClickEnable = ckbClick.Checked;
            MouseMoveEnable = ckbMouseMove.Checked;
            activityTimer.Enabled = false;
            activityTimer.Stop();
            activityTimer.Start();
            activityTimer.Enabled = true;
            activityTimer.Interval = TimeTicked * 1000;
            if (ckbShutdown.Checked)
            {
                shutdownTimer = new System.Timers.Timer();
                shutdownTimer.Elapsed += (source, eve) =>
                {
                    Application.Exit();
                };
                shutdownTimer.AutoReset = true;
                shutdownTimer.Start();
                shutdownTimer.Enabled = true;
                var remain = shutdownDTP.Value - DateTime.Now;
                if (remain.TotalSeconds < 0)
                {
                    remain = shutdownDTP.Value.AddDays(1d) - DateTime.Now;
                }
                shutdownTimer.Interval = remain.TotalMilliseconds;
            }
            else if (shutdownTimer.Enabled)
            {
                shutdownTimer.Stop();
                shutdownTimer.Enabled = false;
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ckbLocation_CheckedChanged(object sender, EventArgs e)
        {
            tbX.Enabled = ckbLocation.Checked;
            tbY.Enabled = ckbLocation.Checked;
        }

        private void ckbShutdown_CheckedChanged(object sender, EventArgs e)
        {
            shutdownDTP.Enabled = ckbShutdown.Checked;
        }
    }
}