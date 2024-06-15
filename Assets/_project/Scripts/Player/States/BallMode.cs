
public class BallMode : Abstract{
    public override void EnterState(){
        Player.ChangeAnimation(Player.BALLMODE);
    }

    public override void ExitState(){
        
    }

    public override void LogicUpdate(){
        Player.HandleChangeMode();
    }

    public override void PhysicsUpdate(){
        
    }
}