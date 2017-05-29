using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Motivation
{
    /// <summary>
    /// DefaultSetting
    /// </summary>
    public static class DefaultSetting
    {
        /// <summary>
        /// Whether to enable AutoSize properties for the next control
        /// </summary>
        public static bool AutoSizeEnabled = true;
        /// <summary>
        /// Default English font
        /// </summary>
        public static Font FontE { get { return new Font("Consolas", 12, FontStyle.Bold); } }
        /// <summary>
        /// Default font
        /// </summary>
        public static Font Font { get { return new Font("微軟正黑體", 12, FontStyle.Regular); } }
    }
}
