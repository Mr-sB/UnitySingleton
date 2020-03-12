/// <summary>
/// Lazy. Thread safe. Support private constructor
/// </summary>
public abstract class PrivateSingleton<T> where T : PrivateSingleton<T>
{
    //Lazy
    public static T Instance => Nested.Instance;
    private static class Nested
    {
        //Thread safe
        internal static readonly T Instance = System.Activator.CreateInstance(typeof(T), true) as T;
    }
}