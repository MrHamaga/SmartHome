using SonosApi;
using SonosApi.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SonosControl
{
    public partial class Form1 : Form
    {
        SonosClient _sonos;
        public Form1()
        {
            InitializeComponent();

            _sonos = new SonosClient(ConfigurationHelper.GetSonosIp());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _sonos.Play(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _sonos.Pause(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _sonos.Seek(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _sonos.GetPositionInfo(0);
        }
    }
}
