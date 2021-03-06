﻿//-----------------------------------------------------------------------
// <copyright file="Level.cs" company="Leim Productions">
//     Copyright (c) Leim Productions Inc.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KnightBear_TD_WindowsDesktop.Entities.Towers
{
    class Projectile : GameObject
    {
        #region Fields
        private Ability projectileAbility;
        private double lastMove;
        private int targetIndex;
        #endregion

        #region Properties
        public Ability ProjectileAbility
        {
            get { return projectileAbility; }
            set { projectileAbility = value; }
        }

        public double LastMove
        {
            get { return lastMove; }
            set { lastMove = value; }
        }

        public int TargetIndex
        {
            get { return targetIndex; }
            set { targetIndex = value; }
        }
        #endregion

        #region Load/Update
        public Projectile(Texture2D texture, Vector2 position, float scale, int targetIndex, Ability projectileAbility)
        {
            ObjectTexture = texture;
            Position = position;
            TargetIndex = targetIndex;
            Scale = scale;
            ProjectileAbility = projectileAbility;
            Origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public void Update(GameTime gameTime, Vector2 targetPosition)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds - lastMove > projectileAbility.MoveSpeed)
            {
                UpdatePosition(targetPosition);
            }
        }
        #endregion

        #region Methods
        private void UpdatePosition(Vector2 target)
        {
            // Difference of x/y coordiantes between shot and target
            float diffX, diffY;

            diffX = target.X - Position.X;
            diffY = target.Y - Position.Y;
            Rotation = (float)Math.Atan2(diffY, diffX);

            Vector2 forward = new Vector2(1, 0);
            Matrix rotMatrix = Matrix.CreateRotationZ(Rotation);
            Vector2 shotDirection = Vector2.Transform(forward, rotMatrix);

            Position += shotDirection;
        }
        #endregion
    }
}
