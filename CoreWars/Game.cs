using System;
using System.Collections.Generic;

namespace CoreWars
{
    namespace Engine
    {
		/// <summary>
		/// Memory cell changed event handler.
		/// </summary>
        public delegate void MemoryCellChangedEventHandler(object sender, MemoryCellChangedEventArgs e);
        /// <summary>
        /// Memory cell changed event arguments.
        /// </summary>
		public class MemoryCellChangedEventArgs : EventArgs
        {
			/// <summary>
			/// The index of the cell.
			/// </summary>
            public readonly int CellIndex;

            internal MemoryCellChangedEventArgs(int cellIndex)
            {
                this.CellIndex = cellIndex;
            }
        }

		/// <summary>
		/// Game started event handler.
		/// </summary>
        public delegate void GameStartedEventHandler(object sender, TurnStartedEventArgs e);
        /// <summary>
        /// Turn started event handler.
        /// </summary>
		public delegate void TurnStartedEventHandler(object sender, TurnStartedEventArgs e);
        /// <summary>
        /// Turn started event arguments.
        /// </summary>
		public class TurnStartedEventArgs : EventArgs
        {
			/// <summary>
			/// The actual player.
			/// </summary>
            public readonly Player ActualPlayer;
            /// <summary>
            /// The round.
            /// </summary>
			public readonly int Round;

            internal TurnStartedEventArgs(Player player, int round)
            {
                this.Round = round;
                this.ActualPlayer = player;
            }
        }

		/// <summary>
		/// Player died event handler.
		/// </summary>
        public delegate void PlayerDiedEventHandler(object sender, ObjectDiedEventArgs<Player> e);
        /// <summary>
        /// Core died event handler.
        /// </summary>
		public delegate void CoreDiedEventHandler(object sender, ObjectDiedEventArgs<Core> e);
        /// <summary>
        /// Object died event arguments.
        /// </summary>
		public class ObjectDiedEventArgs<T> : EventArgs
        {
			/// <summary>
			/// The object.
			/// </summary>
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

			/// <summary>
			/// Gets the turn count.
			/// </summary>
			/// <value>
			/// The turn count.
			/// </value>
            public int TurnCount { get; private set; }

			/// <summary>
			/// Gets a value indicating whether this <see cref="CoreWars.Engine.Game"/> follows the new standard.
			/// </summary>
			/// <value>
			/// <c>true</c> if new standard; otherwise, <c>false</c>.
			/// </value>
            public bool NewStandard { get; private set; }
            #endregion

            #region Events
			/// <summary>
			/// Occurs when memory cell changed.
			/// </summary>
            public event MemoryCellChangedEventHandler MemoryCellChanged;
			/// <summary>
			/// Raises the memory cell change event.
			/// </summary>
			/// <param name='e'>
			/// E.
			/// </param>
            protected virtual void OnMemoryCellChange(MemoryCellChangedEventArgs e)
            {
                if (this.MemoryCellChanged != null)
                    this.MemoryCellChanged(this, e);
            }

			/// <summary>
			/// Occurs when turn started.
			/// </summary>
            public event TurnStartedEventHandler TurnStarted;
			/// <summary>
			/// Raises the turn start event.
			/// </summary>
			/// <param name='e'>
			/// E.
			/// </param>
            protected virtual void OnTurnStart(TurnStartedEventArgs e)
            {
                if (this.TurnStarted != null)
                    this.TurnStarted(this, e);
            }

			/// <summary>
			/// Occurs when game started.
			/// </summary>
            public event GameStartedEventHandler GameStarted;
			/// <summary>
			/// Raises the game start event.
			/// </summary>
			/// <param name='e'>
			/// E.
			/// </param>
            protected virtual void OnGameStart(TurnStartedEventArgs e)
            {
                if (this.GameStarted != null)
                    this.GameStarted(this, e);
            }

			/// <summary>
			/// Occurs when player died.
			/// </summary>
            public event PlayerDiedEventHandler PlayerDied;
			/// <summary>
			/// Raises the player dead event.
			/// </summary>
			/// <param name='e'>
			/// E.
			/// </param>
            protected virtual void OnPlayerDead(ObjectDiedEventArgs<Player> e)
            {
                if (this.PlayerDied != null)
                    this.PlayerDied(this, e);
            }
			/// <summary>
			/// Occurs when core died.
			/// </summary>
            public event CoreDiedEventHandler CoreDied;
			/// <summary>
			/// Raises the core dead event.
			/// </summary>
			/// <param name='e'>
			/// E.
			/// </param>
            protected virtual void OnCoreDead(ObjectDiedEventArgs<Core> e)
            {
                if (this.CoreDied != null)
                    this.CoreDied(this, e);
            }

            #endregion

            /// <summary>
            /// Initialize the specified players and newStandard.
            /// </summary>
            /// <param name='players'>
            /// The participating Players.
            /// </param>
            /// <param name='newStandard'>
			/// Specifies whether the new standard's rules should apply.
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

			/// <summary>
			/// Simulates the next turn.
			/// </summary>
			/// <returns>
			/// <c>true</c> if turn completed succesfully.
			/// </returns>
            public bool SimulateNextTurn()
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
            /// Gets or sets the <see cref="CoreWars.Engine.Game"/> at the specified index.
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
