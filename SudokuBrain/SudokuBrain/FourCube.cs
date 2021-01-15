using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuBrain
{
    class FourCube
    {
        CubeCell[,,,] cubeCells = new CubeCell[4, 9, 9, 9]; //[cube numebr] [azimuthal] [columm] [row] 
        private enum blockPart { First, Second, Third, fourth, fifth, sixth, seventh, eight, ninth}
        public FourCube() { }
        public FourCube(int [,] Sudoku)
        {
            /*Init all the cubcells with conf = 0 and clue = false*/
            for (int c = 0; c < 4; c++)
            {
                for (int row = 0; row < 9; row++)
                {
                    for (int column = 0; column < 9; column++)
                    {
                        for (int azimuthal = 0; azimuthal < 9; azimuthal++)
                        {
                            cubeCells[c, azimuthal, column, row] = new CubeCell
                            {
                                confidence = 0,
                                isClue = false
                            };
                        }
                    }
                }
            }
            for (int c = 0; c < 4; c++)
            {
                    for (int row = 0; row < 9; row++)
                    {
                            for (int column = 0; column < 9; column++)
                            {
                                for (int azimuthal = 0; azimuthal < 9; azimuthal++)
                                {
                                    if (Sudoku[row, column] != 0 && azimuthal != Sudoku[row, column] - 1)
                                    {
                                        cubeCells[c, azimuthal, column, row] = new CubeCell
                                        {
                                            confidence = 0,
                                            isClue = true
                                        };
                                    }
                                    else if (Sudoku[row, column] != 0 && azimuthal == Sudoku[row, column] - 1)
                                    {
                                        int digit = Sudoku[row, column];
                                        SetRowCubeCells(row, digit, c, column);
                                        SetColumnCubeCells(column, digit, c, row);
                                        SetBlockCubeCells(digit, row, column, c);
                                    }

                                }

                            }
                    }
            }
        }
        private void SetRowCubeCells(int row, int digit, int cc, int col)  //[cube numebr] [azimuthal] [columm] [row]
        {
            for (int column = 0; column < 9; column++)
            {
                if (column == col)
                {
                    cubeCells[cc, digit - 1, column, row] = new CubeCell
                    {
                        confidence = 1,
                        isClue = true
                    };
                }
                else
                {
                    cubeCells[cc, digit - 1, column, row] = new CubeCell
                    {
                        confidence = 0,
                        isClue = true
                    };
                }
            }
        }
        private void SetColumnCubeCells(int column, int digit, int cc,int row) //[cube numebr] [azimuthal] [columm] [row]
        {
            for (int r = 0; r < 9; r++)
            {
                if (r == row)
                {
                    cubeCells[cc, digit - 1, column, r] = new CubeCell
                    {
                        confidence = 1,
                        isClue = true
                    };
                }
                else
                {
                    cubeCells[cc, digit - 1, column, r] = new CubeCell
                    {
                        confidence = 0,
                        isClue = true
                    };
                }
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
                                cubeCells[cn, digit - 1, c, r] = new CubeCell
                                {
                                    confidence = 1,
                                    isClue = true
                                };
                            }
                            else
                            {
                                cubeCells[cn, digit - 1, c, r] = new CubeCell
                                {
                                    confidence = 0,
                                    isClue = true
                                };
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
                                cubeCells[cn, digit - 1, c, r] = new CubeCell
                                {
                                    confidence = 1,
                                    isClue = true
                                };
                            }
                            else
                            {
                                cubeCells[cn, digit - 1, c, r] = new CubeCell
                                {
                                    confidence = 0,
                                    isClue = true
                                };
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
                                cubeCells[cn, digit - 1, c, r] = new CubeCell
                                {
                                    confidence = 1,
                                    isClue = true
                                };
                            }
                            else
                            {
                                cubeCells[cn, digit - 1, c, r] = new CubeCell
                                {
                                    confidence = 0,
                                    isClue = true
                                };
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
                                cubeCells[cn, digit - 1, c, r] = new CubeCell
                                {
                                    confidence = 1,
                                    isClue = true
                                };
                            }
                            else
                            {
                                cubeCells[cn, digit - 1, c, r] = new CubeCell
                                {
                                    confidence = 0,
                                    isClue = true
                                };
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
                                cubeCells[cn, digit - 1, c, r] = new CubeCell
                                {
                                    confidence = 1,
                                    isClue = true
                                };
                            }
                            else
                            {
                                cubeCells[cn, digit - 1, c, r] = new CubeCell
                                {
                                    confidence = 0,
                                    isClue = true
                                };
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
                                cubeCells[cn, digit - 1, c, r] = new CubeCell
                                {
                                    confidence = 1,
                                    isClue = true
                                };
                            }
                            else
                            {
                                cubeCells[cn, digit - 1, c, r] = new CubeCell
                                {
                                    confidence = 0,
                                    isClue = true
                                };
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
                                cubeCells[cn, digit - 1, c, r] = new CubeCell
                                {
                                    confidence = 1,
                                    isClue = true
                                };
                            }
                            else
                            {
                                cubeCells[cn, digit - 1, c, r] = new CubeCell
                                {
                                    confidence = 0,
                                    isClue = true
                                };
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
                                cubeCells[cn, digit - 1, c, r] = new CubeCell
                                {
                                    confidence = 1,
                                    isClue = true
                                };
                            }
                            else
                            {
                                cubeCells[cn, digit - 1, c, r] = new CubeCell
                                {
                                    confidence = 0,
                                    isClue = true
                                };
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
                                cubeCells[cn, digit - 1, c, r] = new CubeCell
                                {
                                    confidence = 1,
                                    isClue = true
                                };
                            }
                            else
                            {
                                cubeCells[cn, digit - 1, c, r] = new CubeCell
                                {
                                    confidence = 0,
                                    isClue = true
                                };
                            }
                        }
                    }
                    break;
            }
        }//end of SetBlockCubeCells
        public FourCube Equalizer()
        {
            FourCube fc;
            fc = setClue();
            for (int i = 0; i < 9; i++)
            {
                for (int k = 0; k < 9; k++)
                {
                    for (int h = 0; h < 9; h++)
                    {
                        double ave = cubeCells[0, i, k, h].confidence + cubeCells[1, i, k, h].confidence
                                       + cubeCells[2, i, k, h].confidence + cubeCells[3, i, k, h].confidence;
                        ave /= 4;
                        fc.cubeCells[0, i, k, h].confidence = ave;
                        fc.cubeCells[1, i, k, h].confidence = ave;
                        fc.cubeCells[2, i, k, h].confidence = ave;
                        fc.cubeCells[3, i, k, h].confidence = ave;
                        
                    }
                }
            }
            return fc;
        }//end of Equalizer
        public FourCube Selector()
        {
            FourCube fc;
            fc = setClue();
            // j = azimuthal k = column h = row

            //selector neuron on 1st cube [0][][][] azimuthal axis
            //---------------------------------------------------------------
            for (int k = 0; k < 9; k++)
            {
                for (int h = 0; h < 9; h++)
                {
                    double maxValue = double.MinValue;
                    int positionOfMax = -1;
                    bool isClueInAzimuthal = false;
                    for (int j = 0; j < 9; j++)
                    {
                        if (cubeCells[0, j, k, h].confidence == 1 && cubeCells[0, j, k, h].isClue == true)
                        {
                            fc.cubeCells[0, j, k, h].confidence = 1;
                            isClueInAzimuthal = true;
                        }
                        else
                        {
                            if (cubeCells[0, j, k, h].confidence > maxValue && cubeCells[0, j, k, h].isClue != true) // && cubeCells[0, j, k, h].confidence != 1
                            {
                                maxValue = cubeCells[0, j, k, h].confidence;
                                positionOfMax = j;
                            }
                            fc.cubeCells[0, j, k, h].confidence = 0;
                       }
                    }
                    if (positionOfMax != -1 && isClueInAzimuthal != true)
                    {
                        fc.cubeCells[0, positionOfMax, k, h].confidence = 1;
                    }
                }
            }
            //selector neuron on 2nd cube [1][][][] column axis (row selector)
            //---------------------------------------------------------------
            for (int j = 0; j < 9; j++)
            {
                for (int h = 0; h < 9; h++)
                {
                    double maxValue = double.MinValue;
                    int positionOfMax = -1;
                    bool isClueColummn = false;
                    for (int k = 0; k < 9; k++)
                    {
                        if (cubeCells[1, j, k, h].confidence == 1 && cubeCells[1, j, k, h].isClue == true)
                        {
                            fc.cubeCells[1, j, k, h].confidence = 1;
                            isClueColummn = true;
                        }
                        else
                       {
                            if (cubeCells[1, j, k, h].confidence > maxValue && cubeCells[1, j, k, h].isClue != true) //&& cubeCells[1, j, k, h].confidence != 1
                            {
                                maxValue = cubeCells[1, j, k, h].confidence;
                                positionOfMax = k;
                            }
                            fc.cubeCells[1, j, k, h].confidence = 0;
                        }
                    }
                    if (positionOfMax != -1 && isClueColummn != true)
                    {
                        fc.cubeCells[1, j, positionOfMax, h].confidence = 1;
                    }
                }
            }
            //selector neuron on 3rd cube [2][][][] row axis (column selector)
            //---------------------------------------------------------------
            for (int k = 0; k < 9; k++)
            {
                for (int j = 0; j < 9; j++)
                {
                    double maxValue = double.MinValue;
                    int positionOfMax = -1;
                    bool isClueInRow= false;
                    for (int h = 0; h < 9; h++)
                    {
                        if (cubeCells[2, j, k, h].confidence == 1 && cubeCells[2, j, k, h].isClue == true)
                        {
                            fc.cubeCells[2, j, k, h].confidence = 1;
                            isClueInRow = true;
                        }
                        else
                        {
                            if (cubeCells[2, j, k, h].confidence > maxValue && cubeCells[2, j, k, h].isClue != true)//  && cubeCells[2, j, k, h].confidence != 1
                            {
                                maxValue = cubeCells[2, j, k, h].confidence;
                                positionOfMax = h;
                            }
                            fc.cubeCells[2, j, k, h].confidence = 0;
                        }
                    }
                    if (positionOfMax != -1 && isClueInRow != true)
                    {
                        fc.cubeCells[2, j, k, positionOfMax].confidence = 1;
                    }
                }
            }
            //selector neuron on 4th cube [3][][][] (block selector)
            //---------------------------------------------------------------
            for (int j = 0; j < 9; j++)
            {
                for (int h = 0; h < 9; h += 3)
                {
                    for (int k = 0; k < 9; k += 3)
                    {
                        double maxValue = double.MinValue;
                        int max_positionH = -1;
                        int max_positionK = -1;
                        bool isClueBlock = false;
                        for (int hh = 0; hh < 3; hh++)
                        {
                            for (int kk = 0; kk < 3; kk++)
                            {
                                if (cubeCells[3, j, (k + kk), (h + hh)].confidence == 1 && cubeCells[3, j, (k + kk), (h + hh)].isClue == true)
                                {
                                    fc.cubeCells[3, j, (k + kk), (h + hh)].confidence = 1;
                                    isClueBlock = true;
                                }
                                else
                                {
                                    if (cubeCells[3, j, (k + kk), (h + hh)].confidence > maxValue && cubeCells[3, j, (k + kk), (h + hh)].isClue != true)//  && cubeCells[3, j, (k + kk), (h + hh)].confidence != 1
                                    {
                                        max_positionH = h + hh;
                                        max_positionK = k + kk;
                                        maxValue = cubeCells[3, j, (k + kk), (h + hh)].confidence;
                                    }
                                    fc.cubeCells[3, j, k + kk, h + hh].confidence = 0;
                                }
                            }
                        }
                        if (max_positionH != -1 && isClueBlock != true) 
                        {
                            fc.cubeCells[3, j, max_positionK, max_positionH].confidence = 1;
                        }
                    }
                }
            }
            return fc;
        }//end of Selector
        public FourCube Add(FourCube fc)
        {
            FourCube fcc;
            fcc = setClue();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        for (int h = 0; h < 9; h++)
                        {
                            fcc.cubeCells[i, j, k, h].confidence = this.cubeCells[i, j, k, h].confidence + fc.cubeCells[i, j, k, h].confidence;
                        }
                    }
                }
            }
            return fcc;
        }//end of Plus
        public FourCube Subtract(FourCube fc)
        {
            FourCube fcc;
            fcc = setClue();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        for (int h = 0; h < 9; h++)
                        {
                            fcc.cubeCells[i, j, k, h].confidence = fc.cubeCells[i, j, k, h].confidence - this.cubeCells[i, j, k, h].confidence;
                        }
                    }
                }
            }
            return fcc;

        }//end of Minus
        public FourCube mult(double multipication)
        {
            FourCube fc;
            fc = setClue();
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

        public bool Comparator(FourCube Ps, FourCube Pe)
        {
            while (true)
            {
                for (int CubeNr = 0; CubeNr < 4; CubeNr++)
                {
                    for (int azimuthal = 0; azimuthal < 9; azimuthal++)
                    {
                        for (int column = 0; column < 9; column++)
                        {
                            for (int row = 0; row < 9; row++)
                            {
                                if (Ps.cubeCells[CubeNr, azimuthal, column, row].confidence == Pe.cubeCells[CubeNr, azimuthal, column, row].confidence)
                                    continue;
                                else
                                    return false;
                            }
                        }
                    }
                }
                return true;
            }
        }
        private FourCube setClue()
        {
            int[,] Clue = new int[9, 9];
            FourCube fc = new FourCube(Clue) { };
            for (int CubeNr = 0; CubeNr < 4; CubeNr++)
            {
                for (int azimuthal = 0; azimuthal < 9; azimuthal++)
                {
                    for (int column = 0; column < 9; column++)
                    {
                        for (int row = 0; row < 9; row++)
                        {
                            fc.cubeCells[CubeNr, azimuthal, column, row].isClue = this.cubeCells[CubeNr, azimuthal, column, row].isClue;
                        }
                    }
                }
            }
            return fc;
        }

        public void StepPrinting(FourCube fc)
        {
            for (int CubeNr = 0; CubeNr < 4; CubeNr++)
            {
                Console.WriteLine("*** cube {0}: ***", CubeNr);
                for (int azimuthal = 0; azimuthal < 9; azimuthal++)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("az {0}:", azimuthal);
                    Console.WriteLine("\n");
                    for (int row = 0; row < 9; row++)
                    {
                        Console.WriteLine("\n");
                        for (int column = 0; column < 9; column++)
                        {
                            if (fc.cubeCells[CubeNr, azimuthal, column, row].isClue)
                            {
                                Console.Write("[{0}]",fc.cubeCells[CubeNr, azimuthal, column, row].confidence);
                            }
                            else
                                Console.Write(" {0} ", fc.cubeCells[CubeNr, azimuthal, column, row].confidence);   
                        }
                    }
                }    
            }
        }

        public int[,] SudokuAnswer(FourCube fc)
        {

            int[,] array = new int[9, 9];
            for (int column = 0; column < 9; column++)
            {
                for (int row = 0; row < 9; row++)
                {
                    double maxValue = double.MinValue;
                    int positionOfMax = -1;
                    bool isClueAzimiuthal = false;
                    int number = 0;
                    for (int azimuthal = 0; azimuthal < 9; azimuthal++)
                    {
                        if (fc.cubeCells[2, azimuthal, column, row].isClue == true && fc.cubeCells[2, azimuthal, column, row].confidence == 1)
                        {
                            isClueAzimiuthal = true;
                            number = azimuthal + 1;
                            array[row, column] = number;
                            break;
                        }
                        else
                        {
                            if (fc.cubeCells[2, azimuthal, column, row].confidence > maxValue && fc.cubeCells[2, azimuthal, column, row].isClue != true)
                            {
                                maxValue = fc.cubeCells[2, azimuthal, column, row].confidence;
                                positionOfMax = azimuthal;
                                number = azimuthal + 1;
                            }
                        }

                    }
                    if (positionOfMax != -1 && isClueAzimiuthal != true)
                    {
                        array[row, column] = number;
                    }


                }
            }
            return array;
        }
    }

   
}
