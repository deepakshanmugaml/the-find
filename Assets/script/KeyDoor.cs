using UnityEngine;
using UnityEngine.InputSystem;

public class KeyDoor : MonoBehaviour
{
    public float openDistance = 3f;
    public float openSpeed = 3f;

    private Transform player;
    private bool opening = false;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
            player = playerObject.transform;

        closedRotation = transform.rotation;

        // Door rotates 90 degrees when opened
        openRotation =
            closedRotation * Quaternion.Euler(0, 90, 0);
    }

    void Update()
    {
        if (player == null)
            return;

        float distance =
            Vector3.Distance(transform.position, player.position);

        if (distance <= openDistance &&
            !opening &&
            KeyManager.Instance.keysCollected > 0)
        {
            if (Keyboard.current != null &&
                Keyboard.current.eKey.wasPressedThisFrame)
            {
                OpenDoor();

                // Use one key
                KeyManager.Instance.keysCollected--;

                Debug.Log("🚪 Door opened!");
            }
        }

        if (opening)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                openRotation,
                openSpeed * Time.deltaTime
            );
        }
    }

    void OpenDoor()
    {
        opening = true;
    }
}