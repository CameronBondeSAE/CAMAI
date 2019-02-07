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
            /*
             * get threat locations and move away from them
             * or get one threat / the main target and move away
             */
            print("Fleeing");
        }

        public override void Exit()
        {
            base.Exit();
            print("Exit of Flee");
        }
    }
}