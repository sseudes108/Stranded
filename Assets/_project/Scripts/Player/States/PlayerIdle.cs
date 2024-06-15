using UnityEngine;

public class PlayerIdle : IdleState {
    public override void EnterState(){
        Player.Animation.ChangeAnimation(Player.IDLE);
    }

    public override void LogicUpdate(){
        if (Player.Inputs.Move.x != 0){
            Player.StateMachine.ChangeState(Player.RunState);
        }
    }
}