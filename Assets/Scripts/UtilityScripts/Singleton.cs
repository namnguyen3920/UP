using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Without MonoBehaviour
public class Singleton_Method<T> where T : new()
{
    static T _instance = default(T);

    public static T d_Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = new T();
            }
            return _Instance;
        }
        set
        {
            _Instance = value;
        }
    }
    static T _Instance = default(T);
}
//With MonoBehaviour
public class Singleton_Mono_Method<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T d_Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<T>();
            }
            return _Instance;
        }
        set
        {
            _Instance = value;
        }
    }
    static T _Instance = default(T);
}