using UnityEngine;
using UnityEngine.InputSystem;

public class inputController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement = null;
    [SerializeField] private InputAction _movementAction = null, _lookAction = null, _jumpAction = null;
    Vector2 _dir = Vector2.zero;

    private void Awake()
    {
        if (!_playerMovement) _playerMovement = GetComponent<PlayerMovement>();
        _movementAction = InputSystem.actions.FindAction("Move");
        _lookAction = InputSystem.actions.FindAction("look");
        _jumpAction = InputSystem.actions.FindAction("Jump");
    }

    private void Update()
    {
        // El salto va antes del movimiento
        if (_jumpAction.WasPressedThisFrame())
            _playerMovement.Jump();

        _dir = _movementAction.ReadValue<Vector2>();
        _playerMovement.Movement(_dir);

        Vector2 lookDir = _lookAction.ReadValue<Vector2>();
        _playerMovement.Rotate(lookDir);
    }
}