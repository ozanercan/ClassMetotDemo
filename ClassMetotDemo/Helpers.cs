using System;
using System.Collections.Generic;
using System.Text;

namespace ClassMetotDemo
{
    internal static class Helpers
    {
        static Random _random = new Random();

        internal static int CreateNewId()
        {
            return _random.Next(10000, 255555);
        }
    }
}
