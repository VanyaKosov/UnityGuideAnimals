using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public float Speed;

    public float XRange;

    public float ZRangeTop;

    public float ZRangeBottom;

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

        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");

        var controllerPosition = new Vector3(horizontalInput, transform.position.y, verticalInput);
        var lookAt = controllerPosition + transform.position;
        transform.LookAt(lookAt);

        var pos = transform.position + controllerPosition * Speed * Time.deltaTime;
        pos.x = Mathf.Max(-XRange, pos.x);
        pos.x = Mathf.Min(XRange, pos.x);
        pos.z = Mathf.Max(ZRangeBottom, pos.z);
        pos.z = Mathf.Min(ZRangeTop, pos.z);

        transform.position = pos;
    }
}
