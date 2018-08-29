using System;
using System.ComponentModel;

namespace Challenge_7_Student_Report_Card_Application
{
    public class ReportCard
    {
        private int _computerScience;
        private int _math;
        private int _english;
        public event PropertyChangedEventHandler Result;

        public ReportCard(int computerScience = -1, int math = -1, int english = -1)
        {
            _computerScience = computerScience;
            _math = math;
            _english = english;
        }

        public int Sum
        {
            get => _computerScience + _math + _english;
        }

        public int ComputerScience
        {
            get { return _computerScience; }
            set
            {
                if (value <= 50 && value >= 0)
                {
                    _computerScience = value;
                    Check();
                }
            }
        }

        public int Math
        {
            get { return _math; }
            set
            {
                if (value <= 50 && value >= 0)
                {
                    _math = value;
                    Check();
                }
            }
        }

        public int English
        {
            get { return _english; }
            set
            {
                if (value <= 50 && value >= 0)
                {
                    _english = value;
                    Check();
                }
            }
        }

        private void Check()
        {
            if (ComputerScience > 0 && Math > 0 && English > 0)
            {
                Result.Invoke(this, new PropertyChangedEventArgs(Sum.ToString()));
            }
        }
    }
}