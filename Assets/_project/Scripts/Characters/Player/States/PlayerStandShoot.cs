
using UnityEngine;

public class PlayerStandShoot : Abstract{

    private float _wait;

    public override void EnterState(){
        Player.ChangeAnimation(Player.STAND_SHOOT);
        Player.HandleShoot();
        _wait = 0.5f;
    }

    public override void ExitState(){

    }

    public override void LogicUpdate(){
        HandleShot();
        Player.HandleJump();

        if (Player.Inputs.Move.x != 0){
            Player.ChangeState(Player.RunState);
        }
    }

    public override void PhysicsUpdate(){

    }

    private void HandleShot(){
        _wait -= Time.deltaTime;

        if (Player.Inputs.Shot){
            Player.HandleShoot();
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