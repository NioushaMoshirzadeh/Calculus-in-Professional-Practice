using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    class Plot
    {
            //class to plot x and y values on a form
            //
            //because on the form coordinates start at the upper left corner with 0,0
            //with the y coordinate going down, a little transformation is done here
            //so that x,y coordinates act as normal carthesian coordinates, with 0,0
            //in the center of the form
            struct PlotPort
            {
                public int minX;
                public int maxX;
                public int minY;
                public int maxY;
            };
            private PlotPort _PlotW;    //"window" of carthesian coordinates
            private Size _ClientArea;   //keeps the pixels info
            private double _Xspan;
            private double _Yspan;
            public Plot() { }
            public Plot(Size Plotarea)
            {
                _ClientArea = Plotarea;
            }
            public Size ClientArea { set { _ClientArea = value; } }
            public void SetPlotPort(int minx, int maxx, int miny, int maxy)
            {
                //set the bounderies of the form(screen) to real coordinates.
                _PlotW.minX = minx;
                _PlotW.maxX = maxx;
                _PlotW.minY = miny;
                _PlotW.maxY = maxy;
                _Xspan = _PlotW.maxX - _PlotW.minX;
                _Yspan = _PlotW.maxY - _PlotW.minY;
            }
            public void PlotPixel(double X, double Y, Color C, Graphics G)
            {
                //workhorse of this class
                Bitmap bm = new Bitmap(1, 1);
                bm.SetPixel(0, 0, C);
                G.DrawImageUnscaled(bm, TX(X), TY(Y));
            }
            private int TX(double X) //transform real coordinates to pixels for the X-axis
            {
                double w;
                w = _ClientArea.Width / _Xspan * X + _ClientArea.Width / 2;
                return Convert.ToInt32(w);
            }
            private int TY(double Y) //transform real coordinates to pixels for the Y-axis
            {
                double w;
                w = _ClientArea.Height / _Yspan * Y + _ClientArea.Height / 2;
                return Convert.ToInt32(w);
            }
    }
}
