using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAboutTarget : MonoBehaviour
{
    public Transform parent;
    private Vector2 direction;
    private Vector2 adjustment;
    private Vector2 origin;
    private Camera cam;
    private float angle;
    void Start()
    {
        parent = transform.parent;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        origin = parent.transform.position;
        direction = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x);
        adjustment = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        Debug.Log(angle);
        transform.position = origin + adjustment;
        angle *= Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 3f);
    }
}
