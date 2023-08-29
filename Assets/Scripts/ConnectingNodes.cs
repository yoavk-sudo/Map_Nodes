using System.Collections.Generic;
using UnityEngine;

public class ConnectingNodes : MonoBehaviour
{
    List<Collider2D> edges;
    Dictionary<Collider2D, Node> nodesAndColliders;

    private void Start()
    {
        if (Vertices.Edges == null || Vertices.NodesAndColliders == null) return;
        edges = Vertices.Edges;
        nodesAndColliders = Vertices.NodesAndColliders;
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
            // in case the edge detects too many (or too few) nodes, continue
            if (Physics2D.OverlapCollider(edge, filter, results) != 2)
            {
                continue;
            }
            if (nodesAndColliders.TryGetValue(results[0], out Node node1) &&
                nodesAndColliders.TryGetValue(results[1], out Node node2))
            {
                node1.ConnectedNodes.Add(node2);
                node2.ConnectedNodes.Add(node1);
            }
        }
    }
}
