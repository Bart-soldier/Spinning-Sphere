using UnityEngine;

#nullable enable

public class DissolveAnimation : MonoBehaviour
{
    public bool Animate = false;
    public float Speed = 1.0f;
    
    public bool Visible {
        get => Material.GetFloat("_Animation") < 1.0f;
    }
    public bool IsAnimating = false;

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
    private bool Appearing = false;

    void Update()
    {
        if (Animate)
        {
            if(IsAnimating)
            {
                Appearing = !Appearing;
            }
            else
            {
                Appearing = !Visible;
            }

            IsAnimating = true;
            Animate = false;
        }

        if(IsAnimating)
        {
            float animation = Material.GetFloat("_Animation");
            animation = Appearing ? animation - Speed * Time.deltaTime :
                                    animation + Speed * Time.deltaTime;

            IsAnimating = animation > 0.0f && animation < 1.0f;

            Material.SetFloat("_Animation", animation);
        }
    }

    public void DissolveIn()
    {
        Material.SetFloat("_Animation", 1.0f);
        Animate = true;
    }

    public void DissolveOut()
    {
        Material.SetFloat("_Animation", 0.0f);
        Animate = true;
    }

    public void DissolveInIfNotVisible()
    {
        if(!Visible)
        {
            Animate = true;
        }
    }

    public void DissolveOutIfVisible()
    {
        if(Visible)
        {
            Animate = true;
        }
    }
}
