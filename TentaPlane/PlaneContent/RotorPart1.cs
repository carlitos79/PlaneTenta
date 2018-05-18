using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TentaPlane.PlaneContent
{
    public class RotorPart1 : PlaneParts
    {
        private Vector3 rotation = Vector3.Zero;
        private Vector3 position = new Vector3(1, 5, 0);
        private Vector3 jointPos = new Vector3(4, 0, 0);

        public RotorPart1(GraphicsDevice graphics) : base(graphics, 1, 2, 0, Color.Red){ }

        public override void UpdatePlanePart(GameTime gameTime, float speed)
        {
            rotation = new Vector3(rotation.X, rotation.Y, rotation.Z + speed);

            World = Matrix.Identity * Matrix.CreateTranslation(position) *
                Matrix.CreateFromQuaternion(Quaternion.CreateFromYawPitchRoll(rotation.X, rotation.Y, rotation.Z)) *
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
