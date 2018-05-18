using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentaPlane.PlaneContent
{
    public class RotorPart2 : PlaneParts
    {
        private Vector3 rotation = new Vector3(0, 0, 3);
        private Vector3 position = new Vector3(1, 5, 0);
        private Vector3 jointPos = new Vector3(4, 0, 0);

        public RotorPart2(GraphicsDevice graphics) : base(graphics, 1, 2, 0, Color.Green) { }

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
