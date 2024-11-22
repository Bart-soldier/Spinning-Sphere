using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Keyboard Movement
    public float RollSpeed = 2.0f;
    private float RollDirection = 0.0f;
    private float Roll = Mathf.PI / 2.0f;

    public float GravitationalFactor = 5.0f;
    private float GravitationalForce = 9.81f;
    private bool GravitySensorEnabled = false;

    private void Awake()
    {
        if(GravitySensor.current != null)
        {
            GravitySensorEnabled = true;
            InputSystem.EnableDevice(GravitySensor.current);
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        RollDirection = -context.ReadValue<Vector2>().x;
    }

    private void FixedUpdate()
    {
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
