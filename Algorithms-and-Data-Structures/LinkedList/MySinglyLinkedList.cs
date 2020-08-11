namespace Algorithms_and_Data_Structures
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public class MySinglyLinkedList<T> : ICollection<T>
	{
		public MySinglyLinkedListNode<T> Head {get; set;}
		
		public MySinglyLinkedListNode<T> Tail {get; set;}
		
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
			this.AddFirst(new MySinglyLinkedListNode<T>(value));
		}
		
		public void AddFirst(MySinglyLinkedListNode<T> node)
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
			this.AddLast(new MySinglyLinkedListNode<T>(value));
		}
		
		public void AddLast(MySinglyLinkedListNode<T> node)
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
				Console.WriteLine(temp.Value);
				temp = temp.Next;
			}
			string head = this.Head == null ? null : this.Head.Value.ToString();
			string tail = this.Tail == null ? null : this.Tail.Value.ToString();
			Console.WriteLine($"Head: {head}");
			Console.WriteLine($"Tail: {tail}");
			Console.WriteLine($"Count: {this.Count}");
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
}