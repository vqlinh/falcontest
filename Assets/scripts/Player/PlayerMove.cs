using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Camera cam;
    private Vector3 initialMouseWorldPos;
    private bool isDragging = false;

    public float dragThreshold = 0.1f; 

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialMouseWorldPos = GetMouseWorldPosition();
            isDragging = false;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentMouseWorldPos = GetMouseWorldPosition();
            float distance = Vector2.Distance(initialMouseWorldPos, currentMouseWorldPos);
            if (distance > dragThreshold) isDragging = true;
            if (isDragging) MoveTo(currentMouseWorldPos);
        }
        if (Input.GetMouseButtonUp(0)) isDragging = false;
    }
    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        return mousePos;
    }
    void MoveTo(Vector3 targetPos)
    {
        Vector3 min = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 max = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
        targetPos.x = Mathf.Clamp(targetPos.x, min.x, max.x);
        targetPos.y = Mathf.Clamp(targetPos.y, min.y, max.y);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 10f);
    }
}