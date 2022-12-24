using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motivation
{
    /// <summary>
    /// MyHorizontalLayoutPanel
    /// </summary>
    public partial class MyHorizontalLayoutPanel : TableLayoutPanel
    {
        /// <summary>
        /// MyHorizontalLayoutPanel: DockStyle.Fill, AutoScroll
        /// </summary>
        public MyHorizontalLayoutPanel()
        {
            if (DefaultSetting.AutoSizeEnabled)
            {
                this.AutoSize = true;
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
            this.RowCount = 1;
            this.RowStyles.Add(new RowStyle(SizeType.Percent, 1));
            this.ControlRemoved += ControlChanged;
            this.ControlAdded += ControlChanged;
        }
        private void ControlChanged(object sender, ControlEventArgs e)
        {
            this.ColumnStyles.Clear();
            this.ColumnCount = this.Controls.Count + 1;
            for (int column = 0; column < this.Controls.Count; column++)
            {
                this.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 1));
                this.SetCellPosition(this.Controls[column], new TableLayoutPanelCellPosition(column, 0));
            }
            this.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 1));
        }
    }
}
