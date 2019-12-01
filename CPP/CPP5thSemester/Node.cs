using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CPP5thSemester
{
    class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int initial)
        {
            value = initial;
            left = null;
            right = null;

        }
    }
}
