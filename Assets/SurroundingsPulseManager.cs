using UnityEngine;

public class SurroundingsPulseManager : MonoBehaviour
{
    BeatPulse[] pulses;

    void Awake()
    {
        pulses = GetComponentsInChildren<BeatPulse>();
    }

    public void TriggerAll()
    {
        foreach (var p in pulses)
            p.TriggerPulse();
    }
}
