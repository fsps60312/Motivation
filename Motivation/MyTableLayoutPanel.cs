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
    /// MyTableLayoutPanel
    /// </summary>
    public partial class MyTableLayoutPanel : TableLayoutPanel
    {
        /// <summary>
        /// Add Control into MyTableLayoutPanel
        /// </summary>
        public void AddControl(Control c, int row, int column)
        {
            this.Controls.Add(c);
            this.SetCellPosition(c, new TableLayoutPanelCellPosition(column, row));
        }
        /// <summary>
        /// return the TableLayoutPanel you want :)
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="columnCount"></param>
        /// <param name="rowStyles">
        /// null to let it unchanged<para/>
        /// format: "%S" or "%S[%s]%S", "%S[%s]%S"'s "%s"'s duplication must be 1<para/>
        /// %s: "%t" or "%t%d" or "%t%d%%%d" (type, height (default: 1), duplication (default: 1) )<para/>
        /// %t: "S"(Absolute), "A"(AutoSize), or "P"(Percent)<para/>
        /// %S: concatenation of "%s"<para/>
        /// </param>
        /// <param name="columnStyles">
        /// null to let it unchanged<para/>
        /// format: "%S" or "%S[%s]%S", "%S[%s]%S"'s "%s"'s duplication must be 1<para/>
        /// %s: "%t" or "%t%d" or "%t%d%%%d" (type, width (default: 1), duplication (default: 1) )<para/>
        /// %t: "S"(Absolute), "A"(AutoSize), or "P"(Percent)<para/>
        /// %S: concatenation of "%s"<para/>
        /// </param>
        /// <returns>The TableLayoutPanel you want :)</returns>
        public MyTableLayoutPanel(int rowCount, int columnCount, string rowStyles, string columnStyles)
        {
            if (DefaultSetting.AutoSizeEnabled)
            {
                this.AutoSize = true;
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
            this.Dock = DockStyle.Fill;
            this.RowCount = rowCount;
            this.ColumnCount = columnCount;
            var seperateString = new Func<string, Tuple<SizeType, float, int>>((string s) =>
            {
                var item1 = default(SizeType);
                var item2 = (float)1;
                var item3 = (int)1;
                Debug.Assert(s.Length >= 1);
                switch (s[0])
                {
                    case 'S': item1 = SizeType.Absolute; break;
                    case 'A': item1 = SizeType.AutoSize; break;
                    case 'P': item1 = SizeType.Percent; break;
                    default: Debug.Assert(false, string.Format("Invalid prefix {0}", s[0])); break;
                }
                s = s.Substring(1);
                if (!string.IsNullOrEmpty(s))
                {
                    string[] sa = s.Split('%');
                    Debug.Assert(sa.Length <= 2);
                    if (sa.Length >= 1) Debug.Assert(float.TryParse(sa[0], out item2));
                    if (sa.Length >= 2) Debug.Assert(int.TryParse(sa[1], out item3));
                }
                return new Tuple<SizeType, float, int>(item1, item2, item3);
            });
            var createStyleList = new Func<string, List<Tuple<SizeType, float>>>((string s) =>
            {
                var ans = new List<Tuple<SizeType, float>>();
                for (int i = 0, j; i < s.Length; i = j)
                {
                    j = i + 1;
                    while (j < s.Length && s[j] != 'S' && s[j] != 'A' && s[j] != 'P') ++j;
                    var v = seperateString(s.Substring(i, j - i));
                    for (int k = 0; k < v.Item3; k++) ans.Add(new Tuple<SizeType, float>(v.Item1, v.Item2));
                }
                return ans;
            });
            var createFullStyleList = new Func<string, int, List<Tuple<SizeType, float>>>((string s, int n) =>
            {
                var ls = new List<Tuple<SizeType, float>>();
                if (s.IndexOf('[') == -1) ls = createStyleList(s);
                else
                {
                    int i1 = s.LastIndexOf('['), i2 = s.IndexOf(']');
                    Debug.Assert(i1 < i2);
                    var ls1 = createStyleList(s.Substring(0, i1));
                    var ls2 = createStyleList(s.Substring(i1 + 1, i2 - i1 - 1));
                    var ls3 = createStyleList(s.Substring(i2 + 1, s.Length - i2 - 1));
                    Debug.Assert(ls2.Count == 1);
                    while (ls1.Count + ls3.Count < n) ls1.Add(ls2[0]);
                    ls1.Concat(ls3);
                }
                Debug.Assert(ls.Count == n, string.Format("ls.Count={0}, n={1}", ls.Count, n));
                return ls;
            });
            if (rowStyles != null)
            {
                foreach (var v in createFullStyleList(rowStyles, this.RowCount)) this.RowStyles.Add(new RowStyle(v.Item1, v.Item2));
            }
            if (columnStyles != null)
            {
                foreach (var v in createFullStyleList(columnStyles, this.ColumnCount)) this.ColumnStyles.Add(new ColumnStyle(v.Item1, v.Item2));
            }
        }
    }
}