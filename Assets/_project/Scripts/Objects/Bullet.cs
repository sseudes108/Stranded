using UnityEngine;

public class Bullet : MonoBehaviour{
    private Movement _movement;
    private Weapon _gun;
    public Transform _bulletImpact;

    private void Awake() {
        _movement = GetComponent<Movement>();
    }

    public void Init(float direction, Vector2 firePoint, Weapon gun){
        _movement.SetDirection(direction);
        transform.position = firePoint;
        _gun = gun;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Instantiate(_bulletImpact, transform.position, Quaternion.identity);
        _gun.ReleaseBulletFromPool(this);
    }
}
