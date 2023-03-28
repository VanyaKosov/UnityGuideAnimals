using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    internal PlayerState PlayerState;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerState.gameObject)
        {
            PlayerState.DecrementLives();
        }
        else
        {
            PlayerState.IncrementScore();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
