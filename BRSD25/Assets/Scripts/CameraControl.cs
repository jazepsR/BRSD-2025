using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Clicked();
        }
    }

    void Clicked()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast (ray, out hit))
        {
            Events.OnClickInvoke(hit.point);
        }
    }
}
