using UnityEngine;

public class RotationController : MonoBehaviour
{
    public Transform Transform;
    public float RotationSpeed = 90.0f;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Transform.Rotate(new Vector3(0.0f, 0.0f, -RotationSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Transform.Rotate(new Vector3(0.0f, 0.0f, RotationSpeed * Time.deltaTime));
        }
    }
}
