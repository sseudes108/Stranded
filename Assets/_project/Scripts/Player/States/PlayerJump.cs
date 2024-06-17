
public class PlayerJump : JumpState {
    bool _canDoubleJump = true;
    public override void EnterState(){
        Player.ChangeAnimation(Player.JUMP);
    }

    public override void LogicUpdate(){
        Player.HandleMovement(Player.Inputs.Move.x);

        if (_canDoubleJump){
            if (Player.Inputs.Shot){
                Player.HandleShoot();
            }
        }

        if (Player.Inputs.Jump && _canDoubleJump){
            Player.Movement.StopJumpForce();
            Player.Jump();
            _canDoubleJump = false;
            Player.ChangeAnimation(Player.DOUBLEJUMP);
        }

        if (Player.IsGrounded() && Player.Movement.Body.velocity.y < 0.1f){
            if(Player.Inputs.Move.x == 0){
                Player.ChangeState(Player.IdleState);
            }else{
                Player.ChangeState(Player.RunState);
            }
        }
    }

    public override void ExitState(){
        _canDoubleJump = true;
    }

    public override string ToString(){
        return "Jump";
    }
}