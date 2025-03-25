#region

using System;
using System.Security.Cryptography;

#endregion

namespace FacilityAccessService.Business.TerminalScope.ValueObjects
{
    /// <summary>
    /// Describes a 512 bit terminal API token key.
    /// </summary>
    public record TerminalToken
    {
        private byte[] _token = new byte[64];

        protected TerminalToken()
        {
            RandomNumberGenerator.Fill(_token);
        }

        protected TerminalToken(byte[] token)
        {
            if (_token.Length != token.Length)
            {
                throw new ArgumentException("Key length does not match the set internal size.", nameof(token));
            }

            for (int i = 0; i < _token.Length; i++)
            {
                _token[i] = token[i];
            }
        }

        /// <summary>
        /// Returns the token in a hexadecimal representation as a string.
        /// </summary>
        /// <returns></returns>
        public string GetHexFormat()
        {
            return Convert.ToHexString(_token);
        }

        /// <summary>
        /// Returns a token based on a string representation.
        /// </summary>
        /// <param name="hex">String representation of the token in HEX format.</param>
        /// <returns></returns>
        public static TerminalToken GetFromHex(string hex)
        {
            return new TerminalToken(Convert.FromHexString(hex));
        }

        /// <summary>
        /// Generates a new terminal token.
        /// </summary>
        /// <returns></returns>
        public static TerminalToken GenerateToken()
        {
            return new TerminalToken();
        }
    }
}