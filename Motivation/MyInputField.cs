using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Motivation
{
    /// <summary>
    /// MyInputField
    /// </summary>
    public partial class MyInputField : MyTableLayoutPanel
    {
        private Dictionary<string, TextBox> textBoxes = new Dictionary<string, TextBox>();
        /// <summary>
        /// MyInputField: Autosize, DockStyle.Fill, Font
        /// </summary>
        public MyInputField():base(0,2,null,"AP")
        {
        }
        /// <summary>
        /// Add a field
        /// </summary>
        /// <param name="name">field name</param>
        /// <param name="text">field text</param>
        public TextBox AddField(string name,string text="")
        {
            Debug.Assert(!textBoxes.ContainsKey(name));
            this.RowCount++;
            this.RowStyles.Add(new RowStyle(SizeType.AutoSize, 1));
            {
                MyLabel label = new MyLabel(name + ":");
                this.AddControl(label, this.RowCount - 1, 0);
            }
            {
                MyTextBox txb = new MyTextBox(false,text);
                textBoxes[name] = txb;
                txb.Multiline = false;
                this.AddControl(txb, this.RowCount - 1, 1);
                return txb;
            }
        }
        /// <summary>
        /// Get specific field text
        /// </summary>
        /// <param name="name">field name</param>
        public string GetField(string name)
        {
            return GetTextBox(name).Text;
        }
        /// <summary>
        /// Get specific text box
        /// </summary>
        /// <param name="name">field name</param>
        public TextBox GetTextBox(string name)
        {
            Debug.Assert(textBoxes.ContainsKey(name));
            return textBoxes[name];
        }
    }
}
