using UnityEngine;

public class DiscoGlow : MonoBehaviour
{
    public float pulseInterval = 1.5f;   // time between pulses
    public float fadeSpeed = 5f;
    public float maxEmission = 5f;

    Material mat;
    float currentEmission = 0f;
    bool glowing = false;
    float timer;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        mat.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= pulseInterval)
        {
            glowing = !glowing;
            timer = 0f;
        }

        float target = glowing ? maxEmission : 0f;
        currentEmission = Mathf.Lerp(currentEmission, target, Time.deltaTime * fadeSpeed);
        mat.SetColor("_EmissionColor", mat.color * currentEmission);
    }
}
