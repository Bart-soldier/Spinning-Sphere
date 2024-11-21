using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class RotationController : MonoBehaviour
{
    public float RotationSpeed = 90.0f;

    private float Rotation = 0.0f;

    private bool GyroscopeEnabled = false;
    //private Gyroscope Gyroscope;

    public void OnMovement(InputAction.CallbackContext context)
    {
        Rotation = context.ReadValue<Vector2>().x;
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0.0f, 0.0f, Rotation * RotationSpeed * Time.deltaTime));
    }

    //void FixedUpdate()
    //{
    //    //if(GyroscopeEnabled)
    //    //{
    //    //    //transform.localRotation = Gyroscope.attitude;
    //    //}
    //    //else
    //    //{
    //    //    transform.Rotate(new Vector3(0.0f, 0.0f, Rotate.ReadValue<Vector2>().x * RotationSpeed * Time.deltaTime));

    //    //    //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
    //    //    //{
    //    //    //    transform.Rotate(new Vector3(0.0f, 0.0f, RotationSpeed * Time.deltaTime));
    //    //    //}
    //    //    //else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
    //    //    //{
    //    //    //    transform.Rotate(new Vector3(0.0f, 0.0f, -RotationSpeed * Time.deltaTime));
    //    //    //}
    //    //}
    //}

    private bool EnableGyroscope()
    {
        GyroscopeEnabled = false;

        if (SystemInfo.supportsGyroscope)
        {
            //Gyroscope = Input.gyro;
            GyroscopeEnabled = true;
        }

        return GyroscopeEnabled;
    }
}
