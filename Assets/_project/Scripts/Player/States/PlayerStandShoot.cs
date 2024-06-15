
using UnityEngine;

public class PlayerStandShoot : Abstract{

    private float _wait;

    public override void EnterState(){
        Player.ChangeAnimation(Player.STAND_SHOOT);
        _wait = 0.5f;
    }

    public override void ExitState(){

    }

    public override void LogicUpdate(){
        HandleShot();
    }

    public override void PhysicsUpdate(){

    }

    private void HandleShot(){
        _wait -= Time.deltaTime;

        if (Player.Inputs.Shot){
            _wait = 0.5f;
        }

        if (_wait <= 0){
            Player.ChangeState(Player.IdleState);
        }
    }

    public override string ToString(){
        return "Stand Shoot";
    }
}