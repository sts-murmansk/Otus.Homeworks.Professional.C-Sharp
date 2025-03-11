using System.Reflection;
using PrototypePattern.Interfaces;

namespace PrototypePattern.Entities
{
    /// <summary>
    /// Базовый класс для космического объекта.<br/>
    /// Cодержит <see cref="DistanceToEarth">расстояние до земли в световых годах</see>.
    /// </summary>

    public class SpaceObject : ICloneable, IMyCloneable<SpaceObject>, IEquatable<SpaceObject>
    {
        #region Properties

        public double DistanceToEarth { get; }

        #endregion

        #region Ctor

        public SpaceObject(double distanceToEarth)
        {
            DistanceToEarth = distanceToEarth;
        }

        protected SpaceObject(SpaceObject spaceObject)
        {
            DistanceToEarth = spaceObject.DistanceToEarth;
        }

        #endregion

        #region ICloneable

        public virtual object Clone()
        {
            return new SpaceObject(this);
        }

        #endregion

        #region IMyCloneable

        public virtual SpaceObject GetClone()
        {
            return new SpaceObject(this);
        }

        #endregion

        #region IEquatable

        public bool Equals(SpaceObject? other)
        {
            return
                other != null &&
                DistanceToEarth == other.DistanceToEarth;
        }

        public override bool Equals(object? obj)
        {
            return
                obj != null &&
                obj is SpaceObject spaceObject &&
                Equals(spaceObject);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DistanceToEarth);
        }

        #endregion
    }

    public static class SpaceObjectExtension
    {
        public static void Print(SpaceObject spaceObject)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            foreach (var prop in spaceObject.GetType().GetProperties())
            {
                var value = prop.GetValue(spaceObject);
                if (value != null)
                    values.Add(prop.Name, value.ToString() ?? String.Empty);
            }

            string info = string.Join("; ", values.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
            Console.WriteLine($"{spaceObject.GetType().Name} - {info}");

        }
    }
 }
