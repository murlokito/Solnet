using Solnet.Programs.Utilities;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Programs.StakePool
{
    /// <summary>
    /// 
    /// </summary>
    public static class StakePoolProgram
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly PublicKey ProgramIdKey = new("");

        /// <summary>
        /// 
        /// </summary>
        public static readonly string ProgramName = "Stake Pool Program";

        /// <summary>
        /// Decodes an instruction created by the System Program.
        /// </summary>
        /// <param name="data">The instruction data to decode.</param>
        /// <param name="keys">The account keys present in the transaction.</param>
        /// <param name="keyIndices">The indices of the account keys for the instruction as they appear in the transaction.</param>
        /// <returns>A decoded instruction.</returns>
        public static DecodedInstruction Decode(ReadOnlySpan<byte> data, IList<PublicKey> keys, byte[] keyIndices)
        {
            uint instruction = data.GetU32(0);
            StakePoolProgramInstructions.Values instructionValue =
                (StakePoolProgramInstructions.Values)Enum.Parse(typeof(StakePoolProgramInstructions.Values), instruction.ToString());

            DecodedInstruction decodedInstruction = new()
            {
                PublicKey = ProgramIdKey,
                InstructionName = StakePoolProgramInstructions.Names[instructionValue],
                ProgramName = ProgramName,
                Values = new Dictionary<string, object>(),
                InnerInstructions = new List<DecodedInstruction>()
            };

            switch (instructionValue)
            {
            }

            return decodedInstruction;
        }
    }
}
