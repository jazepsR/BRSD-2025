using System;
using UnityEngine;

public class Minion : MonoBehaviour
{
    private Vector3 _targetPosition;
    [SerializeField] private float speed= 10;
    private Rigidbody _rigidbody;
    private void OnEnable()
    {
        Events.OnClick += GoToClickedPosition;
        
    }

    private void Awake()
    {
        _targetPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _targetPosition) > 1f)
        {
            _rigidbody.AddForce(Vector3.Normalize( _targetPosition- transform.position) * (speed * Time.deltaTime), ForceMode.VelocityChange);
            
        }
    }

    private void OnDisable()
    {
        Events.OnClick -= GoToClickedPosition;
    }

    private void GoToClickedPosition(Vector3 position)
    {
        _targetPosition = position;
    }
}
