using System;
using System.Collections.Generic;

namespace Тумаков___Лабораторная_работа__9
{
    /// <summary>
    /// Перечислимый тип, содержащий виды банковских счетов.
    /// </summary>
    public enum AccountType
    {
        Текущий_счет,
        Сберегательный_счет
    }

    class Program
    {
        static void Main()
        {
            bool tasksEnd = false;
            string taskNumber;

            do
            {
                Console.WriteLine("{0, 81}", "ТУМАКОВ - ЛАБОРАТОРНАЯ РАБОТА №8. МЕНЮ ЗАДАНИЙ\n");
                Console.WriteLine("Подсказка:\n" +
                                  "Упражнение 9.1. Программа из Упражнения 8.1, но удалены методы заполнения полей и добавлены конструкторы    -   цифра 1\n" +
                                  "Упражнения 9.2. Программа из Упражнения 9.1, но после снятия/пополнения создается объект BankTransaction    -   цифра 2\n" +
                                  "Упражнение 9.3. Программа из Упражнения 9.2, но добавлен метод, записывающий данные о транзакциях в файл    -   цифра 3\n" +
                                  "Домашнее задание 9.1. Программа из Домашнего задания 8.2, но добавлены новые конструкторы                   -   цифра 4\n" +
                                  "Закончить выполнение заданий и выйти из программы                                                           -   цифра 0\n");

                Console.Write("Введите номер задания: ");
                taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    case "1":
                        // Упражнение 9.1. Программа из Упражнения 8.1, но удалены методы заполнения полей и добавлены конструкторы.
                        Console.Clear();
                        Console.WriteLine("{0, 113}", "УПРАЖНЕНИЕ 9.1. ПРОГРАММА ИЗ УПРАЖНЕНИЯ 8.1, НО УДАЛЕНЫ МЕТОДЫ ЗАПОЛНЕНИЯ ПОЛЕЙ И ДОБАВЛЕНЫ КОНСТРУКТОРЫ\n");

                        BankAccountEx1 firstBankAccount = new BankAccountEx1(1000000);
                        BankAccountEx1 secondBankAccount = new BankAccountEx1(AccountType.Сберегательный_счет);
                        BankAccountEx1 thirdBankAccount = new BankAccountEx1(5789545745, AccountType.Сберегательный_счет);

                        Console.WriteLine($"{firstBankAccount.BankAccountType} №{firstBankAccount.AccountNumber:D4}, баланс: {firstBankAccount.AccountBalance} рублей\n" +
                                          $"{secondBankAccount.BankAccountType} №{secondBankAccount.AccountNumber:D4}, баланс: {secondBankAccount.AccountBalance} рублей\n" +
                                          $"{thirdBankAccount.BankAccountType} №{thirdBankAccount.AccountNumber:D4}, баланс: {thirdBankAccount.AccountBalance} рублей");

                        Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        // Упражнения 9.2. Программа из Упражнения 9.1, но после снятия/пополнения создается объект типа BankTransaction.
                        Console.Clear();
                        Console.WriteLine("{0, 116}", "УПРАЖНЕНИЕ 9.2. ПРОГРАММА ИЗ УПРАЖНЕНИЯ 9.1, ПО ПОСЛЕ СНЯТИЯ/ПОПОЛНЕНИЯ СОЗДАЕТСЯ ОБЪЕКТ ТИПА BANKTRANSACTION\n");

                        BankAccountEx2 fourthBankAccount = new BankAccountEx2(2456479, AccountType.Сберегательный_счет);
                        Queue<BankTransaction> transactionList;
                        int count;

                        fourthBankAccount.PutMoneyIntoAccount(150);
                        fourthBankAccount.PutMoneyIntoAccount(1000);
                        fourthBankAccount.WithdrawMoneyFromAccount(578);

                        transactionList = fourthBankAccount.TransactionList;
                        count = transactionList.Count;

                        for (int i = 0; i < count; i++)
                        {
                            BankTransaction transaction = transactionList.Dequeue();
                            if (transaction.AmountChange < 0)
                            {
                                Console.WriteLine($"Снятие {transaction.TransactionDate}, {-transaction.AmountChange} рублей");
                            }
                            else
                            {
                                Console.WriteLine($"Пополнение {transaction.TransactionDate}, {transaction.AmountChange} рублей");
                            }
                        }

                        Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        // Упражнение 9.3. Программа из Упражнения 9.2, но добавлен метод, записывающий данные о транзакциях в файл.
                        Console.Clear();
                        Console.WriteLine("{0, 112}", "УПРАЖНЕНИЕ 9.3. ПРОГРАММА ИЗ УПРАЖНЕНИЯ 9.2, НО ДОБАВЛЕН МЕТОД, ЗАПИСЫВАЮЩИЙ ДАННЫЕ О ТРАНЗАКЦИЯХ В ФАЙЛ\n");

                        BankAccountEx3 fifthBankAccount = new BankAccountEx3(545465465, AccountType.Сберегательный_счет);

                        fifthBankAccount.PutMoneyIntoAccount(1587);
                        fifthBankAccount.PutMoneyIntoAccount(10360);
                        fifthBankAccount.WithdrawMoneyFromAccount(78);
                        fifthBankAccount.WithdrawMoneyFromAccount(7461);

                        fifthBankAccount.Dispose(fifthBankAccount);

                        Console.Write("Чтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "4":
                        // Домашнее задание 9.1. Программа из Домашнего задания 8.2, но добавлены новые конструкторы.
                        Console.Clear();
                        Console.WriteLine("{0, 107}", "ДОМАШНЕЕ ЗАДАНИЕ 9.1. ПРОГРАММА ИЗ ДОМАШНЕГО ЗАДАНИЯ 8.2, НО ДОБАВЛЕНЫ НОВЫЕ КОНСТРУКТОРЫ\n");

                        Song firstSong = new Song("Я Русский", "Shaman");
                        Song secondSong = new Song("Моя Россия", "Shaman", firstSong);
                        Song thirdSong = new Song();

                        Console.WriteLine($"{firstSong.Title}, {secondSong.Title}, {thirdSong.Title}");

                        Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine("{0, 69}", "ВЫ ВЫШЛИ ИЗ ПРОГРАММЫ");
                        tasksEnd = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("{0, 98}", "ТАКОГО ЗАДАНИЯ НЕТ! ДОСТУПНЫЕ ЗАДАНИЯ УКАЗАНЫ В ПОДСКАЗКЕ. ПОВТОРИТЕ ПОПЫТКУ\n");
                        break;
                }
            } while (!tasksEnd);
        }
    }
}
