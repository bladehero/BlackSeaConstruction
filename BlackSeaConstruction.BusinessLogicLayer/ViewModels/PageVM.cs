using System.Collections.Generic;
using System.Linq;
using static System.Math;

namespace BlackSeaConstruction.BusinessLogicLayer.ViewModels
{
    public class PageVM
    {
        public const int CountPages = 5;
        public static readonly int[] Sizes = new int[] { 5, 10, 25, 50 };

        public int Number { get; }
        public int Total { get; }
        public int Size { get; }
        public int Count { get; }
        public IEnumerable<int> Pages
        {
            get
            {
                IEnumerable<int> pages = null;
                var averageOfStart = (int)Ceiling(CountPages / 2.0);
                var averageOfEnd = (int)Floor((Total - CountPages) + (CountPages / 2.0));
                if (Total < CountPages)
                {
                    pages = Enumerable.Range(1, Total);
                }
                else if (Number <= averageOfStart)
                {
                    pages = Enumerable.Range(1, CountPages);
                }
                else if (Number > averageOfStart && Number < averageOfEnd)
                {
                    pages = Enumerable.Range(Number - averageOfStart, CountPages);
                }
                else
                {
                    pages = Enumerable.Range(Total - CountPages + 1, CountPages);
                }
                return pages;
            }
        }

        public PageVM(int count, int number, int size)
        {
            Number = number;
            Size = size;
            Count = count;
            Total = (int)Ceiling(count / (double)size);
        }

        public int Skip => Size * (Number - 1);
        public bool HasPreviousPage => (Number > 1);
        public bool HasNextPage => (Number < Total);
    }
}