
namespace PrototypePattern.Entities
{
    /// <summary>
    /// Черная дыра, наследуется от <see cref="Star">звезды</see>.<br/>
    /// Расширяется свойством <see cref="IsGalacticCore">принадледности к ядру галактики</see>.
    /// </summary>

    public class Blackhole : Star
    {
        #region Properties

        public bool IsGalacticCore { get; }

        #endregion Properties

        #region Ctor

        public Blackhole(double distanceToEarth, double massOfSun, bool isGalacticCore) : base(distanceToEarth, massOfSun)
        {
            IsGalacticCore = isGalacticCore;
        }

        protected Blackhole(Blackhole spaceObject) : base(spaceObject)
        {
            IsGalacticCore = spaceObject.IsGalacticCore;
        }

        #endregion Ctor

        #region ICloneable

        public override object Clone()
        {
            return new Blackhole(this);
        }

        #endregion

        #region IMyCloneable

        public override Blackhole GetClone()
        {
            return new Blackhole(this);
        }

        #endregion

        #region IEquatable

        public bool Equals(Blackhole? other)
        {
            return
                other != null &&
                base.Equals(other) &&
                IsGalacticCore == other.IsGalacticCore;
        }

        public override bool Equals(object? obj)
        {
            return
                obj != null &&
                obj is Blackhole blackHole &&
                Equals(blackHole);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DistanceToEarth, MassOfSun, IsGalacticCore);
        }

        #endregion
    }
}
