using UnityEngine;

public class RotationController : MonoBehaviour
{
    public Transform Transform;
    public float RotationSpeed = 90.0f;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Transform.Rotate(new Vector3(0.0f, 0.0f, -RotationSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            Transform.Rotate(new Vector3(0.0f, 0.0f, RotationSpeed * Time.deltaTime));
        }
    }
}
