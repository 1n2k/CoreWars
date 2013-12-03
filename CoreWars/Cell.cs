using System;

namespace CoreWars
{
	/// <summary>
	/// A memory cell.
	/// </summary>
	public struct Cell
	{
		/// <summary>
		/// Gets the opcode.
		/// </summary>
		/// <value>
		/// The opcode.
		/// </value>
		public string opcode{ get; private set; }
		/// <summary>
		/// Gets the first argument.
		/// </summary>
		/// <value>
		/// The first arg.
		/// </value>
		public int arg1 { get; private set; }
		/// <summary>
		/// Gets the second argument.
		/// </summary>
		/// <value>
		/// The second arg.
		/// </value>
		public int arg2 { get; private set; }
	}
}

