using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement Settings")]
    [Tooltip("Movement buttons")]
    [SerializeField] private InputAction moveLeftButton;
    [SerializeField] private InputAction moveRightButton;

    // Update is called once per frame
    [Tooltip("Speed of the player's movement")]
    [SerializeField] private float moveSpeed = 5f;

    [Tooltip("Limit of the player's movement from its center position")]
    [SerializeField] private float limitPlayerMovement = 15f;  // Default range of 2 units

    void Start()
    {
        if (moveLeftButton == null || moveRightButton == null)
        {
            Debug.LogError("Move Left or Move Right Input Actions not set on " + gameObject.name);
            return;
        }
    }

    void OnEnable()
    {
        moveLeftButton.Enable();
        moveRightButton.Enable();
    }

    void OnDisable()
    {
        moveLeftButton.Disable();
        moveRightButton.Disable();
    }
    
    void Update()
    {
        float moveDirection = 0;
        if (moveLeftButton.IsPressed()) { moveDirection = -1; }
        else if (moveRightButton.IsPressed()) { moveDirection = 1; }

        if (moveDirection != 0)
        {
            moveDirection = Mathf.Clamp(transform.position.x + moveDirection * moveSpeed * Time.deltaTime, -limitPlayerMovement, limitPlayerMovement);  // Calculate the new position based on the factor, speed, and direction of movement
            transform.position = new Vector3(moveDirection , transform.position.y, transform.position.z);
        }
    }
}
