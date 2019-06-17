/// <summary>
/// States for filling up state machine for character class <typeparamref name="T"/>
/// </summary>
/// <typeparam name="T">Class for which the state is being created</typeparam>
public abstract class State<T>
{
  /// <summary>
  /// Constructor taking a state machine as a parameter to know which machine
  /// it belongs to
  /// </summary>
  /// <param name="stateMachine">Machine the state will belong to</param>
  public State(StateMachine<T> stateMachine)
  {
    m_StateMachine = stateMachine;
  }

  /// <summary>
  /// Used to declare actions that will take place when the state is entered
  /// </summary>
  /// <param name="character"></param>
  public virtual void OnStateEnter(T character) { }

  /// <summary>
  /// Used to check if it is necessary to change state before updating game logic
  /// </summary>
  /// <param name="character"></param>
  public abstract void OnStatePreUpdate(T character);

  /// <summary>
  /// Logic update specific to this state
  /// </summary>
  /// <param name="character"></param>
  public abstract void OnStateUpdate(T character);

  /// <summary>
  /// Used to declare actions that will take place before exiting this state
  /// </summary>
  /// <param name="character"></param>
  public virtual void OnStateExit(T character) { }

  /// <summary>
  /// State machine this state belongs to
  /// </summary>
  protected readonly StateMachine<T> m_StateMachine;
}
