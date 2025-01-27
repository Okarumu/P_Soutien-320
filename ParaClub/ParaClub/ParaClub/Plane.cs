using System;
using System.Collections.Generic;

namespace ParaClub
{
    internal class Plane
    {
        
        private int cursorXPosition = 0;
        private int cursorYPosition = 0;

        private string[] view =
        {
            @" _                        ",
            @"| \                       ",
            @"|  \       ______         ",
            @"--- \_____/  |_|_\____ |  ",
            @" \_______ --------- __>-} ",
            @"        \_____|_____/  |  "
        };

        public void Update()
        {
            if(cursorXPosition + 2 < Config.SCREEN_WIDTH)
            {
                cursorXPosition += 2;
            }
            else
            {
                cursorXPosition = 0;
                
            }
           
        }

        public void Draw()
        {
            for (int i = 0; i < view.Length; i++)
            {
                Console.SetCursorPosition(cursorXPosition, cursorYPosition + i);
                Console.WriteLine(view[i]);
            }
        }

        public int GetCursorXPosition() { 
            return cursorXPosition; 
        }
    }
}