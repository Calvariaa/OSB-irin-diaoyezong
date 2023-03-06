using OpenTK.Graphics;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;

namespace StorybrewScripts
{
    public class Background : StoryboardObjectGenerator
    {


        public void whiteburn(int starttime, double opacity)
        {
            
            //白色
            string whitePath = "sb/white.jpg";
            {
                var bitmap = GetMapsetBitmap(whitePath);
                var white = GetLayer("").CreateSprite(whitePath, OsbOrigin.Centre);
                white.Scale(starttime, 480.0f / bitmap.Height);
                white.Fade(starttime, starttime + 681, opacity, 0);

            }
        }

        public void blacksquare(int starttime1, int endtime1, int starttime2, int endtime2)
        {
            //黑色框框
            string maskPath = "sb/mask.png";
            {
                var bitmap = GetMapsetBitmap(maskPath);
                var mask = GetLayer("").CreateSprite(maskPath, OsbOrigin.Centre);
                mask.Scale(starttime1, 480.0f / bitmap.Height);
                mask.Fade(starttime1, endtime1, 0, 1);
                mask.Fade(starttime2, endtime2, 1, 0);

            }
        }
        void blacklight(StorybrewCommon.Storyboarding.OsbSprite Scolor, int time1, int time2)
        {
        //申必东西
            Scolor.Fade(time1, time2, 0.2, 0.2);
            Scolor.Fade(time2, time2 + 1364, 0.2, 0);
            Scolor.Fade(time2 + 1364, time2 + 1364, 0, 0);
            Scolor.Color(time1 - 239, time1 + 341, new Color4(255, 255, 255, 1), new Color4(230, 198, 124, 1));
            Scolor.Color(time1 + 341, time2 - 1364, new Color4(230, 198, 124, 1), new Color4(230, 198, 124, 1));
            Scolor.Color(time2 - 1364, time2, new Color4(230, 198, 124, 1), new Color4(255, 255, 255, 1));
            Scolor.Color(time2, time2 + 1364, new Color4(255, 255, 255, 1), new Color4(255, 255, 255, 1));

        }




        //Main mai ni aniand as dnsai dnsaid sa
        public override void Generate()
        {
            //MainBG
            string BackgroundPath = Beatmap.BackgroundPath;
            {
                var bitmap = GetMapsetBitmap(BackgroundPath);
                var bg = GetLayer("").CreateSprite(BackgroundPath, OsbOrigin.Centre);
                bg.Scale(22363, 480.0f / bitmap.Height);
                bg.Fade(22363, 22818, 0, 0.6);
                bg.Fade(22818, 44606, 0.6, 0.6);
                bg.Fade(44606, 44845, 0.6, 0);
                bg.Fade(55755, 66650 + 14, 1, 1);
                bg.Fade(66650 + 14, 115740 + 14, 0, 0);

                bg.Fade(115740 + 14, 148297 + 14, 1, 1);
                bg.Fade(148297 + 14, 148468 + 14, 1, 0);
                bg.Fade(148468 + 14, 202331 + 14, 0, 0);
                
                bg.Fade(203013 + 14, 224661 + 14, 0.6, 0.6);
                bg.Fade(224661 + 14, 224831 + 14, 0.6, 0);

                bg.Fade(246649 + 14, 247331 + 14, 1, 0);
                bg.Fade(247331 + 14, 257559 + 14, 0, 0);
                bg.Fade(257559 + 14, 301195 + 14, 1, 1);
                

            }

            //高斯模糊 113013
            string vaguePath = "sb/extra1.jpg";
            {
                var bitmap = GetMapsetBitmap(vaguePath);
                var vague = GetLayer("").CreateSprite(vaguePath, OsbOrigin.Centre);
                vague.Scale(1000, 480.0f / bitmap.Height);
                vague.Fade(1000, 1909, 0, 0.8);
                vague.Fade(1909, 22363, 0.8, 0.8);
                vague.Fade(22363, 22818, 0.8, 0);
                vague.Fade(53027, 54391, 0, 0.6);
                vague.Fade(54391, 55414, 0.6, 0.6);
                vague.Fade(55414, 55755, 0.6, 0.2);
                vague.Fade(55755, 66323, 0, 0);
                vague.Fade(66323, 66650 + 14, 0, 1);
                vague.Fade(66650 + 14, 69377 + 14, 1, 0);

                vague.Fade(69377 + 14, 112843 + 14, 0.8, 0.8);
                vague.Fade(112843 + 14, 113013 + 14, 0.8, 0);

                vague.Fade(113013 + 14, 148468 + 14, 0, 0);

                vague.Fade(148468 + 14, 149831 + 14, 0, 0.8);
                vague.Fade(149831 + 14, 156649 + 14, 0.8, 0.8);
                vague.Fade(156649 + 14, 159377 + 14, 0.8, 0);
                vague.Fade(159377 + 14, 203013 + 14, 0.8, 0.8);

                vague.Fade(203013 + 14, 243922 + 14, 0, 0);

                
                vague.Fade(243922 + 14, 245286 + 14, 0, 0.6);
                vague.Fade(245286 + 14, 246309 + 14, 0.6, 0.6);
                vague.Fade(246309 + 14, 246649 + 14, 0.6, 0.2);

                //246649 254831 255513 256195
                vague.Fade(246649 + 14, 247331 + 14, 0, 0.8);
                vague.Fade(247331 + 14, 254831 + 14, 0.8, 0.8);
                vague.Fade(256877 + 14, 257559 + 14, 0.8, 0.2);
                vague.Fade(257559 + 14, 300854 + 14, 0, 0);

                
                vague.Fade(300854 + 14, 301195 + 14, 0, 0.6);
                vague.Fade(301195 + 14, 311763 + 14, 0.8, 0.8);
                vague.Fade(311763 + 14, 312104 + 14, 0.8, 0.2);

                

            }

            //color black
            string colorPath = "sb/extra2.jpg";
            {
                



                //red 44606 45527 + 14
                var bitmap = GetMapsetBitmap(colorPath);
                var color = GetLayer("").CreateSprite(colorPath, OsbOrigin.Centre);
                color.Scale(44606, 480.0f / bitmap.Height);
                color.Fade(44606, 44845, 0, 0.2);

                color.Fade(112843 + 14, 113013 + 14, 0, 0.4);
                color.Fade(113013 + 14, 115400 + 14, 0.4, 0.4);
                color.Fade(115400 + 14, 115740 + 14, 0.4, 0.2);
                color.Fade(115740 + 14, 224661 + 14, 0, 0);

                
                color.Fade(224661 + 14, 224831 + 14, 0, 0.2);


                //44845 53027 54391 55755
                blacklight(color, 44845, 54391);

                //224831 243922 245286 246649
                blacklight(color, 224831 + 14, 245286 + 14);

                //312104
                blacklight(color, 312104 + 14, 323013 + 14);
                
            }

            //黑色框框实现 159377
            blacksquare(1000, 1909, 22363, 22818);
            blacksquare(69377 + 14, 70059 + 14, 90854 + 14, 91195 + 14);
            blacksquare(159377 + 14, 160059 + 14, 180854 + 14, 181195 + 14);

            //白色实现 
            whiteburn(55755, 0.6);
            whiteburn(69377 + 14, 0.6);

            whiteburn(115740 + 14, 0.6);
            whiteburn(126650 + 14, 0.6);
            whiteburn(137559 + 14, 0.6);

            whiteburn(159377 + 14, 0.6);

            whiteburn(203013 + 14, 0.6);
            
            whiteburn(246649 + 14, 0.6);
            whiteburn(249377 + 14, 0.6);

            //252104 253468 254831
            whiteburn(252104 + 14, 0.6);
            whiteburn(253468 + 14, 0.6);
            whiteburn(254831 + 14, 0.6);

            whiteburn(257559 + 14, 0.6);
            whiteburn(268468 + 14, 0.6);
            whiteburn(279377 + 14, 0.6);
            whiteburn(290286 + 14, 0.6);
            whiteburn(301195 + 14, 0.6);

            

            //光晕
            string lightPath = "sb/w.jpg";
            {
                var bitmap = GetMapsetBitmap(lightPath);
                var light = GetLayer("").CreateSprite(lightPath, OsbOrigin.Centre);
                light.Scale(44845, 960.0f / bitmap.Height);

                light.Fade(44845, 45527, 0, 0.1);
                light.Fade(45527, 54391, 0.1, 0.1);
                light.Fade(54391, 55755, 0.1 ,0);
                light.Rotate(44845, 54391, 0.3 ,0);

            }
        }
    }
}
