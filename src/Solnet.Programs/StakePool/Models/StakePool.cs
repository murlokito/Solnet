using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Programs.StakePool.Models
{
    /// <summary>
    /// The <see cref="AccountType.StakePool"/> account.
    /// </summary>
    public class StakePool
    {
        /// <summary>
        /// The layout of the structure.
        /// </summary>
        public static class Layout
        {
            /// <summary>
            /// The length of the structure.
            /// </summary>
            public const int Length = 0;
        }

        /// <summary>
        /// Account type, must be StakePool currently
        /// </summary>
        public AccountType AccountType;

        /// <summary>
        /// Manager authority, allows for updating the staker, manager, and fee account
        /// </summary>
        public PublicKey Manager;

        /// <summary>
        /// Staker authority, allows for adding and removing validators, and managing stake
        /// distribution
        /// </summary>
        public PublicKey Staker;

        /// <summary>
        /// Stake deposit authority
        ///
        /// If a depositor pubkey is specified on initialization, then deposits must be
        /// signed by this authority. If no deposit authority is specified,
        /// then the stake pool will default to the result of:
        /// `Pubkey::find_program_address(
        ///     &[&stake_pool_address.to_bytes()[..32], b"deposit"],
        ///     program_id,
        /// )`
        /// </summary>
        public PublicKey StakeDepositAuthority;

        /// <summary>
        /// Stake withdrawal authority bump seed
        /// for `create_program_address(&[state::StakePool account, "withdrawal"])`
        /// </summary>
        public byte StakeWithdrawBumpSeed;

        /// <summary>
        /// Validator stake list storage account
        /// </summary>
        public PublicKey ValidatorList;

        /// <summary>
        /// Reserve stake account, holds deactivated stake
        /// </summary>
        public PublicKey ReserveStake;

        /// <summary>
        /// Pool Mint
        /// </summary>
        public PublicKey PoolMint;

        /// <summary>
        /// Manager fee account
        /// </summary>
        public PublicKey ManagerFee;

        /// <summary>
        /// Pool token program id
        /// </summary>
        public PublicKey TokenProgramId;

        /// <summary>
        /// Total stake under management.
        /// Note that if `last_update_epoch` does not match the current epoch then
        /// this field may not be accurate
        /// </summary>
        public ulong TotalLamports;

        /// <summary>
        /// Total supply of pool tokens (should always match the supply in the Pool Mint)
        /// </summary>
        public ulong PoolTokenSupply;

        /// <summary>
        /// Last epoch the `total_lamports` field was updated
        /// </summary>
        public ulong LastUpdateEpoch;

        /// <summary>
        /// Lockup that all stakes in the pool must have
        /// </summary>
        public byte Lockup;

        /// <summary>
        /// Fee taken as a proportion of rewards each epoch
        /// </summary>
        public Fee EpochFee;

        /// <summary>
        /// Fee for next epoch
        /// </summary>
        public Fee NextEpochFee;

        /// <summary>
        /// Preferred deposit validator vote account pubkey
        /// </summary>
        public PublicKey PreferredDepositValidatorVoteAddress;

        /// <summary>
        /// Preferred withdraw validator vote account pubkey
        /// </summary>
        public PublicKey PreferredWithdrawValidatorVoteAddress;

        /// <summary>
        /// Fee assessed on stake deposits
        /// </summary>
        public Fee StakeDepositFee;

        /// <summary>
        /// Fee assessed on withdrawals
        /// </summary>
        public Fee StakeWithdrawalFee;

        /// <summary>
        /// Future stake withdrawal fee, to be set for the following epoch
        /// </summary>
        public Fee NextStakeWithdrawalFee;

        /// <summary>
        /// Fees paid out to referrers on referred stake deposits.
        /// Expressed as a percentage (0 - 100) of deposit fees.
        /// i.e. `stake_deposit_fee`% of stake deposited is collected as deposit fees for every deposit
        /// and `stake_referral_fee`% of the collected stake deposit fees is paid out to the referrer
        /// </summary>
        public byte StakeReferralFee;

        /// <summary>
        /// Toggles whether the `DepositSol` instruction requires a signature from
        /// this `sol_deposit_authority`
        /// </summary>
        public PublicKey SolanaDepositAuthority;

        /// <summary>
        /// Fee assessed on SOL deposits
        /// </summary>
        public Fee SolanaDepositFee;

        /// <summary>

        /// Fees paid out to referrers on referred SOL deposits.
        /// Expressed as a percentage (0 - 100) of SOL deposit fees.
        /// i.e. `sol_deposit_fee`% of SOL deposited is collected as deposit fees for every deposit
        /// and `sol_referral_fee`% of the collected SOL deposit fees is paid out to the referrer
        /// </summary>
        public byte SolanaReferralFee;

        /// <summary>
        /// Toggles whether the `WithdrawSol` instruction requires a signature from
        /// the `deposit_authority`
        /// </summary>
        public PublicKey SolanaWithdrawAuthority;

        /// <summary>
        /// Fee assessed on SOL withdrawals
        /// </summary>
        public Fee SolanaWithdrawalFee;

        /// <summary>
        /// Future SOL withdrawal fee, to be set for the following epoch
        /// </summary>
        public Fee NextSolanaWithdrawalFee;

        /// <summary>
        /// Last epoch's total pool tokens, used only for APR estimation
        /// </summary>
        public ulong LastEpochPoolTokenSupply;

        /// <summary>
        /// Last epoch's total lamports, used only for APR estimation
        /// </summary>
        public ulong LastEpochTotalLamports;

        public static StakePool Deserialize(ReadOnlySpan<byte> data)
        {
            if (data.Length != Layout.Length)
                throw new ArgumentException("data length is invalid");

            return new StakePool
            {

            };
        }
    }
}
