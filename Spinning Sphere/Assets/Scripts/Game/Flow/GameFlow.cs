using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public static bool IsGameEnded = false;

    public GameObject PauseMenuUI;
    public GameObject EndMenuUI;

    public GameAnimator GameAnimator;

    private void Start()
    {
        GameAnimator.FirstSpawn();
    }

    private void Update()
    {
        if (!IsGameEnded && Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (IsGameEnded && !GameAnimator.Despawn)
        {
            EndMenuUI.SetActive(true);
        }
    }

    public void Pause()
    {
        IsGamePaused = true;
        Time.timeScale = 0.0f;
        PauseMenuUI.SetActive(true);
    }

    public void Resume()
    {
        IsGamePaused = false;
        Time.timeScale = 1.0f;
        PauseMenuUI.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void End()
    {
        IsGameEnded = true;
        GameAnimator.Despawn = true;
    }

    public void Restart()
    {
        IsGameEnded = false;
        EndMenuUI.SetActive(false);

        GameAnimator.Respawn();
    }
}
