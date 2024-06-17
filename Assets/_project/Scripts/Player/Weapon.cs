using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour {
    private ObjectPool<Bullet> _bulletPool;
    public Bullet _bulletPrefab;

    private ObjectPool<Bomb> _bombPool;
    public Bomb _bombPrefab;
    private void Awake() {
        CreateBulletPool();
        CreateBombPool();
    }

#region Bullet
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
#endregion

    public void DropBomb(){
        Bomb newBomb = _bombPool.Get();
        newBomb.Init(this);
    }

    private void CreateBombPool(){
        _bombPool = new ObjectPool<Bomb>(()=>{
            return Instantiate(_bombPrefab);
        }, bomb =>{
            bomb.gameObject.SetActive(true);
        }, bomb =>{
            bomb.gameObject.SetActive(false);
        }, bomb =>{
            Destroy(bomb);
        }, false, 20, 40){
        };
    }

    public void ReleaseBombFromPool(Bomb bomb){
        _bombPool.Release(bomb);
    }
}