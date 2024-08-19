using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM {
    public class Chill : State
    {
        public void UpdateState() {
        }

        public void OnExit() {
        }

        public void OnEnter() {
            _animalStateMachine.status.SetAnimation("Idle");
        }
    }
}
