using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Programs.StakePool.Models
{
    /// <summary>
    /// Status of the stake account in the validator list, for accounting
    /// </summary>
    public enum StakeStatus : byte
    {
        /// <summary>
        /// Stake account is active, there may be a transient stake as well
        /// </summary>
        Active = 0,

        /// <summary>
        /// Only transient stake account exists, when a transient stake is
        /// deactivating during validator removal
        /// </summary>
        DeactivatingTransient = 1,

        /// <summary>
        /// No more validator stake accounts exist, entry ready for removal during
        /// `UpdateStakePoolBalance`
        /// </summary>
        ReadyForRemoval = 2
    }
}
