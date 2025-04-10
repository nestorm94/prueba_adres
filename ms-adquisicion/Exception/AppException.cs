// Ubicación recomendada: ms-adquisicion/Exceptions/AppException.cs
using System;

namespace ms_adquisicion.Exceptions
{
    public class AppException : Exception
    {
        public AppException() { }

        public AppException(string message) : base(message) { }

        public AppException(string message, Exception inner) : base(message, inner) { }
    }
}
