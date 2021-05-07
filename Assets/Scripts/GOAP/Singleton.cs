using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    //private static readonly Lazy<T> LazyInstance = new Lazy<T>(CreateSingleton);
    private static T _instance = null;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = CreateInstance();
                return _instance;
            }
            else
            {
                return _instance;
            }
        }
    }//=> LazyInstance.Value;

    private static T CreateInstance()
    {
        var ownerObject = new GameObject($"{typeof(T).Name} (singleton)");
        var instance = ownerObject.AddComponent<T>();
        DontDestroyOnLoad(ownerObject);
        return instance;
    }
}
