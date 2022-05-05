using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoSingleton<Managers>
{
    private InputManager m_InputManager = new InputManager();
    public InputManager Input
    {
        get
        {
            return m_InputManager;
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
