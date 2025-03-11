using System.Reflection;
using PrototypePattern.Interfaces;

namespace PrototypePattern.Entities
{
    /// <summary>
    /// Звезды, наследуется от <see cref="SpaceObject">базового объекта в космосе</see>.<br/>
    /// Расширяется свойством <see cref="MassOfSun">веса в массах солнца</see>.
    /// </summary>

    public class Star : SpaceObject
    {
        #region Properties

        public double MassOfSun { get; }

        #endregion Properties

        #region Ctor

        public Star(double distanceToEarth, double massOfSun) : base(distanceToEarth)
        {
            MassOfSun = massOfSun;
        }

        protected Star(Star spaceObject) : base(spaceObject)
        {
            MassOfSun = spaceObject.MassOfSun;
        }

        #endregion Ctor

        #region ICloneable

        public override object Clone()
        {
            return new Star(this);
        }

        #endregion

        #region IMyCloneable

        public override Star GetClone()
        {
            return new Star(this);
        }

        #endregion

        #region IEquatable

        public bool Equals(Star? other)
        {
            return
                other != null &&
                base.Equals(other) &&
                MassOfSun == other.MassOfSun;
        }

        public override bool Equals(object? obj)
        {
            return
                obj != null &&
                obj is Star star &&
                Equals(star);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DistanceToEarth, MassOfSun);
        }

        #endregion
    }
}
