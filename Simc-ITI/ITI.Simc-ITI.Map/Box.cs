using System;
using System.Drawing;

namespace ITI.Simc_ITI
{
    public class Box
    {
        [field: NonSerialized]
        Graphics g, screeng;
        [field: NonSerialized]
        Pen _p = new Pen(Color.DimGray);
        readonly Map _map;
        readonly int _line;
        readonly int _column;
        private bool _selected = false;
        IInfrastructureForBox Infrastructure;

        public Box(Map map, int line, int column)
        {
            this.map = map;
            this.j = line;
            this.i = column;
        }
    }
}