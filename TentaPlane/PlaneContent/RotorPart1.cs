using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TentaPlane.PlaneContent
{
    public class RotorPart1 : PlaneParts
    {
        private Vector3 rotation = Vector3.Zero;
        private Vector3 position = new Vector3(1, 2, 0);
        private Vector3 jointPos = new Vector3(3, 2, 0);

        private static Vector3 topMid = new Vector3(0, -2f, 0);
        private static Vector3 bottomLeft = new Vector3(-1, 0.5f, 0);
        private static Vector3 bottomRight = new Vector3(1, 0.5f, 0);

        public RotorPart1(GraphicsDevice graphics) : base(graphics, topMid, bottomLeft, bottomRight, Color.Red){ }

        public override void UpdatePlanePart(GameTime gameTime, float speed)
        {
            rotation = new Vector3(rotation.X + speed, rotation.Y, rotation.Z);

            World = Matrix.Identity * Matrix.CreateTranslation(position) *
                Matrix.CreateFromQuaternion(Quaternion.CreateFromYawPitchRoll(rotation.Y, rotation.X, rotation.Z)) *
                Matrix.CreateTranslation(jointPos);
        }

        public override void DrawPlanePart(BasicEffect effect, Matrix world)
        {
            effect.World = World * world;
            effect.CurrentTechnique.Passes[0].Apply();

            GraphicsDevice.SetVertexBuffer(VertexBuffer);
            GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 3);
        }
    }
}
