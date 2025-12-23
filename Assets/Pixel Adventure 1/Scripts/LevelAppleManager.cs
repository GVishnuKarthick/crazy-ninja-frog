using UnityEngine;

public class LevelAppleManager : MonoBehaviour
{
    public static LevelAppleManager instance;

    int totalApples;
    int collectedApples;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        totalApples = GameObject.FindGameObjectsWithTag("fruit").Length;
        collectedApples = 0;
    }

    public void AppleCollected()
    {
        collectedApples++;
    }

    public bool AllApplesCollected()
    {
        return collectedApples >= totalApples;
    }
}
