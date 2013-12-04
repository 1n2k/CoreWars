using System;

namespace CoreWars
{
    namespace Engine
    {
        /// <summary>
        /// Core.
        /// </summary>
        public class Core
        {
            /// <summary>
            /// The owner.
            /// </summary>
            public readonly Player owner;

            int position;

            /// <summary>
            /// Initializes a new instance of the <see cref="CoreWars.Core"/> class.
            /// </summary>
            /// <param name='player'>
            /// The owning player.
            /// </param>
            /// <param name='startposition'>
            /// The startposition of the core.
            /// </param>
            public Core(Player player, int startposition)
            {
                this.owner = player;
                this.position = startposition;
            }

            /// <summary>
            /// Runs the cell the core is pointing at.
            /// </summary>
            /// <returns>
            /// True if the core survived.
            /// </returns>
            public bool runActualCell()
            {
                Game game = Game.game;
                switch (game[this.position].opcode)
                {
                    //opcodes here
                    case "JMP":

                    case "NOP":
                    default:
                        break;
                }
                return true;
            }
        }
    }
}