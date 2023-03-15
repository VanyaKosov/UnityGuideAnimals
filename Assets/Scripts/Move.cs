using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float Speed;

    public Vector3 Direction;

    // Start is called before the first frame update
    void Start()
    {
        Direction = Direction.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Direction * Speed * Time.deltaTime);
    }
}
