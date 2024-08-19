using UnityEngine;

namespace FSM {
    public abstract class State : ScriptableObject
    {
        protected AnimalStateMachine _animalStateMachine;

        public void SetAnimalStatemachine(AnimalStateMachine animalStateMachine) {
            _animalStateMachine = animalStateMachine;
        }


        public void UpdateState() {
        }

        public void OnExit() {
        }

        public void OnEnter() {
        }
    }
}
