using Solnet.Programs.Utilities;
using Solnet.Wallet;
using System;

namespace Solnet.Programs.StakePool.Models
{
    /// <summary>
    /// Information about a validator in the pool.
    /// </summary>
    public class ValidatorStakeInfo
    {
        /// <summary>
        /// The layout of the structure.
        /// </summary>
        public static class Layout
        {
            /// <summary>
            /// The length of the structure.
            /// </summary>
            public const int Length = 73;

            /// <summary>
            /// The offset at which the active stake lamports value begins.
            /// </summary>
            public const int ActiveStakeLamportsOffset = 0;

            /// <summary>
            /// The offset at which the transient stake lamports value begins.
            /// </summary>
            public const int TransientStakeLamports = 8;

            /// <summary>
            /// The offset at which the last update epoch value begins.
            /// </summary>
            public const int LastUpdateEpochOffset = 16;

            /// <summary>
            /// The offset at which the transient seed suffix start value begins.
            /// </summary>
            public const int TransientSeedSuffixStartOffset = 24;

            /// <summary>
            /// The offset at which the transient seed suffix end value begins.
            /// </summary>
            public const int TransientSeedSuffixEndOffset = 32;

            /// <summary>
            /// The offset at which the status value begins.
            /// </summary>
            public const int StatusOffset = 40;

            /// <summary>
            /// The offset at which the vote account address begins.
            /// </summary>
            public const int VoteAccountAddressOffset = 41;
        }

        /// <summary>
        /// Amount of active stake delegated to this validator, minus the minimum
        /// required stake amount of rent-exemption + `crate::MINIMUM_ACTIVE_STAKE`
        /// (currently 0.001 SOL).
        ///
        /// Note that if `last_update_epoch` does not match the current epoch then
        /// this field may not be accurate
        /// </summary>
        public ulong ActiveStakeLamports;

        /// <summary>
        /// Amount of transient stake delegated to this validator
        ///
        /// Note that if `last_update_epoch` does not match the current epoch then
        /// this field may not be accurate
        /// </summary>
        public ulong TransientStakeLamports;

        /// <summary>
        /// Last epoch the active and transient stake lamports fields were updated
        /// </summary>
        public ulong LastUpdateEpoch;

        /// <summary>
        /// Start of the validator transient account seed suffixess
        /// </summary>
        public ulong TransientSeedSuffixStart;

        /// <summary>
        /// End of the validator transient account seed suffixes
        /// </summary>
        public ulong TransientSeedSuffixEnd;

        /// <summary>
        /// Status of the validator stake account
        /// </summary>
        public StakeStatus Status;

        /// <summary>
        /// Validator vote account address
        /// </summary>
        public PublicKey VoteAccountAddress;

        /// <summary>
        /// Deserialize a span of bytes into a <see cref="ValidatorStakeInfo"/> instance.
        /// </summary>
        /// <param name="data">The data to deserialize into the structure.</param>
        /// <returns>The <see cref="ValidatorStakeInfo"/> structure.</returns>
        public static ValidatorStakeInfo Deserialize(ReadOnlySpan<byte> data)
        {
            if (data.Length != Layout.Length)
                throw new ArgumentException("data length is invalid");

            return new ValidatorStakeInfo
            {
                ActiveStakeLamports = data.GetU64(Layout.ActiveStakeLamportsOffset),
                TransientStakeLamports = data.GetU64(Layout.TransientStakeLamports),
                LastUpdateEpoch = data.GetU64(Layout.LastUpdateEpochOffset),
                TransientSeedSuffixStart = data.GetU64(Layout.TransientSeedSuffixStartOffset),
                TransientSeedSuffixEnd = data.GetU64(Layout.TransientSeedSuffixEndOffset),
                Status = (StakeStatus)Enum.Parse(typeof(StakeStatus), data.GetU8(Layout.StatusOffset).ToString()),
                VoteAccountAddress = data.GetPubKey(Layout.VoteAccountAddressOffset)
            };
        }
    }
}
