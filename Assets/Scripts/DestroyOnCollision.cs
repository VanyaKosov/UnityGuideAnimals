using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    internal PlayerState PlayerState;

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);

        PlayerState.IncrementScore();
    }
}
