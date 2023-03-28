using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    public GameObject FoodPrefab;

    public float ProjectileShift;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            var shift = transform.forward * ProjectileShift;
            Instantiate(FoodPrefab, transform.position + shift, transform.rotation);
        }

        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");

        var controllerPosition = new Vector3(horizontalInput, transform.position.y, verticalInput);
        var lookAt = controllerPosition + transform.position;
        transform.LookAt(lookAt);

        var pos = transform.position + controllerPosition * Speed * Time.deltaTime;
        pos.x = Mathf.Max(Settings.Field.Left, pos.x);
        pos.x = Mathf.Min(Settings.Field.Right, pos.x);
        pos.z = Mathf.Max(Settings.Field.Bottom, pos.z);
        pos.z = Mathf.Min(Settings.Field.Top, pos.z);

        transform.position = pos;
    }
}
