using UnityEngine;

public class Anim : MonoBehaviour {
    private Animator _animator;
    public SpriteRenderer Renderer {get; private set;}
    public int CurrentAnimation {get; private set;}

    private void Awake() {
        _animator = GetComponentInChildren<Animator>();
        Renderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void ChangeAnimation(int AnimationHash){
        _animator.StopPlayback();
        _animator.Play(AnimationHash);
        CurrentAnimation = AnimationHash;
    }
}