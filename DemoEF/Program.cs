using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF
{
    class Program
    {
        static void Main(string[] args)
        {
            blockChainEntities db = new blockChainEntities();
            var bloks = db.blocks.Where(b => b.index > 100).ToList();
            var block = new block();
            db.blocks.Add(block);
            db.SaveChanges();

        }
    }
}
