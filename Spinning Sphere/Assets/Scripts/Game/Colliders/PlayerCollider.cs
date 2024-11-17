using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public GameFlow GameFlow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Obstacle"))
        {
            GameFlow.End();
        }
    }
}
