using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace StorybrewScripts
{
    public class Butterfly : StoryboardObjectGenerator
    {
        /*
        public void butterfly_old(int starttime)
        {
        

            var duration = 6810;
            var loopDuration = 300;
            var loopCount = duration / loopDuration;

            //白色
            string butterPath = "sb/butterfly/butter.png";
            {
                var bitmap = GetMapsetBitmap(butterPath);
                var butter = GetLayer("").CreateSprite(butterPath, OsbOrigin.Centre);

                butter.StartLoopGroup(starttime, loopCount);
                butter.Scale(0, 120.0f / bitmap.Height);
                butter.Rotate(0, MathHelper.DegreesToRadians(30));
                butter.Fade(0, loopDuration, 1, 1);
                butter.MoveY(0, loopDuration * 0.5, 240, 220);
                butter.MoveY(loopDuration * 0.5, loopDuration, 220, 240);
                //Log(butter.PositionAt(time));
                butter.EndGroup();

            }

            
            {
                string fly1Path = "sb/butterfly/fly1.png";
                string fly2Path = "sb/butterfly/fly2.png";
                var bitmap = GetMapsetBitmap(butterPath);

                var fly1 = GetLayer("").CreateSprite(fly1Path, OsbOrigin.Centre);
                fly1.Rotate(starttime, MathHelper.DegreesToRadians(30));
                var fly2 = GetLayer("").CreateSprite(fly2Path, OsbOrigin.Centre);
                fly2.Rotate(starttime, MathHelper.DegreesToRadians(30));
                //fly.Additive(starttime, starttime + 6810);


                fly1.StartLoopGroup(starttime, loopCount);
                fly1.Color(0, new Color4(225, 225, 225, 1));
                fly1.Fade(0, loopDuration, 1, 1); 
                fly1.MoveY(0, loopDuration * 0.5, 240, 220);
                fly1.MoveY(loopDuration * 0.5, loopDuration, 220, 240);

                fly1.ScaleVec(OsbEasing.In , 0, loopDuration * 0.5, 120.0f / bitmap.Height, 120.0f / bitmap.Height, 120.0f / bitmap.Height, - 60.0f / bitmap.Height);
                fly1.ScaleVec(OsbEasing.Out , loopDuration * 0.5, loopDuration, 120.0f / bitmap.Height, - 60.0f / bitmap.Height, 120.0f / bitmap.Height, 120.0f / bitmap.Height);
                fly1.EndGroup();

                fly2.StartLoopGroup(starttime, loopCount);
                fly2.Color(0, new Color4(255, 255, 255, 1));
                fly2.Fade(0, loopDuration, 1, 1); 
                fly2.MoveY(0, loopDuration * 0.5, 240, 220);
                fly2.MoveY(loopDuration * 0.5, loopDuration, 220, 240);

                fly2.ScaleVec(OsbEasing.In , 0, loopDuration * 0.5, 120.0f / bitmap.Height, 120.0f / bitmap.Height, 120.0f / bitmap.Height, - 60.0f / bitmap.Height);
                fly2.ScaleVec(OsbEasing.Out , loopDuration * 0.5, loopDuration, 120.0f / bitmap.Height, - 60.0f / bitmap.Height, 120.0f / bitmap.Height, 120.0f / bitmap.Height);
                fly2.EndGroup();
               


            }
        }
        
        
        public void test2()
        {
            {
                var lastX = Random(StartPosition.X, EndPosition.X);
                var lastY = Random(StartPosition.Y, EndPosition.Y);

                var rVec = MathHelper.DegreesToRadians(Random(0, 360));
                var sVec = Random(1, 16);
                var vX = (Math.Cos(rVec) * sVec) / (TravelSpeed / 2f);
                var vY = (Math.Sin(rVec) * sVec) / (TravelSpeed / 2f);
                var lastAngle = 0d;

                var UpdateRate = 500;
                for (var t = i; t < i + RealTravelTime; t += UpdateRate)
                {
                    var startPosition = new Vector2d(lastX, lastY);
                    var endPosition = new Vector2d(lastX, lastY);

                    var angle = Math.Atan2((startPosition.Y - endPosition.Y), (startPosition.X - endPosition.X)) - Math.PI / 2f;
                    
                    var nextX = lastX + (vX / 10f);
                    var nextY = lastY + (vY / 10f);

                    if(t!=i) {
                        particle.Move(t, t + UpdateRate, lastX, lastY, nextX, nextY);
                        particle.Rotate(t, t + UpdateRate, angle, lastAngle);

                        vX += Random(-TravelSpeed, TravelSpeed) * UpdateRate / 1000f;
                        vY += Random(-TravelSpeed, TravelSpeed) * UpdateRate / 1000f;
                    }

                    lastX = nextX;
                    lastY = nextY;
                    lastAngle = angle;
                }
            }

        public void butterfly(int starttime)
        {
            var duration = 6810;
            var loopDuration = 500;
            var loopCount = duration / loopDuration;

            //白色
            {
                string butterflyPath = "sb/butterfly/bw.png";
                var bitmap = GetMapsetBitmap(butterflyPath);
                var mapheight = 60.0f / bitmap.Height;

                var butterfly = GetLayer("").CreateSprite(butterflyPath, OsbOrigin.Centre);
                butterfly.Rotate(starttime, MathHelper.DegreesToRadians(90));
                //butterfly.Additive(starttime, starttime + 6810);


                butterfly.MoveX(starttime, starttime + duration, 120, 480);

                butterfly.StartLoopGroup(starttime, loopCount);
                butterfly.Color(0, new Color4(225, 225, 225, 1));
                butterfly.Fade(0, loopDuration, 1, 1); 

                //butterfly.MoveY(0, loopDuration * 0.5, 240, 250);
                //butterfly.MoveY(loopDuration * 0.5, loopDuration, 250, 240);

                butterfly.ScaleVec(OsbEasing.In , 0, loopDuration * 0.5, mapheight, mapheight, mapheight * 0.1, mapheight * 0.8);
                butterfly.ScaleVec(OsbEasing.Out , loopDuration * 0.5, loopDuration * 0.8, mapheight * 0.1, mapheight, mapheight, mapheight);
                butterfly.EndGroup();


            }
        }
        }//end

        public void test()
        {
            
            //var Movement = 500;
            for (int i = 0; i < 100; i++) {
                string butterflyPath = "sb/butterfly/bw.png";
                var sprite = GetLayer("").CreateSprite(butterflyPath, OsbOrigin.Centre, new Vector2(Random(0, 640), Random(0, 480)));
                var sTime = i * 200 + 91195;
                var eTime = sTime + 6810;
                
                var bitmap = GetMapsetBitmap(butterflyPath);
                var mapheight = 40.0f / bitmap.Height;
                sprite.ScaleVec(sTime, mapheight, mapheight); //set sprite params here

                //Movement and Rotation
                var flyspeed = 600;
                var step = 5000;



                for (var t = sTime; t < eTime; t += flyspeed) 
                    {
                    sprite.ScaleVec(OsbEasing.In , t, t + flyspeed * 0.5, mapheight, mapheight, mapheight * 0.1, mapheight * 0.8);
                    sprite.ScaleVec(OsbEasing.Out , t + flyspeed * 0.5, t + flyspeed, mapheight * 0.1, mapheight * 0.8, mapheight, mapheight);
                }
                for (var t = sTime; t < eTime; t += step) 
                {
                    

                    var currentPos = sprite.PositionAt(t);
                    var newPos = (Vector2)currentPos + new Vector2((float)Random(-107, 747), (float)Random(0, 480)); //give it a random direction

                    var currentRot = sprite.RotationAt(t);
                    var newRot = Math.Atan2((newPos.Y - currentPos.Y), (newPos.X - currentPos.X)); //calculate the angle we want

                    sprite.Move(t, t + step, currentPos, newPos);
                    sprite.Rotate(t, newRot); //simply set the direction
                    if (t != sTime)
                    {
                        sprite.Rotate(OsbEasing.OutExpo, t, t + step, currentRot, newRot); //you'll need some extra ifs for this to prevent full rotations (but I don't have time to implement it rn)
                    }
                    
                }
            }
        }

        
        public void test4()
        {
            for (int i = 91195; i < 91195 + 6810; i+=300) 
            {
                var StartPosition = new Vector2(Random(0, 640), Random(0, 480));
                var EndPosition = new Vector2(Random(0, 640), Random(0, 480));
                int TravelSpeed = 300;
                //int FlySpeed = 300;
                int RealTravelTime = 6810;

                string butterflyPath = "sb/butterfly/bw.png";
                var particle = GetLayer("").CreateSprite(butterflyPath, OsbOrigin.Centre, StartPosition);
                var bitmap = GetMapsetBitmap(butterflyPath);
                var mapheight = 40.0f / bitmap.Height;

                {
                    var lastX = Random(StartPosition.X, EndPosition.X);
                    var lastY = Random(StartPosition.Y, EndPosition.Y);

                    var rVec = MathHelper.DegreesToRadians(Random(0, 360));
                    var sVec = Random(1, 16);
                    var vX = (Math.Cos(rVec) * sVec) / (TravelSpeed / 2);
                    var vY = (Math.Sin(rVec) * sVec) / (TravelSpeed / 2);

                    var startPosition = new Vector2d(lastX, lastY);
                    var endPosition = new Vector2d(lastX, lastY);

                    var angle = Math.Atan2((startPosition.Y - endPosition.Y), (startPosition.X - endPosition.X)) + Math.PI / 2f;
                    var lastAngle = angle;
                    var UpdateRate = 500;

                    for (var t = i; t < i + RealTravelTime; t += UpdateRate) 
                    {
                        particle.ScaleVec(OsbEasing.In , t, t + UpdateRate * 0.5, mapheight, mapheight, mapheight * 0.1, mapheight * 0.8);
                        particle.ScaleVec(OsbEasing.Out , t + UpdateRate * 0.5, t + UpdateRate, mapheight * 0.1, mapheight * 0.8, mapheight, mapheight);
                    }

                    for (var t = i; t < i + RealTravelTime; t += UpdateRate)
                    {
                        var nextX = lastX + (vX / 10);
                        var nextY = lastY + (vY / 10);

                        var currentPos = particle.PositionAt(t);
                        var newPos = new Vector2((float)nextX, (float)nextY); //give it a random direction

                        var currentRot = particle.RotationAt(t);
                        var newRot = Math.Atan2((newPos.Y - currentPos.Y), (newPos.X - currentPos.X)) + Math.PI / 2f; //calculate the angle we want

                        //particle.Move(t, t + UpdateRate, lastX, lastY, nextX, nextY);
                        //particle.Rotate(t, t + UpdateRate, angle, lastAngle);

                        particle.Move(t, t + UpdateRate, currentPos, newPos);
                        particle.Rotate(OsbEasing.OutExpo,t, t + UpdateRate, currentRot, newRot);

                        lastAngle = angle;

                        vX += Random(-TravelSpeed, TravelSpeed) * UpdateRate / 1000;
                        vY += Random(-TravelSpeed, TravelSpeed) * UpdateRate / 1000;

                        lastX = nextX;
                        lastY = nextY;
                    }
                }
            }
        }


        */

        public void butterBomb(int starttime, Vector2 startPosition, Vector2 endPosition, double SeedNumber)
        {
            starttime -= 100;
            int lifetime = 1362 + 100;
            var flyspeed = 400 - 10 * SeedNumber;
            
            var offsetPosition = new Vector2((endPosition.Y - startPosition.Y), (endPosition.X - startPosition.X));

            int xx = 0;
            int yy = 0;
            if(offsetPosition.Y < 0) yy = -1;
            if(offsetPosition.Y > 0) yy = 1;
            if(offsetPosition.X < 0) xx = -1;
            if(offsetPosition.X > 0) xx = 1;

            var transformed = new Vector2(offsetPosition.Y* 0.1f + (float)Random(SeedNumber* yy* 20), offsetPosition.X* 0.1f + (float)Random(SeedNumber* xx* 20));
            var flyPosition = transformed + endPosition;
            var rotate = Math.Atan2(transformed.Y, transformed.X) + Math.PI / 2f;

            string butterflyPath = "sb/bw.png";
            var particle = GetLayer("").CreateSprite(butterflyPath, OsbOrigin.Centre, startPosition);
            var bitmap = GetMapsetBitmap(butterflyPath);
            var mapheight = (10.0f + SeedNumber) / bitmap.Height;
            //particle.Additive(starttime,  starttime + lifetime);

            particle.StartLoopGroup(starttime, (int)(lifetime /flyspeed ) + 1);
            particle.ScaleVec(OsbEasing.In , 0, flyspeed * 0.5, mapheight * 0.1, mapheight * 0.8, mapheight, mapheight);
            particle.ScaleVec(OsbEasing.Out , flyspeed * 0.5, flyspeed, mapheight, mapheight, mapheight * 0.1, mapheight * 0.8);
            particle.EndGroup();

            particle.Rotate(starttime, rotate);
            particle.Fade(starttime, starttime + 100, 0, 0);
            particle.Fade(starttime + 100, starttime + lifetime, 1, 0);
            particle.Move(OsbEasing.Out, starttime, starttime + lifetime, endPosition, flyPosition);

        }
        
        public void butterControl(int starttime, Vector2 StartPosition, Vector2 EndPosition)
        {
            for(double i = 10; i <= 20; i += 0.5)
            {
                butterBomb(starttime, StartPosition, EndPosition, i);
            }
        }

        [Configurable]
        public int BeatDivisor = 8;

        [Configurable]
        public int FadeTime = 200;


        [Configurable]
        public double SpriteScale = 1;

        public Vector2 Time2PositionS(int Time)
        {
            var dump = new Vector2(0,0);
            foreach (var hitobject in Beatmap.HitObjects)
            {
                
                if (hitobject.StartTime < Time - 345 || Time - 80 <= hitobject.StartTime)
                    continue;
                dump = hitobject.PositionAtTime(Time);
            }
            return dump;
        }
        public Vector2 Time2PositionE(int Time)
        {
            foreach (var hitobject in Beatmap.HitObjects)
            {
                
                if (hitobject.StartTime < Time - 5 || Time + 5 <= hitobject.StartTime)
                    continue;
                return hitobject.PositionAtTime(Time);
            }
            return new Vector2(0,0);
        }
        public void cont(int Time)
        {
            var hitobject = new OsuHitObject();
            butterControl(Time, Time2PositionS(Time), Time2PositionE(Time));
        }

        public override void Generate()
        {
		    //1 and 2 butterControl();
            cont(115740 + 14);
            cont(117104 + 14);
            cont(118468 + 14);
            cont(121195 + 14);
            cont(122559 + 14);
            cont(123922 + 14);
            cont(124604 + 14);
            cont(125286 + 14);
            cont(125968 + 14);
            cont(126650 + 14);
            cont(129377 + 14);
            cont(132104 + 14);
            cont(133468 + 14);
            cont(134831 + 14);
            cont(137559 + 14);
            cont(140286 + 14);
            cont(143013 + 14);
            cont(145740 + 14);
            cont(147104 + 14);

            //137559 2 246649 268468 - 115740  = 130909 152728
            cont(115740 + 130909 + 14);
            cont(117104 + 130909 + 14);
            cont(118468 + 130909 + 14);
            cont(121195 + 130909 + 14);
            cont(122559 + 130909 + 14);
            cont(123922 + 130909 + 14);
            cont(124604 + 130909 + 14);
            cont(125286 + 130909 + 14);
            cont(125968 + 130909 + 14);
            cont(126650 + 130909 + 14);
            cont(129377 + 130909 + 14);
            cont(132104 + 130909 + 14);
            cont(133468 + 130909 + 14);
            cont(134831 + 130909 + 14);
            
            cont(115740 + 152728 + 14);
            cont(117104 + 152728 + 14);
            cont(118468 + 152728 + 14);
            cont(121195 + 152728 + 14);
            cont(122559 + 152728 + 14);
            cont(123922 + 152728 + 14);
            cont(124604 + 152728 + 14);
            cont(125286 + 152728 + 14);
            cont(125968 + 152728 + 14);
            cont(126650 + 152728 + 14);
            cont(129377 + 152728 + 14);
            cont(132104 + 152728 + 14);
            cont(133468 + 152728 + 14);
            cont(134831 + 152728 + 14);

            cont(137559 + 152728 + 14);
            cont(140286 + 152728 + 14);
            cont(143013 + 152728 + 14);
            cont(145740 + 152728 + 14);
            cont(147104 + 152728 + 14);

            
        }
    }
}
