﻿using Microsoft.Xna.Framework;
using Conveyor_Defence.Missiles;

namespace Conveyor_Defence
{
    class Mine
    {
        private Projectile projectile;
        private bool inputReceived = false;
        private Conveyor conveyor;

        public Mine(Conveyor conveyor)
        {
            this.conveyor = conveyor;
        }

        public void Input(Projectile data)
        {
            inputReceived = true;
            projectile = data;
        }

        float timeSinseLastProcessCall = 0f;
        public void Process()
        {
        }

        private int counter =0;
        public void Output()
        {
            counter++;
            System.Diagnostics.Debug.WriteLine(string.Format("Mine produce projectile {0} !",counter));
            conveyor.Input(projectile);
        }

        public void Update(GameTime gameTime)
        {
            if (inputReceived)
            {
                timeSinseLastProcessCall += gameTime.ElapsedGameTime.Milliseconds;
                if (timeSinseLastProcessCall > 1000f)
                {
                    Output();
                    timeSinseLastProcessCall = 0;
                    inputReceived = false;
                }
            }

        }
    }
}
