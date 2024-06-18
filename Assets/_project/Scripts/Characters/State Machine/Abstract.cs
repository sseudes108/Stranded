public abstract class Abstract{
    public MachineController Controller {get; private set;}
    protected Player Player;
    protected Crab Crab;

    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void LogicUpdate();
    public abstract void PhysicsUpdate();

    public void SetController(MachineController controller){
        switch(controller){
            case Player playerController:
                Player = playerController;
                Controller = Player;
            break;
            case Crab crabController:
                Crab = crabController;
                Controller = Crab;
            break;
        }
    }
}