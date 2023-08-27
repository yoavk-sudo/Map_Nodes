using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphManager : MonoBehaviour
{
    [SerializeField, Min(1)] int vertices;

    private List<int>[] adjacency;

    private void Awake()
    {
        if (vertices < 1) return;
        adjacency = new List<int>[vertices];
        for (int i = 0; i < vertices; i++)
        {
            adjacency[i] = new List<int>();
        }
        Debug.Log(adjacency.Length);
    }

    public void AddEdge(int node1, int node2)
    {
        try
        {
            adjacency[node1].Add(node2);
        }
        catch (System.IndexOutOfRangeException)
        {
            Debug.LogError($"Tried to connect a node ({node2}) to one that doesn't exist ({node1})");
            throw;
        }
    }
}
