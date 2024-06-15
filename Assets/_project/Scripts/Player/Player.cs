using UnityEngine;

public class Player : MachineController {
    private PlayerInputs _playerInputs;
    public FrameInput Inputs {get; private set;}

    public StateMachine StateMachine {get; private set;}
    public IdleState IdleState => StateMachine.IdleState;
    public RunState RunState => StateMachine.RunState;
    public JumpState JumpState => StateMachine.JumpState;

    public Anim Animation  {get; private set;}
    public readonly int IDLE = Animator.StringToHash("Player_Idle");
    public readonly int RUN = Animator.StringToHash("Player_Run");
    public readonly int JUMP = Animator.StringToHash("Player_Jump");


    private void Awake() {
        Animation = GetComponent<Anim>();
        _playerInputs = GetComponent<PlayerInputs>();

        StateMachine = GetComponent<StateMachine>();
    }

    private void Start() {
        CreateStates();
        StateMachine.ChangeState(StateMachine.IdleState);
    }

    private void Update() {
        Inputs = _playerInputs.Input;
    }

    private void CreateStates(){
        StateMachine.SetStates(new StatesData{
            Idle = new PlayerIdle(),
            Run = new PlayerRun(),
            Jump = new PlayerJump(),
        });
    }
}