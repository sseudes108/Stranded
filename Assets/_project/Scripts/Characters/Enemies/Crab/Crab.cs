using UnityEngine;

public class Crab : MachineController{
    public CrabPatrol CrabPatrol;
    public IdleState Idle => StateMachine.IdleState;
    public RunState Chase => StateMachine.RunState;
    public JumpState Jump => StateMachine.JumpState;
    public PatrolPoint[] PatrolPoints;

    [SerializeField] private Transform _aggroCheckBox;
    [SerializeField] private Vector2 _aggroCheckSize;
    public Player Target;

    public readonly int MOVE = Animator.StringToHash("Crab_Move");
    public readonly int IDLE = Animator.StringToHash("Crab_Idle");

    public override void Awake() {
        base.Awake();
        PatrolPoints = GetComponentsInChildren<PatrolPoint>();
    }

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
            Hurt = new CrabHurt(),
        });
    }

    public void FlipSpriteDirection(int direction){
        if (direction == 1){
            transform.localScale = new Vector3(-1, 1, 1);
        }if (direction == -1){
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public bool CheckTarget(){
        Collider2D chase = Physics2D.OverlapBox(_aggroCheckBox.position, _aggroCheckSize, 0, LayerMask.GetMask("Player"));
        return chase;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(_aggroCheckBox.position,_aggroCheckSize);
    }
}