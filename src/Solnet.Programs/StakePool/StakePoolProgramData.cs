using Solnet.Programs.StakePool.Enums;
using Solnet.Programs.StakePool.Models;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Programs.StakePool
{
    internal class StakePoolProgramData
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fee"></param>
        /// <param name="withdrawalFee"></param>
        /// <param name="depositFee"></param>
        /// <param name="referralFee"></param>
        /// <param name="maxValidators"></param>
        /// <returns></returns>
        internal static byte[] EncodeInitializeData(Fee fee, Fee withdrawalFee, Fee depositFee, byte referralFee, uint maxValidators)
        {
            byte[] buffer = new byte[1];
            return buffer;
        }

        internal static byte[] EncodeAddValidatorToPoolData()
        {
            byte[] buffer = new byte[1];
            return buffer;
        }

        internal static byte[] EncodeRemoveValidatorFromPoolData()
        {
            byte[] buffer = new byte[1];
            return buffer;
        }

        internal static byte[] EncodeDecreaseValidatorStakeData(ulong lamports, ulong transientStakeSeed)
        {
            byte[] buffer = new byte[1];
            return buffer;
        }

        internal static byte[] EncodeIncreaseValidatorStakeData(ulong lamports, ulong transientStakeSeed)
        {
            byte[] buffer = new byte[1];
            return buffer;
        }

        internal static byte[] EncodeSetPreferredValidatorData(PreferredValidatorType validatorType, PublicKey validatorVoteAddress)
        {
            byte[] buffer = new byte[1];
            return buffer;
        }

        internal static byte[] EncodeUpdateValidatorListBalanceData(uint startIndex, bool noMerge)
        {
            byte[] buffer = new byte[1];
            return buffer;
        }

        internal static byte[] EncodeUpdateStakePoolBalanceData()
        {
            byte[] buffer = new byte[1];
            return buffer;
        }

        internal static byte[] EncodeCleanupRemovedValidatorEntriesData()
        {
            byte[] buffer = new byte[1];
            return buffer;
        }

        internal static byte[] EncodeDepositStakeData()
        {
            byte[] buffer = new byte[1];
            return buffer;
        }

        internal static byte[] EncodeWithdrawStakeData(ulong amoont)
        {
            byte[] buffer = new byte[1];
            return buffer;
        }

        internal static byte[] EncodeSetManagerData()
        {
            byte[] buffer = new byte[1];
            return buffer;
        }

        internal static byte[] EncodeSetFeeData(FeeType feeType)
        {
            byte[] buffer = new byte[1];
            return buffer;
        }

        internal static byte[] EncodeSetStakerData()
        {
            byte[] buffer = new byte[1];
            return buffer;
        }

        internal static byte[] EncodeDepositSolanaData(ulong amoont)
        {
            byte[] buffer = new byte[1];
            return buffer;
        }

        internal static byte[] EncodeSetFundingAuthorityData(FundingType fundingType)
        {
            byte[] buffer = new byte[1];
            return buffer;
        }

        internal static byte[] EncodeWithdrawSolanaData(ulong amoont)
        {
            byte[] buffer = new byte[1];
            return buffer;
        }
    }
}
