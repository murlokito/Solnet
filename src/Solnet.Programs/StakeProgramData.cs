using Solnet.Programs.Models;
using Solnet.Programs.Utilities;

namespace Solnet.Programs
{
    /// <summary>
    /// Implements the stake program data encodings.
    /// </summary>
    internal static class StakeProgramData
    {
        /// <summary>
        /// The offset at which the value which defines the program method begins. 
        /// </summary>
        internal const int MethodOffset = 0;
        
        /// <summary>
        /// Encode the transaction instruction data for the <see cref="StakeProgramInstructions.Values.SetLockup"/> method.
        /// </summary>
        /// <param name="lockup">The lockup information.</param>
        /// <returns>The byte array with the encoded data.</returns>
        internal static byte[] EncodeSetLockupData(Lockup lockup)
        {
            byte[] data = new byte[52];
            
            data.WriteU32((uint) StakeProgramInstructions.Values.SetLockup, MethodOffset);
            data.WriteS64(lockup.UnixTimestamp, 4);
            data.WriteU64(lockup.Epoch, 12);
            data.WritePubKey(lockup.Custodian, 20);
            
            return data;
        }
        
        /// <summary>
        /// Encode the transaction instruction data for the <see cref="StakeProgramInstructions.Values.SetLockupChecked"/> method.
        /// </summary>
        /// <param name="lockup">The lockup information.</param>
        /// <returns>The byte array with the encoded data.</returns>
        internal static byte[] EncodeSetLockupCheckedData(Lockup lockup)
        {
            byte[] data = new byte[20];
            
            data.WriteU32((uint) StakeProgramInstructions.Values.SetLockupChecked, MethodOffset);
            data.WriteS64(lockup.UnixTimestamp, 4);
            data.WriteU64(lockup.Epoch, 12);
            
            return data;
        }
    }
}