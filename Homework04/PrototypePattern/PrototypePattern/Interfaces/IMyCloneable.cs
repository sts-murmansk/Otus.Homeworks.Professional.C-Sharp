namespace PrototypePattern.Interfaces
{
    /// <summary>
    /// Интерфейс для клонирования объектов.
    /// Cодержит <see cref="GetClone"> метод для клонирования</see>.
    /// </summary>

    public interface IMyCloneable<T>
    {
        T GetClone();
    }
}
