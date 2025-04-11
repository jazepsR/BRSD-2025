using System;
using UnityEngine;
using UnityEngine.AI;

public class Minion : MonoBehaviour
{
    private Vector3 _targetPosition;
    [SerializeField] private float speed= 10;
    private Rigidbody _rigidbody;  
    private NavMeshAgent _agent;
    private void OnEnable()
    {
        Events.OnClick += GoToClickedPosition;
        
    }

    private void Awake()
    {
        _targetPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
        
    }

    private void OnDisable()
    {
        Events.OnClick -= GoToClickedPosition;
    }

    private void GoToClickedPosition(Vector3 position)
    {
        _targetPosition = position;
        _agent.SetDestination(_targetPosition);
    }
}
