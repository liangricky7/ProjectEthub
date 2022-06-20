using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        speed = 10f;
        cam = Camera.main;
        render = GameObject.Find("PlayerModel").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector2(horizontal, vertical).normalized;

        mousePos = Input.mousePosition;
        mousePos.z = 5.23f;
        Look();
    }

    private void FixedUpdate() {
        if (!isDashing) rb.velocity = direction * speed;
    }

    private void Look() {
        Vector3 lookDir = mousePos - cam.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        if (angle > 90 || angle < -90) {
            render.flipX = true;
        } else {
            render.flipX = false;
        }
    }
    public void InitDash() {
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
