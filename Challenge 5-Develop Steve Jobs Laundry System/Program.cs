using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5_Develop_Steve_Jobs_Laundry_System
{
    class Program
    {
        private static LaundryObj _laundryObj;

        static void Main(string[] args)
        {
            List<Clothes> _mineClothes = new List<Clothes>();
            for (int i = 0; i < 10; i++)
            {
                _mineClothes.Add(new Clothes("T-Shirt", DateTime.Now - TimeSpan.FromDays(i + 4)));
            }
            _laundryObj = new LaundryObj(_mineClothes);
            _laundryObj.GetClothesLaundered();
        }
    }
}
