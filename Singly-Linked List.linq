<Query Kind="Program" />

void Main()
{
	var MyLinkedList = new MyLinkedList<int>();
	MyLinkedList.AddLast(new MyLinkedListNode<int>(3));
	MyLinkedList.AddLast(new MyLinkedListNode<int>(5));
	MyLinkedList.AddLast(new MyLinkedListNode<int>(7));
	MyLinkedList.PrintList();
	
	MyLinkedList.Remove(9);
	MyLinkedList.PrintList();
}

// Define other methods and classes here

public class MyLinkedList<T> : ICollection<T>
{
	public MyLinkedListNode<T> Head {get; set;}
	
	public MyLinkedListNode<T> Tail {get; set;}
	
	public int Count {get; set;}

	public bool IsReadOnly => false;

	public IEnumerator<T> GetEnumerator()
	{
		var current = this.Head;
		while (current != null)
		{
			yield return current.Value;
			current = current.Next;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable<T>)this).GetEnumerator();
	}

	public void RemoveFirst()
	{
		if (this.Count != 0)
		{
			if (this.Count == 1)
			{
				this.Tail = null;
			}
			var node = this.Head.Next;
			this.Head = node;
			this.Count--;
		}
	}
	
	public void RemoveLast()
	{
		if (this.Count != 0)
		{
			if (this.Count == 1)
			{
				this.Head = null;
				this.Tail = null;
			}
			else
			{
				var current = this.Head;
				while (current.Next != this.Tail)
				{
					current = current.Next;
				}

				this.Tail = current;
				this.Tail.Next = null;
			}

			this.Count--;
		}
	}
	
	public void AddFirst(T value)
	{
		this.AddFirst(new MyLinkedListNode<T>(value));
	}
	
	public void AddFirst(MyLinkedListNode<T> node)
	{
		node.Next = Head;
		this.Head = node;

		if (this.Count == 0)
		{
			this.Tail = this.Head;
		}

		this.Count++;
	}
	
	public void AddLast(T value)
	{
		this.AddLast(new MyLinkedListNode<T>(value));
	}
	
	public void AddLast(MyLinkedListNode<T> node)
	{
		if (Count == 0)
		{
			this.Head = node;
		}
		else
		{
			this.Tail.Next = node;
		}
		
		this.Tail = node;
		this.Count++;
	}

	public void PrintList()
	{
		var temp = this.Head;
		while (temp != null)
		{
			temp.Value.Dump();
			temp = temp.Next;
		}
		string head = this.Head == null ? null : this.Head.Value.ToString();
		string tail = this.Tail == null ? null : this.Tail.Value.ToString();
		$"Head: {head}".Dump();
		$"Tail: {tail}".Dump();
		$"Count: {this.Count}".Dump();
	}

	public void Add(T item)
	{
		this.AddLast(item);
	}

	public void Clear()
	{
		this.Head = null;
		this.Tail = null;
		this.Count = 0;
	}

	public bool Contains(T item)
	{
		var current = this.Head;
		while (current != null)
		{
			if (current.Value.Equals(item))
			{
				return true;
			}
			current = current.Next;
		}
		return false;
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		var current = this.Head;
		while (current != null)
		{
			array[arrayIndex++] = current.Value;
			current = current.Next;
		}
	}

	//Removes first occurrence from list from head to tail
	public bool Remove(T item)
	{
		if (this.Count == 0)
		{
			// Do nothing
			return false;
		}
		else if (this.Count == 1)
		{
			if (this.Head.Value.Equals(item))
			{
				this.Head = null;
				this.Tail = null;
				this.Count = 0;
				return true;
			}
		}
		else 
		{
			// Remove from head
			// remove from tail
			// remove from middle
			// head
			if (this.Head.Value.Equals(item))
			{
				this.Head = this.Head.Next;
				this.Count--;
				return true;
			}
			
			var current = this.Head;
			while (current != null)
			{
				if (current.Next != null && current.Next.Value.Equals(item))
				{
					// Tail
					if (current.Next == this.Tail)
					{
						this.Tail = current;
					}
					
					// Anywhere else
					current.Next = current.Next.Next;
					this.Count--;
					return true;
				}
				current = current.Next;
			}
		}
		return false;
	}
}

public class MyLinkedListNode<T>
{
	public MyLinkedListNode(T value)
	{
		this.Value = value;
	}

	public MyLinkedListNode<T> Next { get; set; }

	public T Value { get; set; }
}