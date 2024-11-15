using System.Collections.Generic;
using UnityEngine;

public class TextureOffsetAnimator : MonoBehaviour
{
    public List<TextureOffsetAnimation> TextureOffsetAnimations;

    public bool ToggleAnimation = false;
    public float AnimationTargetZ = 6.0f;
    public float AnimationSpeed = 6.0f;
    private bool AnimationFinished = true;
    private bool Animating = false;

    void Update()
    {
        Animate();
    }

    private void Animate()
    {
        if (ToggleAnimation)
        {
            Animating = !Animating;
            AnimationFinished = false;

            ToggleAnimation = false;
        }

        if (!AnimationFinished)
        {
            float z = Animating ? transform.localScale.z + AnimationSpeed * Time.deltaTime :
                                  transform.localScale.z - AnimationSpeed * Time.deltaTime;

            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, z);

            AnimationFinished = Animating ? z >= AnimationTargetZ :
                                                 z <= 1.0f;

            if (AnimationFinished)
            {
                foreach (var animator in TextureOffsetAnimations)
                {
                    animator.Enable = Animating;
                }
            }
        }
    }
}
