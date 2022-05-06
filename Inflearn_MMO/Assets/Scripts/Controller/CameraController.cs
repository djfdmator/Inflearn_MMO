using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Define.CameraMode _mode = Define.CameraMode.QuarterView;

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private Vector3 _distance_FromPlayer;
    private float _Radius_FromPlayer;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        if(_player != null)
        {
            RaycastHit hit;
            if(Physics.Raycast(_player.transform.position, _distance_FromPlayer, out hit, _distance_FromPlayer.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - _player.transform.position).magnitude;
                transform.position = _player.transform.position + _distance_FromPlayer.normalized * dist;
            }
            else
            {
                transform.position = _player.transform.position + _distance_FromPlayer;
                transform.LookAt(_player.transform);
            }
        }
    }

    public void SetQuarterView(Vector3 distance)
    {
        _mode = Define.CameraMode.QuarterView;
        _distance_FromPlayer = distance;
    }
}
