using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {


    }

    private void OnTriggerEnter(Collider other)
    {

    }
    void Start()
    {

    }

    void Update()
    {
        Debug.DrawRay(transform.position + Vector3.up, transform.forward * 10, Color.red);

        RaycastHit[] hitAll = Physics.RaycastAll(transform.position + Vector3.up, transform.forward, 10);
        foreach(RaycastHit obj in hitAll)
        {
            Debug.Log($"Raycast : {obj.collider.gameObject.name}!");
        }

        //RaycastHit hit;
        //if (Physics.Raycast(transform.position + Vector3.up, transform.forward, out hit, 10))
        //{
        //    Debug.Log($"Raycast : {hit.collider.gameObject.name}!");

        //}
    }
}
