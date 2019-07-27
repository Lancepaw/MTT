//-----------------------------------------------------------------------
// <copyright file="ExportCheque.cs" company="No Company">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace TestWcfService
{
    /// <summary>
    /// Класс для выгрузки данных из БД.
    /// </summary>
    public class ExportCheque
    {
        /// <summary>
        /// Уникальный ID чека.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Номер чека.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Стоимость всех товаров в чеке.
        /// </summary>
        public int Summ { get; set; }

        /// <summary>
        /// Скидка.
        /// </summary>
        public int Discount { get; set; }

        /// <summary>
        /// Все товары в чеке.
        /// </summary>
        public string Articles { get; set; }
    }
}