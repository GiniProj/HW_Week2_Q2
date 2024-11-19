using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement Settings")]
    [SerializeField] InputAction moveRight = new InputAction(type: InputActionType.Button);
    [Tooltip("Right Movement Input Action")]
    
    [SerializeField] InputAction moveLeft = new InputAction(type: InputActionType.Button);
    [Tooltip("Left Movement Input Action")]
    
    [SerializeField] private float moveSpeed = 5f; // Speed of player movement
    [Tooltip("Speed Limit")]
    
    [SerializeField] private float movementLimit = 17f; // Movement range limit
    [Tooltip("Movement Limit")]

    private float horizontalInput;

    private void OnEnable(){
        moveRight.Enable();
        moveLeft.Enable();
    }

    private void OnDisable(){
        moveRight.Disable();
        moveLeft.Disable();
    }

    void Update()
    {
        if (moveRight.IsPressed() && transform.position.x < movementLimit){
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (moveLeft.IsPressed() && transform.position.x > -movementLimit){
            transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
