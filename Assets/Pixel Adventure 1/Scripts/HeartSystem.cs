using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public int health = 3;
    public Image[] hearts;
    public Sprite emptyHeart;

    public void TakeDamage(bool isTrap = false)
    {
        if (health <= 0) return;

        if (isTrap) 
        {
            // Set all hearts to empty if the player hits a trap
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].sprite = emptyHeart;
            }
            health = 0;  // No remaining health after hitting a trap
        }
        else
        {
            health--;
            hearts[health].sprite = emptyHeart; // Replace correct heart visually
        }
    }
}
