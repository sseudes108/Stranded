using UnityEngine;

public class Bullet : MonoBehaviour{
    private Movement _movement;
    private Weapon _gun;

    private void Awake() {
        _movement = GetComponent<Movement>();
    }

    public void Init(float direction, Vector2 firePoint, Weapon gun){
        _movement.SetDirection(direction);
        transform.position = firePoint;
        _gun = gun;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameManager.Instance.VFXManager.InstantiateImpactVFX(transform.position);
        _gun.ReleaseFromWeaponPool(this);
    }
}
