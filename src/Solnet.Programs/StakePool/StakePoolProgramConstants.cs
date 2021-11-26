using System.Text;

namespace Solnet.Programs.StakePool
{
    /// <summary>
    /// Constants for the <see cref="StakePoolProgram"/>.
    /// </summary>
    public static class StakePoolProgramConstants
    {
        /// <summary>
        /// Seed for deposit authority seed
        /// </summary>
        public static readonly byte[] DepositAuthoritySeed = Encoding.UTF8.GetBytes("deposit");

        /// <summary>
        /// Seed for withdraw authority seed
        /// </summary>
        public static readonly byte[] WithdrawAuthoritySeed = Encoding.UTF8.GetBytes("withdraw");

        /// <summary>
        /// Seed for transient stake account
        /// </summary>
        public static readonly byte[] TransientStakeSeedPrefix = Encoding.UTF8.GetBytes("transient");
    }
}
