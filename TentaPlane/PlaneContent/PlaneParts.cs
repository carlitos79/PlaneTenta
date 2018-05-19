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

        private Vector3 point1;
        private Vector3 point2;
        private Vector3 point3;

        

        public PlaneParts(GraphicsDevice graphics)
        {
            GraphicsDevice = graphics;

            Initialize();
        }

        public PlaneParts(GraphicsDevice graphics, Vector3 p1, Vector3 p2, Vector3 p3, Color partColor)
        {
            GraphicsDevice = graphics;

            point1 = p1;
            point2 = p2;
            point3 = p3;

            this.partColor = partColor;

            Initialize();
        }

        private void Initialize()
        {
            VertexPositionColor[] vertices = new VertexPositionColor[3];

            //Vector3 topLeft = new Vector3(-pointX, pointY, pointZ);
            //Vector3 bottomLeft = new Vector3(0, -pointY, pointZ);
            //Vector3 bottomRight = new Vector3(pointX, pointY, pointZ);

            vertices[0] = new VertexPositionColor(point1, partColor);
            vertices[1] = new VertexPositionColor(point2, partColor);
            vertices[2] = new VertexPositionColor(point3, partColor);

            VertexBuffer = new VertexBuffer(GraphicsDevice, VertexPositionColor.VertexDeclaration, 3, BufferUsage.WriteOnly);
            VertexBuffer.SetData(vertices);
        }

        public virtual void UpdatePlanePart(GameTime gameTime, float speed) { }
        public virtual void DrawPlanePart(BasicEffect effect, Matrix world) { }
    }
}
