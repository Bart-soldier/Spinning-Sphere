using UnityEngine;
using UnityEngine.InputSystem;

public class RotationController : MonoBehaviour
{
    public float RotationSpeed = 90.0f;

    private float Rotation = 0.0f;

    private bool GyroscopeSensorEnabled = false;
    //private Gyroscope Gyroscope;

    private void Awake()
    {
        Debug.Log("Looking");

        if (UnityEngine.InputSystem.Gyroscope.current != null)
        {
            Debug.Log("Found Gyro");
            GyroscopeSensorEnabled = true;
            InputSystem.EnableDevice(UnityEngine.InputSystem.Gyroscope.current);
        }

        //if(AttitudeSensor.current != null)
        //{
        //    GyroscopeSensorEnabled = true;
        //    InputSystem.EnableDevice(AttitudeSensor.current);
        //}
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Rotation = context.ReadValue<Vector2>().x;
    }

    public void OnGyroscope(InputAction.CallbackContext context)
    {
        Debug.Log("Gyroscope Angle = " + context.ReadValue<Vector3>());
        //transform.Rotate(new Vector3(0.0f, 0.0f, Rotation * RotationSpeed * Time.deltaTime));
    }

    private void FixedUpdate()
    {
        if(GyroscopeSensorEnabled)
        {
            Vector3 rotation = UnityEngine.InputSystem.Gyroscope.current.angularVelocity.ReadValue();
            Debug.Log("Angular Velocity = " + rotation);
            //transform.localRotation = AttitudeSensor.current.attitude.ReadValue();
            transform.Rotate(new Vector3(0.0f, 0.0f, rotation.z * RotationSpeed * Time.deltaTime));
        }
        else
        {
            transform.Rotate(new Vector3(0.0f, 0.0f, Rotation * RotationSpeed * Time.deltaTime));
        }
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

    //private bool EnableGyroscope()
    //{
    //    GyroscopeEnabled = false;

    //    if (SystemInfo.supportsGyroscope)
    //    {
    //        //Gyroscope = Input.gyro;
    //        GyroscopeEnabled = true;
    //    }

    //    return GyroscopeEnabled;
    //}
}
