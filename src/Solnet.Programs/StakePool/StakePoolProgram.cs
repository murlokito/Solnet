using Solnet.Programs.StakePool.Enums;
using Solnet.Programs.StakePool.Models;
using Solnet.Programs.Utilities;
using Solnet.Rpc.Models;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Programs.StakePool
{
    /// <summary>
    /// Implements the stake pool program.
    /// <remarks>
    /// For more information see:
    /// 
    /// </remarks>
    /// </summary>
    public static class StakePoolProgram
    {
        /// <summary>
        /// The Stake Pool Program public key.
        /// </summary>
        public static readonly PublicKey ProgramIdKey = new("");

        /// <summary>
        /// The Stake Pool Program name.
        /// </summary>
        public static readonly string ProgramName = "Stake Pool Program";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="stakePool"></param>
        /// <param name="manager"></param>
        /// <param name="staker"></param>
        /// <param name="validatorList"></param>
        /// <param name="reserveStake"></param>
        /// <param name="poolMint"></param>
        /// <param name="managerPoolAccount"></param>
        /// <param name="tokenProgramId"></param>
        /// <param name="fee"></param>
        /// <param name="withdrawalFee"></param>
        /// <param name="depositFee"></param>
        /// <param name="referralFee"></param>
        /// <param name="maxValidators"></param>
        /// <param name="depositAuthority"></param>
        /// <returns></returns>
        public static TransactionInstruction Initialize(PublicKey programId, PublicKey stakePool,
            PublicKey manager, PublicKey staker, PublicKey validatorList, PublicKey reserveStake,
            PublicKey poolMint, PublicKey managerPoolAccount, PublicKey tokenProgramId, Fee fee,
            Fee withdrawalFee, Fee depositFee, byte referralFee, uint maxValidators,
            PublicKey depositAuthority = null)
        {
            return new TransactionInstruction 
            {

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="stakePool"></param>
        /// <param name="staker"></param>
        /// <param name="funder"></param>
        /// <param name="stakePoolWithdraw"></param>
        /// <param name="validatorList"></param>
        /// <param name="stake"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        public static TransactionInstruction AddValidatorToPool(PublicKey programId,
            PublicKey stakePool, PublicKey staker, PublicKey funder, PublicKey stakePoolWithdraw,
            PublicKey validatorList, PublicKey stake, PublicKey validator)
        {
            return new TransactionInstruction
            {

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="stakePool"></param>
        /// <param name="staker"></param>
        /// <param name="stakePoolWithdraw"></param>
        /// <param name="newStakeAuthority"></param>
        /// <param name="validatorList"></param>
        /// <param name="stakeAccount"></param>
        /// <param name="transientStakeAccount"></param>
        /// <param name="destinationStakeAccount"></param>
        /// <returns></returns>
        public static TransactionInstruction RemoveValidatorFromPool(PublicKey programId,
            PublicKey stakePool, PublicKey staker, PublicKey stakePoolWithdraw,
            PublicKey newStakeAuthority, PublicKey validatorList, PublicKey stakeAccount,
            PublicKey transientStakeAccount, PublicKey destinationStakeAccount)
        {
            return new TransactionInstruction { };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="stakePool"></param>
        /// <param name="staker"></param>
        /// <param name="stakePoolWithdrawAuthority"></param>
        /// <param name="validatorList"></param>
        /// <param name="validatorStake"></param>
        /// <param name="transientStake"></param>
        /// <param name="lamports"></param>
        /// <param name="transientStakeSeed"></param>
        /// <returns></returns>
        public static TransactionInstruction DecreaseValidatorStake(PublicKey programId,
            PublicKey stakePool, PublicKey staker, PublicKey stakePoolWithdrawAuthority,
            PublicKey validatorList, PublicKey validatorStake, PublicKey transientStake,
            ulong lamports, ulong transientStakeSeed)
        {
            return new TransactionInstruction { };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="stakePool"></param>
        /// <param name="staker"></param>
        /// <param name="stakePoolWithdrawAuthority"></param>
        /// <param name="validatorList"></param>
        /// <param name="reserveStake"></param>
        /// <param name="transientStake"></param>
        /// <param name="validator"></param>
        /// <param name="lamports"></param>
        /// <param name="transientStakeSeed"></param>
        /// <returns></returns>
        public static TransactionInstruction IncreaseValidatorStake(PublicKey programId,
            PublicKey stakePool, PublicKey staker, PublicKey stakePoolWithdrawAuthority,
            PublicKey validatorList, PublicKey reserveStake, PublicKey transientStake,
            PublicKey validator, ulong lamports, ulong transientStakeSeed)
        {
            return new TransactionInstruction { };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="stakePool"></param>
        /// <param name="staker"></param>
        /// <param name="validatorList"></param>
        /// <param name="preferredValidatorType"></param>
        /// <param name="validatorVoteAddress"></param>
        /// <returns></returns>
        public static TransactionInstruction SetPreferredValidator(PublicKey programId,
            PublicKey stakePool, PublicKey staker, PublicKey validatorList,
            PreferredValidatorType preferredValidatorType, PublicKey validatorVoteAddress = null)
        {
            return new TransactionInstruction { };
        }

        public static TransactionInstruction AddValidatorToPool(PublicKey programId,
            PublicKey stakePool, )
        {
            return new TransactionInstruction { };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="stakePool"></param>
        /// <param name="withdrawAuthority"></param>
        /// <param name="validatorListAddress"></param>
        /// <param name="reserveStake"></param>
        /// <param name="validatorList"></param>
        /// <param name="validatorVoteAccounts"></param>
        /// <param name="startIndex"></param>
        /// <param name="noMerge"></param>
        /// <returns></returns>
        public static TransactionInstruction UpdateValidatorListBalance(PublicKey programId,
            PublicKey stakePool, PublicKey withdrawAuthority, PublicKey validatorListAddress,
            PublicKey reserveStake, ValidatorList validatorList, List<PublicKey> validatorVoteAccounts,
            uint startIndex, bool noMerge)
        {
            return new TransactionInstruction
            {

            };

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="stakePool"></param>
        /// <param name="withdrawAuthority"></param>
        /// <param name="validatorList"></param>
        /// <param name="reserveStake"></param>
        /// <param name="managerFeeAccount"></param>
        /// <param name="poolMint"></param>
        /// <param name="tokenProgramId"></param>
        /// <returns></returns>
        public static TransactionInstruction UpdateStakePoolBalance(PublicKey programId,
            PublicKey stakePool, PublicKey withdrawAuthority, PublicKey validatorList, PublicKey reserveStake,
            PublicKey managerFeeAccount, PublicKey poolMint, PublicKey tokenProgramId)
        {
            return new TransactionInstruction
            {

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="stakePool"></param>
        /// <param name="validatorList"></param>
        /// <returns></returns>
        public static TransactionInstruction CleanupRemovedValidatorEntries(PublicKey programId,
            PublicKey stakePool, PublicKey validatorList)
        {
            return new TransactionInstruction
            {

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="stakePool"></param>
        /// <param name="validatorList"></param>
        /// <param name="stakePoolWithdrawAuthority"></param>
        /// <param name="depositStakeAddress"></param>
        /// <param name="depositStakeWithdrawAuthority"></param>
        /// <param name="validatorStakeAccount"></param>
        /// <param name="reserveStakeAccount"></param>
        /// <param name="poolTokensTo"></param>
        /// <param name="managerFeeAccount"></param>
        /// <param name="referrerPoolTokensAccount"></param>
        /// <param name="poolMint"></param>
        /// <param name="tokenProgramId"></param>
        /// <returns></returns>
        public static TransactionInstruction DepositStake(PublicKey programId,
            PublicKey stakePool, PublicKey validatorList, PublicKey stakePoolWithdrawAuthority,
            PublicKey depositStakeAddress, PublicKey depositStakeWithdrawAuthority, PublicKey validatorStakeAccount,
            PublicKey reserveStakeAccount, PublicKey poolTokensTo, PublicKey managerFeeAccount, PublicKey referrerPoolTokensAccount,
            PublicKey poolMint, PublicKey tokenProgramId)
        {
            return new TransactionInstruction
            {

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="stakePool"></param>
        /// <param name="stakePoolWithdrawAuthority"></param>
        /// <param name="reserveStakeAccount"></param>
        /// <param name="lamportsFrom"></param>
        /// <param name="poolTokensTo"></param>
        /// <param name="managerFeeAccount"></param>
        /// <param name="referrerPoolTokensAccount"></param>
        /// <param name="poolMint"></param>
        /// <param name="tokenProgramId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static TransactionInstruction DepositSolana(PublicKey programId,
            PublicKey stakePool, PublicKey stakePoolWithdrawAuthority, PublicKey reserveStakeAccount,
            PublicKey lamportsFrom, PublicKey poolTokensTo, PublicKey managerFeeAccount,
            PublicKey referrerPoolTokensAccount, PublicKey poolMint, PublicKey tokenProgramId, ulong amount)
        {
            return new TransactionInstruction
            {

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="stakePool"></param>
        /// <param name="solanaDepositAuthority"></param>
        /// <param name="stakePoolWithdrawAuthority"></param>
        /// <param name="reserveStakeAccount"></param>
        /// <param name="lamportsFrom"></param>
        /// <param name="poolTokensTo"></param>
        /// <param name="managerFeeAccount"></param>
        /// <param name="referrerPoolTokensAccount"></param>
        /// <param name="poolMint"></param>
        /// <param name="tokenProgramId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static TransactionInstruction DepositSolanaWithAuthority(PublicKey programId,
            PublicKey stakePool, PublicKey solanaDepositAuthority, PublicKey stakePoolWithdrawAuthority,
            PublicKey reserveStakeAccount, PublicKey lamportsFrom, PublicKey poolTokensTo,
            PublicKey managerFeeAccount, PublicKey referrerPoolTokensAccount, PublicKey poolMint,
            PublicKey tokenProgramId, ulong amount)
        {
            return new TransactionInstruction
            {

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="stakePool"></param>
        /// <param name="validatorList"></param>
        /// <param name="stakePoolWithdraw"></param>
        /// <param name="stakeToSplit"></param>
        /// <param name="stakeToReceive"></param>
        /// <param name="userStakeAuthority"></param>
        /// <param name="userTransferAuthority"></param>
        /// <param name="userPoolTokenAccount"></param>
        /// <param name="managerFeeAccount"></param>
        /// <param name="poolMint"></param>
        /// <param name="TokenProgramId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static TransactionInstruction WithdrawStake(PublicKey programId,
            PublicKey stakePool, PublicKey validatorList, PublicKey stakePoolWithdraw,
            PublicKey stakeToSplit, PublicKey stakeToReceive, PublicKey userStakeAuthority,
            PublicKey userTransferAuthority, PublicKey userPoolTokenAccount, PublicKey managerFeeAccount,
            PublicKey poolMint, PublicKey TokenProgramId, ulong amount)
        {
            return new TransactionInstruction
            {

            };

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="stakePool"></param>
        /// <param name="stakePoolWithdrawAuthority"></param>
        /// <param name="userTransferAuthority"></param>
        /// <param name="poolTokensFrom"></param>
        /// <param name="reserveStakeAccount"></param>
        /// <param name="lamportsTo"></param>
        /// <param name="managerFeeAccount"></param>
        /// <param name="poolMint"></param>
        /// <param name="tokenProgramId"></param>
        /// <param name="poolTokens"></param>
        /// <returns></returns>
        public static TransactionInstruction WithdrawSolana(PublicKey programId,
            PublicKey stakePool, PublicKey stakePoolWithdrawAuthority, PublicKey userTransferAuthority,
            PublicKey poolTokensFrom, PublicKey reserveStakeAccount, PublicKey lamportsTo,
            PublicKey managerFeeAccount, PublicKey poolMint, PublicKey tokenProgramId,
            ulong poolTokens)
        {
            return new TransactionInstruction
            {

            };

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="stakePool"></param>
        /// <param name="solanaWithdrawAuthority"></param>
        /// <param name="stakePoolWithdrawAuthority"></param>
        /// <param name="userTransferAuthority"></param>
        /// <param name="poolTokensFrom"></param>
        /// <param name="reserveStakeAccount"></param>
        /// <param name="lamportsTo"></param>
        /// <param name="managerFeeAccount"></param>
        /// <param name="poolMint"></param>
        /// <param name="tokenProgramId"></param>
        /// <param name="poolTokens"></param>
        /// <returns></returns>
        public static TransactionInstruction WithdrawSolanaWithAuthority(PublicKey programId,
            PublicKey stakePool, PublicKey solanaWithdrawAuthority, PublicKey stakePoolWithdrawAuthority,
            PublicKey userTransferAuthority, PublicKey poolTokensFrom, PublicKey reserveStakeAccount,
            PublicKey lamportsTo, PublicKey managerFeeAccount, PublicKey poolMint, PublicKey tokenProgramId,
            ulong poolTokens)
        {
            return new TransactionInstruction
            {

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="stakePool"></param>
        /// <param name="manager"></param>
        /// <param name="newManager"></param>
        /// <param name="newFeeReceiver"></param>
        /// <returns></returns>
        public static TransactionInstruction SetManager(PublicKey programId,
            PublicKey stakePool, PublicKey manager, PublicKey newManager, PublicKey newFeeReceiver)
        {
            return new TransactionInstruction
            {

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="stakePool"></param>
        /// <param name="manager"></param>
        /// <param name="feeArgs"></param>
        /// <returns></returns>
        public static TransactionInstruction SetFee(PublicKey programId,
            PublicKey stakePool, PublicKey manager, SetFeeArgs feeArgs)
        {
            return new TransactionInstruction
            {

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="stakePool"></param>
        /// <param name="setStakerAuthority"></param>
        /// <param name="newStaker"></param>
        /// <returns></returns>
        public static TransactionInstruction SetStaker(PublicKey programId,
            PublicKey stakePool, PublicKey setStakerAuthority, PublicKey newStaker)
        {


            return new TransactionInstruction
            {

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="stakePool"></param>
        /// <param name="manager"></param>
        /// <param name="fundingType"></param>
        /// <param name="newSolanaDepositAuthority"></param>
        /// <returns></returns>
        public static TransactionInstruction SetFundingAuthority(PublicKey programId,
            PublicKey stakePool, PublicKey manager, FundingType fundingType,
            PublicKey newSolanaDepositAuthority = null)
        {

            return new TransactionInstruction
            {

            };
        }

        /// <summary>
        /// Decodes an instruction created by the System Program.
        /// </summary>
        /// <param name="data">The instruction data to decode.</param>
        /// <param name="keys">The account keys present in the transaction.</param>
        /// <param name="keyIndices">The indices of the account keys for the instruction as they appear in the transaction.</param>
        /// <returns>A decoded instruction.</returns>
        public static DecodedInstruction Decode(ReadOnlySpan<byte> data, IList<PublicKey> keys, byte[] keyIndices)
        {
            uint instruction = data.GetU32(0);
            StakePoolProgramInstructions.Values instructionValue =
                (StakePoolProgramInstructions.Values)Enum.Parse(typeof(StakePoolProgramInstructions.Values), instruction.ToString());

            DecodedInstruction decodedInstruction = new()
            {
                PublicKey = ProgramIdKey,
                InstructionName = StakePoolProgramInstructions.Names[instructionValue],
                ProgramName = ProgramName,
                Values = new Dictionary<string, object>(),
                InnerInstructions = new List<DecodedInstruction>()
            };

            switch (instructionValue)
            {
                case StakePoolProgramInstructions.Values.Initialize:
                    break;
                case StakePoolProgramInstructions.Values.AddValidatorToPool:
                    break;
                case StakePoolProgramInstructions.Values.RemoveValidatorFromPool:
                    break;
                case StakePoolProgramInstructions.Values.DecreaseValidatorStake:
                    break;
                case StakePoolProgramInstructions.Values.IncreaseValidatorStake:
                    break;
                case StakePoolProgramInstructions.Values.SetPreferredValidator:
                    break;
                case StakePoolProgramInstructions.Values.UpdateValidatorListBalance:
                    break;
                case StakePoolProgramInstructions.Values.UpdateStakePoolBalance:
                    break;
                case StakePoolProgramInstructions.Values.CleanupRemovedValidatorEntries:
                    break;
                case StakePoolProgramInstructions.Values.DepositStake:
                    break;
                case StakePoolProgramInstructions.Values.WithdrawStake:
                    break;
                case StakePoolProgramInstructions.Values.SetManager:
                    break;
                case StakePoolProgramInstructions.Values.SetFee:
                    break;
                case StakePoolProgramInstructions.Values.SetStaker:
                    break;
                case StakePoolProgramInstructions.Values.DepositSolana:
                    break;
                case StakePoolProgramInstructions.Values.SetFundingAuthority:
                    break;
                case StakePoolProgramInstructions.Values.WithdrawSolana:
                    break;
            }

            return decodedInstruction;
        }
    }
}
