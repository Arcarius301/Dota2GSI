using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2StateListener.Services.Models
{
    internal struct PointInt
    {
        public int X;
        public int Y;
        public PointInt(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
