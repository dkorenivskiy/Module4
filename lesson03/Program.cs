using lesson03.DbItems;
using System;

namespace lesson03
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ApplicationContext())
            {
                db.SaveChanges();
            }
        }
    }
}
