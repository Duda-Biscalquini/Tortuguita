using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFollow : MonoBehaviour
{
    public Transform follow;
    public float sensivity;

    Vector3 offset;
    float radius;
    float mouseX;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - follow.position;
        radius = offset.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = follow.position + offset;

        mouseX -= Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        offset = new Vector3(Mathf.Cos(mouseX) * radius, offset.y, Mathf.Sin(mouseX) * radius);
    }
}