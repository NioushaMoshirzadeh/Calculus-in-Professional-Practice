using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuBrain
{
    class FourCube
    {
        public int dimention { get; set; }
        CubeCell[,,,] cubeCells = new CubeCell[4, 9, 9, 9]; //[cube numebr] [azimuthal] [columm] [row] 
        private enum blockPart { First, Second, Third, fourth, fifth, sixth, seventh, eight, ninth}
        public FourCube() { }
        public FourCube(int [,] Sudoku)
        {
            for (int cc = 0; cc < 4; cc++)
            {
                for (int r = 0; r < 9; r++)             //Counting of Cubes cells starts from 0 to 8
                {
                    for (int c = 0; c < 9; c++)
                    {
                        if (Sudoku[r, c] == 0)          // for Sudoku in case: row = 0 and culumn = 0
                        {
                            for (int a = 0; a < 9; a++)
                            {
                                cubeCells[cc, a, c, r] = new CubeCell();
                                cubeCells[cc, a, c, r].confidence = 0;
                                cubeCells[cc, a, c, r].isClue = false;
                               // Console.WriteLine("cubecells[cc{0} , d{1}, c{2}, r{3}]:Confidence{4}\t", cc, a, c, r, cubeCells[cc, a, c, r].confidence);
                            }

                        }
                        else                             // when row and culumn has digit
                        {
                            int digit = Sudoku[r, c];
                            SetRowCubeCells(r, digit, cc);
                            SetColumnCubeCells(c, digit, cc);
                            SetBlockCubeCells(digit, r, c, cc);
                        }
                    }

                }
                //Console.WriteLine("\n");
            }
        }
        private void SetRowCubeCells(int row, int digit, int cc)  //[cube numebr] [azimuthal] [columm] [row]
        {
            for (int c = 0; c < 9; c++)
            {
                cubeCells[cc,digit -1, c,row] = new CubeCell();
                if (c == row)
                {
                    this.cubeCells[cc, digit - 1, c, row].confidence = 1;
                }
                else
                {
                    this.cubeCells[cc, digit - 1, c, row].confidence = 0;
                }
                this.cubeCells[cc, digit - 1, c, row].isClue = true;
                //Console.WriteLine("Row:cubecells[cc{0} , d{1}, c{2}, r{3}]:Confid {4}\t", cc, digit - 1, c, row, this.cubeCells[cc, digit - 1, c, row].confidence);
                //Console.WriteLine("\n");
            }

        }
        private void SetColumnCubeCells(int column, int digit, int cc) //[cube numebr] [azimuthal] [columm] [row]
        {
            for (int r = 0; r < 9; r++)
            {
                cubeCells[cc, digit - 1, column, r] = new CubeCell();
                if (r == column)
                {
                    this.cubeCells[cc, digit - 1, column, r].confidence = 1;
                }
                else
                {
                    this.cubeCells[cc, digit - 1, column, r].confidence = 0;
                }
                this.cubeCells[cc, digit - 1, column, r].isClue = true;
                //Console.WriteLine("Column:cubecells[cc{0} , d{1}, c{2}, r{3}]:Confid {4}\t", cc, digit - 1, column, r, this.cubeCells[cc, digit - 1, column, r].confidence);
                //Console.WriteLine("\n");
            }
        }

        private void SetBlockCubeCells(int digit,int row,int column,int cn) //[cube numebr] [azimuthal] [columm] [row]
        {
            int rowRange    = 0;
            int columnRange = 0;
            int blockPart   = 0;
            
            //checking the row rang
            if (row <= 2)
            {
                rowRange = 0;
            }
            else if (row <= 5 && row >=3)
            {
                rowRange = 1;
            }
            else if (row >= 6)
            {
                rowRange = 2;
            }
            //checing the column range
            if (column <= 2)
            {
                columnRange = 0;
            }
            else if (column <= 5 && column >= 3)
            {
                columnRange = 1;
            }
            else if(column >= 6)
            {
                columnRange = 2;
            }
            //assining the block part
            if (rowRange == 0 && columnRange == 0)
            {
                blockPart = 0;
            }
            else if (rowRange == 0 && columnRange == 1)
            {
                blockPart = 1;
            }
            else if (rowRange == 0 && columnRange == 2)
            {
                blockPart = 2;
            }
            else if (rowRange == 1 && columnRange == 0)
            {
                blockPart = 3;
            }
            else if (rowRange == 1 && columnRange == 1)
            {
                blockPart = 4;
            }
            else if (rowRange == 1 && columnRange == 2)
            {
                blockPart = 5;
            }
            else if (rowRange == 2 && columnRange == 0)
            {
                blockPart = 6;
            }
            else if (rowRange == 2 && columnRange == 1)
            {
                blockPart = 7;
            }
            else if (rowRange == 2 && columnRange == 2)
            {
                blockPart = 8;
            }
            //filling cubeCells parameter in its cube part
            switch (blockPart)
            {
                
                case 0:
                    for (int r = 0; r < 3; r++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            if (r == row && c == column)
                            {
                                for (int a = 0; a < 9; a++)
                                {
                                    cubeCells[cn, a, column, row] = new CubeCell();
                                    if (a == digit - 1)
                                    {
                                        cubeCells[cn, a, c, r].confidence = 1;
                                    }
                                    else   
                                        cubeCells[cn, a, c, r].confidence = 0;
                                    cubeCells[cn, a, c, r].isClue     = true;
                                    //Console.WriteLine("block:cubecells[cc{0} , d{1}, c{2}, r{3}]:Conf {4}\t", cn, a, c, r, cubeCells[cn, a, c, r].confidence);
                                    //Console.WriteLine("\n");
                                }
                            }
                        }
                    }
                    break;

                case 1:
                    for (int r = 0; r < 3; r++)
                    {
                        for (int c = 3; c < 6; c++)
                        {
                            if (r == row && c == column)
                            {
                                for (int a = 0; a < 9; a++)
                                {
                                    cubeCells[cn, a, column, row] = new CubeCell();
                                    if (a == digit - 1)
                                    {
                                        cubeCells[cn, a, c, r].confidence = 1;
                                    }
                                    else
                                        cubeCells[cn, a, c, r].confidence = 0;
                                    cubeCells[cn, a, c, r].isClue = true;
                                    //Console.WriteLine("block:cubecells[cc{0} , d{1}, c{2}, r{3}]:Conf {4}\t", cn, a, c, r, cubeCells[cn, a, c, r].confidence);
                                    //Console.WriteLine("\n");
                                }
                            }
                        }
                    }
                    break;
                case 2:
                    for (int r = 0; r < 3; r++)
                    {
                        for (int c = 6; c < 9; c++)
                        {
                            if (r == row && c == column)
                            {
                                for (int a = 0; a < 9; a++) //does it change if I start the azimithual in the begining?????
                                {
                                    cubeCells[cn, a, column, row] = new CubeCell();
                                    if (a == digit -1)
                                    {
                                        cubeCells[cn, a, c, r].confidence = 1;
                                    }
                                    else
                                        cubeCells[cn, a, c, r].confidence = 0;
                                    cubeCells[cn, a, c, r].isClue = true;
                                    //Console.WriteLine("block:cubecells[cc{0} , d{1}, c{2}, r{3}]:Conf {4}\t", cn, a, c, r, cubeCells[cn, a, c, r].confidence);
                                    //Console.WriteLine("\n");
                                }
                            }
                        }
                    }
                    break;
                case 3:
                    for (int r = 3; r < 6; r++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            if (r == row && c == column)
                            {
                                for (int a = 0; a < 9; a++) //does it change if I start the azimithual in the begining?????
                                {
                                    cubeCells[cn, a, column, row] = new CubeCell();
                                    if (a == digit -1)
                                    {
                                        cubeCells[cn, a, c, r].confidence = 1;
                                    }
                                    else
                                        cubeCells[cn, a, c, r].confidence = 0;
                                    cubeCells[cn, a, c, r].isClue = true;
                                    //Console.WriteLine("block:cubecells[cc{0} , d{1}, c{2}, r{3}]:Conf {4}\t", cn, a, c, r, cubeCells[cn, a, c, r].confidence);
                                    //Console.WriteLine("\n");
                                }
                            }
                        }
                    }
                    break;
                case 4:
                    for (int r = 3; r < 6; r++)
                    {
                        for (int c = 3; c < 6; c++)
                        {
                            if (r == row && c == column)
                            {
                                for (int a = 0; a < 9; a++) //does it change if I start the azimithual in the begining?????
                                {
                                    cubeCells[cn, a, column, row] = new CubeCell();
                                    if (a == digit -1)
                                    {
                                        cubeCells[cn, a, c, r].confidence = 1;
                                    }
                                    else
                                        cubeCells[cn, a, c, r].confidence = 0;
                                    cubeCells[cn, a, c, r].isClue = true;
                                    //Console.WriteLine("bock:cubecells[cc{0} , d{1}, c{2}, r{3}]:Conf {4}\t", cn, a, c, r, cubeCells[cn, a, c, r].confidence);
                                    //Console.WriteLine("\n");
                                }
                            }
                        }
                    }
                    break;
                case 5:
                    for (int r = 3; r < 6; r++)
                    {
                        for (int c = 6; c < 9; c++)
                        {
                            if (r == row && c == column)
                            {
                                for (int a = 0; a < 9; a++) //does it change if I start the azimithual in the begining?????
                                {
                                    cubeCells[cn, a, column, row] = new CubeCell();
                                    if (a == digit -1)
                                    {
                                        cubeCells[cn, a, c, r].confidence = 1;
                                    }
                                    else
                                        cubeCells[cn, a, c, r].confidence = 0;
                                    cubeCells[cn, a, c, r].isClue = true;
                                    //Console.WriteLine("block:cubecells[cc{0} , d{1}, c{2}, r{3}]:Conf {4}\t", cn, a, c, r, cubeCells[cn, a, c, r].confidence);
                                    //Console.WriteLine("\n");
                                }
                            }
                        }
                    }
                    break;
                case 6:
                    for (int r = 6; r < 9; r++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            if (r == row && c == column)
                            {
                                for (int a = 0; a < 9; a++) //does it change if I start the azimithual in the begining?????
                                {
                                    cubeCells[cn, a, column, row] = new CubeCell();
                                    if (a == digit - 1)
                                    {
                                        cubeCells[cn, a, c, r].confidence = 1;
                                    }
                                    else
                                        cubeCells[cn, a, c, r].confidence = 0;
                                    cubeCells[cn, a, c, r].isClue = true;
                                    //Console.WriteLine("block:cubecells[cc{0} , d{1}, c{2}, r{3}]:Conf {4}\t", cn, a, c, r, cubeCells[cn, a, c, r].confidence);
                                    //Console.WriteLine("\n");
                                }
                            }
                        }
                    }
                    break;
                case 7:
                    for (int r = 6; r < 9; r++)
                    {
                        for (int c = 3; c < 6; c++)
                        {
                            if (r == row && c == column)
                            {
                                for (int a = 0; a < 9; a++) //does it change if I start the azimithual in the begining?????
                                {
                                    cubeCells[cn, a, column, row] = new CubeCell();
                                    if (a == digit - 1)
                                    {
                                        cubeCells[cn, a, c, r].confidence = 1;
                                    }
                                    else
                                        cubeCells[cn, a, c, r].confidence = 0;
                                    cubeCells[cn, a, c, r].isClue = true;
                                    //Console.WriteLine("block:cubecells[cc{0} , d{1}, c{2}, r{3}]:Conf {4}\t", cn, a, c, r, cubeCells[cn, a, c, r].confidence);
                                    //Console.WriteLine("\n");
                                }
                            }
                        }
                    }
                    break;
                case 8:
                    for (int r = 6; r < 9; r++)
                    {
                        for (int c = 6; c < 9; c++)
                        {
                            if (r == row && c == column)
                            {
                                for (int a = 0; a < 9; a++) //does it change if I start the azimithual in the begining?????
                                {
                                    cubeCells[cn, a, column, row] = new CubeCell();
                                    if (a == digit - 1)
                                    {
                                        cubeCells[cn, a, c, r].confidence = 1;
                                    }
                                    else
                                        cubeCells[cn, a, c, r].confidence = 0;
                                    cubeCells[cn, a, c, r].isClue = true;
                                    //Console.WriteLine("block:cubecells[cc{0} , d{1}, c{2}, r{3}]:Conf {4}\t", cn, a, c, r, cubeCells[cn, a, c, r].confidence);
                                    //Console.WriteLine("\n");
                                }
                            }
                        }
                    }
                break;
            }
        }//end of SetBlockCubeCells
        public FourCube Equalizer()
        {
            int[,] Clue = new int[9, 9];
            FourCube fc = new FourCube(Clue) { };
            for (int i = 0; i < 9; i++)
            {
                for (int k = 0; k < 9; k++)
                {
                    for (int h = 0; h < 9; h++)
                    {
                        if (!cubeCells[0, i, k, h].isClue)
                        {
                            double ave = cubeCells[0, i, k, h].confidence + cubeCells[1, i, k, h].confidence
                                        + cubeCells[2, i, k, h].confidence + cubeCells[3, i, k, h].confidence;
                            ave /= 4;
                            cubeCells[0, i, k, h].confidence = ave;
                            cubeCells[1, i, k, h].confidence = ave;
                            cubeCells[2, i, k, h].confidence = ave;
                            cubeCells[3, i, k, h].confidence = ave;
                            fc.cubeCells[0, i, k, h].confidence = cubeCells[0, i, k, h].confidence;
                            fc.cubeCells[1, i, k, h].confidence = cubeCells[1, i, k, h].confidence;
                            fc.cubeCells[2, i, k, h].confidence = cubeCells[2, i, k, h].confidence;
                            fc.cubeCells[3, i, k, h].confidence = cubeCells[3, i, k, h].confidence;
                        }
                        else
                        {
                            cubeCells[0, i, k, h].confidence = 1;
                            cubeCells[1, i, k, h].confidence = 1;
                            cubeCells[2, i, k, h].confidence = 1;
                            cubeCells[3, i, k, h].confidence = 1;
                            fc.cubeCells[0, i, k, h].confidence = cubeCells[0, i, k, h].confidence;
                            fc.cubeCells[1, i, k, h].confidence = cubeCells[1, i, k, h].confidence;
                            fc.cubeCells[2, i, k, h].confidence = cubeCells[2, i, k, h].confidence;
                            fc.cubeCells[3, i, k, h].confidence = cubeCells[3, i, k, h].confidence;
                        }
                        return fc;
                    }
                }
            }
            return null;
        }//end of Equalizer
        public FourCube Selector()
        {
            int[,] Clue = new int[9, 9];
            FourCube fc = new FourCube(Clue) { };
            // j = azimuthal k = column h = row

            //selector neuron on 1st cube [0][][][] azimuthal axis
            //---------------------------------------------------------------
            for (int k = 0; k < 9; k++)
            {
                for (int h = 0; h < 9; h++)
                {
                    double maxValue = (-1) * double.MaxValue;
                    int positionOfMax = -1;
                    for (int j = 0; j < 9; j++)
                    {
                        if (cubeCells[0,j,k,h].confidence > maxValue)
                        {
                            maxValue = cubeCells[0, j, k, h].confidence;
                            cubeCells[0, j, k, h].confidence = 0;
                            fc.cubeCells[0, j, k, h].confidence = cubeCells[0, j, k, h].confidence;
                            positionOfMax = j;
                        }
                        else
                        {
                            cubeCells[0, j, k, h].confidence = 0;
                            fc.cubeCells[0, j, k, h].confidence = cubeCells[0, j, k, h].confidence;
                        }
                    }
                    if (positionOfMax != -1)
                    {
                        cubeCells[0, positionOfMax, k, h].confidence = 1;
                        fc.cubeCells[0, positionOfMax, k, h].confidence = cubeCells[0, positionOfMax, k, h].confidence;
                    }
                }
            }
            //selector neuron on 2nd cube [1][][][] column axis
            //---------------------------------------------------------------
            for (int j = 0; j < 9; j++)
            {
                for (int h = 0; h < 9; h++)
                {
                    double maxValue = (-1) * double.MaxValue;
                    int positionOfMax = -1;
                    for (int k = 0; k < 9; k++)
                    {
                        if (cubeCells[1,j,k,h].confidence > maxValue)
                        {
                            maxValue = cubeCells[1, j, k, h].confidence;
                            cubeCells[1, j, k, h].confidence = 0;
                            fc.cubeCells[1, j, k, h].confidence = cubeCells[1, j, k, h].confidence;
                            positionOfMax =j;
                        }
                        else
                        {
                            cubeCells[1, j, k, h].confidence = 0;
                            fc.cubeCells[1, j, k, h].confidence = cubeCells[1, j, k, h].confidence;
                        }
                    }
                    if (positionOfMax != -1)
                    {
                        cubeCells[1, j, positionOfMax, h].confidence = 1;
                        fc.cubeCells[1, j, positionOfMax, h].confidence = cubeCells[1, j, positionOfMax, h].confidence;
                    }
                }
            }
            //selector neuron on 3rd cube [2][][][] row axis
            //---------------------------------------------------------------
            for (int k = 0; k < 9; k++)
            {
                for (int j = 0; j < 9; j++)
                {
                    double maxValue = (-1) * double.MaxValue;
                    int positionOfMax = -1;
                    for (int h = 0; h < 9; h++)
                    {
                        if (cubeCells[2, j, k, h].confidence > maxValue)
                        {
                            maxValue = cubeCells[2, j, k, h].confidence;
                            cubeCells[2, j, k, h].confidence= 0;
                            fc.cubeCells[2, j, k, h].confidence = cubeCells[2, j, k, h].confidence;
                            positionOfMax = j;
                        }
                        else
                        {
                            cubeCells[2, j, k, h].confidence = 0;
                            fc.cubeCells[2, j, k, h].confidence = cubeCells[2, j, k, h].confidence;
                        }
                    }
                    if (positionOfMax != -1)
                    {
                        cubeCells[2, j, k, positionOfMax].confidence = 1;
                        fc.cubeCells[2, j, k, positionOfMax].confidence = cubeCells[2, j, k, positionOfMax].confidence;
                    }
                }
            }
            //selector neuron on 4th cube [3][][][]
            //---------------------------------------------------------------
            for (int j = 0; j < 9; j++)
            {
                double maxValue = (-1) * double.MaxValue;
                int max_positionH = -1;
                int max_positionK = -1;
                for (int h = 0; h < 9; h += 3)
                {
                    for (int k = 0; k < 9; k += 3)
                    {
                        for (int hh = 0; hh < 3; hh++)
                        {
                            for (int kk = 0; kk < 3; kk++)
                            {
                                if (cubeCells[3,j,(k + kk),(h + hh)].confidence > maxValue)
                                {
                                    max_positionH = h + hh;
                                    max_positionK = k + kk;
                                    maxValue = cubeCells[3,j,k,h].confidence;
                                    cubeCells[3,j,k + kk,h + hh].confidence = 0;
                                    fc.cubeCells[3, j, k + kk, h + hh].confidence = cubeCells[3, j, k + kk, h + hh].confidence;
                                }
                                else
                                {
                                    cubeCells[3, j, k + kk, h + hh].confidence = 0;
                                    fc.cubeCells[3, j, k + kk, h + hh].confidence = cubeCells[3, j, k + kk, h + hh].confidence;
                                }
                            }
                        }
                    }
                }
                if (max_positionH != -1) // not sure that it should be defined here????
                {
                    cubeCells[3, j, max_positionK, max_positionH].confidence = 1;
                    fc.cubeCells[3, j, max_positionK, max_positionH].confidence = cubeCells[3, j, max_positionK, max_positionH].confidence;
                }
            }
            return null;
        }//end of Selector
        public FourCube Plus(FourCube fc)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        for (int h = 0; h < 9; h++)
                        {
                            fc.cubeCells[i, j, k, h].confidence = this.cubeCells[i, j, k, h].confidence + fc.cubeCells[i, j, k, h].confidence;
                        }
                    }
                }
            }
            return fc;
        }//end of Plus
        public FourCube Min(FourCube fc)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        for (int h = 0; h < 9; h++)
                        {
                            fc.cubeCells[i, j, k, h].confidence = fc.cubeCells[i, j, k, h].confidence - this.cubeCells[i, j, k, h].confidence;
                        }
                    }
                }
            }
            return fc;

        }//end of Minus
        public FourCube mult(double multipication)
        {
            int[,] Clue = new int[9, 9];
            FourCube fc = new FourCube(Clue) { };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        for (int h = 0; h < 9; h++)
                        {
                            fc.cubeCells[i, j, k, h].confidence = this.cubeCells[i, j, k, h].confidence * multipication;
                        }
                    }
                }
            }
            return fc;
        }//end of mult
    }
}
