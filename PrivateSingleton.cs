namespace GameUtil
{
    /// <summary>
    /// Lazy. Thread safe. Support private constructor
    /// </summary>
    public abstract class PrivateSingleton<T> where T : PrivateSingleton<T>
    {
        private static readonly object lockObj = new object();
        private static T instance;

        public static T Instance
        {
            //Lazy
            get
            {
                if (instance == null)
                {
                    //Thread safe
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = System.Activator.CreateInstance(typeof(T), true) as T;
                            instance?.OnStart();
                        }
                    }
                }

                return instance;
            }
        }

        protected virtual void OnStart()
        {
        }
    }
}