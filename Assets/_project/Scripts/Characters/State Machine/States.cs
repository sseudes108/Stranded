public class IdleState : Abstract{
    public override void EnterState(){}
    public override void ExitState(){}
    public override void LogicUpdate(){}
    public override void PhysicsUpdate(){}
}
public class RunState: Abstract{
    public override void EnterState(){}
    public override void ExitState(){}
    public override void LogicUpdate(){}
    public override void PhysicsUpdate(){}
}
public class JumpState: Abstract{
    public override void EnterState(){}
    public override void ExitState(){}
    public override void LogicUpdate(){}
    public override void PhysicsUpdate(){}
}
public class HurtState: Abstract{
    public override void EnterState(){}
    public override void ExitState(){}
    public override void LogicUpdate(){}
    public override void PhysicsUpdate(){}
}

public struct StatesData{
    public IdleState Idle;
    public RunState Run;
    public JumpState Jump;
    public HurtState Hurt;
}