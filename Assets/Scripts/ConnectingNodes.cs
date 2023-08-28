using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectingNodes : MonoBehaviour
{
    [SerializeField] List<Collider2D> edges;

    Dictionary<Collider2D, Node> nodesAndColliders;

    private void Start()
    {
        nodesAndColliders = Vertices.NodesAndColliders;
        if (nodesAndColliders.Count == 0) return;
        ConnectNodes();
    }

    void ConnectNodes()
    {
        foreach (Collider2D edge in edges)
        {
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
