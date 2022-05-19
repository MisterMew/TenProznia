using UnityEngine;

public class PlayerController : MonoBehaviour {
    /// Birb Variables
    private Rigidbody mRigidbody;
    private Animator birbAnimashen;

    /// Physics Variables
    public float forwardForce = 2000F;
    public float forwardClamped = 10F;
    public float sidewaysForce = 50f;

    /// Axis Variables
    private float xThrow;


       /// AWAKE
      /// <summary>
     /// Upon Awake, Get player rigidboday and define the touch-input area
    /// </summary>
    private void Awake() {
        mRigidbody = GetComponent<Rigidbody>();
        birbAnimashen = gameObject.GetComponentInChildren<Animator>();
    }

       /// UPDATE
      /// <summary>
     /// Update birb animations
    /// </summary>
    private void Update() {
        birbAnimashen.SetFloat("horizontal", xThrow);
    }

       /// FIXED UPDATE
      /// <summary>
     /// Fixed Update dependant on the framerate
    /// </summary>
    private void FixedUpdate() {
        mRigidbody.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.Impulse); //Apply forward force

        if (SystemInfo.deviceType == DeviceType.Desktop) { //If the device is desktop
            xThrow = GetAxisInput();
        }

        mRigidbody.AddForce(transform.right * sidewaysForce * xThrow, ForceMode.Impulse); //Apply horizontal force
        mRigidbody.velocity = Vector3.ClampMagnitude(mRigidbody.velocity, forwardClamped);                //Clamp to restricted exceeding maxSpeed

        if (IsOutOfBounds()) { //End the game if player is out of bounds
            FindObjectOfType<PlayerShatter>().shatter();
            FindObjectOfType<GameManager>().EndGame();
        }
    }

       /// INPUT: AXIAL
      /// <summary>
     /// Get Axial input regardless of input controller
    /// </summary>
    private float GetAxisInput() {
        return Input.GetAxis("Horizontal"); //Return the horizontal axial input
    }

       /// OUT OF BOUNDS
      /// <summary>
     /// Validate whether the player is Out of Bounds
    /// </summary>
    private bool IsOutOfBounds() {
        if (mRigidbody.position.y < -15F  || mRigidbody.position.y > 64F)  { return true; }
        if (mRigidbody.position.x < -256F || mRigidbody.position.x > 256F) { return true; }
        return false;
    }

       /// MOVE PLAYER
      /// <summary>
     /// Move the player when using touch Input
    /// </summary>
    public void MovePlayer(float variants) {
        xThrow = variants;
    }
}