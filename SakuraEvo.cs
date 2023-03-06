using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Util;
using System;
using System.Drawing;
using System.Linq;

namespace StorybrewScripts
{
    public class SakuraEvo : StoryboardObjectGenerator
    {
        [Configurable]
        public string Path1 = "sb/sakula/p1.png";
        public string Path2 = "sb/sakula/p2.png";
        public string Path3 = "sb/sakula/p3.png";
        public string Path4 = "sb/sakula/p4.png";
        public string Path5 = "sb/sakula/p5.png";
        public string Path6 = "sb/sakula/p6.png";
        public string Path7 = "sb/sakula/p7.png";
        public string Path8 = "sb/sakula/p8.png";
        public string Path9 = "sb/sakula/p9.png";


        [Configurable]
        public int ParticleCount = 5;

        [Configurable]
        public Vector2 Scale = new Vector2(1, 1);

        [Configurable]
        public float Rotation = 0;

        [Configurable]
        public OsbOrigin Origin = OsbOrigin.Centre;

        [Configurable]
        public Color4 Color = Color4.White;

        [Configurable]
        public float ColorVariance = 0.6f;

        [Configurable]
        public bool Additive = false;

        [Configurable]
        public Vector2 SpawnOrigin = new Vector2(420, 0);

        [Configurable]
        public float SpawnSpread = 360;

        [Configurable]
        public float Angle = 110;

        [Configurable]
        public float AngleSpread = 60;

        [Configurable]
        public float Speed = 120;

        [Configurable]
        public float Lifetime = 5456;

        [Configurable]
        public OsbEasing Easing = OsbEasing.In;

        
        public override void Generate()
        {
            //115740 148468 257559 301195
            run(115740 + 14, 148468 + 14 - (int)Lifetime, Path1);
            run(257559 + 14, 301195 + 14 - (int)Lifetime, Path1);
            //115740 148468 257559 301195
            run(115740 + 14, 148468 + 14 - (int)Lifetime, Path2);
            run(257559 + 14, 301195 + 14 - (int)Lifetime, Path2);
            //115740 148468 257559 301195
            run(115740 + 14, 148468 + 14 - (int)Lifetime, Path3);
            run(257559 + 14, 301195 + 14 - (int)Lifetime, Path3);
            //115740 148468 257559 301195
            run(115740 + 14, 148468 + 14 - (int)Lifetime, Path4);
            run(257559 + 14, 301195 + 14 - (int)Lifetime, Path4);
            //115740 148468 257559 301195
            run(115740 + 14, 148468 + 14 - (int)Lifetime, Path5);
            run(257559 + 14, 301195 + 14 - (int)Lifetime, Path5);
            //115740 148468 257559 301195
            run(115740 + 14, 148468 + 14 - (int)Lifetime, Path6);
            run(257559 + 14, 301195 + 14 - (int)Lifetime, Path6);
            //115740 148468 257559 301195
            run(115740 + 14, 148468 + 14 - (int)Lifetime, Path7);
            run(257559 + 14, 301195 + 14 - (int)Lifetime, Path7);
            //115740 148468 257559 301195
            run(115740 + 14, 148468 + 14 - (int)Lifetime, Path8);
            run(257559 + 14, 301195 + 14 - (int)Lifetime, Path8);
            //115740 148468 257559 301195
            run(115740 + 14, 148468 + 14 - (int)Lifetime, Path9);
            run(257559 + 14, 301195 + 14 - (int)Lifetime, Path9);
        }

        public void run(int StartTime, int EndTime, string SakuraPath)
        {
            if (StartTime == EndTime)
            {
                StartTime = (int)Beatmap.HitObjects.First().StartTime;
                EndTime = (int)Beatmap.HitObjects.Last().EndTime;
            }
            EndTime = Math.Min(EndTime, (int)AudioDuration);
            StartTime = Math.Min(StartTime, EndTime);

            var bitmap = GetMapsetBitmap(SakuraPath);

            var duration = (double)(EndTime - StartTime);
            var loopCount = (int)Math.Floor(duration / Lifetime);

            var layer = GetLayer("");
            for (var i = 0; i < ParticleCount; i++)
            {
                var spawnAngle = Random(Math.PI * 2);
                var spawnDistance = (float)(SpawnSpread * Math.Sqrt(Random(1f)));

                var moveAngle = MathHelper.DegreesToRadians(Angle + Random(-AngleSpread, AngleSpread) * 0.5f);
                var moveDistance = Speed * Lifetime * 0.001f;

                var spriteRotation = moveAngle + MathHelper.DegreesToRadians(Rotation);

                var startPosition = SpawnOrigin + new Vector2((float)Math.Cos(spawnAngle), (float)Math.Sin(spawnAngle)) * spawnDistance;
                var endPosition = startPosition + new Vector2((float)Math.Cos(moveAngle), (float)Math.Sin(moveAngle)) * moveDistance;

                var loopDuration = duration / loopCount;
                var startTime = StartTime + (i * loopDuration) / ParticleCount;
                var endTime = startTime + loopDuration * loopCount;

                if (!isVisible(bitmap, startPosition, endPosition, (float)spriteRotation, (float)loopDuration))
                    continue;

                var color = Color;
                if (ColorVariance > 0)
                {
                    ColorVariance = MathHelper.Clamp(ColorVariance, 0, 1);

                    var hsba = Color4.ToHsl(color);
                    var sMin = Math.Max(0, hsba.Y - ColorVariance * 0.5f);
                    var sMax = Math.Min(sMin + ColorVariance, 1);
                    var vMin = Math.Max(0, hsba.Z - ColorVariance * 0.5f);
                    var vMax = Math.Min(vMin + ColorVariance, 1);

                    color = Color4.FromHsl(new Vector4(
                        hsba.X,
                        (float)Random(sMin, sMax),
                        (float)Random(vMin, vMax),
                        hsba.W));
                }

                var particle = layer.CreateSprite(SakuraPath, Origin);
                if (spriteRotation != 0)
                    particle.Rotate(startTime, spriteRotation);
                if (color.R != 1 || color.G != 1 || color.B != 1)
                    particle.Color(startTime, color);
                /*
                if (Scale.X != 1 || Scale.Y != 1)
                {
                    if (Scale.X != Scale.Y)
                        particle.ScaleVec(startTime, Scale.X, Scale.Y);
                    else particle.Scale(startTime, Scale.X);
                }
                */
                if (Additive)
                    particle.Additive(startTime, endTime);

                particle.StartLoopGroup(startTime, loopCount);
                particle.Fade(OsbEasing.Out, 0, loopDuration * 0.2, 0, color.A);
                particle.Fade(OsbEasing.In, loopDuration * 0.8, loopDuration, color.A, 0);

                particle.Move(Easing, 0, loopDuration, startPosition, endPosition);

                //樱花飘落旋转45度然后开始对折再转90度然后折回去再转45度
                particle.Rotate(Easing, 0, loopDuration * 0.5, MathHelper.DegreesToRadians(0), MathHelper.DegreesToRadians(90));

                particle.ScaleVec(Easing, 0, loopDuration * 0.2, 0.15, 0.15, 0.16, 0.16);
                particle.ScaleVec(Easing, loopDuration * 0.2, loopDuration * 0.5 ,0.16, 0.16, 0.175, 0);
                particle.ScaleVec(Easing, loopDuration * 0.5, loopDuration * 0.8 ,0.175, 0, 0.19, 0.19);
                particle.ScaleVec(Easing, loopDuration * 0.8, loopDuration, 0.19, 0.19, 0.2, 0.2);

                particle.Rotate(Easing, loopDuration * 0.5, loopDuration, MathHelper.DegreesToRadians(90), MathHelper.DegreesToRadians(180));

                particle.EndGroup();
            }
        }

        private bool isVisible(Bitmap bitmap, Vector2 startPosition, Vector2 endPosition, float rotation, float duration)
        {
            var spriteSize = new Vector2(bitmap.Width * Scale.X, bitmap.Height * Scale.Y);
            var originVector = OsbSprite.GetOriginVector(Origin, spriteSize.X, spriteSize.Y);

            for (var t = 0; t < duration; t += 200)
            {
                var position = Vector2.Lerp(startPosition, endPosition, t / duration);
                if (OsbSprite.InScreenBounds(position, spriteSize, rotation, originVector))
                    return true;
            }
            return false;
        }
    }
}
