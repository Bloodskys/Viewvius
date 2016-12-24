using System;
using System.Collections.Generic;
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

        public Tetrad()
        {
            this.top = 0;
            this.right = 0;
            this.bottom = 0;
            this.left = 0;
        }
        public Tetrad(int top, int right, int bottom, int left)
        {
            this.top = top;
            this.right = right;
            this.bottom = bottom;
            this.left = left;
        }
        public Tetrad(Tuple<int,int,int,int> tetrad)
        {
            this.top = tetrad.Item1;
            this.right = tetrad.Item2;
            this.bottom = tetrad.Item3;
            this.left = tetrad.Item4;
        }

        #endregion
    }
}
