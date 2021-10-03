namespace Infrastructure.States
{
  public interface IState : IExitableState
  {
    void Enter();
  }

  public interface IPayloadedState<TPayload> : IExitableState
  {
    void Enter(TPayload levelName);
  }

  public interface IExitableState
  {
    void Exit();
  }
}