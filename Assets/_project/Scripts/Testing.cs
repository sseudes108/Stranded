using TMPro;
using UnityEngine;

public class Testing : MonoBehaviour{

    public static Testing Instance {get; private set;}

    [SerializeField] private TextMeshProUGUI _state;
    [SerializeField] private TextMeshProUGUI _grounded;

    private void Awake() {
        if (Instance != null){
            Debug.LogError("More Than One Instance of Testing.cs");
            Destroy(Instance);
        }
        Instance = this;
    }

    public void UpdateState(Abstract state){
        _state.text = $"State: {state}";
    }

    public void UpdateGrounded(bool grounded){
        _grounded.text = $"Grounded: {grounded}";
    }
}
