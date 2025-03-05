using System;
using System.Security.Cryptography;

namespace FacilityAccessService.Business.TerminalScope.ValueObjects
{
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

        public string GetHexFormat()
        {
            return Convert.ToHexString(_token);
        }

        public static TerminalToken GetFromHex(string hex)
        {
            return new TerminalToken(Convert.FromHexString(hex));
        }

        public static TerminalToken GenerateToken()
        {
            return new TerminalToken();
        }
    }
}