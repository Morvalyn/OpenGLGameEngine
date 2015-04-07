using System;
using OpenTK.Graphics.OpenGL;
using GameStructure.Interfaces;
using GameStructure.GameStates;

namespace GameStructure.GameStates
{
    public class SplashScreenState : IGameObject
    {
        SystemState _state = new SystemState();
        double _delayInSeconds = 3;

        public SplashScreenState(SystemState state)
        {
            _state = state;
        }
        #region IGameObjects
        public void Update(double elapsedTime)
        {
            _delayInSeconds -= elapsedTime;
            if (_delayInSeconds <= 0)
            {
                _delayInSeconds = 3;
                _state.ChangeState("title_menu");
            }
        }

        public void Render()
        {
            GL.ClearColor(1, 1, 1, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Finish();
        }
        #endregion
    }
}
