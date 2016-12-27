using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewvius
{
    public class Tetrad
    {
        public int top;
        public int bottom;
        public int left;
        public int right;

        #region Constructors

        public Tetrad(int value = 0)
        {
            this.top = value;
            this.right = value;
            this.bottom = value;
            this.left = value;
        }
        public Tetrad(int top, int right, int bottom, int left)
        {
            this.top = top;
            this.right = right;
            this.bottom = bottom;
            this.left = left;
        }
        public Tetrad(Tuple<int, int, int, int> tetrad)
        {
            this.top = tetrad.Item1;
            this.right = tetrad.Item2;
            this.bottom = tetrad.Item3;
            this.left = tetrad.Item4;
        }

        #endregion

        public static Tetrad Zero()
        {
            return new Tetrad();
        }

        public static Tetrad operator -(Tetrad t)
        {
            Tetrad result = new Tetrad();
            result.top = -t.top;
            result.right = -t.right;
            result.bottom = -t.bottom;
            result.left = -t.left;
            return result;
        }
        public static Tetrad operator +(Tetrad t1, Tetrad t2)
        {
            return new Tetrad(
                  t1.top + t2.top
                , t1.right + t2.right
                , t1.bottom + t2.bottom
                , t1.left + t2.left
                );
        }
        public static Tetrad operator -(Tetrad t1, Tetrad t2)
        {
            return t1 + (-t2);
        }
        
        public static implicit operator Size(Tetrad t)
        {
            return new Size(t.left, t.top);
        }

        public static implicit operator String(Tetrad t)
        {
            return ("(" + t.top + ", " + t.right + ", " + t.bottom + ", " + t.left + ")");
        }
    }
}
