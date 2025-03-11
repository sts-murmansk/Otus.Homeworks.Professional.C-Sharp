
using PrototypePattern.Entities;
using PrototypePattern.Interfaces;

namespace PrototypePattern.Factories
{
    class BlackholeFactory : IFactory<Blackhole>
    {
        public Blackhole Create()
        {
            Random rnd = new Random();
            return new Blackhole(rnd.NextInt64(), rnd.NextInt64(10, 100_000_000_000), rnd.Next(2) == 1);
        }
    }
}
