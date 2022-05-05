using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Managers _managers;

    // Start is called before the first frame update
    void Start()
    {
        _managers = Managers.Instance;
        _managers.Hello();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
