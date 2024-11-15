using UnityEngine;

public class DissolveAnimation : MonoBehaviour
{
    public bool StartAnimation = false;
    public float Speed = 1.0f;
    
    public bool IsAnimating = false;

    private bool Appearing = false;

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
                Appearing = this.GetComponent<Renderer>().material.GetFloat("_Animation") >= 0.5f;
            }

            IsAnimating = true;
            StartAnimation = false;
        }

        if(IsAnimating)
        {
            float animation = this.GetComponent<Renderer>().material.GetFloat("_Animation");
            animation = Appearing ? animation - Speed * Time.deltaTime :
                                    animation + Speed * Time.deltaTime;

            IsAnimating = animation > 0.0f && animation < 1.0f;

            this.GetComponent<Renderer>().material.SetFloat("_Animation", animation);
        }
    }
}
