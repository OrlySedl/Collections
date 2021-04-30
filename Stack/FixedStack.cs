using System;

namespace Orsel
{
    /// <summary>
    /// Стек на основе массива с фиксированным размером, работающий по принципу "последним пришел - первым вышел" (LIFO).
    /// </summary>
    /// <typeparam name="T">Тип элементов в стеке.</typeparam>
    public class FixedStack<T>
    {
        /// <summary>
        /// Массив содержащий элементы FixedStack<T>.
        /// </summary>
        private T[] items;

        /// <summary>
        /// Емкость хранилища FixedStack<T> по умолчанию.
        /// </summary>
        private const int defaultCapacity = 100;

        /// <summary>
        /// Число элементов выделенной емкости хранилища FixedStack<T>.
        /// </summary>
        public int Capacity
        { 
            get { return items.Length; } 
        }

        /// <summary>
        /// Число элементов, содержащихся в FixedStack<T>.
        /// </summary>
        public int Count
        { 
            get;
            private set;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса FixedStack<T>, который является пустым и обладает указанной начальной емкостью или емкостью по умолчанию.
        /// </summary>
        /// <param name="сapacity">Начальное количество элементов, которое может содержать FixedStack<T>. По умолчанию значение равно 100.</param>
        public FixedStack(int capacity = defaultCapacity)
        {
            items = new T[capacity];
        }

        /// <summary>
        /// Вставляет объект как верхний элемент FixedStack<T>.
        /// </summary>
        /// <param name="item">Объект, вставляемый в FixedStack<T>.</param>
        public void Push(T item)
        {
            if (IsFull())
                throw new InvalidOperationException("Стек полон.");
            items[Count++] = item;
        }

        /// <summary>
        /// Удаляет и возвращает объект, находящийся в начале FixedStack<T>.
        /// </summary>
        /// <returns>Объект, удаляемый из начала FixedStack<T>.</returns>
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Стек пуст.");

            return items[--Count];
        }

        /// <summary>
        /// Возвращает объект, находящийся в начале FixedStack<T>, без его удаления.
        /// </summary>
        /// <returns>Объект, находящийся в начале FixedStack<T>.</returns>
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Стек пуст.");

            return items[Count - 1];
        }

        /// <summary>
        /// Удаляет все объекты из FixedStack<T>
        /// </summary>
        public void Clear()
        {
            Count = 0;
        }

        /// <summary>
        /// Определяет, является ли текущий экземпляр FixedStack<T> пустым.
        /// </summary>
        /// <returns>Значение true, если текущий экземпляр пуст; в противном случае — false.</returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }

        /// <summary>
        /// Определяет, является ли текущий экземпляр FixedStack<T> полным.
        /// </summary>
        /// <returns>Значение true, если текущий экземпляр полон; в противном случае — false.</returns>
        public bool IsFull()
        {
            return Count == Capacity;
        }
    }
}
