using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static class ExtraLayout
        {
            /// <summary>
            /// The length of the structure.
            /// </summary>
            public const int Length = 5;
        }

        /// <summary>
        /// 
        /// </summary>
        public ulong ActiveStakeLamports;

        /// <summary>
        /// 
        /// </summary>
        public ulong TransientStakeLamports;

        /// <summary>
        /// 
        /// </summary>
        public ulong LastUpdateEpoch;

        /// <summary>
        /// 
        /// </summary>
        public ulong TransientSeedSuffixStart;

        /// <summary>
        /// 
        /// </summary>
        public ulong TransientSeedSuffixEnd;

        /// <summary>
        /// 
        /// </summary>
        public StakeStatus Status;

        /// <summary>
        /// 
        /// </summary>
        public PublicKey VoteAccountAddress;

        /// <summary>
        /// Deserialize a span of bytes into a <see cref="ValidatorStakeInfo"/> instance.
        /// </summary>
        /// <param name="data">The data to deserialize into the structure.</param>
        /// <returns>The <see cref="ValidatorStakeInfo"/> structure.</returns>
        public static ValidatorStakeInfo Deserialize(ReadOnlySpan<byte> data)
        {
            return new ValidatorStakeInfo
            {
            };
        }
    }
}
