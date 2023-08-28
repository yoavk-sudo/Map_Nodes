using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectingNodes : MonoBehaviour
{
    [SerializeField] List<Collider2D> edges;
    [SerializeField] List<Node> nodes;
    [SerializeField] List<Collider2D> colliders;

    Dictionary<Collider2D, Node> nodesAndColliders;

    private void Start()
    {
        if (nodes.Count != colliders.Count)
        {
            return;
        }
        nodesAndColliders = new Dictionary<Collider2D, Node>();
        for (int i = 0; i < nodes.Count; i++)
        {
            nodesAndColliders.Add(colliders[i], nodes[i]);
        }
        ConnectNodes();
    }

    void ConnectNodes()
    {
        foreach (Collider2D edge in edges)
        {
            Debug.Log(edge);
            ContactFilter2D filter = new ContactFilter2D();
            List<Collider2D> results = new List<Collider2D>();
            filter.useLayerMask = true;
            filter.layerMask = LayerMask.GetMask("Node");
            if (Physics2D.OverlapCollider(edge, filter, results) == 2)
            {
                if (nodesAndColliders.TryGetValue(results[0], out Node node1) &&
                    nodesAndColliders.TryGetValue(results[1], out Node node2))
                {
                    node1.ConnectedNodes.Add(node2);
                    node2.ConnectedNodes.Add(node1);
                }
            }
        }
    }
}
