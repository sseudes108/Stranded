
public class PlayerIdle : IdleState {
    public override void EnterState(){
        Player.ChangeAnimation(Player.IDLE);
    }

    public override void LogicUpdate(){
        Player.HandleJump();
        Player.HandleChangeMode();
        
        if (Player.Inputs.Move.x != 0){
            Player.ChangeState(Player.RunState);
        }

        if (Player.Inputs.Shot){
            Player.ChangeState(Player.StandShoot);
        }
    }

    public override string ToString(){
        return "Idle";
    }
}