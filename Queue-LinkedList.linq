<Query Kind="Program" />

void Main()
{
	var queue = new MyQueue<int>();
	queue.Enqueue(1);
	queue.Enqueue(2);
	queue.Enqueue(3);
	queue.Count.Dump();
	queue.Head.Dump();
	queue.Dequeue();
	queue.Count.Dump();
	queue.Head.Dump();
	foreach(var item in queue){
		item.Dump();
	}
}

// Define other methods and classes here
public class MyQueue<T> : IEnumerable<T>
{
	private LinkedList<T> list = new LinkedList<T>();
	
	public int Count
	{
		get
		{
			return list.Count;	
		}	
	}
	
	public T Head { get; set; }
	
	public void Clear()
	{
		list.Clear();	
	}
	
	public void Enqueue(T item)
	{
		list.AddLast(item);
		this.Head = list.First();
	}
	
	public T Dequeue()
	{
		if (this.Count == 0)
		{
			throw new Exception("The queue is empty");	
		}
		var item = list.First();
		list.RemoveFirst();
		this.Head = list.First();
		return item;
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