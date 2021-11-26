using Solnet.Programs.StakePool.Enums;
using Solnet.Programs.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Programs.StakePool.Models
{
    /// <summary>
    /// Fee rate as a ratio, minted on `UpdateStakePoolBalance` as a proportion of the rewards
    /// If either the numerator or the denominator is 0, the fee is considered to be 0
    /// </summary>
    public class Fee
    {
        /// <summary>
        /// The layout of the structure.
        /// </summary>
        public static class Layout
        {
            /// <summary>
            /// The length of the structure.
            /// </summary>
            public const int Length = 16;

            /// <summary>
            /// The offset at which the denominator value begins.
            /// </summary>
            public const int DenominatorOffset = 0;

            /// <summary>
            /// The offset at which the numerator value begins.
            /// </summary>
            public const int NumeratorOffset = 8;
        }

        /// <summary>
        /// Denominator of the fee ratio.
        /// </summary>
        public ulong Denominator;

        /// <summary>
        /// Numerator of the fee ratio.
        /// </summary>
        public ulong Numerator;

        /// <summary>
        /// Deserialize a span of bytes into a <see cref="Fee"/> instance.
        /// </summary>
        /// <param name="data">The data to deserialize into the structure.</param>
        /// <returns>The <see cref="Fee"/> structure.</returns>
        public static Fee Deserialize(ReadOnlySpan<byte> data)
        {
            if (data.Length != Layout.Length)
                throw new ArgumentException("data length is invalid");

            return new Fee
            {
                Denominator = data.GetU64(Layout.DenominatorOffset),
                Numerator = data.GetU64(Layout.NumeratorOffset),
            };
        }
    }

    /// <summary>
    /// Argument for the <see cref="StakePoolProgramInstructions.Values.SetFee"/> instruction.
    /// </summary>
    public struct SetFeeArgs
    {
        /// <summary>
        /// The type of fees that can be set on the stake pool.
        /// </summary>
        public FeeType FeeType;

        /// <summary>
        /// The fees, used for:
        /// <see cref="FeeType.SolanaReferral"/>,
        /// <see cref="FeeType.StakeReferral"/>,
        /// </summary>
        public byte Fee;

        /// <summary>
        /// The fee structure, used for:
        /// <see cref="FeeType.Epoch"/>,
        /// <see cref="FeeType.StakeWithdrawal"/>,
        /// <see cref="FeeType.SolanaDeposit"/>,
        /// <see cref="FeeType.StakeDeposit"/>,
        /// <see cref="FeeType.SolanaWithdrawal"/>
        /// </summary>
        public Fee Fees;
    }
}
