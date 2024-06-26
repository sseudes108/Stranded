using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour{
    public FrameInput Input => _frameInput;
    private FrameInput _frameInput;

    private InputSystem_Actions _inputSystem;
    private InputAction _move, _jump, _shot, _crouch;

    private bool _allowInputs = true;

    private void OnEnable() {
        _inputSystem.Enable();
    }
    private void OnDisable(){
        _inputSystem.Disable();
    }

    private void Awake() {
        _inputSystem = new();
        _move = _inputSystem.Player.Move;
        _jump = _inputSystem.Player.Jump;
        _shot = _inputSystem.Player.Attack;
        _crouch = _inputSystem.Player.Crouch;
    }

    private void Update() {
        if(!_allowInputs){return;}
        _frameInput = GatherInput();
    }

    private FrameInput GatherInput(){
        return new FrameInput{
            Move = _move.ReadValue<Vector2>(),
            Jump = _jump.WasPressedThisFrame(),
            Shot = _shot.WasPressedThisFrame(),
            Crouch = _crouch.IsPressed(),
        };
    }

    public void AllowInputs(bool allowInputs){
        _allowInputs = allowInputs;
    }

}

[System.Serializable]
public struct FrameInput{
    public Vector2 Move;
    public bool Jump;
    public bool Shot;
    public bool Crouch;
}
