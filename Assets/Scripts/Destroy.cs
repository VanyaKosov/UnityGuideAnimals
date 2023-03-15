using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    public float BorderZTop;

    public float BorderZBottom;

    void Update()
    {
        var z = transform.position.z;
        if (z > BorderZTop || z < BorderZBottom)
        {
            Destroy(gameObject);
        }

        if (z < BorderZBottom)
        {
            Debug.Log("Game Over!");
        }
    }
}
