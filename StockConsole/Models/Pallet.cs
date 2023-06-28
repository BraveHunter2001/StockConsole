using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockConsole.Models
{
    public class Pallet : StockItem, IEnumerable<Box>
    {
        public const int WEIGHT_ONLY_PALLET = 30;
      
        public List<Box> Boxes {  get; private set; } = new List<Box>();

        public override DateOnly ExpirationDate { get; set; }

        public Pallet(int id, int width, int heigth, int depth) { 
            ID = id;
            Weight += WEIGHT_ONLY_PALLET;
            Width = width;
            Height = heigth;
            Depth = depth;
            Volume = width * heigth * depth;
        }

        public Pallet(int id, int width, int heigth, int depth, IEnumerable<Box> boxes) : this (id,width, heigth, depth) 
        {
            AddRange(boxes);
        }


        public void AddRange(IEnumerable<Box> boxes)
        {
            foreach (Box box in boxes)
            {
                Add(box);
            }
        }

        public void Add(Box box)
        {
            if (box.Width > Width || box.Depth > Depth)
                throw new Exception("Box is large");

            Boxes.Add(box);

            var minDate = Boxes.Min(box => box.ExpirationDate);
            ExpirationDate = minDate;

            Weight += box.Weight;
            Volume += box.Volume;
        }

        public void Remove(Box box)
        {
            Weight -= box.Weight;
            Volume -= box.Volume;
            Boxes.Remove(box);
            var minDate = Boxes.Min(box => box.ExpirationDate);
            ExpirationDate = minDate;
        }

        public override string ToString()
        {
            return $"PALLET {ID}: Width[{Width}]" +
                $" Heigth[{Height}]" +
                $" Depth[{Depth}]" +
                $" Weight[{Weight}]" +
                $" Volume[{Volume}]" +
                $" DateExp[{ExpirationDate}]";
        }

        IEnumerator<Box> IEnumerable<Box>.GetEnumerator()
        {
            return Boxes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Boxes.GetEnumerator();
        }
    }
}
