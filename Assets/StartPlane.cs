using UnityEngine;

public class StartPlane : MonoBehaviour
{
    public GameObject otherPlane;      // assign second plane
    public BeatSpawner beatSpawner;    // drag spawner here

    private bool hasStarted = false;   // prevent double trigger

   private void OnTriggerEnter(Collider other)
{
    Debug.Log("Plane Triggered By: " + other.name);

    if (other.CompareTag("Beat"))
    {
        Debug.Log("SABER DETECTED - STARTING GAME");

        beatSpawner.StartGame();

        gameObject.SetActive(false);

        if (otherPlane != null)
            otherPlane.SetActive(false);
    }
}
}