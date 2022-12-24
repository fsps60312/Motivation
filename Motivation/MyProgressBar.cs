using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motivation
{
    /// <summary>
    /// MyProgressBar
    /// </summary>
    public partial class MyProgressBar:ProgressBar
    {
        /// <summary>
        /// MyProgressBar: DockStyle.Fill
        /// </summary>
        public MyProgressBar()
        {
            this.Dock = DockStyle.Fill;
        }
    }
}
