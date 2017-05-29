using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motivation
{
    /// <summary>
    /// MyPanel
    /// </summary>
    public partial class MyPanel : Panel
    {
        /// <summary>
        /// MyPanel: Autosize, DockStyle.Fill, AutoScroll=true
        /// </summary>
        public MyPanel()
        {
            if (DefaultSetting.AutoSizeEnabled)
            {
                this.AutoSize = true;
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
        }
    }
}
