using UnityEngine;

public class GameAnimator : MonoBehaviour
{
    public DissolveAnimator PlayerDissolveAnimator;
    public Rigidbody PlayerRigidbody;

    public DissolveAnimator EnvironmentDissolveAnimator;
    public TextureOffsetAnimator EnvironmentTextureOffsetAnimator;

    public bool Spawn = false;
    public bool Despawn = false;

    private bool Animating = false;

    void Start()
    {
        PlayerRigidbody.useGravity = false;

        StartSpawnAnimation();
    }

    void Update()
    {
        SpawnAnimation();
        DespawnAnimation();
    }

    public void StartSpawnAnimation()
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

        if(!Animating && EnvironmentDissolveAnimator.Visible)
        {
            PlayerDissolveAnimator.ToggleDissolve = true;
            Animating = true;
        }

        if(Animating && PlayerDissolveAnimator.Visible)
        {
            Spawn = false;
            Animating = false;
            PlayerRigidbody.useGravity = true;
            EnvironmentTextureOffsetAnimator.ToggleAnimation = true;
        }
    }

    private void DespawnAnimation()
    {
        if (Despawn)
        {
            PlayerDissolveAnimator.ToggleDissolve = true;
            EnvironmentTextureOffsetAnimator.ToggleAnimation = true;
            Despawn = false;
        }
    }
}
