using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the zombie moves

    private Transform playerTransform;

    void Start()
    {
        // Find the player GameObject by tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player not found. Make sure the player GameObject is tagged as 'Player'.");
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        // Move towards the player's position
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
