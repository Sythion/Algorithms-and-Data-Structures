<Query Kind="Program" />

void Main()
{
	var stack = new MyStack<int>();
	stack.Push(3);
	stack.GetEnumerator().Dump();
	/*stack.Push(1);
	stack.Push(2);
	stack.Push(3);
	stack.Push(4);
	stack.Push(5);
	stack.Push(6);
	stack.Push(7);
	stack.Push(8);
	//stack.Print();
	stack.Pop().Dump();
	stack.Print();
	stack.Clear();
	stack.Print();*/
}

// Define other methods and classes here
public class MyStack<T> : IEnumerable<T>
{
	private T[] array = new T[0];

	// # of items in array.  NOT the same as array.length;
	private int size;

	public void Push(T item)
	{
		// array full
		if (this.size == this.array.Length)
		{
			int newSize = array.Length == 0 ? 4 : array.Length * 2;
			T[] newArray = new T[newSize];
			array.CopyTo(newArray, 0);
			array = newArray;
		}
		
		this.array[this.size] = item;
		this.size++;
	}

	public T Pop()
	{
		if (this.size == 0)
		{
			throw new Exception("The stack is empty.");
		}

		this.size--;
		return this.array[this.size];
	}

	public T Peek()
	{
		if (this.size == 0)
		{
			throw new Exception("The stack is empty.");
		}

		return this.array[this.size-1];
	}

	public void Clear()
	{
		array = new T[0];
		this.size = 0;
	}

	// Enumerate backwards to present items in LIFO order.
	public IEnumerator<T> GetEnumerator()
	{
		for(int i = this.size-1; i >= 0; i--)
		{
			yield return array[i];	
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}
}