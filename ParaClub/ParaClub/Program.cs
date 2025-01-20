using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParaClub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyPressed;
            Console.SetWindowSize(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT);
            Plane plane = new Plane();
            List<Para> bobs = new List<Para>();
            int counter = 0;
            Console.CursorVisible = false;

            while (true)
            {
                //Modifier le modèle (ce qui *est*)
                plane.Update();
                for (int i = 0; i < bobs.Count; i++)
                {
                    bobs[i].Update();
                }

                if (Console.KeyAvailable) { 
                    keyPressed = Console.ReadKey(false);
                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;

                        case ConsoleKey.Spacebar:
                            Para para = new Para(plane.GetCursorXPosition(), counter);
                            counter++;
                            bobs.Add(para);
                            break;
                        case 0:
                            break;
                    }
                }

                //Modifier ce que l'on *voit*
                Console.Clear();
                plane.Draw();
                for (int i = 0; i < bobs.Count; i++)
                {
                    if (bobs[i].YPosition < (Config.SCREEN_HEIGHT / 2) - 6 || bobs[i].YPosition == Config.SCREEN_HEIGHT - 7) 
                    {
                        bobs[i].DrawWithoutParachute();
                    } else
                    {
                        bobs[i].DrawWithParachute();
                    }
                    for (int j = 0; j < bobs.Count; j++) {
                        if (bobs[j].XPosition >= bobs[i].XPosition - 3 && bobs[j].XPosition <= bobs[i].XPosition + 3 && bobs[j].counter != bobs[i].counter)
                        {
                            if (bobs[j].YPosition == (Config.SCREEN_HEIGHT - 14)){
                                bobs.Remove(bobs[i]);
                            }
                        }
                    }
                }

                //temporiser
                Thread.Sleep(100);
            }

            Console.ReadLine();
        }
    }
}
