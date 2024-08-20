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

    public void OnUpdateState() {
        if (status.feedingStrategy == FeedingStrategy.predetor) {
            Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(status.gameObject.transform.position, status.visionRange);
            Debug.Log("Looking for objects in range");
            foreach (Collider2D collider in objectsInRange) {
                Debug.Log("A wild " + status.name + " appeared!");
            }
        }

        UpdateState();
    }

    protected virtual void UpdateState() {
    }

    public virtual void OnExit() {
    }
}
