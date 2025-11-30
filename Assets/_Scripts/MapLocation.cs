using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShaneClareDev
{
    public class MapLocation
    {
        public int row;
        public int col;

        public MapLocation(int _x, int _z)
        {
            row = _x;
            col = _z;
        }

        public Vector2 ToVector()
        {
            return new Vector2(row, col);
        }
        
        override public string ToString()
        {
            return "(" + row + ", " + col + ")";
        }

        /*
        public static MapLocation operator +(MapLocation a, MapLocation b)
            => new MapLocation(a.x + b.x, a.z + b.z);
        */
        
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;
            else
                return row == ((MapLocation)obj).row && col == ((MapLocation)obj).col;
        }

        public override int GetHashCode()
        {
            return 0;
        }

    }
}
