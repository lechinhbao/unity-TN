using UnityEngine;

public class maincamera : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        // Lấy vị trí của nhân vật
        Vector3 playerPosition = player.transform.position;

        // Chuyển camera đến vị trí của nhân vật
        transform.position = new Vector3(playerPosition.x, playerPosition.y, transform.position.z);
    }
}
