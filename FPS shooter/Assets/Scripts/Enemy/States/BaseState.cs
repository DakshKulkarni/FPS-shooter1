public abstract class BaseState

{
    public Enemy enemy;
    public StateMachines stateMachine;
    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();
}