using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    public List<DissolveAnimator> DissolveAnimators;
    public List<MovementAnimator> MovementAnimators;

    public bool ToggleSpawn = false;
    public bool HasSpawned = false;
    private bool Spawning = false;

    public bool ToggleAnimation = false;
    public float SpeedAnimationTargetZ = 6.0f;
    public float AnimationSpeed = 6.0f;
    private bool SpeedAnimationFinished = true;
    private bool Animating = false;

    void Start()
    {
        foreach (var animator in DissolveAnimators)
        {
            animator.GetComponentInParent<Renderer>().material.SetFloat("_Animation", 1.0f);
        }
    }

    void Update()
    {
        Spawn();

        Animate();
    }

    private void Spawn()
    {
        if (ToggleSpawn)
        {
            Spawning = true;
            ToggleSpawn = false;

            foreach (var animator in DissolveAnimators)
            {
                animator.StartAnimation = true;
                animator.IsAnimating = true;
            }
        }

        if (Spawning && DissolveAnimators.FirstOrDefault()?.IsAnimating == false)
        {
            Spawning = false;
            HasSpawned = true;
        }
    }

    private void Animate()
    {
        if (ToggleAnimation)
        {
            Animating = !Animating;
            SpeedAnimationFinished = false;

            ToggleAnimation = false;
        }

        if (!SpeedAnimationFinished)
        {
            float z = Animating ? transform.localScale.z + AnimationSpeed * Time.deltaTime :
                                  transform.localScale.z - AnimationSpeed * Time.deltaTime;

            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, z);

            SpeedAnimationFinished = Animating ? z >= SpeedAnimationTargetZ :
                                                 z <= 1.0f;

            if (SpeedAnimationFinished)
            {
                foreach (var animator in MovementAnimators)
                {
                    animator.Animate = Animating;
                }
            }
        }
    }
}
