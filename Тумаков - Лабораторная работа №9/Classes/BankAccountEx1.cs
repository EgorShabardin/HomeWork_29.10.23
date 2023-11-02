namespace Тумаков___Лабораторная_работа__9
{
    /// <summary>
    /// Класс счета в банке для Упражнения 9.1.
    /// </summary>
    class BankAccountEx1
    {
        #region Поля
        private static int numberOfBankAccounts;
        private int accountNumber;
        private decimal accountBalance;
        private AccountType bankAccountType;
        #endregion

        #region Свойства
        /// <summary>
        /// Свойство, позволяющее читать поле accountNumber.
        /// </summary>
        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле accountBalance.
        /// </summary>
        public decimal AccountBalance
        {
            get
            {
                return accountBalance;
            }
        }

        /// <summary>
        /// Свойство, позволяющее читать поле bankAccountType.
        /// </summary>
        public AccountType BankAccountType
        {
            get
            {
                return bankAccountType;
            }
        }
        #endregion

        #region Методы
        /// <summary>
        /// Метод, изменяющий количество банковских счетов (поле numberOfBankAccounts).
        /// </summary>
        private void ChangeNumberOfBankAccounts()
        {
            numberOfBankAccounts++;
        }

        /// <summary>
        /// Метод, снимающий некоторую денежную сумму с банковского счета.
        /// </summary>
        /// <param name="withdrawalAmount"> Денежная сумма, которую необходимо снять. </param>
        /// <returns> Возвращает true, если снятие денежной суммы возможно, иначе false. </returns>
        public bool WithdrawMoneyFromAccount(decimal withdrawalAmount)
        {
            if ((accountBalance - withdrawalAmount > 0) && (withdrawalAmount > 0))
            {
                accountBalance -= withdrawalAmount;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Метод, пополняющий банковский счет на некоторую денежную сумму.
        /// </summary>
        /// <param name="depositedAmoun"> Денежная сумма, которую необходимо внести. </param>
        /// <returns> Возвращает true, если пополнение возможно, иначе false. </returns>
        public bool PutMoneyIntoAccount(decimal depositedAmoun)
        {
            if (depositedAmoun > 0)
            {
                accountBalance += depositedAmoun;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Метод, позволяющий переводить деньги с одного счета на другой.
        /// </summary>
        /// <param name="withdrawalAccount"> Счет, с которого снимаются деньги. </param>
        /// <param name="withdrawalAmount"> Сумма снятия. </param>
        /// <returns> Возвращает true, если перевод денег возможен, иначе false. </returns>
        public bool TransferringMoney(BankAccountEx1 withdrawalAccount, decimal withdrawalAmount)
        {
            if ((withdrawalAmount > 0) && (withdrawalAccount.AccountBalance - withdrawalAmount > 0))
            {
                accountBalance += withdrawalAmount;
                withdrawalAccount.accountBalance -= withdrawalAmount;
                return true;
            }

            return false;
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор, который создает экземпляр класса BankAccountEx1 и заполняет его данными.
        /// </summary>
        /// <param name="accountBalance"> Баланс банковского счета. </param>
        public BankAccountEx1(decimal accountBalance)
        {
            this.accountBalance = accountBalance;
            bankAccountType = AccountType.Текущий_счет;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }

        /// <summary>
        /// Конструктор, который создает экземпляр класса BankAccountEx1 и заполняет его данными.
        /// </summary>
        /// <param name="bankAccountType"> Тип банковского счета. </param>
        public BankAccountEx1(AccountType bankAccountType)
        {
            this.bankAccountType = bankAccountType;
            accountBalance = 0;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }

        /// <summary>
        /// Конструктор, который создает экземпляр класса BankAccountEx1 и заполняет его данными.
        /// </summary>
        /// <param name="accountBalance"> Баланс банковского счета. </param>
        /// <param name="bankAccountType"> Тип банковского счета. </param>
        public BankAccountEx1(decimal accountBalance, AccountType bankAccountType)
        {
            this.accountBalance = accountBalance;
            this.bankAccountType = bankAccountType;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }
        #endregion
    }
}
