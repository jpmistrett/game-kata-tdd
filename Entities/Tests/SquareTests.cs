using System;
using Xunit;

namespace game_kata_c_sharp
{
    public class SquareTests
    {
        [Fact]
        public void GetEmptySquare()
        {
            var tmp = new Square();
            var actual = tmp.GetContents();
            Assert.Empty(actual);
        }

        [Fact]
        public void CanAddPlayerToEmptySquare()
        {
            var tmp = new Square();
            var player = new Player();
            tmp.AddContent(player);
            var actual = tmp.GetContents();
            Assert.True(actual[0] == player);
        }
        
        [Fact]
        public void CanAddEnemyToEmptySquare()
        {
            var tmp = new Square();
            var enemy = new Enemy();
            tmp.AddContent(enemy);
            var actual = tmp.GetContents();
            Assert.True(actual[0] == enemy);
        }
        
        [Fact]
        public void CannotAddPlayerToWallSquare()
        {
            bool isWall = true;
            var square = new Square(isWall);
            square.AddContent(new Player());
            var actual = square.GetContents();
            Assert.Empty(actual);
        }
        
        [Fact]
        public void CannotAddItemToWallSquare()
        {
            bool isWall = true;
            var square = new Square(isWall);
            square.AddContent(new Chest());
            var actual = square.GetContents();
            Assert.Empty(actual);
        }
        
        [Fact]
        public void CannotAddPlayerToSquareWithEnemy()
        {
            var square = new Square();
            square.AddContent(new Enemy());
            square.AddContent(new Player());
            var actual = square.GetContents();
            Assert.True(actual.Count == 1);
        }
        
        [Fact]
        public void CanAddChestToSquareWithEnemy()
        {
            var square = new Square();
            square.AddContent(new Enemy());
            square.AddContent(new Chest());
            var actual = square.GetContents();
            Assert.True(actual.Count == 2);
        }
        
        [Fact]
        public void CanAddChestToSquareWithPlayer()
        {
            var square = new Square();
            square.AddContent(new Player());
            square.AddContent(new Chest());
            var actual = square.GetContents();
            Assert.True(actual.Count == 2);
        }
        
        [Fact]
        public void CanAddEnemyToSquareWithChest()
        {
            var square = new Square();
            square.AddContent(new Chest());
            square.AddContent(new Enemy());
            var actual = square.GetContents();
            Assert.True(actual.Count == 2);
        }
        
        [Fact]
        public void CanAddPlayerToSquareWithChest()
        {
            var square = new Square();
            square.AddContent(new Chest());
            square.AddContent(new Player());
            var actual = square.GetContents();
            Assert.True(actual.Count == 2);
        }
        
        [Fact]
        public void CannotAddEnemyToSquareWithEnemy()
        {
            var square = new Square();
            square.AddContent(new Enemy());
            square.AddContent(new Enemy());
            var actual = square.GetContents();
            Assert.True(actual.Count == 1);
        }
        
        [Fact]
        public void CannotAddPlayerToSquareWithPlayer()
        {
            var square = new Square();
            square.AddContent(new Player());
            square.AddContent(new Player());
            var actual = square.GetContents();
            Assert.True(actual.Count == 1);
        }
        
        [Fact]
        public void CanAddChestToSquareWithChest()
        {
            var square = new Square();
            square.AddContent(new Chest());
            square.AddContent(new Chest());
            var actual = square.GetContents();
            Assert.True(actual.Count == 2);
        }
        
        [Fact]
        public void CanAddGhostToBlockedSquare()
        {
            var square = new Square();
            square.AddContent(new Player());
            square.AddContent(new Ghost());
            var actual = square.GetContents();
            Assert.True(actual.Count == 2);
        }
        
        [Fact]
        public void CanRemovePlayerFromSquare()
        {
            var tmp = new Square();
            var player = new Player();
            tmp.AddContent(player);
            tmp.RemoveContent(player);
            Assert.Empty(tmp.GetContents());
        }
        
        [Fact]
        public void CannotRemovePlayerFromEmptySquare()
        {
            var tmp = new Square();
            var player = new Player();
            tmp.RemoveContent(player);
            Assert.Empty(tmp.GetContents());
        }
    }
}