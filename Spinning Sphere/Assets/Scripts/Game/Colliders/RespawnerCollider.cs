using UnityEngine;

public class RespawnerCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Obstacle"))
        {
            other.transform.localPosition = new Vector3(-3.9f, -1.95f, 13.9f);

            other.GetComponent<Renderer>().material.SetFloat("_Animation", 1.0f);
            other.GetComponent<DissolveAnimation>().StartAnimation = true;
        }
    }
}
