using HueLightsApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HueLightsControl
{
    public partial class Form1 : Form
    {
        HueRequestHelper _hue;
        bool updateLightsAllowed = true;
        public Form1()
        {
            InitializeComponent();
            //this.color.CellTemplate = new ColoredDataGridViewTextBoxCell();
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);

            _hue = new HueRequestHelper();

            synchronizeLightsGrid.RunWorkerAsync();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var grid = (DataGridView) sender;
            var light =(Light) grid.Rows[e.RowIndex].DataBoundItem;

            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(light.color.Red, light.color.Green, light.color.Blue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _hue.TurnOffAll();
        }

        private void synchronizeLightsGrid_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1000);
            _hue.PopulateLightList();
        }

        private void synchronizeLightsGrid_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (updateLightsAllowed)
            {
                lightBindingSource.DataSource = _hue.Lights;
            }
            synchronizeLightsGrid.RunWorkerAsync();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                updateLightsAllowed = false;

                var buttonColumn = (DataGridViewButtonColumn) senderGrid.Columns[e.ColumnIndex];
                
                if (buttonColumn.Name == "ToggleState")
                {
                    performLightActions.RunWorkerAsync((Light)senderGrid.Rows[e.RowIndex].DataBoundItem);
                }
            }
        }

        private void performLightActions_DoWork(object sender, DoWorkEventArgs e)
        {
            var light = e.Argument as Light;
            if (light.state.on)
            {
                _hue.TurnOff(light);
            }
            else
            {
                _hue.TurnOn(light);
            }
        }

        private void performLightActions_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            updateLightsAllowed = true;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //_hue.SetColor(new Light() {id="4"}, new RgbColor(11,12,13));

            //var light = new Light() { id = "4" };
            //_hue.TurnOn(light);
            //_hue.SetColor(light, new RgbColor(255, 95, 48));
            _hue.PopulateGroupsList();
        }
    }
    //class ColoredDataGridViewTextBoxCell : DataGridViewTextBoxCell
    //{
    //    protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
    //        DataGridViewElementStates cellState, object value, object formattedValue, string errorText,
    //        DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
    //    {
    //        if (value != null)
    //        {
    //            var color = value as RgbColor;
    //                cellStyle.BackColor = Color.FromArgb(color.Red, color.Green, color.Blue);
    //        }
    //        base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value,
    //            formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
    //    }
    //}
}
