using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel; // Assign PausePanel in the Inspector
    private bool isPaused = false;

    void Start()
    {
        // Ensure the pause panel is hidden initially
        pausePanel.SetActive(false);
    }

    void Update()
    {
        // Toggle pause state when Escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        pausePanel.SetActive(true);    // Show the pause panel
        Time.timeScale = 0f;           // Freeze the game
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);   // Hide the pause panel
        Time.timeScale = 1f;           // Unfreeze the game
        isPaused = false;
    }
}
