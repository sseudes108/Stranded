using UnityEngine;

public class PlayerRun : RunState {
    public override void EnterState(){
        Player.ChangeAnimation(Player.RUN);
    }

    public override void LogicUpdate(){
        if (Player.Inputs.Move.x != 0){
            Player.HandleMovement(Player.Inputs.Move.x);
        }else{
            Player.ChangeState(Player.IdleState);
        }
    }

    public override void ExitState(){
        Player.HandleMovement(0);
    }

    public override string ToString(){
        return "Run";
    }
}