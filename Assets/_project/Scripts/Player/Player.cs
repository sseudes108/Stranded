using UnityEngine;

public class Player : MachineController {
    private PlayerInputs _playerInputs;
    public FrameInput Inputs => _playerInputs.Input;
    public Movement Movement {get; private set;}

#region State Machine
    public StateMachine StateMachine {get; private set;}
    public IdleState IdleState => StateMachine.IdleState;
    public RunState RunState => StateMachine.RunState;
    public JumpState JumpState => StateMachine.JumpState;
#endregion

#region Animation
    public Anim Animation  {get; private set;}
    public readonly int IDLE = Animator.StringToHash("Player_Idle");
    public readonly int RUN = Animator.StringToHash("Player_Run");
    public readonly int RUN_SHOOT = Animator.StringToHash("Player_RunShoot");
    public readonly int STAND_SHOOT = Animator.StringToHash("Player_StandShoot");
    public readonly int JUMP = Animator.StringToHash("Player_Jump");
    public readonly int DOUBLEJUMP = Animator.StringToHash("Player_DoubleJump");
    public readonly int BALLMODE = Animator.StringToHash("Player_BallMode");
#endregion

#region Ground Check
    [SerializeField] private Transform _groundCheckBox;
    [SerializeField] private Vector2 _groundBoxSize;
#endregion

    private void Awake() {
        Animation = GetComponent<Anim>();
        Movement = GetComponent<Movement>();
        _playerInputs = GetComponent<PlayerInputs>();
        StateMachine = GetComponent<StateMachine>();
    }

    private void Start() {
        CreateStates();
        StateMachine.ChangeState(StateMachine.IdleState);
    }

    private void Update() {
        Testing.Instance.UpdateGrounded(IsGrounded());
    }

    private void CreateStates(){
        StateMachine.SetStates(new StatesData{
            Idle = new PlayerIdle(),
            Run = new PlayerRun(),
            Jump = new PlayerJump(),
        });
    }

    public bool IsGrounded(){
        Collider2D isGrounded = Physics2D.OverlapBox(_groundCheckBox.position, _groundBoxSize, 0, LayerMask.GetMask("Ground"));
        return isGrounded;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_groundCheckBox.position, _groundBoxSize);
    }

    public override void ChangeState(Abstract newState){
        Testing.Instance.UpdateState(newState);
        StateMachine.ChangeState(newState);
    }

    public override void ChangeAnimation(int animationHash){
        Animation.ChangeAnimation(animationHash);
    }

    public override void HandleMovement(float direction){
        Movement.SetDirection(direction);
    }

    public override void HandleJump(){
        if (Inputs.Jump && IsGrounded()){
            Movement.Jump(true);
            StateMachine.ChangeState(JumpState);
        }
    }
}