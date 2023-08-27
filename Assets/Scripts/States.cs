using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States : MonoBehaviour
{
    [ColorUsage(true, true), SerializeField] Color lockedColor;
    [ColorUsage(true, true), SerializeField] Color openColor;
    [ColorUsage(true, true), SerializeField] Color completeColor;
    [SerializeField] Node[] nodes;

    static Dictionary<Color, string> nodeStates = new Dictionary<Color, string>(); //erase static??????
    static Dictionary<string, Color> reverseNodeStates = new Dictionary<string, Color>();

    //public static Dictionary<Color, string> NodeStates { get { return nodeStates; } }

    private void Awake()
    {
        nodeStates.Add(lockedColor, "Locked");
        nodeStates.Add(openColor, "Opened");
        nodeStates.Add(completeColor, "Completed");
        foreach (var nodeState in nodeStates)
        {
            reverseNodeStates[nodeState.Value] = nodeState.Key;
        }
        SetNodesStatesFirstTime();
    }

    public static void SetState(Node node, string state)
    {
        node.State = state;
        node.Sprite.color = FindKeyByValue(state);
    }

    private static Color FindKeyByValue(string state)
    {
        if (reverseNodeStates.TryGetValue(state, out Color color))
        {
            return color;
        }
        return Color.white;
    }

    private void SetNodesStatesFirstTime()
    {
        //Node[] nodes = new Node[10]; //////////////////////////////////////////////////////
        foreach (Node node in nodes)
        {
            if (node.CompareTag("root"))
            {
                SetState(node, "Opened");
                continue;
            }
            SetState(node, "Locked");
        }
    }
}
