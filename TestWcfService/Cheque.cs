//-----------------------------------------------------------------------
// <copyright file="Cheque.cs" company="No Company">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace TestWcfService
{
    using System.Collections.Generic;

    /// <summary>
    /// Класс для приёма данных из службы Windows.
    /// </summary>
    public class Cheque
    {
        /// <summary>
        /// Номер чека.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Сумма в чеке.
        /// </summary>
        public decimal Summ { get; set; }

        /// <summary>
        /// Скидка.
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Товары в чеке.
        /// </summary>
        public List<string> Articles { get; set; }
    }
}
