using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Update()
    {
        var border = Settings.World;

        var z = transform.position.z;
        var x = transform.position.x;
        if (z > border.Top || z < border.Bottom || x < border.Left || x > border.Right)
        {
            Destroy(gameObject);
        }

        if (z < border.Bottom)
        {
            Debug.Log("Game Over!");
        }
    }
}
