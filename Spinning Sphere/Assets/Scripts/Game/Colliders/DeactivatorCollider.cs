using UnityEngine;

public class DeactivatorCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Obstacle"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
