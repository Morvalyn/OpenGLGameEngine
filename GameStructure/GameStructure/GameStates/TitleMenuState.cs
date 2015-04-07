using System;
using OpenTK.Graphics.OpenGL;
using GameStructure.Interfaces;

namespace GameStructure.GameStates
{
    public class TitleMenuState : IGameObject
    {
        double _currentRotation = 0;

        #region IGameObjects
        public void Update(double elapsedTime)
        {
            _currentRotation = 10 * elapsedTime;
        }

        public void Render()
        {
           GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f); 
           GL.Clear(ClearBufferMask.ColorBufferBit); 
           GL.PointSize(5.0f);
           GL.Rotate(_currentRotation, 0, 1, 0); 
           GL.Begin(PrimitiveType.TriangleStrip);
           {
               GL.Color4(1.0, 0.0, 0.0, 0.5); 
               GL.Vertex3(-50, 0, 0);
               GL.Color3(0.0, 1.0, 0.0);
               GL.Vertex3(50, 0, 0);
               GL.Color3(0.0, 0.0, 1.0);
               GL.Vertex3(0, 50, 0);

            } 
            GL.End();
            GL.Finish();
        }
        #endregion
    }
}
