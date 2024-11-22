using System;
using UnityEngine;
using UnityEngine.Events;

public class GameAnimator : MonoBehaviour
{
    public UnityEvent SpawnCompleted = new UnityEvent();
    public UnityEvent DespawnCompleted = new UnityEvent();

    public DissolveAnimator PlayerDissolveAnimator;

    public DissolveAnimator EnvironmentDissolveAnimator;
    public TextureOffsetAnimator EnvironmentTextureOffsetAnimator;

    public ObstacleHandler ObstacleHandler;

    public PlayerController PlayerController;

    private bool Spawning = false;
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
            EnvironmentTextureOffsetAnimator.ToggleAnimation = true;

            PlayerController.EnableController();
            ObstacleHandler.Active = true;

            Spawning = false;
            SpawnCompleted.Invoke();
        }
        else if(Despawning)
        {
            PlayerController.ResetValues();
            Despawning = false;
            DespawnCompleted.Invoke();
        }
    }

    public void SpawnEnvironmentAndPlayer()
    {
        EnvironmentDissolveAnimator.Animate();
        Spawning = true;
    }

    public void SpawnPlayer()
    {
        Spawning = true;

        PlayerDissolveAnimator.Animate();
    }

    public void DespawnPlayer()
    {
        Despawning = true;

        PlayerDissolveAnimator.Animate();
        EnvironmentTextureOffsetAnimator.ToggleAnimation = true;

        PlayerController.DisableController();
        ObstacleHandler.Active = false;
    }
}
