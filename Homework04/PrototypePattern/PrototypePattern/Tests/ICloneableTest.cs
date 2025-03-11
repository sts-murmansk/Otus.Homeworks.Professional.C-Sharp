
using PrototypePattern.Entities;
using PrototypePattern.Factories;
using PrototypePattern.Tools;

namespace PrototypePattern.Tests
{
    internal static class ICloneableTest
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine("Проверка ICloneable:");
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 30)));
            bool result = true;

            Console.WriteLine("Проверяем SpaceObject");
            SpaceObject spaceObject = new SpaceObjectFactory().Create();
            if (spaceObject.Clone() is SpaceObject spaceObjectClone)
                result &= SpaceObjectComparer.Check(spaceObject, spaceObjectClone);

            Console.WriteLine("Проверяем Star");
            Star star = new StarFactory().Create();
            if (star.Clone() is Star starClone)
                result &= SpaceObjectComparer.Check(star, starClone);

            Console.WriteLine("Проверяем Blackhole");
            Blackhole blackhole = new BlackholeFactory().Create();
            if (blackhole.Clone() is Blackhole blackholeClone)
                result &= SpaceObjectComparer.Check(blackhole, blackholeClone);

            if (result)
                Console.WriteLine("Ошибок не обнаружено, все клонировалось.");
            else
                Console.WriteLine("Обнаружены ошибки клонирования.");
        }
    }
}
