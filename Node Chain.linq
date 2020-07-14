<Query Kind="Program" />

void Main()
{
	var first = new Node(3);
	var middle = new Node(5);
	var last = new Node(7);
	first.Next = middle;
	middle.Next = last;
	
	PrintList(first);
}

// Define other methods and classes here
public void PrintList(Node node)
{
	while(node != null)
	{
		node.Value.Dump();
		node = node.Next;
	}
}

public class Node
{
	public Node(int value)
	{
		this.Value = value;
	}
	
	public Node Next { get; set; }
	
	public int Value { get; set; }
}