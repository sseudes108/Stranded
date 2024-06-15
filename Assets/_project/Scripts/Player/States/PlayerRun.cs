using UnityEngine;

public class PlayerRun : RunState {
    public override void EnterState(){
        Player.Animation.ChangeAnimation(Player.RUN);
    }

    public override void LogicUpdate(){
        if (Player.Inputs.Move.x == 0){
            Player.StateMachine.ChangeState(Player.IdleState);
        }
    }
}