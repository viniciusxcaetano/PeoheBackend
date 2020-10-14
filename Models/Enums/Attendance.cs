namespace Peohe.Models.Enums
{
    public class Attendance
    {
        public enum Status
        {
            Aberto,
            Pago,
            Vencido,

        }
        public enum TypeOfPayment
        {
            Debito,
            Credito,
            Convenio
        }
    }
}