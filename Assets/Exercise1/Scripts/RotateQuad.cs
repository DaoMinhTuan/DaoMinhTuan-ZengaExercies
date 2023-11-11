using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class RotateQuad : MonoBehaviour
{
    private Camera mainCamera;
    private bool isDragging = false;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // kiem tra xem nguoi choi co nhan giu chuot khong
        if (Input.GetMouseButtonDown(0))
        {
            //Thuc hien raycast tu vi tri chuot tren man hinh
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //kiem tra xem ray co cham vao quad khong
                if (hit.collider.gameObject.CompareTag("Quad"))
                {
                    isDragging = true;
                    offset = transform.position - hit.point;
                }
            }
        }

        if (isDragging && Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //kiem tra xem ray co cham vao quad khong
                if (hit.collider.gameObject.CompareTag("Quad"))
                {
                    //di chuyen cube toi vi tri chuot tren be mat quad
                    transform.position = hit.point + offset;
                }
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            //ket thuc nha chuot
            isDragging = false;
        }
    }
}
