using UnityEngine;

public class Player : MachineController {
    private PlayerInputs _playerInputs;
    public FrameInput Inputs => _playerInputs.Input;
    public Movement Movement {get; private set;}

#region Weapon
    [Header("Fire Points")]
    public Transform StandFirePoint;
    public Transform JumpFirePoint, DuckFirePoint;
    public Weapon Weapon {get; private set;}
#endregion

#region Modes
    [Header("Modes")]
    [SerializeField] private Transform _standMode;
    [SerializeField] private Transform _ballMode, _duckMode;
    public Transform BallForm => _ballMode;
    public Transform StandForm => _standMode;
    public Transform DuckMode => _duckMode;
#endregion

#region State Machine
    public StateMachine StateMachine {get; private set;}
    public IdleState IdleState => StateMachine.IdleState;
    public RunState RunState => StateMachine.RunState;
    public JumpState JumpState => StateMachine.JumpState;
    public PlayerStandShoot StandShoot {get; private set;}
    public BallMode BallMode {get; private set;}
    public DuckState DuckState {get; private set;}
#endregion

#region Animation
    public Anim Animation  {get; private set;}
    public readonly int IDLE = Animator.StringToHash("Player_Idle");
    public readonly int RUN = Animator.StringToHash("Player_Run");
    public readonly int RUN_SHOOT = Animator.StringToHash("Player_RunShoot");
    public readonly int STAND_SHOOT = Animator.StringToHash("Player_StandShoot");
    public readonly int DUCK = Animator.StringToHash("Player_Duck");
    public readonly int JUMP = Animator.StringToHash("Player_Jump");
    public readonly int DOUBLEJUMP = Animator.StringToHash("Player_DoubleJump");
    public readonly int BALLMODE = Animator.StringToHash("Player_BallMode");
    public readonly int BALLMODE_MOVE = Animator.StringToHash("Player_BallMode_Move");
#endregion

#region Ground Check
    [Header("Ground Check")]
    public Transform GroundCheckBox;
    [SerializeField] private Vector2 _groundBoxSize;
#endregion

#region Unity Methods
    private void Awake() {
        Animation = GetComponent<Anim>();
        Movement = GetComponent<Movement>();
        StateMachine = GetComponent<StateMachine>();
        Weapon = GetComponent<Weapon>();
        _playerInputs = GetComponent<PlayerInputs>();
    }

    private void Start() {
        CreateStates();
        StateMachine.ChangeState(StateMachine.IdleState);
    }

    private void Update() {
        Testing.Instance.UpdateGrounded(IsGrounded());
        HandleSpriteFlip();
    }
#endregion

#region State Machine
    private void CreateStates(){
        StandShoot = new();
        BallMode = new();
        DuckState = new();

        StateMachine.SetStates(new StatesData{
            Idle = new PlayerIdle(),
            Run = new PlayerRun(),
            Jump = new PlayerJump(),
        });
    }

    public override void ChangeState(Abstract newState){
        Testing.Instance.UpdateState(newState);
        StateMachine.ChangeState(newState);
    }
#endregion

#region Movement, Jump and Ground Check
    public bool IsGrounded(){
        Collider2D isGrounded = Physics2D.OverlapBox(GroundCheckBox.position, _groundBoxSize, 0, LayerMask.GetMask("Ground"));
        return isGrounded;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(GroundCheckBox.position, _groundBoxSize);
    }

    public override void HandleMovement(float direction){
        Movement.SetDirection(direction);
    }

    public void Jump(){
        Movement.Jump(true);
    }

    public override void HandleJump(){
        if (Inputs.Jump && IsGrounded()){
            Jump();
            if (StateMachine.CurrentState != BallMode){
                StateMachine.ChangeState(JumpState);
            }
        }
    }
#endregion

#region Animation and Sprite
    public override void ChangeAnimation(int animationHash){
        Animation.ChangeAnimation(animationHash);
    }

    public override void HandleSpriteFlip(){
        if (Inputs.Move.x == 1){
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Inputs.Move.x == -1){
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
#endregion

    public void HandleShoot(){
        Vector2 firePoint;
        Abstract currentState = StateMachine.CurrentState;

        if (currentState == JumpState){
            firePoint = JumpFirePoint.position;
        }else if (currentState == DuckState){
            firePoint = DuckFirePoint.position;
        }else{
            firePoint = StandFirePoint.position;
        }
        
        Weapon.Shoot(transform.localScale.x, firePoint);
    }
}