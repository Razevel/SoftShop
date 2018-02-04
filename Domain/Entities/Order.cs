using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Entities
{
    /// <summary>
    /// Описывает заказ на покупку некоторого количества одного вида товара покупателем. 
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Представляет идентификатор заказа
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Представляет или задает идентификатор сессии формата <see cref="T:System.Guid"/>
        /// </summary>
        public string SessionID { get; set; }

        /// <summary>
        /// Представляет или задает идентификатор пользователя
        /// </summary>
        [Required]
        public string UserID { get; set; }

        /// <summary>
        /// Представляет или задает купленный(на покупку) товар.
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Количество единиц товара
        /// </summary>
        public int Quantity { get; set; }
        
        /// <summary>
        /// Цена единицы товара в момент покупки.
        /// Необходима на случай, если цена будет меняться, как базовая, так и со скидкой.
        /// </summary>
        public decimal CostPerItem { get; set; }

        /// <summary>
        /// Представляет общую стоимость заказа.
        /// <remarks>Использовать после установки значения <see cref="Product"/> 
        /// и <see cref="CostPerItem"/>. 
        /// </remarks>
        /// </summary>
        public decimal TotalCost
        {
            get => CostPerItem * Quantity;
            private set => _totalCost = value;
        }

        private decimal _totalCost;
    }
}