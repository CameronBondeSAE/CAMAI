using Michael;


public class RoamState : StateBase
{
    public override void Enter()
    {
        base.Enter();
        print("Entry Accepted");
    }

    public override void Execute()
    {
        base.Execute();
        print("Wait what?!?!");
    }

    public override void Exit()
    {
        base.Exit();
        print("Exit Accepted");
    }
}
