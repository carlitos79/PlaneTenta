using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TentaPlane.PlaneContent
{
    public interface IPlane
    {
        void DrawPlanePart(BasicEffect effect, Matrix world);
        void UpdatePlanePart(GameTime gameTime, float speed);
    }
}
