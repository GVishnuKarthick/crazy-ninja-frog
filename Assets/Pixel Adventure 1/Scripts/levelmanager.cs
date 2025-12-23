using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelmanager : MonoBehaviour
{
    public Button[] levelButtons; // Drag & drop level buttons here in order (Level 1 to 15)
    private int unlockedLevel;

    void Start()
    {
        // Load saved progress from PlayerPrefs
        unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1); // Default Level 1 unlocked

        UpdateLevelButtons();
    }

    /// <summary>
    /// Unlocks the next level after completing current level
    /// </summary>
    /// <param name="completedLevel">The level number just completed</param>
    public void LevelCompleted(int completedLevel)
    {
        int nextLevel = completedLevel + 1;

        if (nextLevel > unlockedLevel)
        {
            unlockedLevel = nextLevel;
            PlayerPrefs.SetInt("UnlockedLevel", unlockedLevel);
            PlayerPrefs.Save();
        }

        UpdateLevelButtons();
    }

    /// <summary>
    /// Updates Level Select buttons to be interactable based on unlocked level
    /// </summary>
    public void UpdateLevelButtons()
    {
        if (levelButtons == null || levelButtons.Length == 0) return;

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (levelButtons[i] != null)
            {
                levelButtons[i].interactable = (i + 1) <= unlockedLevel;
            }
        }
    }

    /// <summary>
    /// Loads a level if it is unlocked
    /// </summary>
    /// <param name="levelNumber">Logical level number</param>
    /// <param name="buildIndex">Scene build index</param>
    public void LoadLevel(int levelNumber, int buildIndex)
    {
        if (levelNumber <= unlockedLevel)
        {
            SceneManager.LoadScene(buildIndex);
        }
        else
        {
            Debug.Log("Level " + levelNumber + " is locked.");
        }
    }

    // ---------------------------
    // Level button methods
    // ---------------------------
    public void lv1() { LoadLevel(1, 2); }
    public void lv2() { LoadLevel(2, 3); }
    public void lv3() { LoadLevel(3, 4); }
    public void lv4() { LoadLevel(4, 5); }
    public void lv5() { LoadLevel(5, 6); }
    public void lv6() { LoadLevel(6, 7); }
    public void lv7() { LoadLevel(7, 8); }
    /* Add more levels as needed
    public void lv8() { LoadLevel(8, 9); }
    public void lv9() { LoadLevel(9, 10); }
    public void lv10() { LoadLevel(10, 11); }
    */
}
