using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motivation
{
    /// <summary>
    /// MyTabControl
    /// </summary>
    public partial class MyTabControl:TabControl
    {
        /// <summary>
        /// MyTabControl: DockStyle.Fill, Font
        /// </summary>
        public MyTabControl()
        {
            this.Dock = DockStyle.Fill;
            this.Font = DefaultSetting.Font;
        }
    }
}
