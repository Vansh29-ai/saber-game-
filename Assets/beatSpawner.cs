// using UnityEngine;

// public class BeatSpawner : MonoBehaviour
// {
//     public GameObject redBeat;
//     public GameObject blueBeat;
//     public Transform[] spawnPoints;
//     public float bpm = 105f;
//     public SurroundingsPulseManager surroundings;

//     float timer;

//     void Update()
//     {
//         timer += Time.deltaTime;
//         if (timer >= 60f / bpm)
//         {
//             Spawn();
//             timer = 0;
//         }
//     }

//     void Spawn()
//     {
//         Transform p = spawnPoints[Random.Range(0, spawnPoints.Length)];
//         Instantiate(Random.value > 0.5f ? redBeat : blueBeat, p.position, Quaternion.identity);

//         if (surroundings != null)
//             surroundings.TriggerAll();
//     }
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    public GameObject redBeat;
    public GameObject blueBeat;
    public Transform[] spawnPoints;
    public float bpm = 105f;
    public SurroundingsPulseManager surroundings;

    public bool gameStarted = false;
    private float timer = 0f;
    private float spawnInterval;

    void Start()
    {
        spawnInterval = 60f / bpm;
        timer = 0f;
    }

    void Update()
    {
        if (!gameStarted)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Spawn();
            timer = 0f;
        }
    }

    public void Spawn()
    {
        if (spawnPoints.Length == 0)
            return;

        Transform p = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject beatToSpawn = Random.value > 0.5f ? redBeat : blueBeat;

        Instantiate(beatToSpawn, p.position, Quaternion.identity);

        if (surroundings != null)
            surroundings.TriggerAll();
    }

    public void StartGame()
    {
        if (gameStarted) return;   // prevents double start

        gameStarted = true;
        timer = 0f;
    }
}
