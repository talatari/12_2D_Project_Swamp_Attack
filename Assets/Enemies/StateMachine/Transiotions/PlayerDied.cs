namespace Enemies.StateMachine.Transiotions
{
    public class PlayerDied : Transition
    {
        private void Update()
        {
            if (Player is null)
                NeedTransit = true;
        }
    }
}