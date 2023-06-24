using TechTalk.SpecFlow;
using UserTests.Utils;
using WalletTests.Clients;

namespace UserTests.Steps
{
    [Binding]
    public sealed class WalletSteps
    {

        private readonly WalletServiceClient _walletServiceClient;
        private readonly WalletCharger _walletCharger;

        private readonly Context _context;

        public WalletSteps (Context context,WalletServiceClient walletServiceClient, WalletCharger walletCharger)
        {
            _context = context;
            _walletServiceClient = walletServiceClient;
            _walletCharger = walletCharger;
        }

        [When(@"The transactions which belongs on this user will be gotten")]
        public async Task GetUserTransaction ()
        {
            var response = await _walletServiceClient.GetTransactions(_context.UserId);

            _context.GetTransactionResponse = response;
        }

        [When(@"The balance which belongs on this user will be gotten")]
        public async Task GetUserBalance()
        {
            var response = await _walletServiceClient.GetBalance(_context.UserId);
            
            _context.GetBalanceResponse = response;
        }

        [When(@"The user who has just created will be deposited '(.*)' amount")]
        public async Task DepositIntoAccountOfUser (string amount)
        {
            decimal quantity = Convert.ToDecimal(amount);

            var requestCharge = _walletCharger.ChargeWallet(_context.UserId, quantity);

            var responce = await _walletServiceClient.Charge(requestCharge);

            _context.GetDepositResponse = responce;
        }

        [When(@"The transaction which is processed last time will be reverted")]
        public async Task RevertTransaction()
        {

            var response = await _walletServiceClient.RevertTransaction(_context.GetDepositResponse.Body.ToString());

            _context.GetRevertTransactionResponse = response;
        }


    }
}