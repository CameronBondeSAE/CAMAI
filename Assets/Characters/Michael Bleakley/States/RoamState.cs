namespace Michael
{
    public class RoamState : StateBase
    {

        public override void Enter()
        {
            base.Enter();
            print("Entry of roam");
        }

        public override void Execute()
        {
            base.Execute();
            print("roaming");
        }

        public override void Exit()
        {
            base.Exit();
            print("Exit of roam");
        }
    }
}
