using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyMatrixSymbolsDrop
{
    class SymbDot
    {
        public Coordinates CurrentCoordinates { get; set; }

        public Coordinates SpawnCoordinates { get; set; }

        public char CurrentSymb { get; set; }

        public SymbDot() => CurrentCoordinates = SpawnCoordinates;


    }
}
