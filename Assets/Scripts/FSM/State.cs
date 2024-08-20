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
        if (status.feedingStrategy == FeedingStrategy.grazer) {
            Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(status.transform.position, (float)status.visionRange);
            foreach (Collider2D collider in objectsInRange) {
                Status objectStatus = collider.gameObject.GetComponent<Status>();
                if (objectStatus != null) {
                    if (objectStatus.prey.Contains(status.animal)) {
                        sc.ChangeState(new Flee());
                    }
                }
            }
        }

        UpdateState();
    }

    protected virtual void UpdateState() {
    }

    public virtual void OnExit() {
    }
}
