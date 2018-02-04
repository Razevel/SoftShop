using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Product
    {
        private int _salePercent;

        /// <summary>
        /// Получает ID товара
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Получает или задает название товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Получает или задает полное описание товара
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// Получает или задает категорию товара
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// Получает или задает базовую цену товара без скидок
        /// </summary>
        public decimal BasePrice { get; set; }

        /// <summary>
        /// Количество товара на складе
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Получает или задает значение, действует ли на товар скидка
        /// </summary>
        public bool IsSale { get; set; }

        /// <summary>
        /// Получает или задает размер скидки в процентах.
        /// <remarks>Знак не влияет, берется модуль</remarks>
        /// </summary>
        public int SalePercent
        {
            get => _salePercent;
            set => _salePercent = Math.Abs(value);
        }

        /// <summary>
        /// <value>Возвращае цену с учетом скидки</value> 
        /// </summary>
        [NotMapped]
        public decimal CurrentPrice
        {
            get =>
                (IsSale ? BasePrice - (BasePrice * SalePercent / 100) : BasePrice);
        }


        //-------------------------------------------------------------

        public virtual List<Order> Orders { get; set; }


    }
}