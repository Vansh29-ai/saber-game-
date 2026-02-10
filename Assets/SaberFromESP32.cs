using UnityEngine;

public class SaberFromESP32 : MonoBehaviour
{
    public ESP32_UDP_Receiver receiver;

    void Update()
    {
        Vector3 d = receiver.data;
        transform.rotation = Quaternion.Euler(
            d.x * 30f,
            d.y * 30f,
            d.z * 30f
        );
    }
}
