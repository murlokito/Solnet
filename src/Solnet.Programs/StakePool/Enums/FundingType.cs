using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Programs.StakePool.Enums
{
    /// <summary>
    /// Defines which authority to update in the `SetFundingAuthority`
    /// instruction
    /// </summary>
    public enum FundingType : byte
    {
        /// <summary>
        /// Sets the stake deposit authority
        /// </summary>
        StakeDeposit = 0,

        /// <summary>
        /// Sets the SOL deposit authority
        /// </summary>
        SolanaDeposit = 1,

        /// <summary>
        /// Sets the SOL withdraw authority
        /// </summary>
        SolanaWithdraw = 2
    }
}
