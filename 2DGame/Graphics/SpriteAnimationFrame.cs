using System;
using System.Collections.Generic;
using System.Text;

namespace RunnerGame.Graphics
{
    public class SpriteAnimationFrame
    {
        public Sprite Sprite { get; set; }

        public float TimeStamp { get; }

        public SpriteAnimationFrame(Sprite sprite, float timeStamp)
        {
            Sprite = sprite;
            TimeStamp = timeStamp;
        }
    }
}
