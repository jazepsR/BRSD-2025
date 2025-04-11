using UnityEngine;
using PurrNet;

public class CubeSpawner : NetworkBehaviour
{
    public GameObject cubePrefab;

    private GameObject _currentCube;
    protected override void OnSpawned()
    {
        base.OnSpawned();
        enabled = isOwner;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_currentCube != null)
                Destroy(_currentCube);  
            _currentCube= Instantiate(cubePrefab, transform.position + transform.forward, transform.rotation);
            
        }
    }
}
