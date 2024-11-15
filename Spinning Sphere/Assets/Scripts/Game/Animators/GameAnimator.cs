using UnityEngine;

public class GameAnimator : MonoBehaviour
{
    public DissolveAnimator PlayerDissolveAnimator;
    public Rigidbody PlayerRigidbody;

    public DissolveAnimator EnvironmentDissolveAnimator;
    public TextureOffsetAnimator EnvironmentTextureOffsetAnimator;

    public bool Spawn = false;
    private bool Spawning = false;

    void Start()
    {
        PlayerRigidbody.useGravity = false;

        StartSpawnAnimation();
    }

    void Update()
    {
        SpawnAnimation();
    }

    private void StartSpawnAnimation()
    {
        Spawn = true;
        EnvironmentDissolveAnimator.ToggleDissolve = true;
    }

    private void SpawnAnimation()
    {
        if (!Spawn)
        {
            return;
        }

        if(!Spawning && EnvironmentDissolveAnimator.Visible)
        {
            PlayerDissolveAnimator.ToggleDissolve = true;
            Spawning = true;
        }

        if(Spawning && PlayerDissolveAnimator.Visible)
        {
            Spawning = false;
            Spawn = false;
            PlayerRigidbody.useGravity = true;
            EnvironmentTextureOffsetAnimator.ToggleAnimation = true;
        }
    }
}
