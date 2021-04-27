using System;

namespace game_kata_c_sharp.CustomExceptions
{
    public class InvalidContentException : Exception
    {
        public InvalidContentException(string message) : base(message) { }
    }
}