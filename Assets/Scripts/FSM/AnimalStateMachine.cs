using UnityEngine;

public class AnimalStateMachine : MonoBehaviour
{
    [SerializeField] Status status;
    MapManager mapManager;
    State currentState;

    void Awake() {
        mapManager = FindObjectOfType<MapManager>();
        ChangeState(new Chill());
    }

    void Update() {
        currentState.UpdateState();
    }

    public void ChangeState(State newState) {
        if (currentState != null) currentState.OnExit();
        currentState = newState;
        currentState.OnStateEnter(this, mapManager, status);
    }
}
