using System;
using System.Collections.Generic;
using Xunit;

namespace game_kata_c_sharp
{
    public enum Direction
    {
        Up, Down, Left, Right
    }

    public class MapTests
    {
        [Fact]
        public void GetEmptyMap()
        {
            var map = new Map();
            Assert.NotNull(map);
        }

        [Fact]
        public void CanGetMapSquare()
        {
            var map = new Map();
            var square = map.GetSquare(0, 0);
            Assert.True(square is Square);
        }

        [Fact]
        public void CanAddPlayerToMapSquare()
        {
            var map = new Map();
            var player = new Player();
            map.AddContent(player, 0, 0);
            var square = map.GetSquare(0, 0);
            var actual = square.GetContents();
            Assert.True(actual[0] == player);
        }

        [Fact]
        public void CanMoveCharacterToValidSquare()
        {
            var map = new Map();
            var player = new Player();
            map.AddContent(player, 0, 0);
            Assert.True(map.MoveCharacter(player, Direction.Right));
        }

        [Fact]
        public void CannotMoveCharacterNotInMap()
        {
            var map = new Map();
            var player = new Player();
            Assert.False(map.MoveCharacter(player, Direction.Right));
        }

        [Fact]
        public void CannotMoveCharacterOutOfBounds()
        {
            var map = new Map();
            var player = new Player();
            map.AddContent(player, 0, 0);
            Assert.False(map.MoveCharacter(player, Direction.Left));
        }

        [Fact]
        public void CharacterGetsAddedToDestinationSquareContent()
        {
            var map = new Map();
            var player = new Player();
            map.AddContent(player, 0, 0);
            map.MoveCharacter(player, Direction.Right);
            var square = map.GetSquare(0, 1);
            var actual = square.GetContents();
            Assert.True(actual[0] == player);
        }

        [Fact]
        public void PlayerGetsRemovedFromOldCoordsAfterMove()
        {
            var map = new Map();
            var player = new Player();
            map.AddContent(player, 0, 0);
            map.MoveCharacter(player, Direction.Right);
            var square = map.GetSquare(0, 0);
            Assert.Empty(square.GetContents());
        }

        [Fact]
        public void CanSpecifyMapWallSquares()
        {
            List<Tuple<int, int>> wallCoordinates = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0,1)
            };

            var map = new Map(wallCoordinates);
            var square = map.GetSquare(wallCoordinates[0].Item1, wallCoordinates[0].Item2);
            Assert.True(square.IsWall());
        }

        [Fact]
        public void WallBlocksAllMoveEffects()
        {
            List<Tuple<int, int>> wallCoordinates = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0,1)
            };

            var map = new Map(wallCoordinates);
            var player = new Player();
            map.AddContent(player, 0, 0);
            Assert.False(map.MoveCharacter(player, Direction.Right));
        }
        
        [Fact]
        public void WallsDontBlockGhostMoves()
        {
            List<Tuple<int, int>> wallCoordinates = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0,1)
            };

            var map = new Map(wallCoordinates);
            var ghost = new Ghost();
            map.AddContent(ghost, 0, 0);
            Assert.True(map.MoveCharacter(ghost, Direction.Right));
        }

        // TODO: Next Tests : Write tests for the constructor for custom map sizes
        // test for walking off map
        
        // TODO:
        // use cases (new game & move player) & layer (use interface)
        // think about visualization in future
    }
}