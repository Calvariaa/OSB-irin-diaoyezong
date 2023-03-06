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

namespace StorybrewScripts
{
    public class Title : StoryboardObjectGenerator
    {
        public void TitleBG(int starttime, int endtime, Color4 BgColor)
        {
            string titleGroundPath = "sb/white.jpg";
            {
                var bitmap = GetMapsetBitmap(titleGroundPath);
                var titleGround = GetLayer("").CreateSprite(titleGroundPath, OsbOrigin.Centre);
                titleGround.ScaleVec(starttime, 1, 0.2);
                titleGround.Color(starttime, starttime + 2386, BgColor, BgColor);
                //titleGround.Additive(starttime, endtime);
                
                titleGround.Fade(starttime, starttime + 340, 0, 0.6);
                titleGround.Fade(starttime + 340, endtime - 341, 0.6, 0.6);
                titleGround.Fade(endtime - 341, endtime, 0.6, 0);
            }
        }

        public void Text(int starttime, int endtime, string textPath)
        {
        
            var bitmap = GetMapsetBitmap(textPath);
            var text = GetLayer("").CreateSprite(textPath, OsbOrigin.Centre);
            text.Scale(starttime, 0.6);
                
            text.Move(starttime, starttime + 340, new Vector2(640, 240), new Vector2(240, 240));
            text.Move(starttime + 340, endtime - 341, new Vector2(240, 240), new Vector2(220, 240));
            text.Move(endtime - 341, endtime, new Vector2(220, 240), new Vector2(0, 240));
            text.Fade(starttime, starttime + 340, 0, 1);
            text.Fade(starttime + 340, endtime - 341, 1, 1);
            text.Fade(endtime - 341, endtime, 1, 0);
        }
        public override void Generate()
        {
            //55755 58482 61209 63936 66650
            TitleBG(55755, 58482, new Color4(230, 198, 124, 1));
            TitleBG(58482, 61209, new Color4(230, 198, 124, 1));
            TitleBG(61209, 63936, new Color4(198, 230, 124, 1));
            TitleBG(63936, 66650 + 14, new Color4(198, 230, 124, 1));
            

            Text(55755, 58482, "sb/title1.png");
            Text(58482, 61209, "sb/title2.png");
            Text(61209, 63936, "sb/mapper.png");
            Text(63936, 66650 + 14, "sb/sber.png");
		    
            
        }
    }
}
