using UnityEngine;

public abstract class State
{
    protected AnimalStateMachine sc;
    protected MapManager mm;
    protected Status status;


    public void OnStateEnter(AnimalStateMachine animalStateMachine, MapManager mapManager, Status animalStatus) {
        sc = animalStateMachine;
        mm = mapManager;
        status = animalStatus;
        OnEnter();
    }

    protected virtual void OnEnter() {
    }

    public virtual void UpdateState() {
    }

    public virtual void OnExit() {
    }

}
