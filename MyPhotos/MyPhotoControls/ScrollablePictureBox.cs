using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Manning.MyPhotoControls
{
    [DefaultEvent("Click")]
    [DefaultProperty("Image")]
    [ToolboxBitmap(typeof(ScrollablePictureBox), "ScrollablePictureBox.bmp")]
    public class ScrollablePictureBox : PictureBox
    {
        private bool _allowScrollBars = true;
        [Browsable(true)]
        [Category("Layout")]
        [DefaultValue(true)]
        [Description("Gets or sets whether the control can display scroll bars")]
        public bool AllowScrollBars
        {
            get { return _allowScrollBars; }
            set
            {
                if (_allowScrollBars != value)
                {
                    _allowScrollBars = value;
                    Invalidate();
                }
            }
        }

        [Category("Action")]
        [Description("Occurs when a scroll bar is shown and the image is scrolled")]
        public event ScrollEventHandler Scroll;
        protected virtual void OnScroll(ScrollEventArgs e)
        {
            if (Scroll != null)
                Scroll(this, e);
        }

        private HScrollBar _hbar = new HScrollBar();
        private VScrollBar _vbar = new VScrollBar();
        private Control _vbarContainer = new Control();

        private HScrollBar HBar
        {
            get { return _hbar; }
        }
        private VScrollBar VBar
        {
            get { return _vbar; }
        }
        private Control VContainer
        {
            get { return _vbarContainer; }
        }

        public new Image Image
        {
            get { return base.Image; }
            set
            {
                base.Image = value;
                ResetScrollBars();
            }
        }

        public ScrollablePictureBox()
        {
            // Initialize horizontal scroll bar
            HBar.Visible = false;
            HBar.Dock = DockStyle.Bottom;
            HBar.Minimum = 0;
            HBar.Maximum = 1000;
            HBar.Scroll += HandleScroll;

            // Initialize vertical scroll bar container
            VContainer.Visible = false;
            VContainer.Width = VBar.Width;
            VContainer.Height = Height;
            VContainer.Dock = DockStyle.Right;

            // Initialize vertical scroll bar
            VBar.Top = 0;
            VBar.Left = 0;
            VBar.Height = VContainer.Height - HBar.Height;
            VBar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            VBar.Minimum = 0;
            VBar.Maximum = 1000;
            VBar.Scroll += HandleScroll;

            VContainer.Controls.Add(VBar);

            Controls.Add(HBar);
            Controls.Add(VContainer);

            DoubleBuffered = true;
        }

        private void HandleScroll(object sender, ScrollEventArgs e)
        {
            Refresh();
            OnScroll(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if (Image != null && (HBar.Visible || VContainer.Visible))
                DrawImage(pe.Graphics);
        }

        private void DrawImage(Graphics g)
        {
            Rectangle targerRect = new Rectangle(0, 0,
                                                 Math.Min(Right - VBar.Width, Image.Width),
                                                 Math.Min(Bottom - HBar.Height, Image.Height));
            Rectangle sourceRect = new Rectangle(HBar.Value, VBar.Value,
                                                 Math.Min(Right - VBar.Width, Image.Width),
                                                 Math.Min(Bottom - HBar.Height, Image.Height));

            if (SizeMode == PictureBoxSizeMode.CenterImage)
            {
                Point p = new Point(0, 0);

                if (Right - VBar.Width > Image.Width)
                    p.X = Math.Max((ClientSize.Width - targerRect.Width) / 2, 0);
                if (Bottom - HBar.Height > Image.Height)
                    p.Y = Math.Max((ClientSize.Height - targerRect.Height) / 2, 0);

                targerRect.Offset(p);
            }
            g.DrawImage(Image, targerRect, sourceRect, GraphicsUnit.Pixel);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (ScrollingActive())
            {
                AdjustScrollBars();
                Refresh();
            }
        }

        private bool ScrollingActive()
        {
            if (Image == null || AllowScrollBars == false 
                || SizeMode != PictureBoxSizeMode.CenterImage
                && SizeMode != PictureBoxSizeMode.Normal)
            {
                HBar.Visible = false;
                VContainer.Visible = false;
            }
            else
            {
                HBar.Visible = Image.Width >= ClientSize.Width - VBar.Width;
                VContainer.Visible = Image.Height >= ClientSize.Height - HBar.Height;
            }
            return (HBar.Visible || VContainer.Visible);
        }

        private void AdjustScrollBars()
        {
            if (HBar.Visible)
            {
                int max = Image.Width - ClientSize.Width;
                HBar.LargeChange = Math.Max(max / 10, 1);
                HBar.SmallChange = Math.Max(max / 20, 1);

                HBar.Maximum = max + HBar.LargeChange;
                if (VBar.Visible)
                    HBar.Maximum += VBar.Width;
            }
            if (VContainer.Visible)
            {
                if (HBar.Visible)
                    VBar.Height = Height - HBar.Height;
                else
                    VBar.Height = Height;

                int max = Image.Height - ClientSize.Height;
                VBar.LargeChange = Math.Max(max / 10, 1);
                VBar.SmallChange = Math.Max(max / 20, 1);

                VBar.Maximum = max + VBar.LargeChange;
                if (HBar.Visible)
                    VBar.Maximum += HBar.Height;
            }
        }

        protected override void OnSizeModeChanged(EventArgs e)
        {
            base.OnSizeModeChanged(e);
            ResetScrollBars();
        }

        private void ResetScrollBars()
        {
            HBar.Value = 0;
            VBar.Value = 0;
            if (Image != null && ScrollingActive())
            {
                AdjustScrollBars();
                if (SizeMode == PictureBoxSizeMode.CenterImage)
                {
                    HBar.Value = Math.Abs(Image.Width / 2 - ClientSize.Width / 2);
                    VBar.Value = Math.Abs(Image.Height / 2 - ClientSize.Height / 2);
                }
            }
        }

    }
}
