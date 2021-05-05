using System;

namespace Orsel
{
    /// <summary>
    /// Стек на основе массива, работающий по принципу "последним пришел - первым вышел" (LIFO).
    /// </summary>
    /// <typeparam name="T">Тип элементов в стеке.</typeparam>
    public class ArrayStack<T>
    {
        /// <summary>
        /// Массив содержащий элементы ArrayStack<T>.
        /// </summary>
        private T[] items;

        /// <summary>
        /// Емкость хранилища ArrayStack<T> по умолчанию.
        /// </summary>
        private const int defaultCapacity = 100;

        /// <summary>
        /// Число элементов выделенной емкости хранилища ArrayStack<T>.
        /// </summary>
        public int Capacity
        {
            get { return items.Length; }
        }

        /// <summary>
        /// Число элементов, содержащихся в ArrayStack<T>.
        /// </summary>
        public int Count
        {
            get;
            private set;
        }

        /// <summary>
        ///  Инициализирует новый экземпляр класса ArrayStack<T>, который является пустым и обладает указанной начальной емкостью или емкостью по умолчанию.
        /// </summary>
        /// <param name="сapacity">Начальное количество элементов, которое может содержать ArrayStack<T>. По умолчанию значение равно 100.</param>
        public ArrayStack(int capacity = defaultCapacity)
        {
            items = new T[capacity];
        }

        /// <summary>
        /// Определяет, является ли текущий экземпляр ArrayStack<T> полным.
        /// </summary>
        /// <returns>Значение true, если текущий экземпляр полон; в противном случае — false.</returns>
        private bool IsFull()
        {
            return Count == Capacity;
        }

        /// <summary>
        /// Изменяет емкость хранилища текущего экземпляра ArrayStack<T>.
        /// </summary>
        /// <param name="newCapacity">Новая емкость экземпляра ArrayStack<T>.</param>
        private void Resize(int newCapacity)
        {
            T[] tempItems = new T[newCapacity];
            Array.Copy(items, tempItems, Count);    
            items = tempItems;
        }

        /// <summary>
        /// Вставляет объект как верхний элемент ArrayStack<T>.
        /// </summary>
        /// <param name="item">Объект, вставляемый в ArrayStack<T>.</param>
        public void Push(T item)
        {
            if (IsFull())
                Resize(Capacity * 2);
            items[Count++] = item;
        }

        /// <summary>
        /// Удаляет и возвращает объект, находящийся в начале ArrayStack<T>.
        /// </summary>
        /// <returns>Объект, удаляемый из начала ArrayStack<T>.</returns>
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Стек пуст.");

            return items[--Count];
        }

        /// <summary>
        /// Возвращает объект, находящийся в начале ArrayStack<T>, без его удаления.
        /// </summary>
        /// <returns>Объект, находящийся в начале ArrayStack<T>.</returns>
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Стек пуст.");

            return items[Count - 1];
        }

        /// <summary>
        /// Удаляет все объекты из ArrayStack<T>
        /// </summary>
        public void Clear()
        {
            Count = 0;
        }

        /// <summary>
        /// Определяет, является ли текущий экземпляр ArrayStack<T> пустым.
        /// </summary>
        /// <returns>Значение true, если текущий экземпляр пуст; в противном случае — false.</returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }
    }
}
