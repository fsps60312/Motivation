using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motivation
{
    /// <summary>
    /// MyButton
    /// </summary>
    public partial class MyButton : Button
    {
        /// <summary>
        /// MyButton: Autosize, DockStyle.Fill, Text, Font
        /// </summary>
        public MyButton(string text)
        {
            if (DefaultSetting.AutoSizeEnabled)
            {
                this.AutoSize = true;
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
            this.Dock = DockStyle.Fill;
            this.Text = text;
            this.Font = DefaultSetting.Font;
        }
    }
}
