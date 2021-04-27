using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace game_kata_c_sharp
{
    public class Map
    {
        private readonly List<List<Square>> MapRows = new List<List<Square>>();
        
        private static readonly Dictionary<Direction, Tuple<int, int>> CoordinateAdjustmentsForDirection;

        static Map()
        {
            CoordinateAdjustmentsForDirection = new Dictionary<Direction, Tuple<int, int>>
            {
                [Direction.Up] = new Tuple<int, int>(-1, 0),
                [Direction.Down] = new Tuple<int, int>(1, 0),
                [Direction.Right] = new Tuple<int, int>(0, 1),
                [Direction.Left] = new Tuple<int, int>(0, -1)
            };
        }
        
        public Map():this(new List<Tuple<int, int>>())
        {
            
        }
        
        public Map(List<Tuple<int,int>> wallCoords)
        {
            var width = 3;
            var height = 3;

            for (int row = 0; row < height; row++)
            {
                List<Square> newList = new List<Square>();

                for (int col = 0; col < width; col++)
                {
                    if (wallCoords.Contains(new Tuple<int, int>(row, col)))
                    {
                        newList.Add(new Square(true));
                    }
                    else
                    {
                        newList.Add(new Square());
                    }
                }
                MapRows.Add(newList);
            }
        }

        public Square GetSquare(int row, int column)
        {
            return MapRows.ElementAt(row).ElementAt(column);
        }

        public void AddContent(SquareContent content, int row, int column)
        {
            MapRows.ElementAt(row).ElementAt(column).AddContent(content);
        }

        public bool MoveCharacter(Character character, Direction direction)
        {
            Tuple<int, int> characterCoords = FindCharacterInMap(character);
            Square originSquare , targetSquare;
            
            if (characterCoords == null)
            {
                return false;
            }
            
            originSquare = GetSquareFromCoordinates(characterCoords);
            characterCoords = AdjustCharacterCoordinates(direction, characterCoords);
            targetSquare = GetSquareFromCoordinates(characterCoords);
            
            if (targetSquare == null)
            {
                return false;
            }

            try
            {
                targetSquare.AddContent(character);
                originSquare.RemoveContent(character);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private Square GetSquareFromCoordinates(Tuple<int,int> characterCoords)
        {
            int row = characterCoords.Item1;
            int col = characterCoords.Item2;

            if (row < 0 || row >= MapRows.Count || col < 0)
                return null;

            var mapRow = MapRows[row];
            if (col >= mapRow.Count)
                return null;

            return mapRow[col];
        }

        private Tuple<int, int> AdjustCharacterCoordinates(Direction direction, Tuple<int, int> initialCoords)
        {
            var adjustment = CoordinateAdjustmentsForDirection[direction];
            
            return new Tuple<int, int>(initialCoords.Item1 + adjustment.Item1, initialCoords.Item2 + adjustment.Item2);
        }

        private Tuple<int, int> FindCharacterInMap(Character character)
        {
            int rowIndex = -1, columnIndex = -1;
            
            foreach (var row in MapRows)
            {
                rowIndex++;
                foreach (var square in row)
                {
                    if (square.GetContents().Contains(character))
                    {
                        columnIndex = row.IndexOf(square);
                        return new Tuple<int, int>(rowIndex, columnIndex);
                    }
                }
            }
            return null;
        }
    }
}