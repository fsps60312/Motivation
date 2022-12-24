using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Motivation
{
    class MyTableLayoutPanelMethods
    {
        public static List<Tuple<SizeType, float>>ToStyleList(string styles, int count)
        {
            var ls = new List<Tuple<SizeType, float>>();
            if (styles.IndexOf('[') == -1) ls = CreateStyleList(styles);
            else
            {
                int i1 = styles.LastIndexOf('['), i2 = styles.IndexOf(']');
                Trace.Assert(i1 < i2);
                var ls1 = CreateStyleList(styles.Substring(0, i1));
                var ls2 = CreateStyleList(styles.Substring(i1 + 1, i2 - i1 - 1));
                var ls3 = CreateStyleList(styles.Substring(i2 + 1, styles.Length - i2 - 1));
                Trace.Assert(ls2.Count == 1);
                while (ls1.Count + ls3.Count < count) ls1.Add(ls2[0]);
                ls1.Concat(ls3);
            }
            Trace.Assert(ls.Count == count, string.Format("ls.Count={0}, n={1}", ls.Count, count));
            return ls;
        }
        private static List<Tuple<SizeType, float>>  CreateStyleList(string styles)
        {
            var ans = new List<Tuple<SizeType, float>>();
            for (int i = 0, j; i < styles.Length; i = j)
            {
                j = i + 1;
                while (j < styles.Length && styles[j] != 'S' && styles[j] != 'A' && styles[j] != 'P') ++j;
                var v = SeperateString(styles.Substring(i, j - i));
                for (int k = 0; k < v.Item3; k++) ans.Add(new Tuple<SizeType, float>(v.Item1, v.Item2));
            }
            return ans;
        }
        private static Tuple<SizeType, float, int> SeperateString(string style)
        {
            var item1 = default(SizeType);
            var item2 = (float)1;
            var item3 = (int)1;
            Trace.Assert(style.Length >= 1);
            switch (style[0])
            {
                case 'S': item1 = SizeType.Absolute; break;
                case 'A': item1 = SizeType.AutoSize; break;
                case 'P': item1 = SizeType.Percent; break;
                default: Trace.Assert(false, string.Format("Invalid prefix {0}", style[0])); break;
            }
            style = style.Substring(1);
            if (!string.IsNullOrEmpty(style))
            {
                string[] sa = style.Split('%');
                Trace.Assert(sa.Length <= 2);
                if (sa.Length >= 1) Trace.Assert(float.TryParse(sa[0], out item2));
                if (sa.Length >= 2) Trace.Assert(int.TryParse(sa[1], out item3));
            }
            return new Tuple<SizeType, float, int>(item1, item2, item3);
        }
    }
}
