using System;
using InterfaceExercise.Entities;

namespace InterfaceExercise.Services
{
    class ContractService
    {
        private IOnlinePaymentService _onlinePaymentService; //instacia a interface

        public ContractService(IOnlinePaymentService onlinePaymentService)//metodo que recebe o tipo de serviço de cobrança por uppercasting
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months)//metodo q efetivamente registra as parcelas do contrato
        {
            double installmentValue = contract.TotalValue / months;

            for(int i = 1; i <= months; i++)
            {
                DateTime date = contract.Date.AddMonths(i);

                //abaixo define a parcela de acordo com as regras de parcelamento impostas pelo serviço de pagamento online
                double parcialQuota = installmentValue + _onlinePaymentService.Interest(installmentValue, i);

                //abaixo define a parcela com o imposto do parcelamento mais a taxa cobrada pelo serviço de pagamento online
                double totalQuota = parcialQuota + _onlinePaymentService.PaymentFee(parcialQuota);

                //adiona na lista de parcelas
                contract.AddInstallment(new Installment(date, totalQuota));
            }
        }
    }

}
