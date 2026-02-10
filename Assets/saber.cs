using UnityEngine;

public class Saber : MonoBehaviour
{
    public float splitLifetime = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Beat"))
        {
            Split(other.gameObject);
        }
    }

    void Split(GameObject obj)
    {
        Vector3 pos = obj.transform.position;
        Quaternion rot = obj.transform.rotation;
        Vector3 scale = obj.transform.localScale;

        Destroy(obj);

        GameObject left = CreateHalf(pos, rot, scale, -1);
        GameObject right = CreateHalf(pos, rot, scale, 1);

        Destroy(left, splitLifetime);
        Destroy(right, splitLifetime);
    }

    GameObject CreateHalf(Vector3 pos, Quaternion rot, Vector3 scale, int dir)
    {
        GameObject half = GameObject.CreatePrimitive(PrimitiveType.Cube);
        half.transform.position = pos + rot * new Vector3(dir * scale.x * 0.25f, 0, 0);
        half.transform.rotation = rot;
        half.transform.localScale = new Vector3(scale.x * 0.5f, scale.y, scale.z);

        // Copy material from original (optional safer than Resources)
        // half.GetComponent<Renderer>().material = obj.GetComponent<Renderer>().material;

        Rigidbody rb = half.AddComponent<Rigidbody>();
        rb.mass = 0.5f;
        rb.AddForce(rot * new Vector3(dir * 1.5f, 1f, 0), ForceMode.Impulse);

        return half;
    }
}
