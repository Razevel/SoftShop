using System.Collections.Generic;
using System.Linq;
using Domain.Abstract;

namespace Domain.Entities
{
    /// <summary>
    /// Представляет корзину покупок.
    /// <returns>Поддерживает Method-Chaining</returns>
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Представляет или задает идентификатор сессии формата 
        /// <see cref="T:System.Guid"/>.
        /// </summary>
        public string SessionID { get; set; }

        /// <summary>
        /// Представляет или задает идентификатор пользователя.
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// Коллекция заказов пользователя.
        /// </summary>
        public List<Order> Orders { get; } = new List<Order>();

        /// <summary>
        /// Добавляет товар в корзину.
        /// <remarks>
        /// Если добавить в корзину больше товара, чем есть на складе, 
        /// то значение будет равно максимальному доступному количеству товара.
        /// </remarks>
        /// </summary>
        /// <param name="product">Товар для заказа.</param>
        /// <param name="quantity">Количество товара.</param>
        public Cart Add(Product product, int quantity = 1)
        {
            if (quantity == 0) return this;
            var _order = Orders.FirstOrDefault(o => o.Product.ID == product.ID);

            if (_order != null)
            {
                if (_order.Quantity + quantity >= product.Quantity)
                    _order.Quantity = product.Quantity;
                else
                    _order.Quantity += quantity;
            }
            else
                Orders.Add(new Order()
                {
                    Product = product,
                    Quantity = quantity >= product.Quantity ? product.Quantity : quantity,
                    CostPerItem = product.CurrentPrice,
                });

            return this;
        }

        /// <summary>
        /// Удаляет указаное число или все экземпляры указанного товара. 
        /// </summary>
        /// <param name="product">Товар для удаления.</param>
        /// <param name="quantity">Количество удаляемых экземпляров.
        /// По умолчанию удаются все.</param>
        public Cart Remove(Product product, int quantity = 0)
        {
            var pr = Orders.FirstOrDefault(o => o.Product.ID == product.ID);

            if (pr == null) return this;

            if (quantity == 0 || pr.Quantity <= quantity)
                Orders.Remove(pr);
            else
                pr.Quantity -= quantity;
            return this;
        }

        /// <summary>
        /// Представляет общую стоимость всех товаров в корзине.
        /// </summary>
        public decimal TotalCost => Orders.Sum(o => o.TotalCost);

        /// <summary>
        /// Представляет общее количество всех товаров в корзине.
        /// </summary>
        public decimal TotalOrders => Orders.Sum(o => o.Quantity);

        /// <summary>
        /// Удаляет все заказы из корзины.
        /// </summary>
        public Cart Clear()
        {
            Orders.Clear();
            return this;
        }
    }
}