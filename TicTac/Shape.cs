using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTac
{
    public class Shape
    {
        public bool isX { get; set; }
        public Point Location { get; set; }

        public Shape()
        {
        }

        public Shape(bool isX, Point location)
        {
            this.isX = isX;
            Location = location;
        }

        public void DrawShape(Graphics g)
        {
            Pen pn = new Pen(Color.Black, 15);
            if (!isX)
            {
                g.DrawEllipse(pn, Location.X-50, Location.Y-50, 100, 100);
            }else
            {
                g.DrawLine(pn, new Point(Location.X+50, Location.Y+50), new Point(Location.X - 50, Location.Y - 50));
                g.DrawLine(pn, new Point(Location.X - 50, Location.Y + 50), new Point(Location.X + 50, Location.Y - 50));
            }
        }
    }
}
