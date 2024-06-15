
public class PlayerIdle : IdleState {
    public override void EnterState(){
        Player.ChangeAnimation(Player.IDLE);
    }

    public override void LogicUpdate(){
        Player.HandleJump();
        if (Player.Inputs.Move.x != 0){
            Player.ChangeState(Player.RunState);
        }
    }

    public override string ToString(){
        return "Idle";
    }
}