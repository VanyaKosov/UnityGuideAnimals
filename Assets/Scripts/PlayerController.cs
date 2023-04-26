using Assets.Scripts;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    public GameObject FoodPrefab;

    public float ProjectileShift;

    public Camera Camera;

    private int _currentControls;

    private Controls[] _controls;

    void Start()
    {
        _controls = new Controls[]
        {
            new KeyboardControls(),
            new ControllerControls(),
            new MouseControls(Camera)
        };
    }

    private void SwitchControls()
    {
        if (_controls[_currentControls].IsActive) return;
        for (var i = 0; i < _controls.Length; i++)
        {
            if (_controls[i].IsActive)
            {
                _currentControls = i;
                return;
            }
        }
    }

    void Update()
    {
        SwitchControls();

        var controls = _controls[_currentControls];

        if (controls.IsFirePressed())
        {
            var shift = transform.forward * ProjectileShift;
            Instantiate(FoodPrefab, transform.position + shift, transform.rotation);
        }

        var controlsPosition = controls.ControlsPosition(transform.position);

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
