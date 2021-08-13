using Solnet.Wallet;

namespace Solnet.Programs.Models
{
    /// <summary>
    /// Represents the state of the stake.
    /// </summary>
    public enum StakeState
    {
        /// <summary>
        /// An uninitialized stake account.
        /// </summary>
        Uninitialized,
        
        /// <summary>
        /// An initialized stake account, holds <see cref="Stake"/>.
        /// </summary>
        Initialized,
        
        /// <summary>
        /// A staked stake account, holds <see cref="Meta"/> and <see cref="Stake"/>.
        /// </summary>
        Stake,
        
        /// <summary>
        /// A rewards pool.
        /// </summary>
        RewardsPool
    }
    
    /// <summary>
    /// Represents which type of authorization is being granted on the stake account.
    /// </summary>
    public enum StakeAuthorize
    {
        /// <summary>
        /// Staking authority.
        /// </summary>
        Staker,
        
        /// <summary>
        /// Withdraw authority.
        /// </summary>
        Withdrawer
    }
    
    /// <summary>
    /// Represents the lockup information of a certain stake account.
    /// </summary>
    public class Lockup
    {
        /// <summary>
        /// Unix timestamp at which this stake will allow withdrawal,
        /// unless the transaction is signed by the custodian.
        /// </summary>
        public long UnixTimestamp;

        /// <summary>
        /// Epoch height at which this stake will allow withdrawal,
        /// unless the transaction is signed by the custodian.
        /// </summary>
        public ulong Epoch;

        /// <summary>
        /// The public key of the custodian whose signature on a transaction exempts the operation from lockup constraints.
        /// </summary>
        public PublicKey Custodian;
    }

    /// <summary>
    /// Represents the delegation information of a certain stake account.
    /// </summary>
    public class Delegation
    {
        /// <summary>
        /// The public key of the voter to whom the stake is delegated.
        /// </summary>
        public PublicKey Voter;

        /// <summary>
        /// Activated stake amount.
        /// </summary>
        public ulong Stake;

        /// <summary>
        /// Epoch at which the stake activated.
        /// </summary>
        public ulong ActivationEpoch;
        
        /// <summary>
        /// Epoch at which the stake was deactivated.
        /// </summary>
        public ulong DeactivationEpoch;

        /// <summary>
        /// How much stake can be activated per epoch as a fraction of currently effective stake.
        /// </summary>
        public double WarmupCooldownRate;
    }

    /// <summary>
    /// Represents the stake information.
    /// </summary>
    public class Stake
    {
        /// <summary>
        /// The delegation information.
        /// </summary>
        public Delegation Delegation;

        /// <summary>
        /// Credits from vote account state when delegated or redeemed.
        /// </summary>
        public ulong CreditsObserved;
    }

    /// <summary>
    /// Represents the authorities of the stake account.
    /// </summary>
    public class Authorized
    {
        /// <summary>
        /// The public key of the staking authority.
        /// </summary>
        public PublicKey Staker;
        
        /// <summary>
        /// The public key of the withdraw authority.
        /// </summary>
        public PublicKey Withdrawer;
    }

    /// <summary>
    /// Represents the stake account.
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// The amount of stake reserved for rent exemption.
        /// </summary>
        public ulong RentExemptReserve;
        
        /// <summary>
        /// The authorities of the stake account.
        /// </summary>
        public Authorized Authorized;

        /// <summary>
        /// The lockup associated with this stake account.
        /// </summary>
        public Lockup Lockup;
    }
}