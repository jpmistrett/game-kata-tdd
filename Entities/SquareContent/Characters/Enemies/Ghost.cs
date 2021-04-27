namespace game_kata_c_sharp
{
    public class Ghost : Enemy
    {
        public override bool BlocksSquare()
        {
            return false;
        }
    }
}