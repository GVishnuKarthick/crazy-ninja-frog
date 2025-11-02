using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    bool isDead = false;

    public HeartSystem heartSystem; // Drag this in Inspector

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        if (other.CompareTag("trap"))
        {
            // Die instantly on trap contact and make all hearts empty
            TakeDamage(true);  // Pass true for trap to empty all hearts
            Die();
        }
        else if (other.CompareTag("beetle"))
        {
            if (!HitBeetleFromTop(other))
            {
                TakeDamage(); // Take 1 hit from beetle (unless from top)
            }
            else
            {
                KillBeetle(other.gameObject); // Jumped on beetle from above
            }
        }
    }

    bool HitBeetleFromTop(Collider2D beetle)
    {
        return rb.linearVelocity.y < -0.1f && transform.position.y > beetle.transform.position.y + 0.2f;
    }

    void KillBeetle(GameObject beetle)
    {
        Destroy(beetle);
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 7f);
    }

    void TakeDamage(bool isTrap = false)
    {
        heartSystem.TakeDamage(isTrap); // Pass the isTrap flag to HeartSystem

        if (heartSystem.health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("death");
        GetComponent<PlayerMovement>().enabled = false;
    }

    // Called by Animation Event at the end of death animation
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
