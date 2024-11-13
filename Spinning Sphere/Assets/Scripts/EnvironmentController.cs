using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    public List<DissolveAnimator> DissolveAnimators;

    public bool Spawn = false;
    public bool HasSpawned = false;
    private bool Spawning = false;

    public bool Animate = false;
    public Vector3 SpeedAnimationEnd = new Vector3(0.0f, 0.0f, 4.0f);
    private bool AnimationStarting = false;

    private void Update()
    {
        SpawnIfApplicable();
        VerifyHasSpawned();
    }

    private void SpawnIfApplicable()
    {
        if(Spawn)
        {
            Spawning = true;
            Spawn = false;

            foreach (var animator in DissolveAnimators)
            {
                animator.StartAnimation = true;
                animator.IsAnimating = true;
            }
        }
    }

    private void VerifyHasSpawned()
    {
        if (Spawning && DissolveAnimators.FirstOrDefault()?.IsAnimating == false)
        {
            Spawning = false;
            HasSpawned = true;
        }
    }
}
