using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    public float BorderZTop;

    public float BorderZBottom;

    public float BorderXLeft;

    public float BorderXRight;

    void Update()
    {
        var z = transform.position.z;
        var x = transform.position.x;
        if (z > BorderZTop || z < BorderZBottom || x < BorderXLeft || x > BorderXRight)
        {
            Destroy(gameObject);
        }

        if (z < BorderZBottom)
        {
            Debug.Log("Game Over!");
        }
    }
}
