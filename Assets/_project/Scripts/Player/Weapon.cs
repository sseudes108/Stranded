using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour {
    private ObjectPool<Bullet> _bulletPool;
    public Bullet _bulletPrefab;
    private void Awake() {
        CreateBulletPool();
    }

    public void Shoot(float direction, Vector2 firePoint){
        Bullet newBullet = _bulletPool.Get();
        newBullet.Init(direction, firePoint, this);
    }

    private void CreateBulletPool(){
        _bulletPool = new ObjectPool<Bullet>(()=>{
            return Instantiate(_bulletPrefab);
        }, bullet =>{
            bullet.gameObject.SetActive(true);
        }, bullet =>{
            bullet.gameObject.SetActive(false);
        }, bullet =>{
            Destroy(bullet);
        }, false, 20, 40){
        };
    }

    public void ReleaseBulletFromPool(Bullet bullet){
        _bulletPool.Release(bullet);
    }
}