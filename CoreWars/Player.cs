using System;
using System.Collections.Generic;

using System.Diagnostics;

namespace CoreWars
{
	/// <summary>
	/// A player.
	/// </summary>
	public class Player
	{
		/// <summary>
		/// The living cores owned by the player.
		/// </summary>
		Queue<Core> cores = new Queue<Core>();

		/// <summary>
		/// The players RedCode.
		/// </summary>
		public readonly List<Cell> code = new List<Cell>();
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string name { get; private set; } 

		/// <summary>
		/// Initializes a new instance of the <see cref="CoreWars.Player"/> class.
		/// </summary>
		/// <param name='name'>
		/// The player's name.
		/// </param>
		/// <param name='code'>
		/// The player's code.
		/// </param>
		public Player (string name, List<Cell> code)
		{
			this.name = name;
			this.code = code;
		}

		/// <summary>
		/// Starts a new core.
		/// </summary>
		/// <param name='position'>
		/// Position of the new core.
		/// </param>
		public void startCore (int position)
		{
			this.cores.Enqueue(new Core(this,position));
		}

		/// <summary>
		/// Gets the next core and dequeues it from the CoreQueue.
		/// </summary>
		/// <returns>
		/// The next core.
		/// </returns>
		public Core getNextCore ()
		{
			Core c = this.cores.Dequeue();
			return c;
		}

		/// <summary>
		/// Sets the last core.
		/// </summary>
		/// <param name='core'>
		/// The core.
		/// </param>
		public void setLastCore (Core core)
		{
			Debug.Assert(core.owner == this);
			this.cores.Enqueue(core);
		}
	}
}

