using System.Collections;

namespace Task3
{
	public class CircularSinglyLinkedList<T> : IEnumerable
	{
		Node<T>? first;
		Node<T>? last;
		public int Count { get; private set; } = 0;

		public CircularSinglyLinkedList() { }
		public CircularSinglyLinkedList(T item)
		{
			Add(item);
		}

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= Count)
					throw new IndexOutOfRangeException();

				Node<T> current = first;
				for (int i = 0; i < Count; i++)
				{
					if (i == index) break;

					current = current.Next;
				}

				return current.Data;
			}
			set
			{
				if (index < 0 || index >= Count)
					throw new IndexOutOfRangeException();

				Node<T> current = first;
				for (int i = 0; i < Count; i++)
				{
					if (i == index)
						current.Data = value;

					current = current.Next;
				}
			}
		}

		public void Add(T item)
		{
			if (first == null)
			{
				AddFirstElement(item);
			}
			else if (first.Next == null)
			{
				last = new Node<T> { Data = item, Next = first };
				first.Next = last;
			}
			else
			{
				last.Next = new Node<T> { Data = item, Next = first };
				last = last.Next;
			}
			Count++;
		}

		public void Clear()
		{
			first = null;
			last = null;
			Count = 0;
		}

		public void Insert(T item, int position)
		{
			if (position > Count || position < 0)
				throw new Exception("Недопустимое значение position");

			if (first == null && Count == 0 && position == 0)
			{
				AddFirstElement(item);
			}
			else
			{
				Node<T>? current = first;
				Node<T>? previous = last;

				for (int i = 0; i <= Count; i++)
				{
					if (i == position)
					{
						current = new Node<T> { Data = item, Next = current };
						if (i == 0)
							first = current;

						previous.Next = current;
						break;
					}
					else
					{
						previous = current;
						current = current.Next;
					}
				}
			}
			Count++;
		}

		public bool Remove(T item)
		{
			Node<T>? current = first;
			Node<T>? previous = last;

			for (int i = 0; i <= Count; i++)
			{
				if (item.Equals(current.Data))
				{
					previous.Next = current.Next;
					if (i == 0)
						first = current.Next;

					Count--;
					return true;

				}
				previous = current;
				current = current.Next;
			}
			return false;
		}

		public void RemoveAt(int index)
		{
			Node<T> current = first;
			Node<T> previous = last;

			for (int i = 0; i <= Count; i++)
			{
				if (i == index)
				{
					previous.Next = current.Next;
					if (i == 0)
						first = current.Next;

					Count--;
					break;
				}
				previous = current;
				current = current.Next;
			}
		}

		public bool Contains(T item)
		{
			Node<T> current = first;

			for (int i = 0; i < Count; i++)
			{
				if (item.Equals(current.Data)) return true;
				current = current.Next;
			}

			return false;
		}

		public IEnumerator GetEnumerator() => new CircularSinglyLinkedListEnumerator<T>(first, last, Count);

		private void AddFirstElement(T item)
		{
			first = new Node<T> { Data = item };
			last = first.Next = first;
		}
	}

	class CircularSinglyLinkedListEnumerator<T> : IEnumerator
	{
		Node<T> first;
		Node<T> last;
		Node<T> current;
		int position = -1;
		int length;

		public object Current => current.Data;

		public CircularSinglyLinkedListEnumerator(Node<T> first, Node<T> last, int count)
		{
			this.first = first;
			this.last = last;
			this.length = count;
			current = last;
		}

		public bool MoveNext()
		{
			if (position < length - 1)
			{
				current = current.Next;
				position++;
				return true;
			}
			return false;
		}

		public void Reset() => position = -1;
		public void Dispose() { }
	}
}
