using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;

namespace StorybrewScripts
{
    public class HitObjectHighlight : StoryboardObjectGenerator
    {


        [Configurable]
        public int BeatDivisor = 8;

        [Configurable]
        public int FadeTime = 200;


        [Configurable]
        public double SpriteScale = 1;


        public override void Generate()
        {
            run(54391, 55755, "sb/pl.png");
            run(114377 + 14, 115740 + 14, "sb/pl.png");
            run(245286 + 14, 246649 + 14, "sb/pl.png");

            //290627 293354 296081
            run(137899 + 14, 137899 + 1023 + 14, "sb/pl.png");
            run(140627 + 14, 140627 + 1023 + 14, "sb/pl.png");
            run(143354 + 14, 143354 + 1023 + 14, "sb/pl.png");
            
            run(290627 + 14, 290627 + 1023 + 14, "sb/pl.png");
            run(293354 + 14, 293354 + 1023 + 14, "sb/pl.png");
            run(296081 + 14, 296081 + 1023 + 14, "sb/pl.png");

        }

        public void run(int StartTime,int EndTime, string SpritePath)
        {
            Log(StartTime.ToString() + EndTime.ToString());
            var hitobjectLayer = GetLayer("");
            foreach (var hitobject in Beatmap.HitObjects)
            {
                if ((StartTime != 0 || EndTime != 0) && 
                    (hitobject.StartTime < StartTime - 5 || EndTime - 5 <= hitobject.StartTime))
                    continue;

                var hSprite = hitobjectLayer.CreateSprite(SpritePath, OsbOrigin.Centre, hitobject.Position);
                hSprite.Scale(OsbEasing.In, hitobject.StartTime, hitobject.EndTime + FadeTime, SpriteScale, SpriteScale * 0.2);
                hSprite.Fade(OsbEasing.In, hitobject.StartTime, hitobject.EndTime + FadeTime, 1, 0);
                hSprite.Additive(hitobject.StartTime, hitobject.EndTime + FadeTime);
                hSprite.Color(hitobject.StartTime, hitobject.Color);

                if (hitobject is OsuSlider)
                {
                    var timestep = Beatmap.GetTimingPointAt((int)hitobject.StartTime).BeatDuration / BeatDivisor;
                    var startTime = hitobject.StartTime;
                    while (true)
                    {
                        var endTime = startTime + timestep;

                        var complete = hitobject.EndTime - endTime < 5;
                        if (complete) endTime = hitobject.EndTime;

                        var startPosition = hSprite.PositionAt(startTime);
                        hSprite.Move(startTime, endTime, startPosition, hitobject.PositionAtTime(endTime));

                        if (complete) break;
                        startTime += timestep;
                    }
                }
            }
        }
    }
}
