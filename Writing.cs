using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.CommandValues;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class Writing : StoryboardObjectGenerator
    {
        public OsbSprite character(char ch)
        {
            String add = "";
            if(Char.IsUpper(ch)) {
                add = "u";
            }
            ch = Char.ToLower(ch);
            String chara = Char.ToString(ch);
            String path = FontPath + "/" + chara + add + ".png";
            return GetLayer("foreground").CreateSprite(path);
        }

        public OsbSprite[] text(String text)
        {
            char[] chars = text.ToCharArray();
            OsbSprite[] sprites = new OsbSprite[chars.Length];
            for(int x = 0; x < chars.Length; x++) 
            {
                sprites[x] = character(chars[x]);
            }
            return sprites;
        }
        
        public OsbSprite[] write(String txt, int x, int y, int start, int fadein, int end, int fadeout, double pt)
        {
            OsbSprite[] sprites = text(txt);
            sprites[0].Scale(start, pt/268);
            sprites[0].Move(start, x, y);
            sprites[0].Fade(start, start, 0, 0);
            sprites[0].Fade(start, fadein, 0, 1);
            sprites[0].Fade(end, fadeout, 1, 0);
            for(int c = 1; c < sprites.Length; c++) {
                int additive = 0;
                if(sprites[c-1].GetTexturePathAt(0) == FontPath+"/ .png") {
                    additive = (int) Math.Round(GetMapsetBitmap(sprites[c].GetTexturePathAt(1)).Width/2 * pt/268);
                } else if(sprites[c].GetTexturePathAt(0) == FontPath+"/ .png") {
                    additive = (int) Math.Round(pt/2);
                } else {
                    additive = (int) Math.Round(GetMapsetBitmap(sprites[c-1].GetTexturePathAt(1)).Width/2 * pt/268);
                    additive = (int) Math.Round(additive + GetMapsetBitmap(sprites[c].GetTexturePathAt(1)).Width/2 * pt/268);
                }
                x += additive;
                additive = (int) Math.Round(additive * pt/268);
                sprites[c].Scale(start, pt/268);
                sprites[c].Move(start, x, y);
                sprites[c].Fade(start, start, 0, 0);
                sprites[c].Fade(start, fadein, 0, 1);
                sprites[c].Fade(end, fadeout, 1, 0);
            }

            return sprites;
        }

        public void move(int start, int end, int sX, int sY, int dX, int dY, params OsbSprite[] sprites)
        {
            foreach(OsbSprite sprite in sprites)
            {
                int x = (int) Math.Round((double) sX == -1 ? sprite.PositionAt(start).X : sX);
                int y = (int) Math.Round((double) sY == -1 ? sprite.PositionAt(start).Y : sY);
                sprite.Move(start, end, x, y, x+dX, y+dY);
            }
        }

        public void scale(int start, int end, int sX, int eX, params OsbSprite[] sprites)
        {
            int x = 0;
            int width = 0;
            {
                OsbSprite firstSprite = sprites[0];
                OsbSprite lastSprite = sprites[sprites.Length-1];
                x = (int) (float) firstSprite.PositionAt(start).X;//-(int) (GetMapsetBitmap(firstSprite.GetTexturePathAt(start)).Width/2*firstSprite.ScaleAt(start).X);
                width = (int) (double) (lastSprite.PositionAt(start).X - firstSprite.PositionAt(start).X);// + (int) (GetMapsetBitmap(lastSprite.GetTexturePathAt(start)).Width/2*lastSprite.ScaleAt(start).X);
            }

            foreach(OsbSprite sprite in sprites)
            {
                var scale = sprite.ScaleAt(start);
                sprite.Scale(start, end, sX*scale.X, eX*scale.X);

                var pos = sprite.PositionAt(start);
                sprite.Move(start, end, (x+width/2) + (pos.X-x-width/2)*sX, pos.Y, (x+width/2) + (pos.X-x-width/2)*eX, pos.Y);
            }
        }

        public void fade(int start, int end, int sF, int eF, params OsbSprite[] sprites)
        {
            foreach(OsbSprite sprite in sprites)
            {
                sprite.Fade(start, end, sF, eF);
            }
        }

        public void flash(int start, int end, params OsbSprite[] sprites)
        {
            scale(start, end, 1, 2, sprites);
            fade(start, end, 1, 0, sprites);
        }

        public void colour(int start, int end, CommandColor sC, CommandColor eC, params OsbSprite[] sprites)
        {
            foreach(OsbSprite sprite in sprites)
            {
                sprite.Color(start, end, sC, eC);
            }
        }

        [Configurable]
        public String FontPath = "font";

        [Configurable]
        public String Text = "";

        [Configurable]
        public int StartX = 0;

        [Configurable]
        public int dx = 0;

        [Configurable]
        public int StartY = 0;

        [Configurable]
        public int dy = 0;

        [Configurable]
        public int StartTime = 0;

        [Configurable]
        public int FadeInDuration = 100;

        [Configurable]
        public int EndTime = 0;

        [Configurable]
        public int FadeOutDuration = 100;

        [Configurable]
        public int FontSize = 20;

        [Configurable]
        public Boolean Flash = false;

        [Configurable]
        public int FlashTime = 0;

        [Configurable]
        public int FlashDuration = 0;

        public override void Generate()
        {
            OsbSprite[] textBuffer = write((String) Text.Clone(), StartX, StartY, StartTime-FadeInDuration, StartTime, EndTime, EndTime+FadeOutDuration, FontSize);
            if(dx != 0 || dy != 0)
                move(StartTime-FadeInDuration, EndTime+FadeOutDuration, -1, -1, dx, dy, textBuffer);

            if(Flash)
            {
                int xpos = ((FlashTime-(StartTime-FadeInDuration))*dx)/((EndTime+FadeOutDuration)-(StartTime-FadeInDuration));
                int ypos = ((FlashTime-(StartTime-FadeInDuration))*dy)/((EndTime+FadeOutDuration)-(StartTime-FadeInDuration));
                OsbSprite[] flashBuffer = write((String) Text.Clone(), StartX+xpos, StartY+ypos, FlashTime, FlashTime, FlashTime, FlashTime, FontSize);
                flash(FlashTime, FlashTime+FlashDuration, flashBuffer);
            }
        }
    }
}
