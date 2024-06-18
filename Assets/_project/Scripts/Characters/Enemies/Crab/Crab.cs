using UnityEngine;

public class Crab : MachineController{
    public CrabPatrol CrabPatrol;
    public IdleState Idle => StateMachine.IdleState;
    public RunState Run => StateMachine.RunState;
    public JumpState Jump => StateMachine.JumpState;

    public override void HandleJump(){

    }

    public override void HandleSpriteFlip(){

    }

    public override void CreateStates(){
        CrabPatrol = new();

        StateMachine.SetStates(new StatesData{
            Idle = new CrabIdle(),
            Run = new CrabRun(),
            Jump = new CrabJump(),
        });
    }
}