using Solnet.Programs.Utilities;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Programs.StakePool.Models
{

    /// <summary>
    /// A structure containing the information for setting Lockup information for a stake
    /// TODO: CHANGE THIS FOR STAKE PROGRAM LOCKUP STRUCT
    /// </summary>
    public class Lockup
    {
        /// <summary>
        /// The layout of the structure.
        /// </summary>
        public static class Layout
        {
            /// <summary>
            /// The length of the structure.
            /// </summary>
            public const int Length = 48;

            /// <summary>
            /// 
            /// </summary>
            public const int TimestampOffset = 0;

            /// <summary>
            /// 
            /// </summary>
            public const int EpochOffset = 8;

            /// <summary>
            /// 
            /// </summary>
            public const int CustodianOffset = 16;
        }

        /// <summary>
        /// UnixTimestamp at which this stake will allow withdrawal, unless the
        ///   transaction is signed by the custodian
        ///   </summary>
        public Int64 UnixTimestamp { get; set; }
        /// <summary>
        /// epoch height at which this stake will allow withdrawal, unless the
        /// transaction is signed by the custodian
        /// </summary>
        public ulong Epoch { get; set; }
        /// <summary>
        /// custodian signature on a transaction exempts the operation from
        /// lockup constraints
        /// </summary>
        public PublicKey Custodian { get; set; }

        /// <summary>
        /// Deserialize a span of bytes into a <see cref="Lockup"/> instance.
        /// </summary>
        /// <param name="data">The data to deserialize into the structure.</param>
        /// <returns>The <see cref="Lockup"/> structure.</returns>
        public static Lockup Deserialize(ReadOnlySpan<byte> data)
        {
            if (data.Length != Layout.Length)
                throw new ArgumentException("data length is invalid");

            return new Lockup
            {
                UnixTimestamp = data.GetS64(Layout.TimestampOffset),
                Epoch = data.GetU64(Layout.EpochOffset),
                Custodian = data.GetPubKey(Layout.CustodianOffset)
            };
        }
    }

    /// <summary>
    /// The <see cref="AccountType.StakePool"/> account.
    /// </summary>
    public class StakePool : StakePoolProgramAccount
    {

        /// <summary>
        /// The layout of the structure.
        /// </summary>
        public static class ExtraLayout
        {
            /// <summary>
            /// The length of the structure.
            /// </summary>
            public const int Length = 0;

            /// <summary>
            /// 
            /// </summary>
            public const int ManagerOffset = 0;

            /// <summary>
            /// 
            /// </summary>
            public const int StakerOffset = 32;

            /// <summary>
            /// 
            /// </summary>
            public const int StakeDepositAuthorityOffset = 64;

            /// <summary>
            /// 
            /// </summary>
            public const int StakeWithdrawBumpSeedOffset = 96;

            /// <summary>
            /// 
            /// </summary>
            public const int ValidatorListOffset = 97;

            /// <summary>
            /// 
            /// </summary>
            public const int ReserveStakeOffset = 129;

            /// <summary>
            /// 
            /// </summary>
            public const int PoolMintOffset = 161;

            /// <summary>
            /// 
            /// </summary>
            public const int ManagerFeeAccountOffset = 193;

            /// <summary>
            /// 
            /// </summary>
            public const int TokenProgramIdOffset = 225;

            /// <summary>
            /// 
            /// </summary>
            public const int TotalLamportsOffset = 257;

            /// <summary>
            /// 
            /// </summary>
            public const int PoolTokenSupplyOffset = 265;

            /// <summary>
            /// 
            /// </summary>
            public const int LastUpdateEpochOffset = 273;

            /// <summary>
            /// 
            /// </summary>
            public const int LockupOffset = 281;

            /// <summary>
            /// 
            /// </summary>
            public const int EpochFeeOffset = 329;

            /// <summary>
            /// 
            /// </summary>
            public const int NextEpochFeeOffset = 345;

            /// <summary>
            /// 
            /// </summary>
            public const int PreferredDepositValidatorAdddressOffset = 361;

            /// <summary>
            /// 
            /// </summary>
            public const int PreferreddWithdrawValidatorAddressOffset = 393;

            /// <summary>
            /// 
            /// </summary>
            public const int StakeDepositFeeOffset = 425;

            /// <summary>
            /// 
            /// </summary>
            public const int StakeWithdrawalFeeOffset = 441;

            /// <summary>
            /// 
            /// </summary>
            public const int NextStakeWithdrawalFeeOffset = 457;

            /// <summary>
            /// 
            /// </summary>
            public const int StakeReferralFeeOffset = 473;

            /// <summary>
            /// 
            /// </summary>
            public const int SolanaDepositAuthorityOffset = 474;

            /// <summary>
            /// 
            /// </summary>
            public const int SolanaDepositFeeOffset = 506;

            /// <summary>
            /// 
            /// </summary>
            public const int SolanaReferralFeeOffset = 522;

            /// <summary>
            /// 
            /// </summary>
            public const int SolanaWithdrawAuthorityOffset = 523;

            /// <summary>
            /// 
            /// </summary>
            public const int SolanaWithdrawalFeeOffset = 555;

            /// <summary>
            /// 
            /// </summary>
            public const int NextSolanaWithdrawalFeeOffset = 571;

            /// <summary>
            /// 
            /// </summary>
            public const int LastEpochPoolTokenSupplyOffset = 579;

            /// <summary>
            /// 
            /// </summary>
            public const int LastEpochTotalLamportsOffset = 587;
        }

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
        public Lockup Lockup;

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

        /// <summary>
        /// Deserialize a span of bytes into a <see cref="StakePool"/> instance.
        /// </summary>
        /// <param name="data">The data to deserialize into the structure.</param>
        /// <returns>The <see cref="StakePool"/> structure.</returns>
        public static StakePool Deserialize(ReadOnlySpan<byte> data)
        {
            if (data.Length != ExtraLayout.Length)
                throw new ArgumentException("data length is invalid");

            return new StakePool
            {
                AccountType = (AccountType)Enum.Parse(typeof(AccountType), data.GetU8(Layout.AccountTypeOffset).ToString()),
                Manager = data.GetPubKey(ExtraLayout.ManagerOffset),
                Staker = data.GetPubKey(ExtraLayout.StakerOffset),
                StakeDepositAuthority = data.GetPubKey(ExtraLayout.StakeDepositAuthorityOffset),
                StakeWithdrawBumpSeed = data.GetU8(ExtraLayout.StakeWithdrawBumpSeedOffset),
                ValidatorList = data.GetPubKey(ExtraLayout.ValidatorListOffset),
                ReserveStake = data.GetPubKey(ExtraLayout.ReserveStakeOffset),
                PoolMint = data.GetPubKey(ExtraLayout.PoolMintOffset),
                ManagerFee = data.GetPubKey(ExtraLayout.ManagerFeeAccountOffset),
                TokenProgramId = data.GetPubKey(ExtraLayout.TokenProgramIdOffset),
                TotalLamports = data.GetU64(ExtraLayout.TotalLamportsOffset),
                PoolTokenSupply = data.GetU64(ExtraLayout.PoolTokenSupplyOffset),
                LastUpdateEpoch = data.GetU64(ExtraLayout.LastUpdateEpochOffset),
                Lockup = Lockup.Deserialize(data.Slice(ExtraLayout.LockupOffset, Lockup.Layout.Length)),
                EpochFee = Fee.Deserialize(data.Slice(ExtraLayout.EpochFeeOffset, Fee.Layout.Length)),
                NextEpochFee = Fee.Deserialize(data.Slice(ExtraLayout.NextEpochFeeOffset, Fee.Layout.Length)),
                PreferredDepositValidatorVoteAddress = data.GetPubKey(ExtraLayout.PreferredDepositValidatorAdddressOffset),
                PreferredWithdrawValidatorVoteAddress = data.GetPubKey(ExtraLayout.PreferreddWithdrawValidatorAddressOffset),
                StakeDepositFee = Fee.Deserialize(data.Slice(ExtraLayout.StakeDepositFeeOffset, Fee.Layout.Length)),
                StakeWithdrawalFee = Fee.Deserialize(data.Slice(ExtraLayout.StakeWithdrawalFeeOffset, Fee.Layout.Length)),
                NextStakeWithdrawalFee = Fee.Deserialize(data.Slice(ExtraLayout.NextStakeWithdrawalFeeOffset, Fee.Layout.Length)),
                StakeReferralFee = data.GetU8(ExtraLayout.StakeReferralFeeOffset),
                SolanaDepositAuthority = data.GetPubKey(ExtraLayout.SolanaDepositAuthorityOffset),
                SolanaDepositFee = Fee.Deserialize(data.Slice(ExtraLayout.SolanaDepositFeeOffset, Fee.Layout.Length)),
                SolanaReferralFee = data.GetU8(ExtraLayout.SolanaReferralFeeOffset),
                SolanaWithdrawAuthority = data.GetPubKey(ExtraLayout.SolanaWithdrawAuthorityOffset),
                SolanaWithdrawalFee = Fee.Deserialize(data.Slice(ExtraLayout.SolanaWithdrawalFeeOffset, Fee.Layout.Length)),
                NextSolanaWithdrawalFee = Fee.Deserialize(data.Slice(ExtraLayout.NextSolanaWithdrawalFeeOffset, Fee.Layout.Length)),
                LastEpochPoolTokenSupply = data.GetU64(ExtraLayout.LastEpochPoolTokenSupplyOffset),
                LastEpochTotalLamports = data.GetU64(ExtraLayout.LastEpochTotalLamportsOffset)
            };
        }
    }
}
