﻿namespace SqualrCore.Source.Engine.Architecture.Assembler
{
    using Proxy;
    using System;
    using Utils.Extensions;

    /// <summary>
    /// The Fasm assembler for x86/64.
    /// </summary>
    internal class Fasm32Assembler : IAssembler
    {
        /// <summary>
        /// Assemble the specified assembly code.
        /// </summary>
        /// <param name="isProcess32Bit">Whether or not the assembly is in the context of a 32 bit program.</param>
        /// <param name="assembly">The assembly code.</param>
        /// <param name="message">The logs generated by the assembler.</param>
        /// <returns>An array of bytes containing the assembly code.</returns>
        public Byte[] Assemble(Boolean isProcess32Bit, String assembly, out String message, out String innerMessage)
        {
            // Assemble and return the code
            return this.Assemble(isProcess32Bit, assembly, IntPtr.Zero, out message, out innerMessage);
        }

        /// <summary>
        /// Assemble the specified assembly code at a base address.
        /// </summary>
        /// <param name="isProcess32Bit">Whether or not the assembly is in the context of a 32 bit program.</param>
        /// <param name="assembly">The assembly code.</param>
        /// <param name="baseAddress">The address where the code is rebased.</param>
        /// <param name="message">The logs generated by the assembler.</param>
        /// <returns>An array of bytes containing the assembly code.</returns>
        public Byte[] Assemble(Boolean isProcess32Bit, String assembly, IntPtr baseAddress, out String message, out String innerMessage)
        {
            // Call proxy service, which simply passes the asm code to Fasm.net to assemble the instructions
            // Note: for assembling instructions, we must always use the 32-bit proxy service to assemble both x86/x64 instructions
            return ProxyCommunicator.GetInstance().GetProxyService(true).Assemble(isProcess32Bit, assembly, baseAddress.ToUInt64(), out message, out innerMessage);
        }
    }
    //// End class
}
//// End namespace