using System;

namespace BankAccountNS
{
    /// <summary>
    /// Класс банковского счета.
    /// Содержит методы для снятия и пополнения средств.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        private BankAccount() { }
        /// <summary>
        /// Создает новый банковский счет.
        /// </summary>
        /// <param name="customerName">Имя владельца счета</param>
        /// <param name="balance">Начальный баланс</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        public const string CreditAmountLessThanZeroMessage = "Credit amount is less than zero";

        /// <summary>
        /// Возвращает имя владельца счета.
        /// </summary>
        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }
        /// <summary>
        /// Снимает деньги со счета.
        /// </summary>
        /// <param name="amount">Сумма списания</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Возникает если сумма больше баланса или меньше нуля.
        /// </exception>
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount;
        }
        /// <summary>
        /// Пополняет баланс счета.
        /// </summary>
        /// <param name="amount">Сумма пополнения</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Возникает если сумма меньше нуля.
        /// </exception>
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException(
                    "amount",
                    amount,
                    CreditAmountLessThanZeroMessage);
            }

            m_balance += amount;
        }        /// <summary>
                 /// Точка входа в программу.
                 /// Демонстрирует работу банковского счета.
                 /// </summary>
        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
            Console.ReadLine();
        }
    }
}
