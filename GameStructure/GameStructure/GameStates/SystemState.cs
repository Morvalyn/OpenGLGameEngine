using System;
using GameStructure.Interfaces;
using System.Collections.Generic;

namespace GameStructure.GameStates
{
    public class SystemState : IGameObject
    {
        Dictionary<string, IGameObject> _stateStore = new Dictionary<string, IGameObject>(); 
        IGameObject _currentState = null;

        #region IGameObjects
        public void Update(double elapsedTime)
        {
           if (_currentState == null) 
           { 
               return; // nothing to update 
           } 
            _currentState.Update(elapsedTime); 
        }

        public void Render()
        {
            if (_currentState == null)
            {
                return; // nothing to render
            } 
            _currentState.Render(); 
        }
        #endregion
        
        public void AddState(string stateId, IGameObject state)
        {
            System.Diagnostics.Debug.Assert(Exists(stateId) == false); 
            _stateStore.Add(stateId, state);
        }

        public void ChangeState(string stateId) 
        { 
            System.Diagnostics.Debug.Assert(Exists(stateId)); 
            _currentState = _stateStore[stateId]; 
        }

        public bool Exists(string stateId) 
        { 
            return _stateStore.ContainsKey(stateId); 
        }

    }
}
