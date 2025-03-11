using PrototypePattern.Entities;
using PrototypePattern.Interfaces;

namespace PrototypePattern.Factories
{
    public class SpaceObjectFactory : IFactory<SpaceObject>
    {
        public SpaceObject Create()
        {
            Random rnd = new Random();
            return new SpaceObject(rnd.NextInt64());
        }
    }
}
