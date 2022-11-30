using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WFMediaControl.Global;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading;

namespace WFMediaControl
{
   
    public partial class frmMain : Form
    {

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        public string _url = "http://localhost:46470/controlHub";
        public HubConnection hubConection;
        public frmMain()
        {
            InitializeComponent();
            hubConection = new HubConnectionBuilder().WithUrl(_url).Build();
            hubConection.Closed += async (error) =>
            {
                MessageBox.Show(error.Message);
                Thread.Sleep(2000);
                await hubConection.StartAsync();
            };
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                await hubConection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            hubConection.On<int>("MediaAction", (int action) => {
                keybd_event(MediaAction.GetValue((eMediaAction)action),0,ActionHex.KEYEVENTF_EXTENTEDKEY,IntPtr.Zero);
            });
        }

   
    }
}
