
using UnityEngine;

public class BallMode : Abstract{
    float _changeCounterMode = 0.5f;
    public override void EnterState(){
        Player.StandForm.gameObject.SetActive(false);
        Player.BallForm.gameObject.SetActive(true);

        Player.ChangeAnimation(Player.BALLMODE);
    }

    public override void LogicUpdate(){
        Player.HandleJump();
        Player.HandleMovement(Player.Inputs.Move.x);

        if (Player.Inputs.Shot){
            Player.Weapon.DropBomb();
        }

        if (Player.IsGrounded()){
            if (Player.Inputs.Move.y == 1){
                _changeCounterMode -= Time.deltaTime;
                if (_changeCounterMode <= 0){
                    Player.ChangeState(Player.IdleState);
                }
            }else{
                _changeCounterMode = 0.5f;
            }
        }

        if (Player.Inputs.Move.x != 0){
            if (Player.Animation.CurrentAnimation == Player.BALLMODE_MOVE){
                return;
            }
            Player.ChangeAnimation(Player.BALLMODE_MOVE);
        }else{
            if (Player.Animation.CurrentAnimation == Player.BALLMODE){
                return;
            }
            Player.ChangeAnimation(Player.BALLMODE);
        }
    }

    public override void PhysicsUpdate(){
        
    }

    public override void ExitState(){
        Player.BallForm.gameObject.SetActive(false);
        Player.StandForm.gameObject.SetActive(true);
    }
}