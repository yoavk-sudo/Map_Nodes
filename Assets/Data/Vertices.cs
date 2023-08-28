using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vertices", menuName = "Vertices")]
public class Vertices : ScriptableObject
{
    [SerializeField] public List<Node> nodes = new List<Node>();

    public List<Node> Nodes { get { return nodes; } }
}
