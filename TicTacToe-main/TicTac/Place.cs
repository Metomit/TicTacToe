using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTac
{
    public class Place
    {
        public Point Location { get; set; }
        public bool isFree { get; set; }
        public bool isX { get; set; }

        public Place(Point location)
        {
            Location = location;
            this.isFree = true;
            isX = false;
        }

        public Place(Point location, bool isFree) : this(location)
        {
            this.isFree = isFree;
        }

        public Place(Point location, bool isFree, bool isX) : this(location, isFree)
        {
            this.isX = isX;
        }

        public Place()
        {
        }
    }
}
