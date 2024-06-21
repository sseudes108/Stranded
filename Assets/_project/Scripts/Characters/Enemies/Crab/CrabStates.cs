using System.Collections;
using UnityEngine;

public class CrabPatrol : Abstract{
    private int _currentPoint;
    private float _wait;
    private float _direction;
    public override void EnterState(){

    }

    public override void LogicUpdate(){
        CheckTarget();
        Patrol();
        FlipSpriteDirection();
    }

    private void FlipSpriteDirection(){
        if (_direction == 1){
            Crab.transform.localScale = new Vector3(-1, 1, 1);
        }if (_direction == -1){
            Crab.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void Patrol(){
        if (Vector3.Distance(Crab.transform.position, Crab.PatrolPoints[_currentPoint].transform.position) > 0.2f){
            _wait = 5f;
            if (Crab.Movement.Body.transform.position.x > Crab.PatrolPoints[_currentPoint].transform.position.x){
                Crab.Movement.SetDirection(-1f);
                _direction = -1f;
            }else{
                Crab.Movement.SetDirection(1f);
                _direction = 1f;
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

public class CrabIdle : IdleState{
    public override void EnterState(){
        Crab.StartCoroutine(EnterPatrolStateRoutine());
    }
    public override void LogicUpdate(){
        
    }
    public override void PhysicsUpdate(){

    }
    public override void ExitState(){

    }
    private IEnumerator EnterPatrolStateRoutine(){
        yield return new WaitForSeconds(1.5f);
        yield return null;
        Crab.ChangeState(Crab.CrabPatrol);
    }
}

//Chase
public class CrabRun : RunState{
    private Player _target;
    public override void EnterState(){
        Debug.Log("Chase State");
        _target = Crab.FindFirstObjectByType<Player>();
    }
    public override void LogicUpdate(){
        if (Vector3.Distance(Crab.transform.position, _target.transform.position) > 0.2f){
            Vector3.MoveTowards(Crab.transform.position, _target.transform.position, Crab.Movement.GetSpeed());
        }else{

        }
    }
    public override void PhysicsUpdate(){

    }
    public override void ExitState(){

    }
}

public class CrabJump : JumpState{
    public override void EnterState(){

    }
    public override void LogicUpdate(){

    }
    public override void PhysicsUpdate(){

    }
    public override void ExitState(){

    }
}