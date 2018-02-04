using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Abstract
{
    /// <summary>
    /// Интерфейс - прослойка между БД и таблицей категории.
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Категории товара
        /// </summary>
        IEnumerable<T> All { get; }
    }
}