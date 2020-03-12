using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>, new()
{
#if UNITY_EDITOR
    private static bool _onApplicationQuit;
#endif

    protected static T instance;
    public static T Instance
    {
        get
        {
            //Aviod calling Instance in OnDestroy method to cause error when application quit
#if UNITY_EDITOR
            if (_onApplicationQuit)
            {
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
        if(instance == null)
            instance = this as T;
    }

#if UNITY_EDITOR
    private void OnApplicationQuit()
    {
        _onApplicationQuit = true;
    }
#endif
}
