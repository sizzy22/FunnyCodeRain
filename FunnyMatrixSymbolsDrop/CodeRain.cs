using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FunnyMatrixSymbolsDrop
{
    class CodeRain
    {

        //Update page time
        public double UpdateTime = 0.3;

        private Random rnd = new Random();

        //Your console screen width
        private int _screenWidth;
        //Your console screen height
        private int _screenHeight;
        private char[,] _map;
        private char[] _symbs;
        private char empty = ' ';
        private ICollection<SymbDot> symbDots;
        public CodeRain(int screenWidth, int screenHeight, char[] symbs)
        {
            _screenHeight = screenHeight;
            _screenWidth = screenWidth;
            _symbs = symbs;
            _map = new char[_screenHeight, _screenWidth];
            symbDots = new List<SymbDot>();
        }

        public void OnFrame()
        {

            //YOU CAN UNCOMMENT THIS
            //Console.Clear();
            SpawnSymb();
            Entrying();
            Conclusion();

            symbDots = symbDots.Where(dot => dot.CurrentCoordinates.Y >= 0 && dot.CurrentCoordinates.Y < _screenHeight).ToList();


            foreach (SymbDot dot in symbDots)
            {
                dot.CurrentCoordinates.Y++;
                dot.CurrentSymb = _symbs[rnd.Next(0, _symbs.Length)];
            }

            Thread.Sleep((int)(UpdateTime * 1000));
        }

        private void Entrying()
        {
            for (int row = 0; row < _screenHeight; row++)
            {
                for (int cow = 0; cow < _screenWidth; cow++)
                {
                    _map[row, cow] = empty;
                }
            }

            foreach (SymbDot dot in symbDots)   
            {
                int y = dot.CurrentCoordinates.Y;

                for (int i = 0; i <= y - dot.SpawnCoordinates.Y; i++)
                {
                    int yi = y - i;
                    if (yi >= 0 && yi < _screenHeight)
                        _map[yi, dot.CurrentCoordinates.X] = _symbs[rnd.Next(_symbs.Length)];


                }
            }
        }

        private void Conclusion()
        {
            string result = "";
            for (int row = 0; row < _screenHeight; row++)
            {
                for (int cow = 0; cow < _screenWidth; cow++)
                {
                    result += _map[row, cow];
                }
                result += "\n";
            }

            Console.WriteLine(result);
        }

        private void SpawnSymb()
        {
            int x = rnd.Next(0, _screenWidth);
            int y = rnd.Next(0, _screenHeight / 2);
            symbDots.Add(new SymbDot
            {
                SpawnCoordinates = new Coordinates { X = x, Y = y },
                CurrentCoordinates = new Coordinates { X = x, Y = y },
                CurrentSymb = _symbs[rnd.Next(0, _symbs.Length)]
            });
        }

    }
}
