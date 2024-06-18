using UnityEngine;

public abstract class Abstract{
    public MachineController Controller {get; private set;}
    protected Player Player;

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
        }
    }
}