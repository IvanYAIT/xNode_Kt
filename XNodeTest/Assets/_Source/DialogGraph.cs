using UnityEngine;
using XNode;

[CreateAssetMenu]
public class DialogGraph : NodeGraph 
{
	private DialogNode _currentNode;
	
	public void Start()
	{
		_currentNode = (DialogNode)nodes[0];
	}

	public void SetCurrentNode(DialogNode node) => 
		_currentNode = node;

    public DialogNode GetCurrentNode() => _currentNode;
}