using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrototypePattern.Entities;
using PrototypePattern.Interfaces;

namespace PrototypePattern.Factories
{
    class StarFactory : IFactory<Star>
    {
        public Star Create()
        {
            Random rnd = new Random();
            return new Star(rnd.NextInt64(), rnd.Next(1, 4000) / 10);
        }
    }
}
