using UnityEngine;

public class DissolveAnimator : MonoBehaviour
{
    public bool StartAnimation = false;
    public float AnimationSpeed = 1.5f;
    
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
            animation = Appearing ? animation - AnimationSpeed * Time.deltaTime : animation + AnimationSpeed * Time.deltaTime;

            IsAnimating = animation > 0.0f && animation < 1.0f;

            this.GetComponent<Renderer>().material.SetFloat("_Animation", animation);
        }
    }
}
