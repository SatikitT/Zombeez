using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 10f;
    public Rigidbody2D rb;
    public float screenLimitX = 10f; // Adjust this value based on your screen boundaries

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        CheckOffScreen();
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Target target = hitInfo.GetComponent<Target>();
        if (target != null && target.gameObject.CompareTag("Zombie"))
        {
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    void CheckOffScreen()
    {
        if (transform.position.x > screenLimitX)
        {
            Destroy(gameObject);
        }
    }
}
