/// <summary>
/// Lazy. Thread safe. Public constructor
/// </summary>
public class PublicSingleton<T> where T : PublicSingleton<T>, new()
{
    public static T Instance => Nested.Instance;
    private static class Nested
    {
        internal static readonly T Instance = new T();
    }
}