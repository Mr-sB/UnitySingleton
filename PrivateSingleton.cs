using System;
using UnityEngine;

namespace GameUtil
{
    /// <summary>
    /// Lazy. Thread safe. Support private constructor
    /// </summary>
    public abstract class PrivateSingleton<T> where T : PrivateSingleton<T>
    {
        private static readonly object lockObj = new object();
        private static T instance;

        public static bool IsInstance
        {
            get
            {
                lock (lockObj)
                {
                    return instance != null;
                }
            }
        }
        
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
                            try
                            {
                                instance = Activator.CreateInstance(typeof(T), true) as T;
                            }
                            catch (Exception e)
                            {
                                Debug.LogError(e);
                            }
                            finally
                            {
                                instance?.OnStart();
                            }
                        }
                    }
                }

                return instance;
            }
        }

        public static void Remove()
        {
            lock (lockObj)
            {
                if (instance != null)
                {
                    instance.OnRemove();
                    instance = null;
                }
            }
        }
        
        protected virtual void OnStart()
        {
        }

        protected virtual void OnRemove()
        {
        }
    }
}