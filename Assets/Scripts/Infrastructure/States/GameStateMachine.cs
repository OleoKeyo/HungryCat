﻿using System;
using System.Collections.Generic;
using AlchemyCat.Infrastructure.Factory;
using AlchemyCat.Infrastructure.SceneManagement;
using Infrastructure.Services.AllServices;

namespace AlchemyCat.Infrastructure.States
{
  public class GameStateMachine : IGameStateMachine
  {
    private readonly Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;

    public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain curtain, ServiceContainer services)
    {
      _states = new Dictionary<Type, IExitableState>
      {
        [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
        [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, curtain,
          services.Resolve<IGameFactory>()),
        [typeof(GameLoopState)] = new GameLoopState(this)
      };
    }
    
    public void Enter<TState>() where TState : class, IState
    {
      IState state = ChangeState<TState>();
      state.Enter();
    }
    
    private TState ChangeState<TState>() where TState : class, IExitableState
    {
      _activeState?.Exit();
      
      TState state = GetState<TState>();
      _activeState = state;
      
      return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState => 
      _states[typeof(TState)] as TState;

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
    {
      IPayloadedState<TPayload> state = ChangeState<TState>();
      state.Enter(payload);
    }
  }
}