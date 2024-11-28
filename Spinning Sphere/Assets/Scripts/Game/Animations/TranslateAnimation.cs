using UnityEngine;

public class TranslateAnimation : MonoBehaviour
{
    public bool Animate = false;
    public float Speed = 60.0f;

    private void Update()
    {
        if(!Animate)
        {
            return;
        }

        float z = transform.position.z - Speed * Time.deltaTime;

        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
}
