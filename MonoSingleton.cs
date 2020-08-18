using UnityEngine;

namespace GameUtil
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>, new()
    {
#if UNITY_EDITOR
        protected static bool IsApplicationQuit { private set; get; }
#endif

        private static T instance;

        public static T Instance
        {
            get
            {
                //Avoid calling Instance in OnDestroy method to cause error when application quit
#if UNITY_EDITOR
                if (IsApplicationQuit)
                {
                    // ReSharper disable once Unity.IncorrectMonoBehaviourInstantiation
                    return new T();
                }
#endif
                if (instance == null)
                {
                    //Find
                    instance = FindObjectOfType<T>();
                    //Create
                    if (instance == null)
                    {
                        var go = new GameObject(typeof(T).Name);
                        instance = go.AddComponent<T>();
                        DontDestroyOnLoad(go);
                    }
                }

                return instance;
            }
        }

        protected virtual void Awake()
        {
            if (instance == null)
                instance = this as T;
            else if (this != instance)
                Destroy(this);
        }

#if UNITY_EDITOR
        private void OnApplicationQuit()
        {
            IsApplicationQuit = true;
        }
#endif
    }
}