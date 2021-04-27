namespace game_kata_c_sharp
{
    public abstract class Character : SquareContent
    {
        public override bool BlocksSquare()
        {
            return true;
        }
    }
}