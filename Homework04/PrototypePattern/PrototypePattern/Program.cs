using PrototypePattern.Tests;

namespace PrototypePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICloneableTest.Run();
            IMyCloneableTest.Run();
        }
    }
}
