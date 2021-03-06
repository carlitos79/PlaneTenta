﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace TentaPlane.PlaneContent
{
    class PlaneBody : PlaneParts
    {
        private List<IPlane> parts = new List<IPlane>();

        private Vector3 rotation = Vector3.Zero;
        private Vector3 position = Vector3.Zero;

        private static Vector3 topLeft = new Vector3(-4, 2, 0);
        private static Vector3 bottomLeft = new Vector3(-4, -2, 0);
        private static Vector3 bottomRight = new Vector3(4, 2, 0);

        public PlaneBody(GraphicsDevice graphicsDevice) : base(graphicsDevice, topLeft, bottomLeft, bottomRight, Color.Blue)
        {
            parts.Add(new RotorPart1(graphicsDevice));
            parts.Add(new RotorPart2(graphicsDevice));
        }

        public override void UpdatePlanePart(GameTime gameTime, float speed)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                rotation = new Vector3(rotation.X + 0.02f, rotation.Y, rotation.Z);

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                rotation = new Vector3(rotation.X - 0.02f, rotation.Y, rotation.Z);

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                position = new Vector3(position.X, position.Y + 0.05f, position.Z);

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                position = new Vector3(position.X, position.Y - 0.05f, position.Z);            

            World = Matrix.Identity * Matrix.CreateFromQuaternion(Quaternion.CreateFromYawPitchRoll(rotation.X, rotation.Y, rotation.Z)) *
                Matrix.CreateTranslation(position);

            foreach (IPlane part in parts)
            {
                part.UpdatePlanePart(gameTime, speed);
            }
        }

        public override void DrawPlanePart(BasicEffect effect, Matrix world)
        {
            effect.World = World * world;
            effect.CurrentTechnique.Passes[0].Apply();

            GraphicsDevice.SetVertexBuffer(VertexBuffer);
            GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 3);

            foreach (IPlane part in parts)
            {
                part.DrawPlanePart(effect, World * world);
            }
        }
    }
}
