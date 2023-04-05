using Assets.Scripts;
using UnityEngine;

internal interface IControls
{
    bool IsFirePressed();
    Vector3 ControlsPosition(Vector3 playerPos);
}

internal class ControllerControls : IControls
{
    public Vector3 ControlsPosition(Vector3 playerPos)
    {
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");

        return new Vector3(horizontalInput, playerPos.y, verticalInput);
    }

    public bool IsFirePressed()
    {
        return Input.GetKeyDown(KeyCode.Joystick1Button0);
    }
}

internal class MouseControls : IControls
{
    private readonly Camera _camera;

    public MouseControls(Camera camera)
    {
        _camera = camera;
    }

    public Vector3 ControlsPosition(Vector3 playerPos)
    {
        if (!Input.GetKey(KeyCode.Mouse0))
        {
            return new Vector3(0, playerPos.y, 0);
        }

        var lookAt = _camera.ScreenToWorldPoint(Input.mousePosition) - playerPos;
        lookAt.y = playerPos.y;

        if (lookAt.sqrMagnitude < 0.2)
        {
            return new Vector3(0, playerPos.y, 0);
        }

        return lookAt.normalized;
    }

    public bool IsFirePressed()
    {
        return Input.GetKeyDown(KeyCode.Mouse1);
    }
}

public class PlayerController : MonoBehaviour
{
    public float Speed;

    public GameObject FoodPrefab;

    public float ProjectileShift;

    public Camera Camera;

    //private IControls _controls = new ControllerControls();
    private IControls _controls;

    void Start()
    {
        _controls = new MouseControls(Camera);
    }

    void Update()
    {
        if (_controls.IsFirePressed())
        {
            var shift = transform.forward * ProjectileShift;
            Instantiate(FoodPrefab, transform.position + shift, transform.rotation);
        }

        var controlsPosition = _controls.ControlsPosition(transform.position);

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
