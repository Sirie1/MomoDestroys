using UnityEngine;

public abstract class DogBaseState: MonoBehaviour
{
    public abstract void EnterState(DogStateController dog);

    public abstract void ExitState(DogStateController dog);
    public abstract void UpdateState(DogStateController dog);

    public abstract void FixedUpdateState(DogStateController dog);
}
