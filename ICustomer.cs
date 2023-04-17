using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welch_Bank
{
    public interface ICustomer
    {
        #region Properties
         string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Mobile { get; set; }
        #endregion
    }
}
