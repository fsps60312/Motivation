using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motivation
{
    /// <summary>
    /// MyStackLayoutPanel
    /// </summary>
    public partial class MyStackLayoutPanel:TableLayoutPanel
    {
        /// <summary>
        /// Whether the layout is vertical or horizontal
        /// </summary>
        public bool IsVertical { get; private set; }
        /// <summary>
        /// return the TableLayoutPanel you want :)
        /// </summary>
        /// <param name="isVertical"></param>
        /// <param name="count"></param>
        /// <param name="styles">
        /// null to let it unchanged<para/>
        /// format: "%S" or "%S[%s]%S", "%S[%s]%S"'s "%s"'s duplication must be 1<para/>
        /// %s: "%t" or "%t%d" or "%t%d%%%d" (type, width (default: 1), duplication (default: 1) )<para/>
        /// %t: "S"(Absolute), "A"(AutoSize), or "P"(Percent)<para/>
        /// %S: concatenation of "%s"<para/>
        /// </param>
        /// <returns>The TableLayoutPanel you want :)</returns>
        public MyStackLayoutPanel(bool isVertical,int count,string styles)
        {
            IsVertical = isVertical;
            if (DefaultSetting.AutoSizeEnabled)
            {
                this.AutoSize = true;
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
            if (IsVertical)
            {
                this.RowCount = count;
                if (styles != null)
                {
                    foreach (var v in MyTableLayoutPanelMethods.ToStyleList(styles, this.RowCount)) this.RowStyles.Add(new RowStyle(v.Item1, v.Item2));
                }
            }
            else
            {
                this.ColumnCount = count;
                if (styles != null)
                {
                    foreach (var v in MyTableLayoutPanelMethods.ToStyleList(styles, this.ColumnCount)) this.ColumnStyles.Add(new ColumnStyle(v.Item1, v.Item2));
                }
            }
        }
        /// <summary>
        /// Add Control into MyStackLayoutPanel
        /// </summary>
        public void AddControl(Control c, int position)
        {
            this.Controls.Add(c, IsVertical ? 0 : position, IsVertical ? position : 0);
        }
    }
}
