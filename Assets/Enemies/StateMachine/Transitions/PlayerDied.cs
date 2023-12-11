namespace Enemies
{
    public class PlayerDied : Transition
    {
        private void Update()
        {
            if (Player == null)
                NeedTransit = true;
        }
    }
}