using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateQuadEx2 : MonoBehaviour
{
    private Camera mainCamera;
    private bool isRotating = false;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    isRotating = true;
                }
            }
        }

        if (isRotating && Input.GetMouseButton(0))
        {
            RotateQuadWithMouse();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }
    }

    void RotateQuadWithMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 mousePosition = hit.point;
            Vector3 quadCenter = transform.position;

            Vector3 direction = mousePosition - quadCenter;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}