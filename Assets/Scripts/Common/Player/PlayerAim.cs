using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private float sensitivity = 20f;
    [SerializeField] private Camera aimCamera;
    
    void Update()
    {
        // Get the position of the mouse cursor in screen space
        Vector3 mousePosScreen = Input.mousePosition;

        // Convert the screen space position to world space relative to the camera's viewport
        Vector3 mousePosWorld = aimCamera.ScreenToWorldPoint(new Vector3(mousePosScreen.x, mousePosScreen.y, aimCamera.transform.position.y - transform.position.y));

        // Calculate the direction from the player's current position to the mouse position
        Vector3 direction = (mousePosWorld - transform.position).normalized;
        direction.y = 0;
        // Calculate the rotation that the player needs to face towards the mouse position
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        // Apply the rotation to the player
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * sensitivity);
    }
}