using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] Camera raycastCamera;

    List<Node> nodes;
    List<Collider2D> colliders;
    Dictionary<Collider2D, Node> nodesAndColliders;
    Node hitNode;

    // Start is called before the first frame update
    void Start()
    {
        raycastCamera ??= Camera.main;
        nodes = Vertices.Nodes;
        colliders = Vertices.Colliders; 
        nodesAndColliders = Vertices.NodesAndColliders;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        var ray = Physics2D.GetRayIntersection(raycastCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (ray.collider != null)
        {
            foreach (Collider2D collider in colliders)
            {
                if (ray.collider == collider)
                {
                    nodesAndColliders.TryGetValue(collider, out hitNode);
                    break;
                }
            }
            //Node hitNode = ray.collider.GetComponent<Node>();
            if (hitNode != null)
            {
                hitNode.OnClick(hitNode);
            }
        }
    }
}
