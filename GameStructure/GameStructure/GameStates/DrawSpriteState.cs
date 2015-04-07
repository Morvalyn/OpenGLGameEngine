using System;
using OpenTK.Graphics.OpenGL;
using GameStructure.Interfaces;

namespace GameStructure.GameStates
{
    public class DrawSpriteState : IGameObject
    {
        public void Update(double elapsedTime)
        {
            //throw new NotImplementedException();
        }

        public void Render()
        {
            double x = 0; 
            double y = 0; 
            double z = 0;


            double height = 200; 
            double width = 200; 
            double halfHeight = height / 2; 
            double halfWidth = width / 2;

            
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit); 
            GL.Begin(PrimitiveType.Triangles); 
            {
                GL.Vertex3(x-halfWidth, y+halfHeight, z); // top left 
                GL.Vertex3(x+halfWidth, y+halfHeight, z); // top right 
                GL.Vertex3(x-halfWidth, y-halfHeight, z); // bottom left


                GL.Vertex3(x+halfWidth, y+halfHeight, z); // top right 
                GL.Vertex3(x+halfWidth, y-halfHeight, z); // bottom right 
                GL.Vertex3(x-halfWidth, y-halfHeight, z); // bottom left

            } 
            GL.End();

        }
    }
}
