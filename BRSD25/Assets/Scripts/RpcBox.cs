using PurrNet;
using UnityEngine;

public class RpcBox : NetworkBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SetColor(Color.blue);   
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SetColor(Color.red); 
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SetColor(Color.yellow); 
        if (Input.GetKeyDown(KeyCode.Alpha4))
            SetColor(Color.green);
        
    }

    [ServerRpc(requireOwnership: false)]
    private void SetColor(Color color,RPCInfo info = default)
    {
        SetColor_Target(info.sender,color);
    }

    [TargetRpc]
    private void SetColor_Target(PlayerID target, Color color)
    {
        GetComponent<Renderer>().material.color = color;    
        
    }
}
