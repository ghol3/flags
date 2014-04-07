using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace flags
{
    public partial class Flags : UserControl
    {
        private FlagType flag = FlagType.cz;
        [Category("Appearance")]
        public FlagType Flag
        {
            get
            {
                return this.flag;
            }
            set
            {
                this.flag = value;
                this.Invalidate();
            }
        }

        // if flag contain text we can using this font
        private Font textFont = new Font("Arial", 50.0f);
        [Category("Appearance")]
        public Font TextFont 
        {
            get
            {
                return this.textFont;
            }
            set
            {
                this.textFont = value;
                Invalidate();
            }
        }

        private Graphics g;

        public Flags()
        {
            InitializeComponent();
        }

        /// <summary>
        /// override OnPaint method
        /// </summary>
        /// <param name="e">eventargs class with data about event</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.g = e.Graphics;                                                             
            MethodInfo i = this.GetType().GetMethod(Enum.GetName(typeof(FlagType), this.flag));     // Get string from enum item and get method from this string
            i.Invoke(this, null);                                                                   // Invoke method
        }

        /// <summary>
        /// Drawing GERMAN flag
        /// </summary>
        public void de()
        {
            g.FillRectangle(Brushes.Black, 0, 0, this.Width, this.Height / 3);
            g.FillRectangle(Brushes.Red, 0, this.Height / 3, this.Width, this.Height / 3);
            g.FillRectangle(Brushes.Yellow, 0, this.Height / 3 * 2, this.Width, this.Height / 3);
        }

        /// <summary>
        /// Drawing CZECH flag
        /// </summary>
        public void cz()
        {
            g.FillRectangle(Brushes.White, 0, 0, this.Width, this.Height / 2);
            g.FillRectangle(Brushes.Red, 0, this.Height / 2, this.Width, this.Height / 2);
            g.FillPolygon(Brushes.Blue, new Point[] 
            {
                new Point(0,0),
                new Point(0, this.Height),
                new Point(this.Width / 2, this.Height / 2)
            });
        }

        /// <summary>
        /// Drawing UNITED STATES OF AMERICA flag
        /// </summary>
        public void usa()
        {
            for (int i = 0; i < 13; i++)
                g.FillRectangle(i % 2 == 0 ? Brushes.Red : Brushes.White,
                                0, i * (this.Height / 13), this.Width, this.Height / 13);
            g.FillRectangle(Brushes.Blue, 0, 0, this.Width / 2.5f, (this.Height / 13) * 7);

            SizeF starSize = new SizeF((this.Width / 2.5f) / 13, ((this.Height / 13) * 7)/10);
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 5; j++)
                    DrawStar(((this.Width / 2.5f) / 6) * i + starSize.Width/2, ((this.Height / 13)* 7/5) * j+starSize.Height/2, (int)starSize.Width, (int)starSize.Height);
                    //g.FillRectangle(Brushes.White, ((this.Width / 2.5f) / 6) * i + starSize.Width/2, ((this.Height / 13)* 7/5) * j+starSize.Height/2, starSize.Width, starSize.Height);

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 4; j++)
                    DrawStar(((this.Width / 2.5f) / 6) * i + (starSize.Width * 1.5f), ((this.Height / 13) * 7 / 5) * j + (starSize.Height * 1.5f), (int)starSize.Width, (int)starSize.Height);
                    //g.FillRectangle(Brushes.Wheat, ((this.Width / 2.5f) / 6) * i+(starSize.Width*1.5f), ((this.Height / 13) * 7 / 5) * j+(starSize.Height*1.5f), starSize.Width, starSize.Height);
            
        }

        /// <summary>
        /// Method for Drawing stars 
        /// </summary>
        /// <param name="x">star position x</param>
        /// <param name="y">star position y</param>
        /// <param name="width">star width</param>
        /// <param name="height">star height</param>
        private void DrawStar(float x, float y, int width, int height)
        {
            int X = (int)x;
            int Y = (int)y;
            g.FillPolygon(Brushes.White, new Point[] 
            {
                new Point(X+0,Y+(height/3)),                //1
                new Point(X+(width/3), Y+(height/3)),     //2
                new Point(X+(width/2), Y+(0)),                 //3
                new Point(X+(width/3*2), Y+(height/3)),   //4
                new Point(X+(width), Y+(height / 3)),     //5
                new Point(X+(width/3*2), Y+(height/5*3)), //6
                new Point(X+(width), Y+(height)),         //7
                new Point(X+(width/2), Y+(height/5*4)),   //8
                new Point(X+(0), Y+(height)),                  //9
                new Point(X+(width/3), Y+(height/5*3))    //10
            });
        }

        /// <summary>
        /// Drawing RUSIAN flag
        /// </summary>
        public void ru()
        {
            g.FillRectangle(Brushes.White, 0, 0, this.Width, this.Height / 3);
            g.FillRectangle(Brushes.Red, 0, this.Height / 3, this.Width, this.Height / 3);
            g.FillRectangle(Brushes.Blue, 0, this.Height / 3 * 2, this.Width, this.Height / 3);
        }

        /// <summary>
        /// Method just for fun
        /// </summary>
        public void BigShock()
        {
            g.FillRectangle(Brushes.Gold, 0, 0, this.Width, this.Height);
            StringFormat sFormat = new StringFormat();
            sFormat.Alignment = StringAlignment.Center;
            sFormat.LineAlignment = StringAlignment.Center;
            g.DrawString("Big Shock", this.textFont, Brushes.Black, new PointF(this.Width/2, this.Height / 2), sFormat);
        }
    }

    /// <summary>
    /// Enum with existing flags
    /// </summary>
    public enum FlagType
    {
        cz,
        de,
        usa,
        ru,
        BigShock,

    }
}
