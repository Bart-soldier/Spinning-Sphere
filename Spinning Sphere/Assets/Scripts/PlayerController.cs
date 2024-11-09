using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 0.01f;

    private float GravityStrength = 9.81f;
    public float GravityDirection = (3 * Mathf.PI) / 2;

    void Start()
    {
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            GravityDirection = (GravityDirection - Speed * Time.deltaTime);
            GravityDirection = GravityDirection < 0 ? 2 * Mathf.PI - GravityDirection : GravityDirection;
        }
        if (Input.GetKey(KeyCode.D))
        {
            GravityDirection = (GravityDirection + Speed * Time.deltaTime) % (2 * Mathf.PI);
        }

        float x = Mathf.Cos(GravityDirection) * GravityStrength;
        float y = Mathf.Sin(GravityDirection) * GravityStrength;

        //bool verticalGravity = Mathf.Abs(y) >= Mathf.Abs(x);

        Physics.gravity = new Vector3(x, y, 0.0f);
        Debug.Log("X = " + x + ", Y = " + y);
        //Physics.gravity = new Vector3(verticalGravity ? 0.0f : x, verticalGravity ? y : 0.0f, 0.0f);
        //Debug.Log("Vertical : " + verticalGravity);
    }

    void Update()
    {
        
    }
}
