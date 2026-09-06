using UnityEngine;
[RequireComponent (typeof(CharacterController), typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public Collider hitbox = null;
    [SerializeField] private float _speed = 5f, _rotationSpeed = 5f, _force = 10f;
    private CharacterController _cC = null;
    private Rigidbody _rb = null;
    private float _rotationY = 0f;

    private void Awake()
    {
        if (!_cC) _cC = GetComponent<CharacterController>();
        if (!_rb) _rb = GetComponent<Rigidbody>();
        
    }

    public void Movement (Vector2 dir)
    {
        Vector3 move = transform.forward * dir.y + transform.right * dir.x;
        move.Normalize();
        move = move.normalized * _speed * Time.deltaTime;

        _cC.Move(move);            
    }

    public void RB_Movement(Vector2 dir)
    {
        Vector3 move = transform.forward * dir.y + transform.right * dir.x;
        move = move.normalized * _speed * _force * Time.fixedDeltaTime;
        _rb.AddForce(move, ForceMode.Impulse);
    }

    public void Rotate (Vector2 lookdir)
    {
        _rotationY += lookdir.x * _rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, _rotationY, 0);
    }

}
