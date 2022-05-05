using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    public GameObject Tank;

    void Start()
    {
        Tank = Managers.Resource.Instantiate("Tank");
    }

    void Update()
    {
        
    }
}
