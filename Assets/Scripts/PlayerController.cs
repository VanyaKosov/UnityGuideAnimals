using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public float Speed;

    public float XRange;

    public GameObject FoodPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(FoodPrefab, transform.position, FoodPrefab.transform.rotation);
        }

        var horizontalInput = Input.GetAxis("Horizontal");

        var pos = transform.position + Vector3.right * horizontalInput * Speed * Time.deltaTime;
        pos.x = Mathf.Max(-XRange, pos.x);
        pos.x = Mathf.Min(XRange, pos.x);
        
        transform.position = pos;

        /*transform.Translate(Vector3.right * horizontalInput * Speed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Min(transform.position.x, 20), 0, 0);
        transform.position = new Vector3(Mathf.Max(transform.position.x, -20), 0, 0);*/

        /*if (transform.position.x > 20)
        {
            transform.position = new Vector3(20, 0, 0);
        }*/
    }
}
