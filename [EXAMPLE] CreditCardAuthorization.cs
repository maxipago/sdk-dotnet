using MaxiPago.DataContract;
using MaxiPago.Gateway; 

namespace MaxiPagoTransaction 
{
     class Program 
     {
          static void Main(string[] args) 
          {
               Transaction transaction = new Transaction();
               transaction.Environment = "TEST";

               ResponseBase response = transaction.Auth("100", "21g8u6gh6szw1gywfs165vui", "TestTransaction123", 1.00, "5555555555554444", "10", "2020", "", "123", "noAuthentication", "1", "1", "N", "123.123.123.123", "12345678909"); 

               if (response.IsTransactionResponse) 
               {
                    TransactionResponse result = response as TransactionResponse;

                    if (result.ResponseCode == "0") 
                    {
                         // APPROVED
                    }
                    else 
                    { 
                         // DECLINED
                    }
               }
               else if (response.IsErrorResponse)
               {
                    ErrorResponse result = response as ErrorResponse;
                    // Fail
               }
          }
     }
}