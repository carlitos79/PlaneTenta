using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentaPlane
{
    public class Box
    {
        private static readonly Vector3 FRONT_TOP_LEFT = new Vector3(-1, 1, 1);
        private static readonly Vector3 FRONT_TOP_RIGHT = new Vector3(1, 1, 1);
        private static readonly Vector3 FRONT_BOTTOM_LEFT = new Vector3(-1, -1, 1);
        private static readonly Vector3 FRONT_BOTTOM_RIGHT = new Vector3(1, -1, 1);
        private static readonly Vector3 BACK_TOP_LEFT = new Vector3(-1, 1, -1);
        private static readonly Vector3 BACK_TOP_RIGHT = new Vector3(1, 1, -1);
        private static readonly Vector3 BACK_BOTTOM_LEFT = new Vector3(-1, -1, -1);
        private static readonly Vector3 BACK_BOTTOM_RIGHT = new Vector3(1, -1, -1);

        private VertexPositionColor[] vertices;
        private VertexBuffer vertexBuffer;
        private IndexBuffer indexBuffer;
        private GraphicsDevice graphics;


        public Box(Vector3 pos, Color col, GraphicsDevice g)
        {
            graphics = g;

            vertices = new VertexPositionColor[36];

            // Front face
            vertices[0] = new VertexPositionColor(FRONT_TOP_LEFT + pos, col);
            vertices[1] = new VertexPositionColor(FRONT_TOP_RIGHT + pos, col);
            vertices[2] = new VertexPositionColor(FRONT_BOTTOM_RIGHT + pos, col);
            vertices[3] = new VertexPositionColor(FRONT_TOP_LEFT + pos, col);
            vertices[4] = new VertexPositionColor(FRONT_BOTTOM_RIGHT + pos, col);
            vertices[5] = new VertexPositionColor(FRONT_BOTTOM_LEFT + pos, col);

            // Right face
            vertices[6] = new VertexPositionColor(FRONT_TOP_RIGHT + pos, col);
            vertices[7] = new VertexPositionColor(BACK_TOP_RIGHT + pos, col);
            vertices[8] = new VertexPositionColor(BACK_BOTTOM_RIGHT + pos, col);
            vertices[9] = new VertexPositionColor(FRONT_TOP_RIGHT + pos, col);
            vertices[10] = new VertexPositionColor(BACK_BOTTOM_RIGHT + pos, col);
            vertices[11] = new VertexPositionColor(FRONT_BOTTOM_RIGHT + pos, col);

            // Back face
            vertices[12] = new VertexPositionColor(BACK_TOP_LEFT + pos, col);
            vertices[13] = new VertexPositionColor(BACK_BOTTOM_LEFT + pos, col);
            vertices[14] = new VertexPositionColor(BACK_BOTTOM_RIGHT + pos, col);
            vertices[15] = new VertexPositionColor(BACK_BOTTOM_RIGHT + pos, col);
            vertices[16] = new VertexPositionColor(BACK_TOP_RIGHT + pos, col);
            vertices[17] = new VertexPositionColor(BACK_TOP_RIGHT + pos, col);

            // Left face
            vertices[18] = new VertexPositionColor(BACK_TOP_LEFT + pos, col);
            vertices[19] = new VertexPositionColor(FRONT_TOP_LEFT + pos, col);
            vertices[20] = new VertexPositionColor(FRONT_BOTTOM_LEFT + pos, col);
            vertices[21] = new VertexPositionColor(BACK_TOP_LEFT + pos, col);
            vertices[22] = new VertexPositionColor(FRONT_BOTTOM_LEFT + pos, col);
            vertices[23] = new VertexPositionColor(BACK_BOTTOM_LEFT + pos, col);

            // Top face 
            vertices[24] = new VertexPositionColor(BACK_TOP_LEFT + pos, col);
            vertices[25] = new VertexPositionColor(BACK_TOP_RIGHT + pos, col);
            vertices[26] = new VertexPositionColor(FRONT_TOP_RIGHT + pos, col);
            vertices[27] = new VertexPositionColor(BACK_TOP_LEFT + pos, col);
            vertices[28] = new VertexPositionColor(FRONT_TOP_RIGHT + pos, col);
            vertices[29] = new VertexPositionColor(FRONT_TOP_LEFT + pos, col);

            // Bottom face
            vertices[30] = new VertexPositionColor(FRONT_BOTTOM_LEFT + pos, col);
            vertices[31] = new VertexPositionColor(FRONT_BOTTOM_RIGHT + pos, col);
            vertices[32] = new VertexPositionColor(BACK_BOTTOM_RIGHT + pos, col);
            vertices[33] = new VertexPositionColor(FRONT_BOTTOM_LEFT + pos, col);
            vertices[34] = new VertexPositionColor(BACK_BOTTOM_RIGHT + pos, col);
            vertices[35] = new VertexPositionColor(BACK_BOTTOM_LEFT + pos, col);

            vertexBuffer = new VertexBuffer(graphics, typeof(VertexPositionColor), 36, BufferUsage.WriteOnly);
            vertexBuffer.SetData(vertices);

            short[] indices = new short[36];
            for (short i = 0; i < 36; ++i)
                indices[i] = i;
            indexBuffer = new IndexBuffer(graphics, typeof(short), 36, BufferUsage.WriteOnly);
            indexBuffer.SetData(indices);
        }

        public void Draw(BasicEffect effect, Matrix world)
        {
            effect.World = world;
            effect.CurrentTechnique.Passes[0].Apply();

            graphics.SetVertexBuffer(vertexBuffer);
            graphics.Indices = indexBuffer;
            graphics.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 12);
            //graphics.DrawPrimitives(PrimitiveType.TriangleList, 0, 3);
        }
    }
}
