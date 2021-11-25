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
    /// </remarks>
    /// </summary>
    internal static class StakePoolProgramInstructions
    {
        /// <summary>
        /// Represents the user-friendly names for the instruction types for the <see cref="StakePoolProgram"/>.
        /// </summary>
        internal static Dictionary<Values, string> Names = new()
        {
        };

        /// <summary>
        /// Represents the instruction types for the <see cref="StakePoolProgram"/>.
        /// </summary>
        public enum Values : byte
        {
        }
    }
}
