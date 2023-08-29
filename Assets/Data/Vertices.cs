using System.Collections.Generic;
using UnityEngine;

public class Vertices : MonoBehaviour
{
    [SerializeField] List<Node> nodes;
    [SerializeField] List<Collider2D> colliders;
    [SerializeField] List<Collider2D> edges;

    static List<Node> uniqueNodeList;
    static List<Collider2D> uniqueColliderList;
    static List<Collider2D> uniqueEdgeList;
    static Dictionary<Collider2D, Node> nodesAndColliders;
    static string emptyArrayMessage = "Array of nodes, node colliders or edges is empty, populate in inspector or the program won't work";
    static string differentSizesArraysMessage = "Arrays of nodes and of colliders are not of similar size";

    public static List<Node> Nodes => uniqueNodeList;
    public static List<Collider2D> Colliders => uniqueColliderList;
    public static List<Collider2D> Edges => uniqueEdgeList;
    public static Dictionary<Collider2D, Node> NodesAndColliders => nodesAndColliders;
   
    private void Awake()
    {
        if (nodes.Count == 0 || colliders.Count == 0)
        {
            Debug.LogError(emptyArrayMessage);
            Application.Quit();
            return;
        }
        if (nodes.Count != colliders.Count)
        {
            Debug.LogError(differentSizesArraysMessage);
            Application.Quit();
            return;
        }
        if (edges.Count == 0)
        {
            Debug.LogError(emptyArrayMessage);
            Application.Quit();
            return;
        }
        nodesAndColliders = new Dictionary<Collider2D, Node>();
        uniqueNodeList ??= nodes;
        uniqueColliderList ??= colliders;
        uniqueEdgeList ??= edges;
        for (int i = 0; i < uniqueNodeList.Count; i++)
        {
            nodesAndColliders.Add(uniqueColliderList[i], uniqueNodeList[i]);
        }
    }
}
