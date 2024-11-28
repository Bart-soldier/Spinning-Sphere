using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DissolveAnimator : MonoBehaviour
{
    public UnityEvent AnimationCompleted = new UnityEvent();

    public List<DissolveAnimation> DissolveAnimations;

    private bool Animating = false;

    private void Awake()
    {
        foreach (var animator in DissolveAnimations)
        {
            animator.GetComponentInParent<Renderer>().material.SetFloat("_Animation", 1.0f);
            animator.AnimationCompleted.AddListener(OnAnimationCompleted);
        }
    }

    public void Animate()
    {
        Animating = true;

        foreach (var animator in DissolveAnimations)
        {
            animator.Animate();
        }
    }

    public void AnimateIn()
    {
        Animating = true;

        foreach (var animator in DissolveAnimations)
        {
            animator.DissolveIn();
        }
    }

    public void AnimateOut()
    {
        Animating = true;

        foreach (var animator in DissolveAnimations)
        {
            animator.DissolveOut();
        }
    }

    private void OnAnimationCompleted()
    {
        if(Animating)
        {
            Animating = false;
            AnimationCompleted.Invoke();
        }
    }
}
