using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour{
    private Weapon _gun;
    public Transform _explosion;

    public void Init(Weapon gun){
        _gun = gun;
    }

    private void Start() {
        StartCoroutine(StartCountExplosion());
    }

    private IEnumerator StartCountExplosion(){
        yield return new WaitForSeconds(1f);
        Explode();
        yield return null;
    }

    private void Explode(){
        Instantiate(_explosion, transform.position, Quaternion.identity);
        _gun.ReleaseBombFromPool(this);
    }
}