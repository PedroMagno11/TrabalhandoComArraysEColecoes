using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhandoComArraysEColecoes.ByteBank.Exceptions
{
    internal class ByteBankException : Exception
    {
        public ByteBankException()
        {
        }

        public ByteBankException(string? message) : base(message)
        {
        }

        public ByteBankException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ByteBankException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
