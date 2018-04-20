using System;

namespace CALCULATOR
{


    class calculator
    {
        public double pi = Math.PI;
        public double e = Math.E;

        public double sub(ref double x, ref double y)
        {
            double res;
            res = x - y;
            return res;
        }

        public double add(ref double x, ref double y)
        {
            double res;
            res = x + y;
            return res;
        }

        public double div(ref double x, ref double y)
        {
            double res;
            res = x / y;
            return res;
        }

        public double mul(ref double x, ref double y)
        {
            double res;
            res = x * y;
            return res;
        }

        public double sinx(ref double x)
        {
            double res = 0;
            x *= Math.PI / 180;
            res = Math.Sin(x);
            return res;
        }

        public double cosx(ref double x)
        {
            double res = 0;
            x *= Math.PI / 180;
            res = Math.Cos(x);
            return res;
        }

        public double tanx(ref double x)
        {
            double res;
            x *= Math.PI / 180;
            res = Math.Tan(x);
            return res;
        }

        public int fac(ref int x)
        {
            int res = 1;
            for (int i = 1; i <= x; i++)
            {
                res = res * i;
            }
            return res;
        }

        public double per(ref double x)
        {
            double res;
            res = x / 100;
            return res;
        }

        public double sqrtu(ref double x)
        {
            double res;
            res = Math.Sqrt(x);
            return res;
        }

        public double powu(ref double x, ref double y)
        {
            double res;
            res = Math.Pow(x, y);
            return res;
        }

        public double ln(ref double x)
        {
            double res;
            res = Math.Log(x);
            return res;
        }

    }
}