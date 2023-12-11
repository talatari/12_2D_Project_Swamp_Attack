namespace Enemies.StateMachine.Transiotions
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