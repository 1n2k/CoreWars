using System;

namespace CoreWars
{
    namespace Engine
    {
        /// <summary>
        /// Settings for a game.
        /// </summary>
        public static class Settings
        {
            /// <summary>
            /// The MEMORYSIZE of a game.
            /// </summary>
            public static int MEMORYSIZE = 8000;

            /// <summary>
            /// The MAXCORESPERPLAYER.
            /// </summary>
            public static int MAXCORESPERPLAYER = 100;

            /// <summary>
            /// The MAXLENGTH.
            /// </summary>
            public static int MAXLENGTH = 100;

            /// <summary>
            /// The MAXCYCLES.
            /// </summary>
            public static int MAXCYCLES = 100000;

            public static int CODEDISTANCE = 100;
            
            /// <summary>
            /// Gets the initial position for a player's code.
            /// </summary>
            /// <returns>
            /// The initial position.
            /// </returns>
            /// <param name='player'>
            /// The number of the player.
            /// </param>
            public static int GetInitialPosition(int player)
            {
                return ((CODEDISTANCE + MAXLENGTH) * player) % MEMORYSIZE;
            }
        }
    }
}
