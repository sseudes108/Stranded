using System.Collections;
using UnityEngine;

public class PlayerStandShoot : Abstract{
    private IEnumerator _routine;
    public override void EnterState(){
        if(_routine != null){
            Player.StopCoroutine(_routine);
        }
        _routine = ExitStandShoot();
        Player.StartCoroutine(_routine);
    }

    public override void ExitState(){

    }

    public override void LogicUpdate(){

    }

    public override void PhysicsUpdate(){

    }

    private IEnumerator ExitStandShoot(){
        Player.ChangeAnimation(Player.STAND_SHOOT );
        yield return new WaitForSeconds(0.5f);

        if (Player.Inputs.Shot){
            Player.ChangeState(Player.StandShoot);
        }
        
        yield return null;
    }

    public override string ToString(){
        return "Stand Shoot";
    }
}