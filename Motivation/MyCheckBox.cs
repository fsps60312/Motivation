using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motivation
{
    /// <summary>
    /// MyCheckBox
    /// </summary>
    public partial class MyCheckBox:CheckBox
    {
        /// <summary>
        /// MyCheckBox: Autosize, DockStyle.Fill, Text, Font
        /// </summary>
        public MyCheckBox(string text)
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
