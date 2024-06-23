using System.Collections;
using UnityEngine;

public class CrabIdle : IdleState{
    public override void EnterState(){
        Crab.ChangeAnimation(Crab.IDLE);
        Crab.Movement.SetDirection(0);
        Crab.StartCoroutine(EnterPatrolStateRoutine());
    }
    public override void LogicUpdate(){}
    public override void PhysicsUpdate(){}
    public override void ExitState(){}
    private IEnumerator EnterPatrolStateRoutine(){
        yield return new WaitForSeconds(1.5f);
        yield return null;
        Crab.ChangeState(Crab.CrabPatrol);
    }
}

public class CrabPatrol : Abstract{
    private int _currentPoint;
    private float _wait;

    public override void EnterState(){}

    public override void LogicUpdate(){
        CheckTarget();
        Patrol();
    }

    private void Patrol(){
        if (Vector3.Distance(Crab.transform.position, Crab.PatrolPoints[_currentPoint].transform.position) > 0.2f){
            _wait = 5f;
            if (Crab.Movement.Body.transform.position.x > Crab.PatrolPoints[_currentPoint].transform.position.x){
                Crab.Movement.SetDirection(-1f);
                Crab.FlipSpriteDirection(-1);
            }else{
                Crab.Movement.SetDirection(1f);
                Crab.FlipSpriteDirection(1);
            }
            if (Crab.Animation.CurrentAnimation == Crab.MOVE){
                return;
            }
            Crab.ChangeAnimation(Crab.MOVE);
        }else{
            Crab.Movement.SetDirection(0);
            _wait -= Time.deltaTime;
            if (_wait <= 0){
                _currentPoint++;
                if (_currentPoint >= Crab.PatrolPoints.Length)
                {
                    _currentPoint = 0;
                    _wait = 0;
                }
            }
            if (Crab.Animation.CurrentAnimation == Crab.IDLE){
                return;
            }
            Crab.ChangeAnimation(Crab.IDLE);
        }
    }

    private void CheckTarget(){
        if (Crab.CheckTarget()){
            Crab.ChangeState(Crab.Chase);
        }
    }
    public override void PhysicsUpdate(){
        
    }
    public override void ExitState(){

    }
}

//Chase
public class CrabRun : RunState{
    Player _target;
    public override void EnterState(){
        _target = Crab.FindAnyObjectByType<Player>();
    }
    public override void LogicUpdate(){
        if(!Crab.CheckTarget()){
            _target = null;
            Crab.ChangeState(Crab.Idle);
            return;
        }

        if (Vector3.Distance(Crab.transform.position, _target.transform.position) > 1.4f){
                if (Crab.Movement.Body.transform.position.x < _target.transform.position.x){
                    Crab.Movement.SetDirection(1f);
                    Crab.FlipSpriteDirection(1);
                }else{
                    Crab.Movement.SetDirection(-1f);
                    Crab.FlipSpriteDirection(-1);
                }

                if (Crab.Animation.CurrentAnimation == Crab.MOVE){
                    return;
                }
                Crab.ChangeAnimation(Crab.MOVE);
            }else{
                Crab.Movement.SetDirection(0);
                Crab.ChangeAnimation(Crab.IDLE);
                _target.GetComponent<Knockback>().ApplyKnockBackForce(_target, Crab.Movement.transform.position);
            }
    }
    public override void PhysicsUpdate(){}
    public override void ExitState(){}
}

public class CrabJump : JumpState{
    public override void EnterState(){}
    public override void LogicUpdate(){}
    public override void PhysicsUpdate(){}
    public override void ExitState(){}
}

public class CrabHurt : HurtState{
    public override void EnterState(){}
    public override void LogicUpdate(){}
    public override void PhysicsUpdate(){}
    public override void ExitState(){}
}