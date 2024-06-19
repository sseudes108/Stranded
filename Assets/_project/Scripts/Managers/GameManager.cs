using UnityEngine;
using UnityEngine.Pool;

public class GameManager : MonoBehaviour {
    public static GameManager Instance {get; private set;}
    public VFXManager VFXManager {get; private set;}
    
    private void Awake() {
        SetInstance();
        SetManagers();
    }

    public ObjectPool<T> CreatePool<T>(T prefab) where T : MonoBehaviour{
        ObjectPool<T> objectPool = new(()=>{
            return Instantiate(prefab);
        }, newObject =>{
            newObject.gameObject.SetActive(true);
        }, newObject =>{
            newObject.gameObject.SetActive(false);
        }, newObject =>{
            Destroy(newObject);
        }, false, 20, 40){
        };
        return objectPool;
    }

    private void SetInstance(){
        if (Instance != null){
            Debug.LogError("More than one instance of GameManager.cs");
        }
        Instance = this;
    }
    
    private void SetManagers(){
        VFXManager = GetComponent<VFXManager>();
    }
}