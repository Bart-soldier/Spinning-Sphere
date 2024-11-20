using UnityEngine;

public class TranslateAnimation : MonoBehaviour
{
    public float Speed = 60.0f;

    void Update()
    {
        if(GameFlow.IsGameEnded)
        {
            return;
        }

        float z = transform.position.z - Speed * Time.deltaTime;

        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
}
