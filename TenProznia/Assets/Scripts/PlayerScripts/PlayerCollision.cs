using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    public PlayerController movement;
    public AudioClip deathSound;
    public int flowerOrbs;

    /// ON TRIGGER
    /* When colliding with a collectible */
    /// <summary>
    /// Trigger when player collides with a collectible
    /// </summary>
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Orb") { //If the collided object is an Orb
            Destroy(other.gameObject, 0F);  //Destroy the collected gameObject
            flowerOrbs++;                  //Add the collectible to the total
        }
    }

    /// GET ORB COUNT
    /* Returns the total amount of flower Orbs */
    /// <summary>
    /// Return the current amount of orbs collected
    /// </summary>
    public int GetOrbCount() { return this.flowerOrbs; }

    /// DEATH COLLISION
    /* Upon Collision with an Obstacle */
    /// <summary>
    /// Check player collision with obstacles to determine death
    /// </summary>
    void OnCollisionEnter(Collision collisionInfo) {           //Upon collision with another object (recieves information about the "collisionInfo")
        if (collisionInfo.collider.CompareTag("Obstacle")) {  //Checking if collided object has "Obstacle" tag
            FindObjectOfType<AudioSource>().PlayOneShot(deathSound);   
            movement.enabled = false;                       //Disables player movement
            FindObjectOfType<PlayerShatter>().shatter();   //Shatter player object
            FindObjectOfType<GameManager>().EndGame();    //End the game.
        }
    }
}
