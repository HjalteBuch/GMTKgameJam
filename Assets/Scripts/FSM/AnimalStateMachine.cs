using UnityEngine;

namespace FSM {
    public class AnimalStateMachine : MonoBehaviour
    {
        [SerializeField] private State _initialState;
        [SerializeField] public Status status;

        public MapManager mapManager;
        public State CurrentState { get; set; }

        void Awake() {
            mapManager = FindObjectOfType<MapManager>();

            CurrentState = _initialState;
            CurrentState.SetAnimalStatemachine(this);
        }

        void Update() {
            CurrentState.UpdateState();
        }

        public void ChangeState(State newState) {
            CurrentState.OnExit();
            CurrentState = newState;
            CurrentState.SetAnimalStatemachine(this);
            CurrentState.OnEnter();
        }
    }
}
