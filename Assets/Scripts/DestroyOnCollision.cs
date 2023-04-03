using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public int Points;

    public Health Health;

    internal PlayerState PlayerState;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerState.gameObject)
        {
            PlayerState.DecrementLives();
            return;
        }
        if (Health.Reduce())
        {
            PlayerState.IncrementScore(Points);
            Destroy(gameObject);
        }
        Destroy(other.gameObject);
    }
}
