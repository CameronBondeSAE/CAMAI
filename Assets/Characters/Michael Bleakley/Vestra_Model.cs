using Michael;

public class Vestra_Model : CharacterBase
{
   public StateBase RoamState;
    
   public StateBase currentState;

   public void changeState(StateBase newState)
   {
      /*
       * check current state
       * exit current state
       * enter new state
       * update current state
       */
      if (currentState == newState) return;
      if (currentState != null) currentState.Exit();
      
          newState.Enter();

      currentState = newState;
   }

   private void Update()
   {
       if (currentState != null) currentState.Execute();
   }
}
