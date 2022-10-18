using System.Collections;
using UnityEngine;

public class RotateAboutTargetEnemy : MonoBehaviour {
    public GameObject parent;
    private GameObject target;
    
    private Vector2 direction;
    private Quaternion originalRotation;
    private float angle;
    private bool isActivated;
    void Awake() {
        isActivated = false;
    }
    private void Start() {
        target = PlayerManager.instance.player;
    }
    void FixedUpdate() {
        if (isActivated) {
            direction = target.transform.position - transform.position;
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

    public void Activate() {
        //StartCoroutine(Adjust());
        isActivated = true;
    }
    //IEnumerator Adjust() { //slowly rotate to target (implement later)
    //    angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //    Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
    //    Debug.Log(targetRotation);
    //    while (transform.rotation != targetRotation) {
    //        Quaternion.RotateTowards(transform.rotation, targetRotation, 2f * Time.deltaTime);
    //        yield return null;
    //    }
    //    isActivated = true;
    //}

    public void Deactivate() {
        transform.rotation = originalRotation;
        gameObject.SetActive(false);
    }
}
