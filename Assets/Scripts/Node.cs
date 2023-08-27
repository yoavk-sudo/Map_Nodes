using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Node> ConnectedNodes;

    [SerializeField] SpriteRenderer sprite;
    [SerializeField, ReadOnly] string state;

    public SpriteRenderer Sprite { get { return sprite; } }
    public string State { get { return state; } set { state = value; } }
}
