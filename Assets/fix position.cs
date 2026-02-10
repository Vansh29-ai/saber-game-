using UnityEngine;

public class LockXROrigin : MonoBehaviour
{
    Vector3 startPos;
    Quaternion startRot;

    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    void LateUpdate()
    {
        transform.position = startPos;
        transform.rotation = startRot;
    }
}
