public class PlayerRun : RunState {
    public override void EnterState(){
        Player.ChangeAnimation(Player.RUN);
    }

    public override void LogicUpdate(){
        Player.HandleJump();

        if (!Player.IsGrounded()){
            Player.ChangeState(Player.JumpState);
        }

        if (Player.Inputs.Shot){
            Player.ChangeAnimation(Player.RUN_SHOOT);
        }

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