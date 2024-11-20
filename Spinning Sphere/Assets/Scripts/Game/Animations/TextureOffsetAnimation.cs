using UnityEngine;

public class TextureOffsetAnimation : MonoBehaviour
{
    public bool Animate = false;
    public float Speed = 1.0f;

    void Update()
    {
        if (Animate)
        {
            Vector2 movement = this.GetComponent<Renderer>().material.GetVector("_Texture_Offset");
            movement -= new Vector2(0.0f, Speed * Time.deltaTime);

            this.GetComponent<Renderer>().material.SetVector("_Texture_Offset", movement);
        }
    }
}
