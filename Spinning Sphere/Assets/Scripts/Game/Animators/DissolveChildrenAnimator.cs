using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DissolveChildrenAnimator : MonoBehaviour
{
    public bool Visible = false;

    public bool ToggleDissolve = false;
    private bool Dissolving = false;

    void Start()
    {
        foreach (var animator in GetComponentsInChildren<DissolveAnimation>())
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
        if (ToggleDissolve)
        {
            Dissolving = true;
            ToggleDissolve = false;

            foreach (var animator in GetComponentsInChildren<DissolveAnimation>())
            {
                animator.StartAnimation = true;
                animator.IsAnimating = true;
            }
        }

        if (Dissolving && GetComponentsInChildren<DissolveAnimation>().FirstOrDefault().IsAnimating == false)
        {
            Dissolving = false;
            Visible = !Visible;
        }
    }
}
