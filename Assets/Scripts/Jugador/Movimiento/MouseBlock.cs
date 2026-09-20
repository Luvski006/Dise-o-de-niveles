using UnityEngine;
using UnityEngine.InputSystem;

public class MouseBlock : MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;
    [SerializeField] private Transform orientation;

    private InputAction _lookAction;
    private float xRotation;
    private float yRotation;

    private void Awake()
    {
        _lookAction = InputSystem.actions.FindAction("look");
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector2 look = _lookAction.ReadValue<Vector2>();

        yRotation += look.x * Time.deltaTime * sensX;
        xRotation -= look.y * Time.deltaTime * sensY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }
}