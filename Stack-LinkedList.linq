<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class MyStack<T> : IEnumerable<T>
{
	LinkedList<T> list = new LinkedList<T>();
	
	public int Count()
	{
		return list.Count;	
	}
	
	public void Push(T item)
	{
		list.AddFirst(item);
	}
	
	public T Pop()
	{
		if (list.Count == 0)
		{
			throw new Exception("The stack is empty.");	
		}
		var item = list.First;
		list.RemoveFirst();
		return item.Value;
	}
	
	public T Peek()
	{
		if (list.Count == 0)
		{
			throw new Exception("The stack is empty.");	
		}
		return list.First.Value;	
	}
	
	public void Clear()
	{
		list.Clear();
	}
	
	public IEnumerator<T> GetEnumerator()
	{
		return list.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return list.GetEnumerator();
	}
}

public class MyStackNode
{
	
}