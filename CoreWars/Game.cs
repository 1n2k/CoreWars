using System;
using System.Collections.Generic;

namespace CoreWars
{
    namespace Engine
    {
        public delegate void MemoryCellChangedEventHandler(object sender, MemoryCellChangedEventArgs e);
        public class MemoryCellChangedEventArgs : EventArgs
        {
            public readonly int CellIndex;

            internal MemoryCellChangedEventArgs(int cellIndex)
            {
                this.CellIndex = cellIndex;
            }
        }

        public delegate void GameStartedEventHandler(object sender, TurnStartedEventArgs e);
        public delegate void TurnStartedEventHandler(object sender, TurnStartedEventArgs e);
        public class TurnStartedEventArgs : EventArgs
        {
            public readonly Player ActualPlayer;
            public readonly int Round;

            internal TurnStartedEventArgs(Player player, int round)
            {
                this.Round = round;
                this.ActualPlayer = player;
            }
        }

        public delegate void PlayerDiedEventHandler(object sender, ObjectDiedEventArgs<Player> e);
        public delegate void CoreDiedEventHandler(object sender, ObjectDiedEventArgs<Core> e);
        public class ObjectDiedEventArgs<T> : EventArgs
        {
            public readonly T Object;

            internal ObjectDiedEventArgs(T dyingObject)
            {
                this.Object = dyingObject;
            }
        }


        /// <summary>
        /// The single game.
        /// </summary>
        public class Game
        {
            #region Fields
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
            private List<Player> Players = new List<Player>();
            /// <summary>
            /// The memory operating on.
            /// </summary>
            private List<Cell> Memory = new List<Cell>();

            public int TurnCount { get; private set; }

            public bool NewStandard { get; private set; }
            #endregion

            #region Events
            public event MemoryCellChangedEventHandler MemoryCellChanged;
            protected virtual void OnMemoryCellChange(MemoryCellChangedEventArgs e)
            {
                if (this.MemoryCellChanged != null)
                    this.MemoryCellChanged(this, e);
            }

            public event TurnStartedEventHandler TurnStarted;
            protected virtual void OnTurnStart(TurnStartedEventArgs e)
            {
                if (this.TurnStarted != null)
                    this.TurnStarted(this, e);
            }

            public event GameStartedEventHandler GameStarted;
            protected virtual void OnGameStart(TurnStartedEventArgs e)
            {
                if (this.GameStarted != null)
                    this.GameStarted(this, e);
            }

            public event PlayerDiedEventHandler PlayerDied;
            protected virtual void OnPlayerDead(ObjectDiedEventArgs<Player> e)
            {
                if (this.PlayerDied != null)
                    this.PlayerDied(this, e);
            }
            public event CoreDiedEventHandler CoreDied;
            protected virtual void OnCoreDead(ObjectDiedEventArgs<Core> e)
            {
                if (this.CoreDied != null)
                    this.CoreDied(this, e);
            }

            #endregion

            /// <summary>
            /// Initialize the game.
            /// </summary>
            /// <param name='players'>
            /// Players participating.
            /// </param>
            public void Initialize(List<Player> players, bool newStandard = false)
            {
                this.Memory.Clear();
                this.Players.Clear();
                this.NewStandard = newStandard;

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
                    this.Players[i].StartCore(offset);
                }
            }

            public bool SimulateNextStep()
            {
                if (Players.Count == 0)
                    return false;
                Player nextPlayer = Players[0];
                Players.RemoveAt(0);

                if (this.TurnCount == 0)
                    OnGameStart(new TurnStartedEventArgs(nextPlayer, 1));
                OnTurnStart(new TurnStartedEventArgs(nextPlayer, ++this.TurnCount));

                Core nextCore = nextPlayer.GetNextCore();

                if (!nextCore.RunActualCell())
                {
                    OnCoreDead(new ObjectDiedEventArgs<Core>(nextCore));
                    if (nextPlayer.CoreCount == 0)//Actual Players's last Core died.
                    {
                        OnPlayerDead(new ObjectDiedEventArgs<Player>(nextPlayer));
                        return true;
                    }
                }
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
