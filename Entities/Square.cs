using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;
using game_kata_c_sharp.CustomExceptions;
using Xunit.Sdk;

namespace game_kata_c_sharp
{
    public class Square
    {
        private List<SquareContent> contents = new List<SquareContent>();
        private bool isWall;

        public Square(bool isWall)
        {
            this.isWall = isWall;
        }

        public Square()
        {
        }

        public bool IsWall()
        {
            return isWall;
        }

            public List<SquareContent> GetContents()
        {
            return contents;
        }

        public void AddContent(SquareContent newContent)
        {
            if (!isWall || !newContent.BlocksSquare())
            {
                if (!SquareIsBlockedByContents())
                {
                    contents.Add(newContent);
                    return;
                }
            }

            throw new InvalidContentException("AddContent Failed!");
        }

        private bool SquareIsBlockedByContents()
        {
            foreach (var element in contents)
            {
                if (element.BlocksSquare())
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveContent(SquareContent content)
        {
            contents.Remove(content);
        }
    }
}