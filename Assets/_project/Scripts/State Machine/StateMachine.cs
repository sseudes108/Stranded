using UnityEngine;

public class StateMachine : MonoBehaviour {
    public Abstract _currentState;

    public IdleState IdleState { get; private set; }
    public RunState RunState { get; private set; }
    public JumpState JumpState { get; private set; }

    public void ChangeState (Abstract newState){
        _currentState?.ExitState();
        _currentState = newState;

        if(_currentState.Controller == null){
            _currentState.SetController(GetComponent<MachineController>());
        }

        _currentState.EnterState();
    }

    private void Update() {
        _currentState.LogicUpdate();
    }

    public void SetStates(StatesData states){
        IdleState = states.Idle;
        RunState = states.Run;
        JumpState = states.Jump;
    }
}