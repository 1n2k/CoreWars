using System;
using System.Collections.Generic;

namespace CoreWars
{
    namespace Engine
    {
        /// <summary>
        /// The single game.
        /// </summary>
        public class Game
        {
            /// <summary>
            /// The lazy instance of the Game.
            /// </summary>
            private static Lazy<Game> lazy =
                new Lazy<Game>(() => new Game());
            /// <summary>
            /// Gets the instance of the game.
            /// </summary>
            /// <value>
            /// The single game.
            /// </value>
            public static Game game { get { return lazy.Value; } }

            /// <summary>
            /// The players participating.
            /// </summary>
            private List<Player> players;
            /// <summary>
            /// The memory operating on.
            /// </summary>
            private List<Cell> memory = new List<Cell>();

            /// <summary>
            /// Initialize the game.
            /// </summary>
            /// <param name='players'>
            /// Players participating.
            /// </param>
            public void initialize(List<Player> players)
            {
                this.memory.Clear();
                this.players.Clear();

                this.players = players;
                for (int i = 0; i < Settings.MEMORYSIZE; i++)
                    memory.Add(new Cell());
                for (int i = 0; i < this.players.Count; i++)
                {
                    int offset = Settings.getInitialPosition(i);
                    for (int j = 0; j < this.players[i].code.Count; j++)
                        this.memory[offset + j] = this.players[i].code[j]; //Copy over player's code

                }
            }

            /// <summary>
            /// Gets or sets the <see cref="CoreWars.Game"/> at the specified index.
            /// </summary>
            /// <param name='index'>
            /// Index.
            /// </param>
            public Cell this[int index]
            {
                get
                {
                    return memory[index];
                }
                set
                {
                    memory[index] = value;
                }
            }

            private Game() { }
        }
    }
}
