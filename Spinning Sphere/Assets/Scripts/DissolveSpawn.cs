using UnityEngine;

public class DissolveSpawn : MonoBehaviour
{
    public DissolveAnimator DissolveAnimator;
    public Rigidbody Rigidbody;

    private bool Spawning = false;

    void Start()
    {
        Spawning = true;
        Rigidbody.useGravity = false;
        DissolveAnimator.StartAnimation = true;
        DissolveAnimator.IsAnimating = true;

        this.GetComponent<Renderer>().material.SetFloat("_Animation", 1.0f);
    }

    void Update()
    {
        if(Spawning && !DissolveAnimator.IsAnimating)
        {
            Spawning = false;
            Rigidbody.useGravity = true;
        }
    }
}
