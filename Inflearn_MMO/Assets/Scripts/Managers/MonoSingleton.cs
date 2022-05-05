using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool ms_ShuttingDown = false;

    private static object ms_Lock = new object();
    private static T ms_Instance;

    public static T Instance
    {
        get
        {
            if(ms_ShuttingDown)
            {
                return null;
            }

            lock(ms_Lock)
            {
                if(ms_Instance == null)
                {
                    ms_Instance = (T)FindObjectOfType(typeof(T));

                    if(ms_Instance == null)
                    {
                        GameObject go = new GameObject(typeof(T).ToString() + " (Singleton)");
                        ms_Instance = go.AddComponent<T>();

                        DontDestroyOnLoad(go);
                    }
                }

                return ms_Instance;
            }
        }
    }

    private void OnApplicationQuit()
    {
        ms_ShuttingDown = true;
    }

    private void OnDestroy()
    {
        ms_ShuttingDown = true;
    }
}
