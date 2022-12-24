using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Motivation
{
    /// <summary>
    /// MyTableLayoutPanel
    /// </summary>
    public partial class MyTableLayoutPanel : TableLayoutPanel
    {
        /// <summary>
        /// return the TableLayoutPanel you want :)
        /// </summary>
        /// <param name="columnCount"></param>
        /// <param name="rowCount"></param>
        /// <param name="columnStyles">
        /// null to let it unchanged<para/>
        /// format: "%S" or "%S[%s]%S", "%S[%s]%S"'s "%s"'s duplication must be 1<para/>
        /// %s: "%t" or "%t%d" or "%t%d%%%d" (type, width (default: 1), duplication (default: 1) )<para/>
        /// %t: "S"(Absolute), "A"(AutoSize), or "P"(Percent)<para/>
        /// %S: concatenation of "%s"<para/>
        /// </param>
        /// <param name="rowStyles">
        /// null to let it unchanged<para/>
        /// format: "%S" or "%S[%s]%S", "%S[%s]%S"'s "%s"'s duplication must be 1<para/>
        /// %s: "%t" or "%t%d" or "%t%d%%%d" (type, height (default: 1), duplication (default: 1) )<para/>
        /// %t: "S"(Absolute), "A"(AutoSize), or "P"(Percent)<para/>
        /// %S: concatenation of "%s"<para/>
        /// </param>
        /// <returns>The TableLayoutPanel you want :)</returns>
        public MyTableLayoutPanel(int columnCount, int rowCount, string columnStyles,  string rowStyles)
        {
            if (DefaultSetting.AutoSizeEnabled)
            {
                this.AutoSize = true;
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
            this.RowCount = rowCount;
            this.ColumnCount = columnCount;
            if (rowStyles != null)
            {
                foreach (var v in MyTableLayoutPanelMethods.ToStyleList(rowStyles, this.RowCount)) this.RowStyles.Add(new RowStyle(v.Item1, v.Item2));
            }
            if (columnStyles != null)
            {
                foreach (var v in MyTableLayoutPanelMethods.ToStyleList(columnStyles, this.ColumnCount)) this.ColumnStyles.Add(new ColumnStyle(v.Item1, v.Item2));
            }
        }
    }
}