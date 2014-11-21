using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace MFAT
{
    public class GlassTabControl : TabControl
    {

        public GlassTabControl() : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            pevent.Graphics.Clear(Color.FromArgb(0));

            foreach (TabPage tab in this.TabPages)
            {
                Rectangle tabRect = GetTabRect(this.TabPages.IndexOf(tab));

                using (StringFormat sf = new StringFormat(StringFormatFlags.NoWrap))
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    SizeF textSize = pevent.Graphics.MeasureString(tab.Text, this.Font);
                    RectangleF rc = new RectangleF(tabRect.Left + ((tabRect.Width / 2) - (textSize.Width / 2)), tabRect.Top + tabRect.Height / 2 - textSize.Height / 2, textSize.Width, textSize.Height);
                    rc.Inflate(4, 5);

                    GraphicsPath path = new GraphicsPath();
                    path.AddRectangle(rc);

                    using (PathGradientBrush brush = new PathGradientBrush(path))
                    {
                        brush.CenterColor = Color.FromArgb(192, tab == this.SelectedTab ? Color.Red : Color.Black);
                        brush.SurroundColors = new Color[] { Color.Black };
                        pevent.Graphics.FillRectangle(brush,rc);
                    }

                    var tc = new SolidBrush(Color.FromArgb(tab.ForeColor.A, tab.ForeColor.R, tab.ForeColor.G, tab.ForeColor.B));

                    pevent.Graphics.DrawString(tab.Text, this.Font, tc, rc, sf);

                }
            }
        }

        private GraphicsPath RoundRegion(Rectangle r)
        {
            int radius = r.Height;

            GraphicsPath path = new GraphicsPath();

            path.AddArc(r.Left, r.Top, radius, radius, 180, 90);
            path.AddArc(r.Right - radius, r.Top, radius, radius, 270, 90);
            path.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(r.Left, r.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            return path;
        }

    }
}