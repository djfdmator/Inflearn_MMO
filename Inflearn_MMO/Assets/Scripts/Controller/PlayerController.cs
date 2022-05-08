using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Creature
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
        Managers.Input.MouseAction -= Input_MouseClicked;
        Managers.Input.MouseAction += Input_MouseClicked;

        Managers.UI.ShowSceneUI<UI_Inven>();
        //Managers.UI.ClosePopupUI();
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

    public void MoveForward()
    {
        transform.position += Vector3.forward * Time.deltaTime * MoveSpeed;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
    }

    public void MoveBack()
    {
        transform.position += Vector3.back * Time.deltaTime * MoveSpeed;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
    }

    public void MoveRight()
    {
        transform.position += Vector3.right * Time.deltaTime * MoveSpeed;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
    }

    public void MoveLeft()
    {
        transform.position += Vector3.left * Time.deltaTime * MoveSpeed;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
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
