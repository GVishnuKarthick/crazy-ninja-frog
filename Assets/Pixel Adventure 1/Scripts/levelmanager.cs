using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelmanager : MonoBehaviour
{
    public Button[] levelButtons; // Drag & drop level buttons here in order (Level 1 to 15)

    void Start()
    {
        // Ensure Level 1 is unlocked by default
        if (!PlayerPrefs.HasKey("UnlockedLevel"))
        {
            PlayerPrefs.SetInt("UnlockedLevel", 1);
        }

        UpdateLevelButtons();
    }

    public void UnlockNextLevel(int levelNumber)
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        if (levelNumber > unlockedLevel)
        {
            PlayerPrefs.SetInt("UnlockedLevel", levelNumber);
            PlayerPrefs.Save();
        }
    }

    public void LoadLevel(int levelNumber, int buildIndex)
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        if (levelNumber <= unlockedLevel)
        {
            SceneManager.LoadScene(buildIndex);
        }
        else
        {
            Debug.Log("Level " + levelNumber + " is locked.");
        }
    }

    public void UpdateLevelButtons()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = (i + 1) <= unlockedLevel;
        }
    }

    // Example: Call this method when a level is completed
    public void LevelCompleted(int completedLevel)
    {
        UnlockNextLevel(completedLevel + 1);
        UpdateLevelButtons();
    }

    // Level button methods
    public void lv1() { LoadLevel(1, 2); }
    public void lv2() { LoadLevel(2, 3); }
    public void lv3() { LoadLevel(3, 4); }
    public void lv4() { LoadLevel(4, 5); }
    public void lv5() { LoadLevel(5, 6); }
    public void lv6() { LoadLevel(6, 7); }
    public void lv7() { LoadLevel(7, 8); }
   /* public void lv8() { LoadLevel(8, 9); }
    public void lv9() { LoadLevel(9, 10); }
    public void lv10() { LoadLevel(10, 11); }*/
  
}
