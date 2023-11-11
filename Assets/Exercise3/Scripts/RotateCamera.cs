using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float leftLimit;//gioi han quay trai
    public float rightLimit;//gioi han quay phai
    private float rotationX = 0;

    void Start()
    {

        transform.position = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;//lay gia tri di chuyen cua chuot theo chieu ngang
            rotationX += mouseX;
            rotationX = Mathf.Clamp(rotationX, leftLimit, rightLimit);//gioi han goc quay
            //ap dung goc quay moi vao camera
            transform.rotation = Quaternion.Euler(0, rotationX, 0);
        }
    }
}
