using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace Motivation
{
    /// <summary>
    /// for image matching or processing
    /// </summary>
    public static class MyBitmap
    {
        /// <summary>
        /// if function didn't find specific point, it would return failedPoint
        /// </summary>
        public static Point failedPoint = new Point(-1, -1);
        /// <summary>
        /// determine whether a specific rectangle area on the source bitmap matches the target bitmap
        /// </summary>
        /// <param name="source">the source bitmap</param>
        /// <param name="target">the target bitmap</param>
        /// <param name="p">the upper-left point of the comparing area on the source bitmap</param>
        /// <returns></returns>
        public static unsafe bool IsMatch(Bitmap source, Bitmap target, Point p)
        {
            int h = target.Height, w = target.Width;
            Debug.Assert(p.X + w <= source.Width && p.Y + h <= source.Height);
            BitmapData sd = source.LockBits(new Rectangle(p.X, p.Y, w, h), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData td = target.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            //if (++msgCounter > 1920 * 1070) { form.Size = new Size(500, 0); form.Show(); form.Text = String.Format("({0},{1})({2},{3})#{4}", sd.Width, sd.Height, td.Width, td.Height, msgCounter); }
            bool answer = IsMatch(sd, td, new Point(0,0));
            source.UnlockBits(sd);
            target.UnlockBits(td);
            return answer;
        }
        /// <summary>
        /// determine whether a specific rectangle area on the source bitmapdata matches the target bitmapdata
        /// </summary>
        /// <param name="sd">the source bitmapdata</param>
        /// <param name="td">the target bitmapdata</param>
        /// <param name="p">the upper-left point of the comparing area on the source bitmapdata</param>
        /// <returns></returns>
        public static unsafe bool IsMatch(BitmapData sd, BitmapData td, Point p)
        {
            int h = td.Height, w = td.Width;
            Debug.Assert(p.X + w <= sd.Width && p.Y + h <= sd.Height);
            //if (++msgCounter > 1920 * 1070) { form.Size = new Size(500, 0); form.Show(); form.Text = String.Format("({0},{1})({2},{3})#{4}", sd.Width, sd.Height, td.Width, td.Height, msgCounter); }
            int tolerance = h * w * 4 * 5;
            for(int y=0;y<h;y++)
            {
                byte* s = (byte*)sd.Scan0.ToPointer() + (p.Y + y) * sd.Stride + p.X * 4, t = (byte*)td.Scan0.ToPointer() + y * td.Stride;
                for (int i = 0; i < w * 4; i++) if ((tolerance-=Math.Abs((*s++) - (*t++)))<=0) return false;
            };
            return true;
        }
        /// <summary>
        /// find the location of target bitmapdata on the source bitmapdata
        /// </summary>
        /// <param name="sd">the source bitmapdata</param>
        /// <param name="td">the target bitmapdata</param>
        /// <returns>the location of target bitmapdata on the source bitmapdata, if the point didn't exist, failedPoint would be returned</returns>
        public static Point FindImage(BitmapData sd,BitmapData td)
        {
            for (int i = 0; i + td.Height <= sd.Height; i++)
            {
                for (int j = 0; j + td.Width <= sd.Width; j++)
                {
                    if (MyBitmap.IsMatch(sd, td, new Point(j,i)))
                    {
                        return new Point(j, i);
                    }
                }
            }
            return failedPoint;
        }
        /// <summary>
        /// find the location of target bitmap on the source bitmap
        /// </summary>
        /// <param name="source">the source bitmap</param>
        /// <param name="target">the target bitmap</param>
        /// <returns>the location of target bitmap on the source bitmap, if the point didn't exist, failedPoint would be returned</returns>
        public static Point FindImage(Bitmap source, Bitmap target)
        {
            BitmapData sd = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData td = target.LockBits(new Rectangle(0, 0, target.Width, target.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            Point answer = FindImage(sd,td);
            source.UnlockBits(sd);
            target.UnlockBits(td);
            return answer;
        }
        /// <summary>
        /// capture specific area from specific image as Bitmap
        /// </summary>
        /// <param name="bmp">the source image</param>
        /// <param name="rect">the area to capture</param>
        /// <returns></returns>
        public static Bitmap Capture(Bitmap bmp,Rectangle rect)
        {
            Bitmap answer = new Bitmap(rect.Width,rect.Height);
            Graphics g = Graphics.FromImage(answer);
            g.DrawImage(bmp,new Point(-rect.X,-rect.Y));
            g.ReleaseHdc(g.GetHdc());
            g.Dispose();
            return answer;
        }
    }
}
