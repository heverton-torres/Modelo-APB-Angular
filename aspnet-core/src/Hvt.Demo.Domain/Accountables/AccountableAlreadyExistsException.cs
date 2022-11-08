using System;
using System.Runtime.Serialization;
using Volo.Abp;

namespace Hvt.Demo.Accountables
{
    public class AccountableAlreadyExistsException : BusinessException
    {

        public AccountableAlreadyExistsException(string name) :base(DemoDomainErrorCodes.AccountableAlreadyExists)
        {
            WithData("name", name);
        }


    }
}