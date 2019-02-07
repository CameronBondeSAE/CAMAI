namespace Michael
{
    public class FleeState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            print("Entry of Flee");
        }

        public override void Execute()
        {
            base.Execute();
            print("Fleeing");
        }

        public override void Exit()
        {
            base.Exit();
            print("Exit of Flee");
        }
    }
}