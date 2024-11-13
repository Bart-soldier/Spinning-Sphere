using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public DissolveAnimator PlayerDissolveAnimator;
    public Rigidbody Rigidbody;

    public EnvironmentController EnvironmentSpawner;

    public bool HasSpawned = false;
    
    private bool Spawning = false;

    void Start()
    {
        Rigidbody.useGravity = false;
        this.GetComponent<Renderer>().material.SetFloat("_Animation", 1.0f);

        EnvironmentSpawner.Spawn = true;
    }

    void Update()
    {
        if(HasSpawned)
        {
            return;
        }

        if(!Spawning && EnvironmentSpawner.HasSpawned)
        {
            SpawnPlayer();
        }

        if(Spawning && !PlayerDissolveAnimator.IsAnimating)
        {
            Spawning = false;
            HasSpawned = true;
            Rigidbody.useGravity = true;
        }
    }

    private void SpawnPlayer()
    {
        Spawning = true;

        PlayerDissolveAnimator.StartAnimation = true;
        PlayerDissolveAnimator.IsAnimating = true;
    }
}
