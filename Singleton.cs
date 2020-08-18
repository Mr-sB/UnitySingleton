namespace GameUtil
{
    /// <summary>
    /// Lazy. Thread safe. Public constructor
    /// </summary>
    public abstract class Singleton<T> where T : Singleton<T>, new()
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
                            instance = new T();
                            instance.OnStart();
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