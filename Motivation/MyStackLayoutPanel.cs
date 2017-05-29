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
    public partial class MyStackLayoutPanel:MyTableLayoutPanel
    {
        /// <summary>
        /// Whether the layout is vertical or horizontal
        /// </summary>
        public bool IsVertical { get; private set; }
        /// <summary>
        /// return the TableLayoutPanel you want :)
        /// </summary>
        /// <param name="isVertical"></param>
        /// <param name="stackCount"></param>
        /// <param name="stackStyles">
        /// null to let it unchanged<para/>
        /// format: "%S" or "%S[%s]%S", "%S[%s]%S"'s "%s"'s duplication must be 1<para/>
        /// %s: "%t" or "%t%d" or "%t%d%%%d" (type, width (default: 1), duplication (default: 1) )<para/>
        /// %t: "S"(Absolute), "A"(AutoSize), or "P"(Percent)<para/>
        /// %S: concatenation of "%s"<para/>
        /// </param>
        /// <returns>The TableLayoutPanel you want :)</returns>
        public MyStackLayoutPanel(bool isVertical,int stackCount,string stackStyles):base(
            isVertical?stackCount:1,
            isVertical?1:stackCount,
            isVertical ? stackStyles : null,
            isVertical ? null: stackStyles)
        {
        }
        /// <summary>
        /// Add Control into MyStackLayoutPanel
        /// </summary>
        public void AddControl(Control c, int position)
        {
            this.Controls.Add(c);
            this.SetCellPosition(c, new TableLayoutPanelCellPosition(IsVertical ? 0 : position, IsVertical ? position : 0));
        }
    }
}
