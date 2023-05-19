using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using WpfApp2.ViewModels;
using Forms = System.Windows.Forms;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Forms.NotifyIcon _notifyIcon;
        
        public App()
        {
            _notifyIcon = new Forms.NotifyIcon();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            //MainWindow = new MainWindow();
            //MainWindow.Show();

            _notifyIcon.Icon = new System.Drawing.Icon("Resources/BARTtransparent.ico");
            _notifyIcon.Text = "BART Background Process Demo";
            _notifyIcon.Click += NotifyIcon_Click;

            _notifyIcon.ContextMenuStrip = new Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Status",Image.FromFile("Resources/BARTs.ico"), OnStatusClicked);
            _notifyIcon.ContextMenuStrip.Items.Add(new Forms.ToolStripLabel("asdkjwatg"));
            _notifyIcon.ContextMenuStrip.Items.Add(new Forms.ToolStripButton("some button"));
            _notifyIcon.ContextMenuStrip.Items.Add(
                new Forms.ToolStripDropDownButton(
                    "asdasd", null,
                new Forms.ToolStripLabel("eagrn"),
                new Forms.ToolStripLabel("qwerty")
                ));

            MainWindow = new MainWindow();
            MainWindow.DataContext = new NotifyViewModel(_notifyIcon);
            MainWindow.Show();

            _notifyIcon.Visible = true;

            base.OnStartup(e);
        }

        private void _notifyIcon_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)

        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MainWindow.WindowState = WindowState.Normal;
                MainWindow.Activate();
            }
        }

        private void OnStatusClicked(object sender, EventArgs e)
        {
            MessageBox.Show("WMATA Background process is running", "Status", MessageBoxButton.OK);
        }
        private void NotifyIcon_Click (object sender, EventArgs e)
        {

            MainWindow.WindowState = WindowState.Normal;
            MainWindow.Activate();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _notifyIcon.Dispose();

            base.OnExit(e);
        }
    }
}
