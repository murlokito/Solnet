using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Programs.StakePool.Models
{
    /// <summary>
    /// A base account managed by the <see cref="StakePoolProgram"/>.
    /// </summary>
    public abstract class StakePoolProgramAccount
    {
        /// <summary>
        /// The layout of the structure.
        /// </summary>
        public static class Layout
        {
            /// <summary>
            /// The offset at which the account type value begins.
            /// </summary>
            public const int AccountTypeOffset = 0;
        }

        /// <summary>
        /// Account type, must be StakePool currently
        /// </summary>
        public AccountType AccountType;
    }
}
