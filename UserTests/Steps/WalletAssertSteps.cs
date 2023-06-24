using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UserTests.Steps
{
    [Binding]
    internal class WalletAssertSteps
    {

        private readonly Context _context;

        public WalletAssertSteps (Context context)
        {
            _context = context;
        }

        [Then(@"The transaction will be validated as '(.*)'")]
        public async Task ThenAssertTransaction (string transactioncount)
        {
            Assert.AreEqual(Convert.ToInt32(transactioncount), _context.GetTransactionResponse.BodyArr.Length);   
        }

        [Then(@"The charge status will be given as '(.*)'")]
        public async Task ThenAssertChargeStatusIsError(string statusCode)
        {
            var httpcode = Enum.Parse(typeof(HttpStatusCode), statusCode);
            Assert.AreEqual(httpcode, _context.GetDepositResponse.Status);
        }


        [Then(@"The balance will be validated as '(.*)'")]
        public async Task ThenAssertBalance (string totalbalace)
        {
            Assert.AreEqual(Convert.ToDecimal(totalbalace), _context.GetBalanceResponse.Body);
        }

        [Then(@"The balance status will be given as '(.*)'")]
        public async Task ThenAssertBalanceStatus (string statusCode)
        {
            var httpcode = Enum.Parse(typeof(HttpStatusCode), statusCode);
            Assert.AreEqual(httpcode, _context.GetBalanceResponse.Status);
        }

       

    }
}
