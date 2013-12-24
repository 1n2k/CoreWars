using System;
using System.Collections.Generic;

using System.Diagnostics;

namespace CoreWars
{
    namespace Engine
    {
		namespace Simulator
		{
        /// <summary>
        /// A player.
        /// </summary>
	        public class Player
	        {
	            /// <summary>
	            /// The living cores owned by the player.
	            /// </summary>
	            Queue<Core> Cores = new Queue<Core>();

	            /// <summary>
	            /// The players RedCode.
	            /// </summary>
	            public readonly List<Cell> Code = new List<Cell>();
	            /// <summary>
	            /// Gets the name.
	            /// </summary>
	            /// <value>
	            /// The name.
	            /// </value>
	            public string Name { get; private set; }

	            /// <summary>
	            /// Gets the core count.
	            /// </summary>
	            /// <value>
	            /// The core count.
	            /// </value>
	            public int CoreCount { get; private set; }

				/// <summary>
				/// Gets the start index of the core.
				/// </summary>
				/// <value>
				/// The start index of the core.
				/// </value>
	            public int StartCoreIndex { get; private set; }

	            /// <summary>
	            /// Initializes a new instance of the <see cref="CoreWars.Engine.Player"/> class.
	            /// </summary>
	            /// <param name='name'>
	            /// Name.
	            /// </param>
	            /// <param name='code'>
	            /// Code.
	            /// </param>
	            /// <param name='startCoreIndex'>
	            /// Start core index.
	            /// </param>
	            public Player(string name, List<Cell> code,int startCoreIndex = 0)
	            {
	                this.Name = name;
	                this.Code = code;
	                this.CoreCount = 0;
	                this.StartCoreIndex = startCoreIndex;
	            }

	            /// <summary>
	            /// Starts a new core.
	            /// </summary>
	            /// <param name='position'>
	            /// Position of the new core.
	            /// </param>
	            public void StartCore(int position)
	            {
	                this.Cores.Enqueue(new Core(this, position));
	                this.CoreCount++;
	            }

	            /// <summary>
	            /// Gets the next core and dequeues it from the CoreQueue.
	            /// </summary>
	            /// <returns>
	            /// The next core.
	            /// </returns>
	            public Core GetNextCore()
	            {
	                Core c = this.Cores.Dequeue();
	                CoreCount--;
	                return c;
	            }

	            /// <summary>
	            /// Sets the last core.
	            /// </summary>
	            /// <param name='core'>
	            /// The core.
	            /// </param>
	            public void SetLastCore(Core core)
	            {
	                Debug.Assert(core.Owner == this);
	                CoreCount++;
	                this.Cores.Enqueue(core);
	            }
	        }
	    }
	}
}