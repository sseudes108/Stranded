using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour {
    private ObjectPool<Bullet> _bulletPool;
    [SerializeField] private Bullet _bulletPrefab;

    private ObjectPool<Bomb> _bombPool;
    [SerializeField] private Bomb _bombPrefab;

    private void Awake() {
        _bulletPool = GameManager.Instance.CreatePool(_bulletPrefab);
        _bombPool = GameManager.Instance.CreatePool(_bombPrefab);
    }

    public void ReleaseFromWeaponPool(MonoBehaviour obj){
        if (obj is Bullet){
            _bulletPool.Release(obj as Bullet);
            return;
        }

        if (obj is Bomb){
            _bombPool.Release(obj as Bomb);
            return;
        }
    }

    public void Shoot(float direction, Vector2 firePoint){
        Bullet newBullet = _bulletPool.Get();
        newBullet.Init(direction, firePoint, this);
    }

    public void DropBomb(Vector2 firePoint){
        Bomb newBomb = _bombPool.Get();
        newBomb.Init(firePoint, this);
    }
}