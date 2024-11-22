using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Keyboard Controller
    [Header("Keyboard Controller")]
    public float RollSpeed = 2.0f;
    private float RollDirection = 0.0f;
    private float Roll = Mathf.PI / 2.0f;

    // Sensor Controller
    private float GravitationalForce = 9.81f;
    private bool GravitySensorEnabled = false;

    // Controller
    [Header("Controller")]
    public Rigidbody PlayerRigidbody;
    public float GravitationalFactor = 5.0f;
    private bool Enabled = false;

    private void Awake()
    {
        if (GravitySensor.current != null)
        {
            GravitySensorEnabled = true;
            InputSystem.EnableDevice(GravitySensor.current);
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        RollDirection = -context.ReadValue<Vector2>().x;
    }

    public void EnableController()
    {
        PlayerRigidbody.useGravity = true;

        Enabled = true;
    }

    public void DisableController()
    {
        PlayerRigidbody.useGravity = false;
        PlayerRigidbody.angularVelocity = Vector3.zero;
        PlayerRigidbody.linearVelocity = Vector3.zero;

        Enabled = false;
    }

    public void ResetValues()
    {
        transform.localRotation = Quaternion.identity;
        transform.localPosition = Vector3.zero;

        Roll = Mathf.PI / 2.0f;
        Physics.gravity = new Vector3(0.0f, -GravitationalForce, 0.0f);
    }

    private void FixedUpdate()
    {
        if(!Enabled)
        {
            return;
        }

        float x = 0.0f;
        float y = 0.0f;

        if (GravitySensorEnabled)
        {
            Vector3 gravity = GravitySensor.current.gravity.ReadValue();
            x = gravity.x;
            y = gravity.y;
        }
        else
        {
            Roll += (RollDirection * RollSpeed * Time.deltaTime);
            Roll %= (2.0f * Mathf.PI);
            Roll = Roll < 0 ? (2.0f * Mathf.PI) - Roll : Roll;

            x = math.cos(Roll);
            y = -math.sin(Roll);
        }

        x *= GravitationalForce * GravitationalFactor;
        y *= GravitationalForce * GravitationalFactor;

        Physics.gravity = new Vector3(x, y, 0.0f);
    }
}
