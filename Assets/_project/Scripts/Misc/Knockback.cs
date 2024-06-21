using System.Collections;
using UnityEngine;

public class Knockback : MonoBehaviour {
    [SerializeField] private float _knockbackForce;
    private Movement _movement;

    private void Awake() {
        _movement = GetComponent<Movement>();
    }

    public void ApplyKnockBackForce(MachineController character, Vector2 hitDirection){
        Debug.Log("ApplyKnockBackForce()");
        Vector3 difference = _knockbackForce * _movement.Body.mass * (character.Movement.Body.position - hitDirection).normalized;

        character.Movement.Body.AddForce(difference, ForceMode2D.Impulse);
        character.ChangeState(character.StateMachine.HurtState);
    }
}