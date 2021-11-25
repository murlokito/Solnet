using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Programs.StakePool.Models
{
    /// <summary>
    /// The type of fees that can be set on the stake pool
    /// </summary>
    public enum FeeType : byte
    {
        /// Referral fees for SOL deposits
        SolReferral = 0,
        /// Referral fees for stake deposits
        StakeReferral = 1,
        /// Management fee paid per epoch
        Epoch = 2,
        /// Stake withdrawal fee
        StakeWithdrawal = 3,
        /// Deposit fee for SOL deposits
        SolDeposit = 4,
        /// Deposit fee for stake deposits
        StakeDeposit = 5,
        /// SOL withdrawal fee
        SolWithdrawal = 6,
    }
}
