
public class PlayerJump : JumpState {
    public override void EnterState(){
        Player.ChangeAnimation(Player.JUMP);
    }

    public override void LogicUpdate(){
        if (Player.IsGrounded() && Player.Movement.Body.velocity.y < 0.05f){
            Player.ChangeState(Player.IdleState);
        }
    }

    public override string ToString(){
        return "Jump";
    }
}