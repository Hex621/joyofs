using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private Vector3 dragOrigin;
    [SerializeField] private float zoomStep, minCamSize, maxCamSize;
    [SerializeField] private SpriteRenderer boundSprite;

    private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    private void Awake()
    {
        mapMinX = boundSprite.transform.position.x - boundSprite.bounds.size.x / 2f;
        mapMaxX = boundSprite.transform.position.x + boundSprite.bounds.size.x / 2f;

        mapMinY = boundSprite.transform.position.y - boundSprite.bounds.size.y / 2f;
        mapMaxY = boundSprite.transform.position.y + boundSprite.bounds.size.y / 2f;
    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;


        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }




    private void Update()
    {
        
            PanCamera();
    }

    private void PanCamera()
        {
            if(Input.GetMouseButtonDown(1))
            {
                dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(1))
            {
                Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            cam.transform.position = ClampCamera(cam.transform.position + difference);
            }
        }
        

        public void ZoomIn()
    {
        float newSize = cam.orthographicSize - zoomStep;

        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
        cam.transform.position = ClampCamera(cam.transform.position);
    }
    public void ZoomOut()
    {
        float newSize = cam.orthographicSize + zoomStep;

        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
        cam.transform.position = ClampCamera(cam.transform.position);
    }
}
