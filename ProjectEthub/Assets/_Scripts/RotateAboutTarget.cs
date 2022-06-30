using UnityEngine;
using UnityEngine.InputSystem;

public class RotateAboutTarget : MonoBehaviour
{
    public Transform parent;
    private Vector2 direction;
    private Camera cam;
    private float angle;
    void Start()
    {
        parent = transform.parent;
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position;
        direction.Normalize();
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        if (angle > 90 || angle < -90) {
            if (parent.transform.eulerAngles.y == 0) {
                transform.localRotation = Quaternion.Euler(180, 0, -angle);
            } else if (parent.transform.eulerAngles.y == 180) {
                transform.localRotation = Quaternion.Euler(180, 180, -angle);
            }
        }
    }
}
