using UnityEngine;

namespace Assets.Scripts
{
    internal abstract class Controls
    {
        public bool IsActive
        {
            get
            {
                return IsFirePressed() || ControlsPosition(Vector3.zero) != Vector3.zero;
            }
        }

        public abstract bool IsFirePressed();

        public abstract Vector3 ControlsPosition(Vector3 playerPos);
    }

    internal class ControllerControls : Controls
    {
        public override Vector3 ControlsPosition(Vector3 playerPos)
        {
            var verticalInput = Input.GetAxis("Vertical");
            var horizontalInput = Input.GetAxis("Horizontal");

            return new Vector3(horizontalInput, playerPos.y, verticalInput);
        }

        public override bool IsFirePressed()
        {
            return Input.GetKeyDown(KeyCode.Joystick1Button0);
        }
    }

    internal class MouseControls : Controls
    {
        private readonly Camera _camera;

        public MouseControls(Camera camera)
        {
            _camera = camera;
        }

        public override Vector3 ControlsPosition(Vector3 playerPos)
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

        public override bool IsFirePressed()
        {
            return Input.GetKeyDown(KeyCode.Mouse1);
        }
    }
}
