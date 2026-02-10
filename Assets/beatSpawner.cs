using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    public GameObject redBeat;
    public GameObject blueBeat;
    public Transform[] spawnPoints;
    public float bpm = 105f;
    public SurroundingsPulseManager surroundings;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 60f / bpm)
        {
            Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {
        Transform p = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(Random.value > 0.5f ? redBeat : blueBeat, p.position, Quaternion.identity);

        if (surroundings != null)
            surroundings.TriggerAll();
    }
}
