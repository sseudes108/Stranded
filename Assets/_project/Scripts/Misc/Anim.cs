using UnityEngine;

public class Anim : MonoBehaviour {
    private Animator _animator;

    private void Awake() {
        _animator = GetComponentInChildren<Animator>();
    }

    public void ChangeAnimation(int AnimationHash){
        _animator.StopPlayback();
        _animator.Play(AnimationHash);
    }
}