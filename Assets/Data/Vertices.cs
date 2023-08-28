using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertices : MonoBehaviour
{
    [SerializeField] List<Node> nodes;
    [SerializeField] List<Collider2D> colliders;

    static List<Node> staticNodes;
    static List<Collider2D> staticColliders;
    static Dictionary<Collider2D, Node> nodesAndColliders;

    public static List<Node> Nodes => staticNodes;
    public static List<Collider2D> Colliders => staticColliders;
    public static Dictionary<Collider2D, Node> NodesAndColliders => nodesAndColliders;
    private void Awake()
    {
        if (nodes.Count == 0 || colliders.Count == 0)
        {
            Debug.LogError("Array of nodes or node colliders is empty, populate in inspector or the program won't work");
            return;
        }
        if (nodes.Count != colliders.Count)
        {
            Debug.LogError("Arrays of nodes and of colliders are not of similar size");
            return;
        }
        nodesAndColliders = new Dictionary<Collider2D, Node>();
        staticNodes ??= nodes;
        staticColliders ??= colliders;
        for (int i = 0; i < staticNodes.Count; i++)
        {
            nodesAndColliders.Add(staticColliders[i], staticNodes[i]);
        }
    }
}
