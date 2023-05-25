using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Node : MonoBehaviour
{
	public string NodeValue
	{
		get => _text.text;
		set => _text.text = value;
	}

	[SerializeField] private Arrow _arrowPrefab;
	[SerializeField] private Transform[] _nodeList;
	[SerializeField] private TMP_Text _text;

    private HashSet<Transform> _nodes;
	private Dictionary<Transform, Arrow> _arrows;

	private void Awake()
	{
		_nodes = new HashSet<Transform>();
		_arrows = new Dictionary<Transform, Arrow>();

		foreach (var node in _nodeList)
			AddNode(node);
	}

	public void AddNode(Transform node)
	{
		if (!_nodes.Add(node))
		{
			Debug.Assert(false, $"Node {node.name} already added");
			return;
		}

		Arrow arrow = Instantiate(_arrowPrefab);
		arrow.SetPosition(transform, node);
		_arrows.Add(node, arrow);
	}

	public void Remove(Transform node)
	{
		if (!_nodes.Add(node))
		{
			Debug.Assert(false, $"Node {node.name} not exists");
			return;
		}

		_arrows.Remove(node);
	}
}
