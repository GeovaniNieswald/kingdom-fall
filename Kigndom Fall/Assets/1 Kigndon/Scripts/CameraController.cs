using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour{

    public Transform target;

    private Vector3 velocity = Vector3.zero;

    public float smoothTime = 0.3f;

    // Update is called once per frame
    void FixedUpdate() {
        Vector3 vector = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
        transform.position = new Vector3(vector.x, Mathf.Clamp(vector.y, 0, vector.y), transform.position.z);
    }
}
