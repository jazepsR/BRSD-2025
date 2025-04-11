using PurrNet;
using UnityEngine;

public class Necromancer : NetworkBehaviour
{
    [SerializeField] private float reviveRange = 10;
    [SerializeField] private LayerMask layerMask;
    private Collider[] _colliders= new Collider[10];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
            CastRevive(transform.position,reviveRange);
    }
    
    void CastRevive(Vector3 center, float radius)
    {
        var size = Physics.OverlapSphereNonAlloc(center, radius, _colliders, layerMask);
        foreach (var hitCollider in _colliders)
        {
            if (hitCollider!= null && hitCollider.TryGetComponent(out Reviveable reviveable))
            {
                reviveable.ReviveChar();
            }
        }
    }
}
