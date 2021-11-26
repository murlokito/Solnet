using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Programs.StakePool
{
    /// <summary>
    /// Represents the instruction types for the <see cref="StakePoolProgram"/> along with a friendly name so as not to use reflection.
    /// <remarks>
    /// For more information see:
    /// 
    /// </remarks>
    /// </summary>
    internal static class StakePoolProgramInstructions
    {
        /// <summary>
        /// Represents the user-friendly names for the instruction types for the <see cref="StakePoolProgram"/>.
        /// </summary>
        internal static Dictionary<Values, string> Names = new()
        {
            { Values.Initialize, "Initialize" },
            { Values.AddValidatorToPool, "Add Validator To Pool"},
            { Values.RemoveValidatorFromPool, "Remove Validator From Pool" },
            { Values.DecreaseValidatorStake, "Decrease Validator Stake" },
            { Values.IncreaseValidatorStake, "Increase Validator Stake"},
            { Values.SetPreferredValidator, "Set Preferred Validator"},
            { Values.UpdateValidatorListBalance, "Update Validator List Balance"},
            { Values.UpdateStakePoolBalance, "Update Stake Pool Balance"},
            { Values.CleanupRemovedValidatorEntries, "Cleanup Removed Validator Entries"},
            { Values.DepositStake, "Deposit Stake" },
            { Values.WithdrawStake, "Withdraw Stake" },
            { Values.SetManager, "Set Manager" },
            { Values.SetFee, "Set Fee" },
            { Values.SetStaker, "Set Staker" },
            { Values.DepositSolana, "Deposit Solana" },
            { Values.SetFundingAuthority, "Set Funding Authority" },
            { Values.WithdrawSolana, "Withdraw Solana" }
        };

        /// <summary>
        /// Represents the instruction types for the <see cref="StakePoolProgram"/>.
        /// </summary>
        public enum Values : byte
        {
            /// <summary>
            ///   Initializes a new StakePool.
            /// </summary>
            Initialize = 0,

            /// <summary>
            ///   (Staker only) Adds stake account delegated to validator to the pool's
            ///   list of managed validators.
            ///
            ///   The stake account will have the rent-exempt amount plus
            ///   `crate::MINIMUM_ACTIVE_STAKE` (currently 0.001 SOL).
            /// </summary>
            AddValidatorToPool = 1,

            /// <summary>
            ///   (Staker only) Removes validator from the pool
            ///
            ///   Only succeeds if the validator stake account has the minimum of
            ///   `crate::MINIMUM_ACTIVE_STAKE` (currently 0.001 SOL) plus the rent-exempt
            ///   amount.
            /// </summary>
            RemoveValidatorFromPool = 2,

            /// <summary>
            /// (Staker only) Decrease active stake on a validator, eventually moving it to the reserve
            ///
            /// Internally, this instruction splits a validator stake account into its
            /// corresponding transient stake account and deactivates it.
            ///
            /// In order to rebalance the pool without taking custody, the staker needs
            /// a way of reducing the stake on a stake account. This instruction splits
            /// some amount of stake, up to the total activated stake, from the canonical
            /// validator stake account, into its "transient" stake account.
            ///
            /// The instruction only succeeds if the transient stake account does not
            /// exist. The amount of lamports to move must be at least rent-exemption
            /// plus 1 lamport.
            /// </summary>
            DecreaseValidatorStake = 3,

            /// <summary>
            /// (Staker only) Increase stake on a validator from the reserve account
            ///
            /// Internally, this instruction splits reserve stake into a transient stake
            /// account and delegate to the appropriate validator. `UpdateValidatorListBalance`
            /// will do the work of merging once it's ready.
            ///
            /// This instruction only succeeds if the transient stake account does not exist.
            /// The minimum amount to move is rent-exemption plus `crate::MINIMUM_ACTIVE_STAKE`
            /// (currently 0.001 SOL) in order to avoid issues on credits observed when
            /// merging active stakes later.
            /// </summary>
            IncreaseValidatorStake = 4,

            /// <summary>
            /// (Staker only) Set the preferred deposit or withdraw stake account for the
            /// stake pool
            ///
            /// In order to avoid users abusing the stake pool as a free conversion
            /// between SOL staked on different validators, the staker can force all
            /// deposits and/or withdraws to go to one chosen account, or unset that account.
            /// </summary>
            SetPreferredValidator = 5,

            /// <summary>
            ///  Updates balances of validator and transient stake accounts in the pool
            ///
            ///  While going through the pairs of validator and transient stake accounts,
            ///  if the transient stake is inactive, it is merged into the reserve stake
            ///  account. If the transient stake is active and has matching credits
            ///  observed, it is merged into the canonical validator stake account. In
            ///  all other states, nothing is done, and the balance is simply added to
            ///  the canonical stake account balance.
            /// </summary>
            UpdateValidatorListBalance = 6,

            /// <summary>
            ///   Updates total pool balance based on balances in the reserve and validator list
            /// </summary>
            UpdateStakePoolBalance = 7,

            /// <summary>
            ///   Cleans up validator stake account entries marked as `ReadyForRemoval`
            /// </summary>
            CleanupRemovedValidatorEntries = 8,

            /// <summary>
            ///   Deposit some stake into the pool.  The output is a "pool" token representing ownership
            ///   into the pool. Inputs are converted to the current ratio.
            /// </summary>
            DepositStake = 9,

            /// <summary>
            ///   Withdraw the token from the pool at the current ratio.
            ///
            ///   Succeeds if the stake account has enough SOL to cover the desired amount
            ///   of pool tokens, and if the withdrawal keeps the total staked amount
            ///   above the minimum of rent-exempt amount + 0.001 SOL.
            ///
            ///   When allowing withdrawals, the order of priority goes:
            ///
            ///   * preferred withdraw validator stake account (if set)
            ///   * validator stake accounts
            ///   * transient stake accounts
            ///   * reserve stake account
            ///
            ///   A user can freely withdraw from a validator stake account, and if they
            ///   are all at the minimum, then they can withdraw from transient stake
            ///   accounts, and if they are all at minimum, then they can withdraw from
            ///   the reserve.
            /// </summary>
            WithdrawStake = 10,

            /// <summary>
            ///  (Manager only) Update manager
            /// </summary>
            SetManager = 11,

            /// <summary>
            ///  (Manager only) Update fee
            /// </summary>
            SetFee = 12,

            /// <summary>
            ///  (Manager or staker only) Update staker
            /// </summary>
            SetStaker = 13,

            /// <summary>
            ///   Deposit SOL directly into the pool's reserve account. The output is a "pool" token
            ///   representing ownership into the pool. Inputs are converted to the current ratio.
            /// </summary>
            DepositSolana = 14,

            /// <summary>
            ///  (Manager only) Update SOL deposit authority
            /// </summary>
            SetFundingAuthority = 15,

            /// <summary>
            ///   Withdraw SOL directly from the pool's reserve account. Fails if the
            ///   reserve does not have enough SOL.
            /// </summary>
            WithdrawSolana = 16
        }
    }
}
