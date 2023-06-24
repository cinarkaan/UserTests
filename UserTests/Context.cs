using UserTests.Models.Responces;
using UserTests.Models.Responces.Base;
using WalletTests.Models.Responces;

namespace UserTests
{
    public class Context
    {
        public int TotalUserCount;
        public int UserId;
        public CommonResponse<Int32> CreateUserResponce;
        public CommonResponse<object> UserStatusResponce;
        public CommonResponse<object> DeleteUserResponse;
        public CommonResponse<GetAllUsersResponse> GetUserResponse;
        public CommonResponse<object> GetBalanceResponse;
        public CommonResponse<GetTransactionsResponse> GetTransactionResponse;
        public CommonResponse<object> GetDepositResponse;
        public CommonResponse<object> GetRevertTransactionResponse;
    }
}
