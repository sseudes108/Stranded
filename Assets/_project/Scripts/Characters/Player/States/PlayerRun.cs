using UnityEngine;

public class PlayerRun : RunState {
    private float _wait;

    public override void EnterState(){
        Player.ChangeAnimation(Player.RUN);
        _wait = 0.5f;
    }

    public override void LogicUpdate(){
        Player.HandleJump();

        if (!Player.IsGrounded()){
            Player.ChangeState(Player.JumpState);
        }

        HandleShot();

        if (Player.Inputs.Move.x != 0){
            Player.HandleMovement(Player.Inputs.Move.x);
        }
        else{
            Player.ChangeState(Player.IdleState);
        }
    }

    private void HandleShot(){
        _wait -= Time.deltaTime;

        if (Player.Inputs.Shot){
            Player.HandleShoot();
            Player.ChangeAnimation(Player.RUN_SHOOT);
            _wait = 0.5f;
        }

        if (_wait <= 0){
            Player.ChangeAnimation(Player.RUN);
        }
    }

    public override void ExitState(){
        Player.HandleMovement(0);
    }

    public override string ToString(){
        return "Run";
    }
}