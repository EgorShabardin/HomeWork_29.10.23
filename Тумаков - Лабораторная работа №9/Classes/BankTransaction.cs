using System;

namespace Тумаков___Лабораторная_работа__9
{
    /// <summary>
    /// Класс, содержащий информацию о всех банковских операциях.
    /// </summary>
    class BankTransaction
    {
        #region Поля
        private DateTime transactionDate;
        private decimal amountChange;
        #endregion

        #region Свойства
        /// <summary>
        /// Свойство, позволяющее читать поле transactionDate.
        /// </summary>
        public DateTime TransactionDate
        {
            get
            {
                return transactionDate;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле amountChange.
        /// </summary>
        public decimal AmountChange
        {
            get
            {
                return amountChange;
            }
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор, который создает экземпляр класса BankTransaction и заполняет его данными.
        /// </summary>
        /// <param name="amountChange"> Сумма снятия/пополнения. </param>
        public BankTransaction(decimal amountChange)
        {
            this.amountChange = amountChange;
            transactionDate = DateTime.Now;
        }
        #endregion
    }
}
