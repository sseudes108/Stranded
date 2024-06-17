using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour{
    private Weapon _gun;

    public void Init(Vector2 position, Weapon gun){
        transform.position = position;
        _gun = gun;

        StartCoroutine(ExplosionRoutine());
    }

    private IEnumerator ExplosionRoutine(){
        yield return new WaitForSeconds(1f);
        Explode();
        yield return null;
    }

    private void Explode(){
        GameManager.Instance.VFXManager.InstantiateExplosionVFX(transform.position);
        _gun.ReleaseFromWeaponPool(this);
    }
}