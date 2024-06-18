using UnityEngine;

public class PlayerIdle : IdleState {
    float _changeCounterMode = 0.5f;

    public override void EnterState(){
        Player.ChangeAnimation(Player.IDLE);
    }

    public override void LogicUpdate(){
        Player.HandleJump();
        
        if (Player.Inputs.Move.x != 0){
            Player.ChangeState(Player.RunState);
        }

        if (Player.Inputs.Shot){
            Player.ChangeState(Player.StandShoot);
        }

        if (Player.Inputs.Crouch){
            Player.ChangeState(Player.DuckState);
        }
        
        if (Player.Inputs.Move.y == -1){
            _changeCounterMode -= Time.deltaTime;
            if (_changeCounterMode <= 0){
                Player.ChangeState(Player.BallMode);
            }
        }else{
            _changeCounterMode = 0.5f;
        }
    }

    public override string ToString(){
        return "Idle";
    }
}