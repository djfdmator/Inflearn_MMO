using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoSingleton<Managers>
{
    private InputManager m_InputManager = new InputManager();
    public static InputManager Input
    {
        get
        {
            return Instance.m_InputManager;
        }
    }

    private ResourceManager m_ResourceManager = new ResourceManager();
    public static ResourceManager Resource
    {
        get
        {
            return Instance.m_ResourceManager;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Input.OnUpdate();
    }

    public void Hello()
    {
        Debug.Log("Hello");
    }
}
