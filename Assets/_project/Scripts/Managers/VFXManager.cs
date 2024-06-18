using UnityEngine;

public class VFXManager : MonoBehaviour {
    [SerializeField] private Transform _bulletImpact;
    [SerializeField] private Transform _explosion;

    public void InstantiateImpactVFX(Vector2 position){
        Instantiate(_bulletImpact, position, Quaternion.identity);
    }

    public void InstantiateExplosionVFX(Vector2 position){
        Instantiate(_explosion, position, Quaternion.identity);
    }
}