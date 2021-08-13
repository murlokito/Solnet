using Solnet.Programs.Models;
using Solnet.Rpc.Models;
using Solnet.Wallet;
using System.Collections.Generic;

namespace Solnet.Programs
{
    /// <summary>
    /// Implements the Stake Program methods.
    /// <remarks>
    /// For more information see:
    /// https://docs.solana.com/developing/runtime-facilities/programs#stake-program
    /// https://docs.rs/solana-program/1.7.6/src/solana_program/stake/instruction.rs.html
    /// </remarks>
    /// </summary>
    public static class StakeProgram
    {
        /// <summary>
        /// The public key of the System Program.
        /// </summary>
        public static PublicKey ProgramIdKey = new("Stake11111111111111111111111111111111111111");

        /// <summary>
        /// The program's name.
        /// </summary>
        private const string ProgramName = "System Program";

        /// <summary>
        /// The stake account layout size.
        /// <remarks>
        /// As found in https://docs.rs/solana-stake-program/1.4.4/solana_stake_program/stake_state/enum.StakeState.html
        /// </remarks>
        /// </summary>
        public const int StakeAccountDataSize = 200;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stakeAccount"></param>
        /// <param name="authorized"></param>
        /// <param name="lockup"></param>
        /// <returns></returns>
        public static TransactionInstruction Initialize(PublicKey stakeAccount, Authorized authorized, Lockup lockup)
        {
            return new TransactionInstruction();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stakeAccount"></param>
        /// <param name="authority"></param>
        /// <param name="newAuthority"></param>
        /// <param name="stakeAuthorize"></param>
        /// <param name="custodian"></param>
        /// <returns></returns>
        public static TransactionInstruction Authorize(
            PublicKey stakeAccount, PublicKey authority, PublicKey newAuthority, StakeAuthorize stakeAuthorize,
            PublicKey custodian = null)
        {
            return new TransactionInstruction();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stakeAccount"></param>
        /// <param name="authority"></param>
        /// <param name="voteAccount"></param>
        /// <returns></returns>
        public static TransactionInstruction DelegateStake(PublicKey stakeAccount, PublicKey authority,
            PublicKey voteAccount)
        {
            return new TransactionInstruction();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stakeAccount"></param>
        /// <param name="authority"></param>
        /// <param name="lamports"></param>
        /// <param name="splitStakeAccount"></param>
        /// <returns></returns>
        public static TransactionInstruction Split(PublicKey stakeAccount, PublicKey authority, ulong lamports,
            PublicKey splitStakeAccount)
        {
            return new TransactionInstruction();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stakeAccount"></param>
        /// <param name="withdrawAuthority"></param>
        /// <param name="destinationAccount"></param>
        /// <param name="lamports"></param>
        /// <param name="custodian"></param>
        /// <returns></returns>
        public static TransactionInstruction Withdraw(
            PublicKey stakeAccount, PublicKey withdrawAuthority, PublicKey destinationAccount, ulong lamports,
            PublicKey custodian = null)
        {
            return new TransactionInstruction();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stakeAccount"></param>
        /// <param name="authority"></param>
        /// <returns></returns>
        public static TransactionInstruction Deactivate(PublicKey stakeAccount, PublicKey authority)
        {
            return new TransactionInstruction();
        }

        public static TransactionInstruction SetLockup(PublicKey stakeAccount, Lockup lockup, PublicKey custodian)
        {
            List<AccountMeta> keys = new()
            {
                AccountMeta.Writable(stakeAccount, false),
                AccountMeta.ReadOnly(custodian, true),
            };
            
            return new TransactionInstruction()
            {
                ProgramId = ProgramIdKey.KeyBytes,
                Keys = keys,
                Data = StakeProgramData.EncodeSetLockupData(lockup)
            };
        }

        public static TransactionInstruction Merge()
        {
            return new TransactionInstruction();
        }

        public static TransactionInstruction AuthorizeWithSeed()
        {
            return new TransactionInstruction();
        }
        
        public static TransactionInstruction InitializeChecked(PublicKey stakeAccount, Authorized authorized)
        {
            return new TransactionInstruction();
        }

        public static TransactionInstruction AuthorizeChecked()
        {
            return new TransactionInstruction();
        }

        public static TransactionInstruction AuthorizeCheckedWithSeed()
        {
            return new TransactionInstruction();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stakeAccount"></param>
        /// <param name="lockup"></param>
        /// <param name="custodian"></param>
        /// <returns></returns>
        public static TransactionInstruction SetLockupChecked(PublicKey stakeAccount, Lockup lockup, PublicKey custodian)
        {
            List<AccountMeta> keys = new()
            {
                AccountMeta.Writable(stakeAccount, false),
                AccountMeta.ReadOnly(custodian, true),
            };
            
            if (lockup.Custodian != null)
                keys.Add(AccountMeta.ReadOnly(lockup.Custodian, true));
            
            return new TransactionInstruction()
            {
                ProgramId = ProgramIdKey.KeyBytes,
                Keys = keys,
                Data = StakeProgramData.EncodeSetLockupCheckedData(lockup)
            };
        }
    }
}