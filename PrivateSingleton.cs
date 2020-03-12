/// <summary>
/// Lazy. Thread safe. Support private constructor
/// </summary>
public class PrivateSingleton<T> where T : PrivateSingleton<T>
{
    public static T Instance => Nested.Instance;
    private static class Nested
    {
        internal static readonly T Instance = System.Activator.CreateInstance(typeof(T), true) as T;
    }
}