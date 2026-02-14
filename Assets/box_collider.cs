using UnityEngine;

public class box_collider : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
{ 
    }   private void OnCollisionEnter(Collision Collision)
    {
        if(Collision.gameObject.tag=="Beat")
        {
            Debug.Log("Collided with Ground");
        }
        // if(collision.gameObject.tag=="Enemy")
        // {
        //     FindAnyObjectByType<Game_manager>().ReloadLevel();
        // }
    }
    
}

