using UnityEngine;

public class PlayerIdle : IdleState {
    float _changeCounterMode = 0.5f;

    public override void EnterState(){
        if (Player.BallForm.gameObject.activeSelf){
            Player.BallForm.gameObject.SetActive(false);
            Player.StandForm.gameObject.SetActive(true);
        }

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