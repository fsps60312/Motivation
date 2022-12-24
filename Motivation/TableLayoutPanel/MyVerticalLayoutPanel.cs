using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motivation
{
    /// <summary>
    /// MyVerticalLayoutPanel
    /// </summary>
    public partial class MyVerticalLayoutPanel : TableLayoutPanel
    {
        /// <summary>
        /// MyVerticalLayoutPanel: DockStyle.Fill, AutoScroll
        /// </summary>
        public MyVerticalLayoutPanel()
        {
            if (DefaultSetting.AutoSizeEnabled)
            {
                this.AutoSize = true;
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
            this.ControlRemoved += ControlChanged;
            this.ControlAdded += ControlChanged;
        }
        private void ControlChanged(object sender, ControlEventArgs e)
        {
            this.RowStyles.Clear();
            this.RowCount = this.Controls.Count + 1;
            for (int row = 0; row < this.Controls.Count; row++)
            {
                this.RowStyles.Add(new RowStyle(SizeType.AutoSize, 1));
                this.SetCellPosition(this.Controls[row], new TableLayoutPanelCellPosition(0, row));
            }
            this.RowStyles.Add(new RowStyle(SizeType.AutoSize, 1));
        }
    }
}
