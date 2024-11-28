using System.Collections.Generic;
using UnityEngine;

public class TextureOffsetAnimator : MonoBehaviour
{
    public List<TextureOffsetAnimation> TextureOffsetAnimations;

    public float AnimationTargetZ = 6.0f;
    public float AnimationSpeed = 6.0f;

    private bool Animating = false;
    private bool Speeding = false;

    void Update()
    {
        Animate();
    }

    public void StartSpeedAnimation()
    {
        Animating = true;
        Speeding  = true;
    }

    public void StopSpeedAnimation()
    {
        Animating = true;
        Speeding  = false;
    }

    private void Animate()
    {
        if(Animating)
        {
            float z = Speeding ? transform.localScale.z + AnimationSpeed * Time.deltaTime :
                                 transform.localScale.z - AnimationSpeed * Time.deltaTime;

            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, z);

            Animating = Speeding ? z < AnimationTargetZ :
                                   z > 1.0f;

            if (!Animating)
            {
                foreach (var animator in TextureOffsetAnimations)
                {
                    animator.Animate = Speeding;
                }
            }
        }
    }
}
