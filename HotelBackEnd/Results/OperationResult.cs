namespace HotelBackEnd.Results
{
         public class OperationResult<T>
        {
            public bool Success { get; set; }
            public T Data { get; set; }
            public string ErrorMessage { get; set; }

            public OperationResult()
            {
                Success = true;
                Data = default(T);
                ErrorMessage = null;
            }

            public OperationResult(T data)
            {
                Success = true;
                Data = data;
                ErrorMessage = null;
            }

            public OperationResult(string errorMessage)
            {
                Success = false;
                Data = default(T);
                ErrorMessage = errorMessage;
            }
        }

    }
