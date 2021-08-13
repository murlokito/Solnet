using System.Collections.Generic;

namespace Solnet.Programs
{
    /// <summary>
    /// Represents the instruction types for the <see cref="StakeProgram"/> along with a friendly name so as not to use reflection.
    /// <remarks>
    /// For more information see:
    /// https://docs.solana.com/developing/runtime-facilities/programs#stake-program
    /// https://docs.rs/solana-program/1.7.6/src/solana_program/stake/instruction.rs.html
    /// </remarks>
    /// </summary>
    internal static class StakeProgramInstructions
    {
        /// <summary>
        /// Represents the user-friendly names for the instruction types for the <see cref="StakeProgram"/>.
        /// </summary>
        internal static readonly Dictionary<Values, string> Names = new()
        {
            { Values.Initialize, "Initialize" },
            { Values.Authorize, "Authorize" },
            { Values.DelegateStake, "Delegate Stake" },
            { Values.Split, "Split" },
            { Values.Withdraw, "Withdraw" },
            { Values.Deactivate, "Deactivate" },
            { Values.SetLockup, "Set Lockup" },
            { Values.Merge, "Merge" },
            { Values.AuthorizeWithSeed, "Authorize With Seed" },
            { Values.InitializeChecked, "Initialize Checked" },
            { Values.AuthorizeChecked, "Authorize Checked" },
            { Values.AuthorizeCheckedWithSeed, "Authorize Checked With Seed" },
            { Values.SetLockupChecked, "Set Lockup Checked" }
        };

        /// <summary>
        /// Represents the instruction types for the <see cref="StakeProgram"/>.
        /// </summary>
        internal enum Values : byte
        {
            /// <summary>
            /// Initialize the stake account.
            /// </summary>
            Initialize = 0,

            /// <summary>
            /// Authorize a key to manage stake or withdrawal.
            /// </summary>
            Authorize = 1,

            /// <summary>
            /// Delegate a stake to a particular vote account.
            /// </summary>
            DelegateStake = 2,

            /// <summary>
            /// Split stake off a stake account into another stake account.
            /// </summary>
            Split = 3,

            /// <summary>
            /// Withdraw unstaked lamports from the stake account.
            /// </summary>
            Withdraw = 4,

            /// <summary>
            /// Deactivates the stake in the account.
            /// </summary>
            Deactivate = 5,

            /// <summary>
            /// Set the stake's lockup.
            /// </summary>
            SetLockup = 6,

            /// <summary>
            /// Merge two stake accounts.
            /// </summary>
            Merge = 7,

            /// <summary>
            /// Authorize a key to manage stake or withdrawal with a derived key.
            /// </summary>
            AuthorizeWithSeed = 8,

            /// <summary>
            /// Initialize a stake with authorization information.
            /// <remarks>
            /// This instruction is similar to `Initialize` except that the withdraw authority
            /// must be a signer, and no lockup is applied to the account.
            /// </remarks>
            /// </summary>
            InitializeChecked = 9,

            /// <summary>
            /// Authorize a key to manage stake or withdrawal.
            /// <remarks>
            /// This instruction behaves like `Authorize` with the additional requirement that the new
            /// stake or withdraw authority must also be a signer.
            /// </remarks>
            /// </summary>
            AuthorizeChecked = 10,

            /// <summary>
            /// Authorize a key to manage stake or withdrawal with a derived key.
            /// <remarks>
            /// This instruction behaves like `AuthorizeWithSeed` with the additional requirement that
            /// the new stake or withdraw authority must also be a signer.
            /// </remarks>
            /// </summary>
            AuthorizeCheckedWithSeed = 11,

            /// <summary>
            /// Set the stake's lockup.
            /// <remarks>
            /// This instruction behaves like `SetLockup` with the additional requirement that
            /// the new lockup authority also be a signer.
            /// </remarks>
            /// </summary>
            SetLockupChecked = 12
        }
    }
}