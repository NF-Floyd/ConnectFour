using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ConnectFour
{
    internal partial class Gamefield : UserControl
    {
        bool _antiAlias;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Member")]
        int[,] _fields = new int[Settings.WIDTH_UNITS, Settings.HEIGHT_UNITS];
        SolidBrush emptyBrush = new SolidBrush(Color.Black);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush darkRedBrush = new SolidBrush(Color.DarkRed);
        SolidBrush darkBlueBrush = new SolidBrush(Color.DarkBlue);

        public Gamefield()
        {
            InitializeComponent();

            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.Selectable, false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle r = e.ClipRectangle;

            if (_antiAlias)
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.FillRectangle(new SolidBrush(Color.WhiteSmoke), e.ClipRectangle);

            SolidBrush b = emptyBrush;

            for (int x = 0; x < Settings.WIDTH_UNITS; x++)
            {
                for (int y = 0; y < Settings.HEIGHT_UNITS; y++)
                {
                    if (_fields[x, y] == 0)
                        continue;

                    if (_fields[x, y] == 1)
                        b = redBrush;
                    if (_fields[x, y] == 2)
                        b = blueBrush;
                    if (_fields[x, y] == 3)
                        b = darkRedBrush;
                    if (_fields[x, y] == 4)
                        b = darkBlueBrush;

                    g.FillEllipse(b, r.Width / Settings.WIDTH_UNITS * x, r.Height / Settings.HEIGHT_UNITS * (Settings.HEIGHT_UNITS - 1 - y), r.Width / Settings.WIDTH_UNITS, r.Height / Settings.HEIGHT_UNITS);
                }
            }
        }

        [
        System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode"),
        Category("Appearance"),
        DefaultValue(false),
        Description("Definiert, ob das Feld mit Anti-Aliasing gezeichnet wird.")
        ]
        public bool AntiAlias
        {
            get { return _antiAlias; }
            set
            {
                _antiAlias = value;
                Invalidate();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Member")]
        public int[,] Fields
        {
            get { return _fields; }
        }

        public void SetField(int x, int y, int player)
        {
            _fields[x, y] = player;
        }
    }
}
