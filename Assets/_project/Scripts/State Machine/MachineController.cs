using UnityEngine;

public abstract class MachineController : MonoBehaviour {
    public abstract void ChangeState(Abstract newState);
    public abstract void ChangeAnimation(int animationHash);
    public abstract void HandleMovement(float direction);
    public abstract void HandleJump();
}