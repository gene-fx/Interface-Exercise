using System;
using System.Globalization;
using InterfaceExercise.Entities;
using InterfaceExercise.Services;

namespace InterfaceExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;

            switch (x)
            {
                case 1:
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("----------------CONTRACT DATA");
                        Console.Write("\nContract number: ");
                        int inputNumber = int.Parse(Console.ReadLine());

                        Console.Write("\nDate (dd/MM/yyyy): ");
                        DateTime inputDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        Console.Write("\nContract value: ");
                        double inputValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        Console.Write("\nEnter number of installments:");
                        int inputInstallment = int.Parse(Console.ReadLine());

                        //instancia um novo contrato
                        Contract contract = new Contract(inputNumber, inputDate, inputValue);

                        //instancia novo serviço de contrato e passa como parametro o tipo de serviço para a inteface por meio de up-casting
                        ContractService contractService = new ContractService(new PaypalServices());

                        //chamada do metodo de processo de contrato passando como parametro o novo contrado instanciado acima e o numro de parcelas
                        contractService.ProcessContract(contract, inputInstallment);

                        Console.WriteLine(contract);
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine("ERROR:" + e.Message);
                        Console.WriteLine("-------------------------");
                        Console.Write("\n\nDo you wish to try again (y/n)?: ");
                        char opt = char.Parse(Console.ReadLine());
                        char.ToLower(opt);
                        if (opt == 'y')
                            goto case 1;
                    }
                    break;
            }


        }
    }
}
