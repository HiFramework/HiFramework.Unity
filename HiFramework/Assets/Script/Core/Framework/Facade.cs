using System;
using System.Collections.Generic;
namespace HiFramework
{
    public class Facade
    {
        private static IMediator mediator;
        public static IMediator Mediator
        {
            get
            {
                if (mediator == null)
                    mediator = new Mediator();
                return mediator;
            }
        }
        private static ITick gameTick;
        public static ITick GameTick
        {
            get
            {
                if (gameTick == null)
                    gameTick = new GameTick();
                return gameTick;
            }
        }
    }
}