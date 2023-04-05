using Assets.Scripts;
using UnityEngine;

internal interface IControls
{
    bool IsFirePressed();
    Vector3 ControlsPosition(float y);
}

internal class ControllerControls : IControls
{
    public Vector3 ControlsPosition(float y)
    {
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");

        return new Vector3(horizontalInput, y, verticalInput);
    }

    public bool IsFirePressed()
    {
        return Input.GetKeyDown(KeyCode.Joystick1Button0);
    }
}

public class PlayerController : MonoBehaviour
{
    public float Speed;

    public GameObject FoodPrefab;

    public float ProjectileShift;

    private IControls _controls = new ControllerControls();

    void Update()
    {
        if (_controls.IsFirePressed())
        {
            var shift = transform.forward * ProjectileShift;
            Instantiate(FoodPrefab, transform.position + shift, transform.rotation);
        }

        var controlsPosition = _controls.ControlsPosition(transform.position.y);

        var lookAt = controlsPosition + transform.position;
        transform.LookAt(lookAt);

        var pos = transform.position + controlsPosition * Speed * Time.deltaTime;
        pos.x = Mathf.Max(Settings.Field.Left, pos.x);
        pos.x = Mathf.Min(Settings.Field.Right, pos.x);
        pos.z = Mathf.Max(Settings.Field.Bottom, pos.z);
        pos.z = Mathf.Min(Settings.Field.Top, pos.z);

        transform.position = pos;
    }
}
