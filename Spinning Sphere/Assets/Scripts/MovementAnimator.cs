using UnityEngine;

public class MovementAnimator : MonoBehaviour
{
    public bool Animate = false;
    public float AnimationSpeed = 1.0f;

    void Update()
    {
        if (Animate)
        {
            Vector2 movement = this.GetComponent<Renderer>().material.GetVector("_Texture_Offset");
            movement -= new Vector2(0.0f, AnimationSpeed * Time.deltaTime);

            this.GetComponent<Renderer>().material.SetVector("_Texture_Offset", movement);
        }
    }
}
