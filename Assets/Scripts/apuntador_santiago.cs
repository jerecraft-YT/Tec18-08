using UnityEngine;
using UnityEngine.InputSystem;

public class CustomCursor : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        Cursor.visible = false; 
    }

    private void Update()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        
        Vector3 worldPos = cam.ScreenToWorldPoint(mousePos);
        worldPos.z = 0f;

        transform.position = worldPos;
    }
}