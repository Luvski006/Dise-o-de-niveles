using UnityEngine;

public class MouseBlock : MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;
    private float xRotation;
    private float yRotation;
    [SerializeField] private Transform orientation;
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        Cursor.lockState = CursorLockMode.Locked;
    }
    
}
