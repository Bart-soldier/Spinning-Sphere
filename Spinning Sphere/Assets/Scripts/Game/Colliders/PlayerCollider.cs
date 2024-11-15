using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public RotationController RotationController;
    public GameAnimator GameAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Obstacle"))
        {
            RotationController.enabled = false;
            GameAnimator.Despawn = true;
        }
    }
}
