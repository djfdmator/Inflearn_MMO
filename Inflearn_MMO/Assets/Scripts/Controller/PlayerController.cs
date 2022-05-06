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

    public enum PlayerState
    {
        Idle,
        Die,
        Moving
    }
    PlayerState _state;

    [SerializeField]
    private Animator _animator;

    Vector3 _destPos;

    private void Awake()
    {
        _state = PlayerState.Idle;
        if (_animator == null)
            _animator = GetComponent<Animator>();
    }

    void Start()
    {
        Managers.Input.KeyAction -= Input_Keyboard;
        Managers.Input.KeyAction += Input_Keyboard;

        Managers.Input.MouseAction -= Input_MouseClicked;
        Managers.Input.MouseAction += Input_MouseClicked;
    }

    void Update()
    {
        switch (_state)
        {
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
        }
    }

    void Input_Keyboard()
    {
        float dt = Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * dt * MoveSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * dt * MoveSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * dt * MoveSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * dt * MoveSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
        }
    }

    void Input_MouseClicked(Define.MouseEvent evt)
    {
        if (_state == PlayerState.Die)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {
            _destPos = hit.point;
            _state = PlayerState.Moving;
        }
    }

    #region Animation
    void UpdateIdle()
    {
        _animator.SetFloat("Speed", 0.0f);
    }

    void UpdateDie()
    {

    }

    void UpdateMoving()
    {
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.0001f)
        {
            _state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(m_MoveSpeed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10.0f * Time.deltaTime);
        }

        _animator.SetFloat("Speed", m_MoveSpeed);
    }

    void OnRunEvent()
    {
        Debug.Log("Run");
    }

    #endregion
}
