using System;
using System.Text;
using System.Globalization;
using System.Collections.Generic;

namespace InterfaceExercise.Entities
{
    class Contract
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public double TotalValue { get; set; }
        public List<Installment> Installment { get; set; } //lista que registra as parcelas geradas

        public Contract(int number, DateTime date, double totalValue)
        {
            Number = number;
            Date = date;
            TotalValue = totalValue;
            Installment = new List<Installment>();
        }

        public void AddInstallment(Installment installment)
        {
            Installment.Add(installment);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\n\n--------------------");
            sb.AppendLine("INSTALLMENTS:");

            foreach (Installment installments in Installment)
            {
                sb.AppendLine("\n" + installments.DueDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                    + " - "
                    + installments.Amount.ToString("F2", CultureInfo.InvariantCulture));
            }

            return sb.ToString();
        }
    }
}
