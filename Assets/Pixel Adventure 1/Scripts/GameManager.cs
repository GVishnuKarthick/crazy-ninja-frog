using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject restartpnl,pausepnl,menupnl,settingspnl;
    public GameObject pausebtn;
    public AudioSource audio;
    public Text onlineText;
    void Start(){
        audio=GetComponent<AudioSource>();

    }
    public void Playgame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void QuitGame(){
    Application.Quit();
    }
     public void pausegame()
    {
        Time.timeScale = 0f;          // Pause the game
        pausepnl.SetActive(true);     // Show pause panel
        pausebtn.SetActive(false);    // Hide pause button
    }

    public void resumegame()
    {
        Time.timeScale = 1f;          // Resume the game
        pausebtn.SetActive(true);     // Show pause button
        pausepnl.SetActive(false);    // Hide pause panel
    }

    public void exitgame()
    {
        Time.timeScale = 1f;          // Ensure time is running
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    }

    public void restartgame()
    {
        Time.timeScale = 1f;          // Start the game
       /* menupnl.SetActive(false);     // Hide main menu
        pausebtn.SetActive(true);     // Show pause button
        restartpnl.SetActive(true); */
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Keep restart panel hidden
    }
    public void settings(){
        Time.timeScale=1f;
        
        settingspnl.SetActive(true);
    }
    public void musicon(){
        audio.Play();
    }
    public void musicoff(){
        audio.Pause();
    }
    
    public void returnmainmenu(){
        Time.timeScale=1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  
}
