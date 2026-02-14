using UnityEngine;

public class heart_killer : MonoBehaviour
{   public float zLimit = 1f;   // X position limit
    public int damage = 1;

    private bool alreadyPenalized = false;
    private PlayerHealth playerHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       playerHealth = FindObjectOfType<PlayerHealth>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        // If box crosses X limit and not yet counted
        if (!alreadyPenalized && transform.position.z < zLimit)
        {
            playerHealth.ReduceHeart(damage);
            alreadyPenalized = true;

            Destroy(gameObject); // optional remove box
        
    }}
}
// using UnityEngine;

// public class BoxHealthPenalty : MonoBehaviour
// {
//     public float xLimit = -10f;   // X position limit
//     public int damage = 1;

//     private bool alreadyPenalized = false;
//     private PlayerHealth playerHealth;

//     void Start()
//     {
//         playerHealth = FindObjectOfType<PlayerHealth>();
//     }

//     void Update()
//     {
//         // If box crosses X limit and not yet counted
//         if (!alreadyPenalized && transform.position.x < xLimit)
//         {
//             playerHealth.ReduceHeart(damage);
//             alreadyPenalized = true;

//             Destroy(gameObject); // optional remove box
//         }
//     }
// }