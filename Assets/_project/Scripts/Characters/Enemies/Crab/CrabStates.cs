using System.Collections;
using UnityEngine;

public class CrabPatrol : Abstract{
    public override void EnterState(){

    }

    public override void LogicUpdate(){

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
    public override void EnterState(){

    }
    public override void LogicUpdate(){

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