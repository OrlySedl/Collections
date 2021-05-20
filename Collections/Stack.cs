﻿using System;

namespace Orsel.Collections
{
    /// <summary>
    /// Стек на основе массива, работающий по принципу "последним пришел - первым вышел" (LIFO).
    /// </summary>
    /// <typeparam name="T">Тип элементов в стеке.</typeparam>
    public class Stack<T>
    {
        /// <summary>
        /// Массив содержащий элементы Stack<T>.
        /// </summary>
        private T[] items;

        /// <summary>
        /// Емкость хранилища Stack<T> по умолчанию.
        /// </summary>
        private const int defaultCapacity = 100;

        /// <summary>
        /// Получает или устанавливает число элементов емкости хранилища Stack<T>.
        /// </summary>
        public int Capacity
        {
            get
            {
                return items.Length;
            }

            set
            {
                T[] tempItems = new T[value];
                Array.Copy(items, tempItems, Count);
                items = tempItems;
            }
        }

        /// <summary>
        /// Число элементов, содержащихся в Stack<T>.
        /// </summary>
        public int Count
        {
            get;
            private set;
        }

        /// <summary>
        ///  Инициализирует новый экземпляр класса Stack<T>, который является пустым и обладает указанной начальной емкостью или емкостью по умолчанию.
        /// </summary>
        /// <param name="сapacity">Начальное количество элементов, которое может содержать Stack<T>. По умолчанию значение равно 100.</param>
        public Stack(int capacity = defaultCapacity)
        {
            items = new T[capacity];
        }

        /// <summary>
        /// Определяет, является ли текущий экземпляр Stack<T> полным.
        /// </summary>
        /// <returns>Значение true, если текущий экземпляр полон; в противном случае — false.</returns>
        private bool IsFull()
        {
            return Count == Capacity;
        }

        /// <summary>
        /// Вставляет объект как верхний элемент Stack<T>.
        /// </summary>
        /// <param name="item">Объект, вставляемый в Stack<T>.</param>
        public void Push(T item)
        {
            if (IsFull())
                Capacity = Capacity * 2;
            items[Count++] = item;
        }

        /// <summary>
        /// Удаляет и возвращает объект, находящийся в начале Stack<T>.
        /// </summary>
        /// <returns>Объект, удаляемый из начала Stack<T>.</returns>
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Стек пуст.");

            return items[--Count];
        }

        /// <summary>
        /// Возвращает объект, находящийся в начале Stack<T>, без его удаления.
        /// </summary>
        /// <returns>Объект, находящийся в начале Stack<T>.</returns>
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Стек пуст.");

            return items[Count - 1];
        }

        /// <summary>
        /// Удаляет все объекты из Stack<T>
        /// </summary>
        public void Clear()
        {
            Count = 0;
        }

        /// <summary>
        /// Определяет, является ли текущий экземпляр Stack<T> пустым.
        /// </summary>
        /// <returns>Значение true, если текущий экземпляр пуст; в противном случае — false.</returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }
    }
}