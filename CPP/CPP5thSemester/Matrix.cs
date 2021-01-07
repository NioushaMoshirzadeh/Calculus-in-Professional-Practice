using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace CPP5thSemester
{
    class Matrix
    {
        List<Point> points = new List<Point>();
        private int NrOfPoints;
        private double[,] matrix;
        public Matrix(int kNrOfPoints, List<Point> kpoints)
        {
            foreach (var item in kpoints)
            {
                points.Add(item);
            }
            NrOfPoints = kNrOfPoints;
            matrix = new double[kNrOfPoints, kNrOfPoints + 2]; //addded one more cols
        }
        public double[,] loadArr()
        {
            int deg = NrOfPoints - 1;
            int col = NrOfPoints;
            int colAns = NrOfPoints + 2;
            for (int i = 0; i < NrOfPoints; i++)
            {
                for (int j = 0; j < NrOfPoints; j++)
                {
                    matrix[j, i] = Math.Pow(points[j].X, deg);
                }
                deg--;
            }
            for (int i = 0; i < NrOfPoints; i++)
            {
                matrix[i, col] = points[i].Y;
            }
            return matrix;
        }

        public double[,] solveEquation()
        {
            double[,] loadArr = new double[NrOfPoints, NrOfPoints + 1];
            
            loadArr = this.loadArr();
            for (int i = 0; i < NrOfPoints; i++)
            {
                for (int j = 0; j <= NrOfPoints + 1; j++)
                {
                    Console.WriteLine("a[{0},{1} = {2}]", i, j, loadArr[i, j]);
                }
            }
            /*********************************/
            //solve the system of equation 
            const double tiny = 0.00001;
            //build augmented matrix
            double[,] arr = loadArr;
            double[,] orig_arr = loadArr;
            //start solving 
            for (int r = 0; r < NrOfPoints - 1; r++)
            {
                if (Math.Abs(arr[r, r]) < tiny)
                {
                    //too close to zero. try to swap with a later row
                    for (int r2 = r + 1; r2 < NrOfPoints; r2++)
                    {
                        if (Math.Abs(arr[r2, r]) > tiny)
                        {
                            //this raw will work.swap them
                            for (int c = 0; c <= NrOfPoints; c++)
                            {
                                double tmp = arr[r, c];
                                arr[r, c] = arr[r2, c];
                                arr[r2, c] = tmp;
                            }
                            break;
                        }

                    }

                }

                //if this raw has a non-zero entry in column r , use it
                if (Math.Abs(arr[r, r]) > tiny)
                {
                    //zero out this colums in later work
                    for (int r2 = r + 1; r2 < NrOfPoints; r2++)
                    {
                        double factor = -arr[r2, r] / arr[r, r];
                        for (int c = r; c <= NrOfPoints; c++)
                        {
                            arr[r2, c] = arr[r2, c] + factor * arr[r, c];
                        }
                    }

                }
            }
            if (arr[NrOfPoints - 1, NrOfPoints - 1] == 0)
            {
                //we have no solution 
                //see if all of the entries in this raw are 0
                bool all_zeros = true;
                for (int c = 0; c <= NrOfPoints + 1; c++)
                {
                    if (arr[NrOfPoints - 1, c] != 0)
                    {
                        all_zeros = false;
                        break;
                    }
                }
                if (all_zeros)
                {
                    Console.WriteLine("the solution is not unique");
                }
                else
                {
                    Console.WriteLine("there is no solution");
                }
            }
            else
            {
                //backsolve
                for (int r = NrOfPoints - 1; r >= 0; r--)
                {
                    double tmp = arr[r, NrOfPoints];
                    for (int r2 = r + 1; r2 < NrOfPoints; r2++)
                    {
                        tmp -= arr[r, r2] * arr[r2, NrOfPoints + 1];
                    }
                    arr[r, NrOfPoints + 1] = tmp / arr[r, r];
                }
                //display the result 
                for (int r = 0; r < NrOfPoints; r++)
                {
                    Console.WriteLine("\r\nx" + r.ToString() + " = " + arr[r, NrOfPoints + 1].ToString());
                }
            }
            /*********************************/
            return arr;
        }

    }
}
