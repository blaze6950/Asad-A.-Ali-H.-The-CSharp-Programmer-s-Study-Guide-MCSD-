using System;
using System.Collections.Generic;
using System.Threading;

namespace Challenge_5_Develop_Steve_Jobs_Laundry_System
{
    public class LaundryObj
    {
        private List<Clothes> _bagOfClothes;
        private string _bestLaundryPlaceAdress;
        private double _pocketMoney;

        public LaundryObj()
        {
            Initial();
        }

        public LaundryObj(params Clothes[] clothes)
        {
            Initial();
            _bagOfClothes.AddRange(clothes);
        }

        public LaundryObj(List<Clothes> bagOfClothes)
        {
            Initial();
            _bagOfClothes = bagOfClothes;
        }

        private void Initial()
        {
            _bagOfClothes = new List<Clothes>();
            _bestLaundryPlaceAdress = "Frantsuz'ky Bulvar, 66";
            _pocketMoney = 300.0;
        }

        public List<Clothes> BagOfClothes
        {
            get { return _bagOfClothes; }
        }

        public double PocketMoney
        {
            get { return _pocketMoney; }
            set { _pocketMoney = value; }
        }

        public List<Clothes> GetClothesLaundered()
        {
            if (_bagOfClothes.Count > 0)
            {
                return DoWork();
            }
            else
            {
                Console.WriteLine("Please, give me your dirty clothes!");
                return null;
            }
        }

        private List<Clothes> DoWork()
        {
            GoOut();
            Thread.Sleep(500);
            HailATaxicab();
            Thread.Sleep(500);
            GoIntoBestLaundryPlace();
            Thread.Sleep(500);
            WaitingForWashing();
            Thread.Sleep(500);
            PayForServices();
            Thread.Sleep(500);
            HailATaxicab();
            Thread.Sleep(500);
            GoBack();
            Thread.Sleep(500);
            return GiveYouCleanClothes();
        }

        private List<Clothes> GiveYouCleanClothes()
        {
            Console.WriteLine("Here are your clean clothes.");
            var buf = _bagOfClothes;
            _bagOfClothes = new List<Clothes>();
            return buf;
        }

        private void GoBack()
        {
            Console.WriteLine("Going back for give you your clean clothes!");
        }

        private void PayForServices()
        {
            var cost = new Random(DateTime.Now.Second).Next(0, 100);
            if (_pocketMoney - cost < 0)
            {
                Console.WriteLine("Insufficient money, write-off from a credit account!");
                _pocketMoney = 0;
            }
            else
            {
                _pocketMoney -= cost;
            }
        Console.WriteLine($"Paying money ({cost}), Money left: {_pocketMoney}");
        }

        private void WaitingForWashing()
        {
            Console.WriteLine("Waiting for washing...");
            foreach (var clothes in _bagOfClothes)
            {
                clothes.LastWash = DateTime.Now;
            }
        }

        private void GoIntoBestLaundryPlace()
        {
            Console.WriteLine($"Going to {_bestLaundryPlaceAdress}...");
        }

        private void HailATaxicab()
        {
            Console.WriteLine("Hailing a taxicab...");
        }

        private void GoOut()
        {
            Console.WriteLine("I'm go out...");
        }
    }
}