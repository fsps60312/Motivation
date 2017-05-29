using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motivation
{
    /// <summary>
    /// MyLabel
    /// </summary>
    public partial class MyLabel : Label
    {
        /// <summary>
        /// MyLabel: Autosize, DockStyle.Fill, Text, Font
        /// </summary>
        public MyLabel(string text)
        {
            if (DefaultSetting.AutoSizeEnabled)
            {
                this.AutoSize = true;
            }
            this.Dock = DockStyle.Fill;
            this.Text = text;
            this.Font = DefaultSetting.Font;
        }
    }
}
