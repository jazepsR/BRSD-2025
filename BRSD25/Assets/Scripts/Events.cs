using UnityEngine;
using UnityEngine.UIElements;

public class Events
{
    public delegate void ClickEvent(Vector3 position);    
    public static event ClickEvent OnClick;


    public static void OnClickInvoke(Vector3 position)
    {
        OnClick?.Invoke(position);  
    }
}
