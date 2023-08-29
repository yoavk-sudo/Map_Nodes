using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] List<Node> connectedNodes;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField, ReadOnly] NodeStates state;

    public SpriteRenderer Sprite { get { return sprite; } }
    public List<Node> ConnectedNodes { get { return connectedNodes; } }
    public NodeStates State { get { return state; } set { state = value; } }

    public void NodeClicked()
    {
        if (this.state != NodeStates.open)
        {
            Debug.Log($"Cannot be clicked, node's state is {this.state}");
            return;
        }
        CompleteNode(this);
    }

    private void CompleteNode(Node node)
    {
        Debug.Log(node + " is now complete.");
        States.SetState(node, NodeStates.completed);
        // set open nodes to locked
        foreach (Node connectedNode in ConnectedNodes)
        {
            if (connectedNode.state != NodeStates.locked) continue;
            States.SetState(connectedNode, NodeStates.open);
        }
    }
}
