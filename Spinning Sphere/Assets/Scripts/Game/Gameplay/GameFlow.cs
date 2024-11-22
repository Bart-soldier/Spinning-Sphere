using UnityEngine;
using UnityEngine.InputSystem;

public class GameFlow : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public static bool IsGameEnded = false;

    public GameObject PauseMenuUI;
    public GameObject EndMenuUI;

    public GameAnimator GameAnimator;

    public void OnEscape(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Debug.Log("Escape");

            if (!IsGameEnded)
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
        }
    }

    private void Awake()
    {
        GameAnimator.DespawnCompleted.AddListener(OnDespawnCompleted);
    }

    private void Start()
    {
        GameAnimator.SpawnEnvironmentAndPlayer();
    }

    private void OnDespawnCompleted()
    {
        if(IsGameEnded)
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
        GameAnimator.DespawnPlayer();
    }

    public void Restart()
    {
        IsGameEnded = false;
        EndMenuUI.SetActive(false);

        GameAnimator.SpawnPlayer();
    }
}
