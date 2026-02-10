using UnityEngine;

public class TunnelFrameRotator : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float phaseOffset = 0.2f;

    float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
{
    transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
}

}

