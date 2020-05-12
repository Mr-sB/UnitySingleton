/// <summary>
/// Lazy. Thread safe. Public constructor
/// </summary>
public abstract class Singleton<T> where T : Singleton<T>, new()
{
    //Lazy
    public static T Instance => Nested.Instance;
    private static class Nested
    {
        //Thread safe
        internal static readonly T Instance = new T();
    }
}