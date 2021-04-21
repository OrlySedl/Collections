using System;

namespace Orsel
{
    /// <summary>
    /// Стек на основе массива.
    /// </summary>
    /// <typeparam name="T">Тип данных, хранимых в стеке.</typeparam>
    public class FixedStack<T>
    {
        /// <summary>
        /// Массив для хранения элементов стека.
        /// </summary>
        private T[] items;
       
        /// <summary>
        /// Количество элементов в стеке по умолчанию.
        /// </summary>
        private const int defaultCapacity = 100;

        /// <summary>
        /// Размер стека.
        /// </summary>
        public int Capacity
        { 
            get { return items.Length; } 
        }

        /// <summary>
        /// Количество элементов в стеке.
        /// </summary>
        public int Count
        { 
            get;
            private set;
        }

        /// <summary>
        /// Конструктор стека.
        /// </summary>
        /// <param name="сapacity">Размер стека по умолчанию равен 100.</param>
        public FixedStack(int capacity = defaultCapacity)
        {
            items = new T[capacity];
        }

        /// <summary>
        /// Добавить данные в стек.
        /// </summary>
        /// <param name="item">Добавляемые данные.</param>
        public void Push(T item)
        {
            if (IsFull())
                throw new InvalidOperationException("Стек полон");
            items[Count++] = item;
        }

        /// <summary>
        /// Получить верхний элемент стека с удалением.
        /// </summary>
        /// <returns>T тип данных. Возвращает верхний элемент стека.</returns>
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Стек пуст");

            return items[--Count];
        }

        /// <summary>
        /// Получить верхний элемент стека без удаления.
        /// </summary>
        /// <returns>T тип данных. Возвращает верхний элемент стека.</returns>
        public T Top()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Стек пуст");

            return items[Count - 1];
        }

        /// <summary>
        /// Очистка стека.
        /// </summary>
        public void Clear()
        {
            Count = 0;
        }

        /// <summary>
        /// Проверка на пустой стек.
        /// </summary>
        /// <returns>Логический тип данных. True - если стек пустой, в ином случае - False.</returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }

        /// <summary>
        /// Проверка на полный стек.
        /// </summary>
        /// <returns>Логический тип данных. True - если стек полон, в ином случае - False.</returns>
        public bool IsFull()
        {
            return Count == Capacity;
        }
    }
}
