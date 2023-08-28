using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] Camera raycastCamera;
    // Start is called before the first frame update
    void Start()
    {
        raycastCamera ??= Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        var ray = Physics2D.GetRayIntersection(raycastCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        //Vector3 mousePosition = Input.mousePosition;
        //Vector2 mousePosition2D = raycastCamera.ScreenToWorldPoint(mousePosition);
        //RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero);
        if (ray.collider != null)
        {
            Node hitNode = ray.collider.GetComponent<Node>();
            if (hitNode != null)
            {
                Debug.Log(hitNode);
                hitNode.OnClick(hitNode);
            }
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        Vector3 mousePosition = Input.mousePosition;
    //        Vector2 mousePosition2D = raycastCamera.ScreenToWorldPoint(mousePosition);
    //        RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero);
    //        if (hit.collider != null)
    //        {
    //            Node hitNode = hit.collider.GetComponent<Node>();
    //            if (hitNode != null)
    //            {
    //                Debug.Log(hitNode);
    //                hitNode.OnClick(hitNode);
    //            }
    //        }
    //    }
    //}
}
