using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DissolveAnimator : MonoBehaviour
{
    public bool ToggleAnimation = false;
    public List<DissolveAnimation> DissolveAnimations;

    public bool Visible = false;

    private bool Animating = false;

    void Start()
    {
        foreach (var animator in DissolveAnimations)
        {
            animator.GetComponentInParent<Renderer>().material.SetFloat("_Animation", 1.0f);
        }
    }

    void Update()
    {
        Dissolve();
    }

    private void Dissolve()
    {
        if (ToggleAnimation)
        {
            Animating = true;
            ToggleAnimation = false;

            foreach (var animator in DissolveAnimations)
            {
                animator.Animate = true;
                animator.IsAnimating = true;
            }
        }

        if (Animating && DissolveAnimations.FirstOrDefault().IsAnimating == false)
        {
            Animating = false;
            Visible = !Visible;
        }
    }
}
