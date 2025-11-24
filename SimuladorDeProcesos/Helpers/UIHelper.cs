using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimuladorDeProcesos.Helpers
{
    public static class UIHelper
    {
        // Palette
        public static Color BackgroundColor = Color.FromArgb(30, 30, 30);
        public static Color SurfaceColor = Color.FromArgb(45, 45, 48);
        public static Color TextColor = Color.FromArgb(240, 240, 240);
        public static Color AccentColor = Color.FromArgb(0, 122, 204);
        public static Color SecondaryColor = Color.FromArgb(60, 60, 60);

        public static void SetRoundedRegion(Control control, int radius)
        {
            Rectangle bounds = new Rectangle(0, 0, control.Width, control.Height);
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.X + bounds.Width - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.X + bounds.Width - d, bounds.Y + bounds.Height - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Y + bounds.Height - d, d, d, 90, 90);
            path.CloseFigure();

            control.Region = new Region(path);
        }

        public static void StyleButton(Button btn, Color backColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = backColor;
            btn.ForeColor = TextColor;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            
            // Apply rounding on Resize to handle dynamic sizing
            btn.Resize += (s, e) => SetRoundedRegion(btn, 10);
            SetRoundedRegion(btn, 10);
        }

        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = SurfaceColor;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = SecondaryColor;
            dgv.EnableHeadersVisualStyles = false;

            // Header
            dgv.ColumnHeadersDefaultCellStyle.BackColor = AccentColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextColor;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = AccentColor;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 40;

            // Rows
            dgv.RowsDefaultCellStyle.BackColor = SurfaceColor;
            dgv.RowsDefaultCellStyle.ForeColor = TextColor;
            dgv.RowsDefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgv.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 65);
            dgv.RowsDefaultCellStyle.SelectionForeColor = TextColor;
            dgv.RowHeadersVisible = false;
        }

        public static void StyleGroupBox(GroupBox grp)
        {
            grp.ForeColor = AccentColor; // Title color
            grp.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            // We can't easily change the border color of a GroupBox without custom painting,
            // but we can make it blend in or look minimal.
            grp.Paint += (s, e) =>
            {
                GroupBox box = (GroupBox)s;
                e.Graphics.Clear(SurfaceColor); // Fill background
                
                // Draw Title
                SizeF strSize = e.Graphics.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X, box.ClientRectangle.Y + (int)(strSize.Height / 2), box.ClientRectangle.Width - 1, box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);
                
                // Custom Border
                using (Pen pen = new Pen(SecondaryColor, 2))
                {
                    // Draw rounded rectangle for groupbox
                    int radius = 10;
                    int d = radius * 2;
                    e.Graphics.DrawArc(pen, rect.X, rect.Y, d, d, 180, 90);
                    e.Graphics.DrawArc(pen, rect.X + rect.Width - d, rect.Y, d, d, 270, 90);
                    e.Graphics.DrawArc(pen, rect.X + rect.Width - d, rect.Y + rect.Height - d, d, d, 0, 90);
                    e.Graphics.DrawArc(pen, rect.X, rect.Y + rect.Height - d, d, d, 90, 90);
                    e.Graphics.DrawLine(pen, rect.X + radius, rect.Y, rect.X + rect.Width - radius, rect.Y);
                    e.Graphics.DrawLine(pen, rect.X + rect.Width, rect.Y + radius, rect.X + rect.Width, rect.Y + rect.Height - radius);
                    e.Graphics.DrawLine(pen, rect.X + rect.Width - radius, rect.Y + rect.Height, rect.X + radius, rect.Y + rect.Height);
                    e.Graphics.DrawLine(pen, rect.X, rect.Y + rect.Height - radius, rect.X, rect.Y + radius);
                }

                // Draw Text with background to cover border
                e.Graphics.FillRectangle(new SolidBrush(SurfaceColor), box.Padding.Left, 0, strSize.Width, strSize.Height);
                e.Graphics.DrawString(box.Text, box.Font, new SolidBrush(AccentColor), box.Padding.Left, 0);
            };
        }
    }
}
