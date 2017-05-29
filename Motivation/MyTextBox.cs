using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motivation
{
    /// <summary>
    /// MyTextBox
    /// </summary>
    public partial class MyTextBox : TextBox
    {
        /// <summary>
        /// MyTextBox: if ScrollBars.Both then (DockStyle.Fill, Multiline=true), WordWrap=false, Font, Text
        /// </summary>
        public MyTextBox(bool scrollbars, string text = null)
        {
            if (scrollbars)
            {
                this.ScrollBars = ScrollBars.Both;
                this.Multiline = true;
            }
            this.Dock = DockStyle.Fill;
            this.WordWrap = false;
            this.Font = DefaultSetting.Font;
            this.Text = text;
        }
    }
}
