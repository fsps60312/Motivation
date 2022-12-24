using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motivation
{
    /// <summary>
    /// VerticalLayoutPanel
    /// </summary>
    public partial class VerticalLayoutPanel:FlowLayoutPanel
    {
        /// <summary>
        /// VerticalLayoutPanel: DockStyle.Fill, AutoScroll
        /// </summary>
        public VerticalLayoutPanel()
        {
            if (DefaultSetting.AutoSizeEnabled)
            {
                this.AutoSize = true;
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
            this.FlowDirection = FlowDirection.TopDown;
            this.WrapContents = false;
            this.ControlAdded += delegate (object sender, ControlEventArgs e)
            {
                e.Control.Dock = DockStyle.None;
            };
        }
    }
}
