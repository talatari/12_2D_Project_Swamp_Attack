namespace Enemies
{
    public class PlayerDied : Transition
    {
        public void Transit() => 
            NeedTransit = true;
    }
}