using System;
using OpenTK.Graphics.OpenGL;
using Tao.DevIl;
using GameLibrary;
using System.Windows.Forms;
using GameStructure.GameStates;
using System.Drawing;


namespace GameStructure
{
    public partial class Form1 : Form
    {
        SystemState _system = new SystemState();
        bool _fullscreen = false;
       
        
        public Form1()
        {
            //Initialize DeviL
            Il.ilInit();
            Ilu.iluInit();
            Ilut.ilutInit();
            Ilut.ilutRenderer(Ilut.ILUT_OPENGL);

            FastLoop _fastLoop = new FastLoop(GameLoop);
            InitializeComponent();
            if (_fullscreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                ClientSize = new Size(1280, 720);
            }

            // Add all the states that will be used. 
            _system.AddState("splash", new SplashScreenState(_system)); 
            _system.AddState("title_menu", new TitleMenuState());
            _system.AddState("sprite_test", new DrawSpriteState());

            // Select the start state 
            _system.ChangeState("sprite_test");
            
        }

        #region Custom Functions

        void GameLoop(double elapsedTime)
        {           
            _system.Update(elapsedTime);
            _system.Render();
            glControl1.SwapBuffers();
            glControl1.Refresh();
        }

        private void Graphics2DSetup(double width, double height)
        {
            double halfWidth = width / 2;
            double halfHeight = height / 2;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-halfWidth, halfWidth, -halfHeight, halfHeight, -100, 100);
            GL.MatrixMode(MatrixMode.Modelview); 
            GL.LoadIdentity();

        }

        #endregion

        #region Event Triggers
        private void OnGraphicsLoad(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            Graphics2DSetup(this.ClientSize.Width, this.ClientSize.Height);
        }
        #endregion
    }

   
}
