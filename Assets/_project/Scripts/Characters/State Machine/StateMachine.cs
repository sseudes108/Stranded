using UnityEngine;

public class StateMachine : MonoBehaviour {
    public Abstract CurrentState { get; private set; }
    public IdleState IdleState { get; private set; }
    public RunState RunState { get; private set; }
    public JumpState JumpState { get; private set; }
    public HurtState HurtState { get; private set; }

    public void ChangeState (Abstract newState){
        CurrentState?.ExitState();
        CurrentState = newState;

        if(CurrentState.Controller == null){
            CurrentState.SetController(GetComponent<MachineController>());
        }

        CurrentState.EnterState();
    }

    private void Update() {
        CurrentState.LogicUpdate();
    }

    public void SetStates(StatesData states){
        IdleState = states.Idle;
        RunState = states.Run;
        JumpState = states.Jump;
        HurtState = states.Hurt;
    }
}