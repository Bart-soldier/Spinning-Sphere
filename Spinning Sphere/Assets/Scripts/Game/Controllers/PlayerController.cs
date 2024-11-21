using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float RotationSpeed = 2.0f;
    private float Direction = 0.0f;

    private float GravitationalForce = 9.81f;
    private float Roll = Mathf.PI / 2.0f;
    private bool AttitudeSensorEnabled = false;

    private void Awake()
    {
        if (AttitudeSensor.current != null)
        {
            AttitudeSensorEnabled = true;
            InputSystem.EnableDevice(AttitudeSensor.current);
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Direction = -context.ReadValue<Vector2>().x;
    }

    private void FixedUpdate()
    {
        if (AttitudeSensorEnabled)
        {
            Roll = (AttitudeSensor.current.attitude.ReadValue().eulerAngles.z) * Mathf.Deg2Rad;
        }
        else
        {
            Roll += (Direction * RotationSpeed * Time.deltaTime);
            Roll %= (2.0f * Mathf.PI);
            Roll = Roll < 0 ? (2.0f * Mathf.PI) - Roll : Roll;

            //float x = math.cos(Rotation) * GravitationalForce;
            //float y = math.sin(Rotation) * GravitationalForce;

            //RaycastHit hitInfo;

            //Physics.Raycast(transform.position, new Vector3(x, y, 0.0f), out hitInfo);


            //Debug.Log("Barycentric Coordinate : " + hitInfo.point);
            //Physics.gravity = hitInfo.point;

            //Physics.gravity = new Vector3(x, y, 0.0f);
            //transform.position = hitInfo.point;
            //Rigidbody.AddForce(hitInfo.point, ForceMode.Force);
        }

        float x =  math.cos(Roll) * GravitationalForce;
        float y = -math.sin(Roll) * GravitationalForce;

        Physics.gravity = new Vector3(x, y, 0.0f);
    }
}
