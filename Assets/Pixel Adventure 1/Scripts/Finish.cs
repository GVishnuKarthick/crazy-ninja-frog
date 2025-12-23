using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        // 🔒 CHECK: Are all apples collected?
        if (LevelAppleManager.instance == null ||
            !LevelAppleManager.instance.AllApplesCollected())
        {
            Debug.Log("Collect all apples to finish the level!");
            return; // ❌ Do nothing if apples remain
        }

        // ✅ Apples complete → unlock next level
        levelmanager lm = FindObjectOfType<levelmanager>();
        if (lm != null)
        {
            int currentLevel = SceneManager.GetActiveScene().buildIndex;
            lm.LevelCompleted(currentLevel);
        }

        Invoke(nameof(NextLevel), 0.5f);
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
