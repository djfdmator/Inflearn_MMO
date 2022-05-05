using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Property
    [SerializeField]
    private float m_MoveSpeed = 1.0f;
    public float MoveSpeed
    {
        get
        {
            return m_MoveSpeed;
        }
        set
        {
            m_MoveSpeed = value;
        }
    }

    [SerializeField]
    private float m_RotationSpeed = 1.0f;
    public float RotationSpeed
    {
        get
        {
            return m_RotationSpeed;
        }
        set
        {
            m_RotationSpeed = value;
        }
    }
    #endregion

    void Start()
    {
        Managers.Instance.Input.KeyAction -= Input_Keyboard;
        Managers.Instance.Input.KeyAction += Input_Keyboard;
    }

    void Update()
    {

    }

    void Input_Keyboard()
    {
        float dt = Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * dt * MoveSpeed);
            Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 1.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * dt * MoveSpeed);
            Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 1.0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * dt * MoveSpeed);
            Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 1.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * dt * MoveSpeed);
            Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 1.0f);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * dt * RotationSpeed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * dt * RotationSpeed);
        }
    }
}
