using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D rb;
    private float speed;

    private Vector2 direction;
    private Vector3 mousePos;

    private Camera cam;
    private SpriteRenderer render;

    private float dashSpeed = 20f;
    private float dashCD = 0.75f;
    private bool canDash = true;
    private bool isDashing = false;
    private float dashingTime = 0.3f;

    public InputAction playerControls;

    private void OnEnable() {
        playerControls.Enable();
    }

    private void OnDisable() {
        playerControls.Disable();
    }

    void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        speed = 10f;
        cam = Camera.main;
        render = GameObject.Find("PlayerModel").GetComponent<SpriteRenderer>();
    }

    void Update() {
        direction = playerControls.ReadValue<Vector2>();

        mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 5.23f;
        Look();
    }

    private void FixedUpdate() {
        if (!isDashing)
            rb.velocity = direction * speed;
    }

    private void Look() {
        Vector3 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        if (angle > 90 || angle < -90) {
            render.flipX = true;
        } else {
            render.flipX = false;
        }
    }
    public void InitDash() {
        Debug.Log("enter dash cmd");
        if (canDash) {
            Debug.Log("dashing");
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash() {
        canDash = false;
        isDashing = true;
        rb.velocity = direction * dashSpeed;
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        yield return new WaitForSeconds(dashCD);
        canDash = true;
    }
}
