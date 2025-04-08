using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public bool PlayerMove { get; set; } = true;

    public float moveSpeed = 2.0f;
    public Rigidbody2D playerRigidbody; // Reference to the CharacterController component for movement control
    private Vector2 moveVector;

    private Animator animator; // variable for the blend tree

    private Vector2 lastDirection;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Get the CharacterController component attached to the GameObject
        playerRigidbody = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Grab animator
        // Subscribe to the MovePlayerEvent to update movement direction
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        InputActions.MovePlayerEvent += UpdateMoveVector;
    }

    // Method to update the movement direction based on the input from InputManager
    private void UpdateMoveVector(Vector2 InputVector)
    {
        if (!PlayerMove) return;

        lastDirection = moveVector;

        moveVector = InputVector;
        
        Animations(); // Calls the method that switches between anims
    }


    /// <summary>
    ///  Created animator method
    /// </summary>
    private void Animations()
    {
        if(moveVector == Vector2.zero) // This means player is frozen/not moving
        {
            animator.SetBool("isMoving", false);  // States player as not moving
            animator.SetFloat("idleX", lastDirection.x); // "moveVector" Gives you a float of the x
            animator.SetFloat("idleY", lastDirection.y); // "moveVector" Gives you a float of the y
        }
        else
        {
            animator.SetBool("isMoving", true);  // States player as moving
            animator.SetFloat("X", moveVector.x); // "moveVector" Gives you a float of the x
            animator.SetFloat("Y", moveVector.y); // "moveVector" Gives you a float of the y
        }
    }

    void HandlePlayerMovement(Vector2 moveVector)
    {
        if (!PlayerMove) return;

        // Move the character based on the input direction and moveSpeed
        playerRigidbody.MovePosition(playerRigidbody.position + moveVector * moveSpeed * Time.fixedDeltaTime);
    }
    void FixedUpdate()
    {
        // Handle the player movement using the current direction
        HandlePlayerMovement(moveVector);
    }
    void OnDisable()
    {
        // Unsubscribe from the MovePlayerEvent
        InputActions.MovePlayerEvent -= UpdateMoveVector;
    }
}