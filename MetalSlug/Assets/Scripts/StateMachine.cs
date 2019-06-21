using System;

/// <summary>
/// State machine for character class <typeparamref name="T"/>
/// </summary>
/// <typeparam name="T"></typeparam>
public class StateMachine<T>
{
  /// <summary>
  /// Initializes State Machine with <paramref name="initialState"/>
  /// </summary>
  /// <param name="initialState"></param>
  public void Init(State<T> initialState, T character)
  {
    m_CurrentState = m_LastState = initialState;
    m_CurrentState.OnStateEnter(character);
  }

  /// <summary>
  /// Updates <paramref name="character"/> using current state logic
  /// </summary>
  /// <param name="character"></param>
  public void OnState(T character)
  {
    m_CurrentState.OnStatePreUpdate(character);
    m_CurrentState.OnStateUpdate(character);
  }

  /// <summary>
  /// Sets current state to <paramref name="nextState"/> and last state to
  /// current state
  /// </summary>
  /// <param name="nextState"></param>
  /// <param name="character"></param>
  public void ToState(State<T> nextState, T character)
  {
    m_CurrentState.OnStateExit(character);

    m_LastState = m_CurrentState;
    m_CurrentState = nextState;

    m_CurrentState.OnStateEnter(character);
  }

  /// <summary>
  /// State Machine's current state
  /// </summary>
  private State<T> m_CurrentState;

  /// <summary>
  /// State Machine's last state
  /// </summary>
  private State<T> m_LastState;

  /// <summary>
  /// 
  /// </summary>
  public State<T> CurrentState { get { return m_CurrentState; } }

  /// <summary>
  /// 
  /// </summary>
  public State<T> LastState { get { return m_LastState; } }
}
