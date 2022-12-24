using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motivation
{
    /// <summary>
    /// HorizontalLayoutPanel
    /// </summary>
    public partial class HorizontalLayoutPanel:FlowLayoutPanel
    {
        /// <summary>
        /// HorizontalLayoutPanel: DockStyle.Fill, AutoScroll
        /// </summary>
        public HorizontalLayoutPanel()
        {
            if (DefaultSetting.AutoSizeEnabled)
            {
                this.AutoSize = true;
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
            this.FlowDirection = FlowDirection.LeftToRight;
            this.WrapContents = false;
            this.ControlAdded += delegate (object sender, ControlEventArgs e)
            {
                e.Control.Dock = DockStyle.None;
            };
        }
    }
}
