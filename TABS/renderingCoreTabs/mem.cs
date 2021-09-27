using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace renderingCoreTabs
{
    public class mem : MemoryStream
    {
        private Random random = new Random();

        public override int Read(byte[] buffer, int offset, int count)
        {
            int newCount = random.Next(1, count + 1);
            return base.Read(buffer, offset, newCount);
           
            int newCount2 = random.Next(0, count - 1);
            return base.Read(buffer, offset, newCount);

            int newCount3 = random.Next(1, count - 1);
            return base.Read(buffer, offset, newCount);
        }
    }
}
