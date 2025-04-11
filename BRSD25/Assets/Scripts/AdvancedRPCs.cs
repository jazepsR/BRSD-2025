using System.Threading.Tasks;
using PurrNet;
using UnityEngine;

public class AdvancedRPCs : NetworkBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    async void  Update()
    {


        bool myResult = false;
        if(Input.GetKeyDown(KeyCode.X))
        {
            myResult = await MyMixedRPC((1));
            Debug.Log($"myResult:{myResult}");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            myResult = await MyMixedRPC("afe");

            Debug.Log($"myResult:{myResult}");
        }

    }

    [ServerRpc(requireOwnership:false)]
    public static void MyStaticRPC(string msg)
    {
        Debug.Log(msg); 
    }

    [ServerRpc(requireOwnership: false)]
    private void MyGenericRPC<T>(T data)
    {
        Debug.Log($"Received generic data:{data}| type: {typeof(T)}");
    }

    [ServerRpc(requireOwnership: false)]
    private async Task<bool> MyAwaitRPC(int MyInput)
    {
        await Task.Delay(1000);
        
        return MyInput>0;
    }


    [ServerRpc(requireOwnership: false)]
    public static async Task<bool> MyMixedRPC<T>(T data)
    {
        Debug.Log($"Server recieved {data}");
        await Task.Delay(1000);
        return data is System.Int32;
    }
    
}
