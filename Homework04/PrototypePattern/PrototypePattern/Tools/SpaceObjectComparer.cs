using PrototypePattern.Entities;

namespace PrototypePattern.Tools
{
    public static class SpaceObjectComparer
    {
        public static bool Check<T>(T spaceObject, T clone) where T : SpaceObject
        {
            Console.Write("Оригинал: ");
            SpaceObjectExtension.Print(spaceObject);
            Console.Write("Клон:     ");
            SpaceObjectExtension.Print(clone);
            var result = spaceObject.Equals(clone);
            Console.WriteLine($"Идентичны = {result}");
            return result;
        }
    }
}
