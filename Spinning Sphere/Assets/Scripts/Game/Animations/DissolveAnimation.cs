using UnityEngine;
using UnityEngine.Events;

#nullable enable

public class DissolveAnimation : MonoBehaviour
{
    public UnityEvent AnimationCompleted = new UnityEvent();

    public float AnimationSpeed = 1.0f;
    
    public bool Visible {
        get => Material.GetFloat("_Animation") < 1.0f;
    }

    private Material? material = null;
    public Material Material
    {
        get
        {
            if(material == null)
            {
                material = GetComponent<Renderer>().material;
            }

            return material;
        }
    }

    private bool IsAnimating = false;
    private bool Appearing = false;

    private void Update()
    {
        if(IsAnimating)
        {
            float animation = Material.GetFloat("_Animation");
            animation = Appearing ? animation - AnimationSpeed * Time.deltaTime :
                                    animation + AnimationSpeed * Time.deltaTime;

            IsAnimating = animation > 0.0f && animation < 1.0f;

            Material.SetFloat("_Animation", animation);

            if(!IsAnimating)
            {
                AnimationCompleted.Invoke();
            }
        }
    }

    public void Animate()
    {
        if (IsAnimating)
        {
            Appearing = !Appearing;
        }
        else
        {
            Appearing = !Visible;
        }

        IsAnimating = true;
    }

    public void DissolveIn()
    {
        Material.SetFloat("_Animation", 1.0f);
        Animate();
    }

    public void DissolveOut()
    {
        Material.SetFloat("_Animation", 0.0f);
        Animate();
    }

    public void DissolveInIfNotVisible()
    {
        if(!Visible)
        {
            Animate();
        }
    }

    public void DissolveOutIfVisible()
    {
        if(Visible)
        {
            Animate();
        }
    }
}
