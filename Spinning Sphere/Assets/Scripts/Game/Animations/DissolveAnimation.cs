using UnityEngine;

public class DissolveAnimation : MonoBehaviour
{
    public bool StartAnimation = false;
    public float Speed = 1.0f;
    
    public bool Visible { get; private set; }
    //public bool IsAnimating { get; private set; } = false;
    public bool IsAnimating = false;

    private Material Material;
    private bool Appearing = false;

    void Start()
    {
        Material = GetComponentInParent<Renderer>().material;
        Visible = Material.GetFloat("_Animation") <= 1.0f ? true : false;
    }

    void Update()
    {
        if(StartAnimation)
        {
            if(IsAnimating)
            {
                Appearing = !Appearing;
            }
            else
            {
                Appearing = Material.GetFloat("_Animation") >= 0.5f;
            }

            IsAnimating = true;
            StartAnimation = false;
        }

        if(IsAnimating)
        {
            float animation = Material.GetFloat("_Animation");
            animation = Appearing ? animation - Speed * Time.deltaTime :
                                    animation + Speed * Time.deltaTime;

            IsAnimating = animation > 0.0f && animation < 1.0f;

            if(!IsAnimating)
            {
                Visible = Appearing;
            }

            Material.SetFloat("_Animation", animation);
        }
    }
}
