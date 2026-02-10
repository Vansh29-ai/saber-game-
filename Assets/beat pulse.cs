using UnityEngine;

public class BeatPulse : MonoBehaviour
{
    public float baseIntensity = 1f;
    public float pulseIntensity = 4f;
    public float pulseSpeed = 6f;

    Material mat;
    float pulse;

    void Awake()
    {
        var renderer = GetComponent<Renderer>();
        if (renderer != null)
            mat = renderer.material;
    }

    public void TriggerPulse()
    {
        pulse = 1f;
    }

    void Update()
    {
        if (mat == null) return;

        pulse = Mathf.MoveTowards(pulse, 0f, Time.deltaTime * pulseSpeed);
        float intensity = Mathf.Lerp(baseIntensity, pulseIntensity, pulse);
        mat.SetColor("_EmissionColor", mat.color * intensity);
    }
}
