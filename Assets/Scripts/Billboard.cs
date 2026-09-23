using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera targetCamera;

    public bool lockYAxis = true;

    void LateUpdate()
    {
        if (targetCamera == null)
        {
            targetCamera = Camera.main;
            if (targetCamera == null) return;
        }

        Vector3 forward = targetCamera.transform.forward;

        if (lockYAxis)
        {
            forward.y = 0f;
            if (forward.sqrMagnitude < 0.0001f) return;
        }

        transform.forward = forward.normalized;
    }
}
