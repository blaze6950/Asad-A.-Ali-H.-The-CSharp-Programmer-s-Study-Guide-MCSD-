using System;
using System.Collections.Generic;

namespace Challenge_5_Develop_Steve_Jobs_Laundry_System
{
    class Program
    {
        private static LaundryObj _laundryObj;

        static void Main()
        {
            List<Clothes> mineClothes = new List<Clothes>();
            for (int i = 0; i < 10; i++)
            {
                mineClothes.Add(new Clothes("T-Shirt", DateTime.Now - TimeSpan.FromDays(i + 4)));
            }
            _laundryObj = new LaundryObj(mineClothes);
            _laundryObj.GetClothesLaundered();
        }
    }
}
