/// <summary>
/// Lazy. Thread safe. Public constructor
/// </summary>
public class PublicSingleton<T> where T : PublicSingleton<T>, new()
{
    //Lazy
    public static T Instance => Nested.Instance;
    private static class Nested
    {
        //Thread safe
        internal static readonly T Instance = new T();
    }
}