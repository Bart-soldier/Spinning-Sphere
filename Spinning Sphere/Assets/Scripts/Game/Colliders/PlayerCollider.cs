using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public GameController GameFlow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Obstacle"))
        {
            GameFlow.End();
        }
    }
}
