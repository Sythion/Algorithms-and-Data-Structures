namespace Algorithms_and_Data_Structures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyQueueLinkedList<T> : IEnumerable<T>
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
		this.Head = list.First.Value;
	}
	
	public T Dequeue()
	{
		if (this.Count == 0)
		{
			throw new Exception("The queue is empty");	
		}
		var item = list.First.Value;
		list.RemoveFirst();
		this.Head = list.First.Value;
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
}