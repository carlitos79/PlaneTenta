using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TentaPlane.PlaneContent;

namespace TentaPlane
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        PlaneBody planeBody;
        BasicEffect effect;
        float speed = 0f;
        Box[] boxes;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            GraphicsDevice.RasterizerState = RasterizerState.CullNone;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            CreateBoxes();

            planeBody = new PlaneBody(GraphicsDevice);
            effect = new BasicEffect(GraphicsDevice);
            effect.VertexColorEnabled = true;

            effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, GraphicsDevice.Viewport.AspectRatio, 0.01f, 1000f);
            effect.View = Matrix.CreateLookAt(new Vector3(0f, 0f, 15f), new Vector3(0, 0, 0), Vector3.Up);
        }

        private void CreateBoxes()
        {
            boxes = new Box[100];
            for (int i = 0; i < 100; ++i)
                boxes[i] = new Box(new Vector3(-100 + i * 5, 0, 0), Color.Yellow, GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.A))
                speed += 0.0009f;

            if (Keyboard.GetState().IsKeyDown(Keys.Z))
                speed -= 0.0009f;

            planeBody.UpdatePlanePart(gameTime, speed);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (var b in boxes)
                b.Draw(effect, Matrix.Identity);
            planeBody.DrawPlanePart(effect, Matrix.Identity);

            base.Draw(gameTime);
        }
    }
}
