using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Programs.StakePool.Enums
{
    /// <summary>
    /// Defines which validator vote account is set during the
    /// `SetPreferredValidator` instruction
    /// </summary>
    public enum  PreferredValidatorType : byte
    {
        /// <summary>
        /// Set preferred validator for deposits
        /// </summary>
        Deposit = 0,

        /// <summary>
        /// Set preferred validator for withdraws
        /// </summary>
        Withdraw = 1
    }
}
