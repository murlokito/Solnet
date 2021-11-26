using Solnet.Programs.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Programs.StakePool.Models
{
    /// <summary>
    /// An helper structure used just to deserialize the header of the <see cref="ValidatorList"/> account.
    /// </summary>
    public class ValidatorListHeader : StakePoolProgramAccount
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

            /// <summary>
            /// The offset at which the maximum validators value begins.
            /// </summary>
            public const int MaxValidatorsOffset = 1;
        }

        /// <summary>
        /// Maximum allowable number of validators
        /// </summary>
        public uint MaxValidators;

        /// <summary>
        /// Deserialize a span of bytes into a <see cref="StakePool"/> instance.
        /// </summary>
        /// <param name="data">The data to deserialize into the structure.</param>
        /// <returns>The <see cref="StakePool"/> structure.</returns>
        public static ValidatorListHeader Deserialize(ReadOnlySpan<byte> data)
        {
            if (data.Length != ExtraLayout.Length)
                throw new ArgumentException("data length is invalid");

            return new ValidatorListHeader
            {
                AccountType = (AccountType)Enum.Parse(typeof(AccountType), data.GetU8(Layout.AccountTypeOffset).ToString()),
                MaxValidators = data.GetU32(ExtraLayout.MaxValidatorsOffset)
            };

        }
    }

    /// <summary>
    /// Storage list for all validator stake accounts in the pool.
    /// </summary>
    public class ValidatorList
    {
        /// <summary>
        /// The layout of the structure.
        /// </summary>
        public static class Layout
        {
            /// <summary>
            /// The offset at which the header structure begins.
            /// </summary>
            public const int HeaderOffset = 0;

            /// <summary>
            /// The offset at which the validators list begins.
            /// </summary>
            public const int ValidatorsOffset = 5;
        }

        /// <summary>
        /// Data outside of the validator list, separated out for cheaper deserializations.
        /// </summary>
        public ValidatorListHeader Header;

        /// <summary>
        /// List of stake info for each validator in the pool.
        /// </summary>
        public List<ValidatorStakeInfo> Validators;

        /// <summary>
        /// Deserialize a span of bytes into a <see cref="ValidatorList"/> instance.
        /// </summary>
        /// <param name="data">The data to deserialize into the structure.</param>
        /// <returns>The <see cref="ValidatorList"/> structure.</returns>
        public static ValidatorList Deserialize(ReadOnlySpan<byte> data)
        {
            int numValidators = (int)data.GetU32(Layout.ValidatorsOffset);
            List<ValidatorStakeInfo> validators = new(numValidators);

            for (int i = 0; i < numValidators; i++)
            {
                ValidatorStakeInfo validator = ValidatorStakeInfo.Deserialize(
                    data.Slice(Layout.ValidatorsOffset + sizeof(uint) * i, ValidatorStakeInfo.Layout.Length));
                validators.Add(validator);
            }

            return new ValidatorList
            {
                Header = ValidatorListHeader.Deserialize(data.Slice(Layout.HeaderOffset, ValidatorListHeader.ExtraLayout.Length)),
                Validators = validators
            };
        }
    }
}
