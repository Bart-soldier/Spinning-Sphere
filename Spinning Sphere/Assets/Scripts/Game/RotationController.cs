using UnityEngine;

public class RotationController : MonoBehaviour
{
    public float RotationSpeed = 90.0f;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0.0f, 0.0f, RotationSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0.0f, 0.0f, -RotationSpeed * Time.deltaTime));
        }
    }
}
