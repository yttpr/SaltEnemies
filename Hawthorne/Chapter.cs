using System;
using System.Collections.Generic;
using System.Text;

namespace Hawthorne
{
    public static class Chapter
    {
        static UnlockItem _one;
        public static UnlockItem One
        {
            get
            {
                if (_one == null)
                {

                }
                return _one;
            }
        }
    }
}
