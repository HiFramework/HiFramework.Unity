using System;
using System.Collections.Generic;
namespace HiFramework
{
    public class Facade
    {
        private static ICommand mediator;
        public static ICommand Mediator
        {
            get
            {
                if (mediator == null)
                    mediator = new Mediator();
                return mediator;
            }
        }
        private static ITick gameWorld;
        public static ITick GameWorld
        {
            get
            {
                if (gameWorld == null)
                    gameWorld = new GameTick();
                return gameWorld;
            }
        }
    }
}