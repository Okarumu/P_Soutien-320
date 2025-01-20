using System;

namespace ParaClub
{
    internal class Para
    {
        private string name = "Bob";
        public int XPosition;
        public int YPosition = 1;
        public int counter;

        private string[] withoutParachute =
        {
            @"     ",
            @"     ",
            @"     ",
            @"  o  ",
            @" /░\ ",
            @" / \ ",
        };

        private string[] withParachute =
        {
            @" ___ ",
            @"/|||\",
            @"\   /",
            @" \o/ ",
            @"  ░  ",
            @" / \ ",
        };

        public Para(int cursorXPosition, int counter)
        {
            XPosition = cursorXPosition;
            this.counter = counter;
        }

        public void Update()
        {
            if (YPosition <= Config.SCREEN_HEIGHT - 8)
            {
                if (YPosition < (Config.SCREEN_HEIGHT / 2) - 6)
                {
                    YPosition += 3;
                } else
                {
                    YPosition++;
                }
            }
            
            else
            {
                YPosition = Config.SCREEN_HEIGHT - 7;
            }
        }
        public void DrawWithoutParachute()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            Console.Write($"Bob {counter}");
            for (int i = 1; i <= withoutParachute.Length; i++)
            {
                Console.SetCursorPosition(XPosition, YPosition + i);
                Console.Write(withoutParachute[i - 1]);
            }
        }

        public void DrawWithParachute()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            Console.Write($"Bob {counter}");
            for (int i = 1; i <= withParachute.Length; i++)
            {
                Console.SetCursorPosition(XPosition, YPosition + i);
                Console.Write(withParachute[i - 1]);
            }
        }
    }
}
