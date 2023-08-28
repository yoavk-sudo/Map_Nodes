using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States : MonoBehaviour
{
    [ColorUsage(true, true), SerializeField] Color lockedColor;
    [ColorUsage(true, true), SerializeField] Color openColor;
    [ColorUsage(true, true), SerializeField] Color completeColor;
    [SerializeField] Node[] nodes; ///

    static Dictionary<Color, NodeStates> nodeStates = new Dictionary<Color, NodeStates>(); //erase static??????
    static Dictionary<NodeStates, Color> reverseNodeStates = new Dictionary<NodeStates, Color>();
    static Node currentNode;

    //public static Dictionary<Color, string> NodeStates { get { return nodeStates; } }

    private void Awake()
    {
        nodeStates.Add(lockedColor, NodeStates.locked);
        nodeStates.Add(openColor, NodeStates.open);
        nodeStates.Add(completeColor, NodeStates.completed);
        foreach (var nodeState in nodeStates)
        {
            reverseNodeStates[nodeState.Value] = nodeState.Key;
        }
        SetNodesStatesFirstTime();
    }

    public static void SetState(Node node, NodeStates state)
    {
        node.State = state;
        node.Sprite.color = FindKeyByValue(state);
        if (state == NodeStates.completed)
        {
            SetOpenNodesToLocked();
            currentNode = node;
        }
    }

    private static void SetOpenNodesToLocked()
    {
        foreach (Node conNode in currentNode.ConnectedNodes)
        {
            if (conNode.State == NodeStates.open)  SetState(conNode, NodeStates.locked);
        }
    }

    private static Color FindKeyByValue(NodeStates state)
    {
        if (reverseNodeStates.TryGetValue(state, out Color color))
        {
            return color;
        }
        return Color.white;
    }

    private void SetNodesStatesFirstTime()
    {
        foreach (Node node in nodes)
        {
            if (node.CompareTag("root"))
            {
                SetState(node, NodeStates.open);
                currentNode = node;
                continue;
            }
            SetState(node, NodeStates.locked);
        }
    }
}
