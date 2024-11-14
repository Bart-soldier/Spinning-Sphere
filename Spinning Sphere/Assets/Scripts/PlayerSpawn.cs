using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public DissolveAnimator PlayerDissolveAnimator;
    public Rigidbody Rigidbody;

    public EnvironmentController EnvironmentController;

    public bool HasSpawned = false;
    
    private bool Spawning = false;

    void Start()
    {
        Rigidbody.useGravity = false;
        this.GetComponent<Renderer>().material.SetFloat("_Animation", 1.0f);

        EnvironmentController.ToggleSpawn = true;
    }

    void Update()
    {
        Spawn();

    }

    private void Spawn()
    {
        if (HasSpawned)
        {
            return;
        }

        if (!Spawning && EnvironmentController.HasSpawned)
        {
            Spawning = true;

            PlayerDissolveAnimator.StartAnimation = true;
            PlayerDissolveAnimator.IsAnimating = true;
        }

        if (Spawning && !PlayerDissolveAnimator.IsAnimating)
        {
            Spawning = false;
            HasSpawned = true;
            Rigidbody.useGravity = true;
            EnvironmentController.ToggleAnimation = true;
        }
    }
}
