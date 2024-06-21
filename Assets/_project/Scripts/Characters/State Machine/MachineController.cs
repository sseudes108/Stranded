using UnityEngine;

public abstract class MachineController : MonoBehaviour {
    public StateMachine StateMachine {get; private set;}
    public Anim Animation  {get; private set;}
    public Movement Movement {get; private set;}
    public Knockback Knockback {get; private set;}

    public virtual void Awake() {
        Animation = GetComponent<Anim>();
        Movement = GetComponent<Movement>();
        Knockback = GetComponent<Knockback>();
        StateMachine = GetComponent<StateMachine>();
    }

    public virtual void Start() {
        CreateStates();
        StateMachine.ChangeState(StateMachine.IdleState);
    }

    public abstract void CreateStates();

    public void ChangeState(Abstract newState){
        if (this is Player){
            Testing.Instance.UpdateState(newState);
        }
        StateMachine.ChangeState(newState);
    }

    public void ChangeAnimation(int animationHash){
        Animation.ChangeAnimation(animationHash);
    }

    public void HandleMovement(float direction){
        Movement.SetDirection(direction);
    }

    public abstract void HandleJump();
    public abstract void HandleSpriteFlip();
}