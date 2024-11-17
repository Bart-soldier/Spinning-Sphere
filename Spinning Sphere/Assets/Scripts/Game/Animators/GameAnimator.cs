using UnityEngine;

public class GameAnimator : MonoBehaviour
{
    public DissolveAnimator PlayerDissolveAnimator;
    public Rigidbody PlayerRigidbody;

    public DissolveAnimator EnvironmentDissolveAnimator;
    public TextureOffsetAnimator EnvironmentTextureOffsetAnimator;

    public RotationController RotationController;

    public bool Spawn = false;
    public bool Despawn = false;

    private bool Spawning = false;
    private bool Despawning = false;

    void Update()
    {
        DespawnAnimation();
        SpawnAnimation();
    }

    public void FirstSpawn()
    {
        EnvironmentDissolveAnimator.ToggleDissolve = true;
        Respawn();
    }

    public void Respawn()
    {
        PlayerRigidbody.gameObject.transform.position = Vector3.zero;

        PlayerRigidbody.useGravity = false;

        Spawn = true;
    }

    private void SpawnAnimation()
    {
        if (!Spawn)
        {
            return;
        }

        if(!Spawning && EnvironmentDissolveAnimator.Visible)
        {
            Spawning = true;

            PlayerDissolveAnimator.ToggleDissolve = true;
        }

        if(Spawning && PlayerDissolveAnimator.Visible)
        {
            EnvironmentTextureOffsetAnimator.ToggleAnimation = true;

            PlayerRigidbody.useGravity = true;
            RotationController.enabled = true;

            Spawn = false;
            Spawning = false;
        }
    }

    private void DespawnAnimation()
    {
        if(!Despawn)
        {
            return;
        }

        if(!Despawning && PlayerDissolveAnimator.Visible)
        {
            Despawning = true;

            PlayerDissolveAnimator.ToggleDissolve = true;
            EnvironmentTextureOffsetAnimator.ToggleAnimation = true;

            PlayerRigidbody.useGravity = false;
            RotationController.enabled = false;
        }

        if (Despawning && !PlayerDissolveAnimator.Visible)
        {
            Despawn = false;
            Despawning = false;
        }
    }
}
