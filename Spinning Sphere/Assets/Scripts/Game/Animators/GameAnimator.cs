using System;
using UnityEngine;
using UnityEngine.Events;

public class GameAnimator : MonoBehaviour
{
    public static UnityEvent SpawnCompleted   = new UnityEvent();
    public static UnityEvent DespawnCompleted = new UnityEvent();

    public DissolveAnimator PlayerDissolveAnimator;

    public DissolveAnimator EnvironmentDissolveAnimator;
    public TextureOffsetAnimator EnvironmentTextureOffsetAnimator;

    public ObstacleHandler ObstacleHandler;

    public PlayerController PlayerController;

    private bool Spawning   = false;
    private bool Despawning = false;

    private void Awake()
    {
        EnvironmentDissolveAnimator.AnimationCompleted.AddListener(OnEnvironmentAnimationCompleted);
        PlayerDissolveAnimator     .AnimationCompleted.AddListener(OnPlayerAnimationCompleted);
    }

    private void OnEnvironmentAnimationCompleted()
    {
        if(Spawning)
        {
            SpawnPlayer();
        }
    }

    private void OnPlayerAnimationCompleted()
    {
        if(Spawning)
        {
            Spawning = false;

            EnvironmentTextureOffsetAnimator.StartSpeedAnimation();

            PlayerController.EnableController();
            ObstacleHandler.Active = true;

            SpawnCompleted.Invoke();
        }
        else if(Despawning)
        {
            Despawning = false;

            PlayerController.ResetValues();
            DespawnCompleted.Invoke();
        }
    }

    public void SpawnEnvironmentAndPlayer()
    {
        Spawning = true;
        EnvironmentDissolveAnimator.AnimateIn();
    }

    public void SpawnPlayer()
    {
        Spawning = true;
        PlayerDissolveAnimator.AnimateIn();
    }

    public void DespawnPlayer()
    {
        Despawning = true;

        PlayerDissolveAnimator.AnimateOut();
        EnvironmentTextureOffsetAnimator.StopSpeedAnimation();

        PlayerController.DisableController();
        ObstacleHandler.Active = false;
    }
}
