using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TentaPlane.PlaneContent
{
    public abstract class PlaneParts : IPlane
    {
        protected GraphicsDevice GraphicsDevice;
        protected VertexBuffer VertexBuffer;

        protected Matrix World = Matrix.Identity;
        private Color partColor;

        private float pointX = 1f;
        private float pointY = 1f;
        private float pointZ = 1f;

        public PlaneParts(GraphicsDevice graphics)
        {
            GraphicsDevice = graphics;

            Initialize();
        }

        public PlaneParts(GraphicsDevice graphics, float pointX, float pointY, float pointZ, Color partColor)
        {
            GraphicsDevice = graphics;

            this.pointX = pointX;
            this.pointY = pointY;
            this.pointZ = pointZ;

            this.partColor = partColor;

            Initialize();
        }

        private void Initialize()
        {
            VertexPositionColor[] vertices = new VertexPositionColor[3];

            Vector3 topLeft = new Vector3(-pointX, pointY, pointZ);
            Vector3 bottomLeft = new Vector3(-pointX, -pointY, pointZ);
            Vector3 bottomRight = new Vector3(pointX, pointY, pointZ);

            vertices[0] = new VertexPositionColor(topLeft, partColor);
            vertices[1] = new VertexPositionColor(bottomLeft, partColor);
            vertices[2] = new VertexPositionColor(bottomRight, partColor);

            VertexBuffer = new VertexBuffer(GraphicsDevice, VertexPositionColor.VertexDeclaration, 3, BufferUsage.WriteOnly);
            VertexBuffer.SetData(vertices);
        }

        public virtual void UpdatePlanePart(GameTime gameTime, float speed) { }
        public virtual void DrawPlanePart(BasicEffect effect, Matrix world) { }
    }
}
