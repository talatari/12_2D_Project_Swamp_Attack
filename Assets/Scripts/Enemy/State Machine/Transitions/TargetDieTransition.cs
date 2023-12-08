public class TargetDieTransition : Transition
{
    private void Update()
    {
        if (Target is null) 
            NeedTransit = true;
    }
}