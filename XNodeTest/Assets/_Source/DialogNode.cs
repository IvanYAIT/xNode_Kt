using static XNode.Node;
using XNode;
using UnityEngine;

public class DialogNode : Node
{
    [Input] public int enter;

    [Output] public int yes;
    [Output] public int no;

    public bool isEndNode;
    public string text = "";
    public Sprite image;

    private DialogNode previousNode;

    public void NextNode(string _exit)
    {
        DialogNode b = null;
        foreach (NodePort p in this.Ports)
        {
            if (p.fieldName == _exit)
            {
                //This is the one we're after
                b = p.Connection.node as DialogNode;
                break;
            }
        }
        if (b != null)
        {
            DialogGraph _graph = this.graph as DialogGraph;
            b.SetPreviousNode(this);
            _graph.SetCurrentNode(b);
        }
    }

    public void SetPreviousNode(DialogNode node) =>
        previousNode = node;

    public DialogNode GetPreviousNode() =>
        previousNode;

    public void Yes() =>
        NextNode("yes");

    public void No() =>
        NextNode("no");
}