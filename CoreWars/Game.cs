using System;
using System.Collections.Generic;

namespace CoreWars
{
    namespace Engine
    {
        public delegate void MemoryCellChangedEventHandler(object sender, MemoryCellChangedEventArgs e);
        public class MemoryCellChangedEventArgs : EventArgs
        {
            public int CellIndex;

            public MemoryCellChangedEventArgs(int cellIndex)
            {
                this.CellIndex = cellIndex;
            }
        }

        /// <summary>
        /// The single game.
        /// </summary>
        public class Game
        {
            /// <summary>
            /// The lazy instance of the Game.
            /// </summary>
            private static Lazy<Game> Lazy =
                new Lazy<Game>(() => new Game());
            /// <summary>
            /// Gets the instance of the game.
            /// </summary>
            /// <value>
            /// The single game.
            /// </value>
            public static Game GetGame { get { return Lazy.Value; } }

            /// <summary>
            /// The players participating.
            /// </summary>
            private List<Player> Players;
            /// <summary>
            /// The memory operating on.
            /// </summary>
            private List<Cell> Memory = new List<Cell>();

            public event MemoryCellChangedEventHandler MemoryCellChanged;
            protected virtual void OnMemoryCellChange(MemoryCellChangedEventArgs e)
            {
                if (this.MemoryCellChanged != null)
                    this.MemoryCellChanged(this, e);
            }

            /// <summary>
            /// Initialize the game.
            /// </summary>
            /// <param name='players'>
            /// Players participating.
            /// </param>
            public void Initialize(List<Player> players)
            {
                this.Memory.Clear();
                this.Players.Clear();

                this.Players = players;
                for (int i = 0; i < Settings.MEMORYSIZE; i++)
                {
                    Memory.Add(new Cell());
                    OnMemoryCellChange(new MemoryCellChangedEventArgs(i));
                }
                for (int i = 0; i < this.Players.Count; i++)
                {
                    int offset = Settings.GetInitialPosition(i);
                    for (int j = 0; j < this.Players[i].Code.Count; j++)
                    {
                        this.Memory[offset + j] = this.Players[i].Code[j]; //Copy over player's code
                        OnMemoryCellChange(new MemoryCellChangedEventArgs(offset + j));
                    }
                }
            }

            public bool SimulateNextStep()
            {
                Player nextPlayer = Players[0];
                Players.RemoveAt(0);
                Core nextCore = nextPlayer.GetNextCore();
                if (!nextCore.RunActualCell() && nextPlayer.CoreCount == 0) //Actual Players's last Core died.
                    return false;
                nextPlayer.SetLastCore(nextCore);
                Players.Add(nextPlayer);
                return true;
            }

            /// <summary>
            /// Gets or sets the <see cref="CoreWars.Game"/> at the specified index.
            /// </summary>
            /// <param name='index'>
            /// Index.
            /// </param>
            public Cell this[int index]
            {
                get { return Memory[index]; }
                set
                {
                    Memory[index] = value;
                    OnMemoryCellChange(new MemoryCellChangedEventArgs(index));
                }
            }

            private Game() { }
        }
    }
}
