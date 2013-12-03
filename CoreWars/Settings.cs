using System;

namespace CoreWars
{
	/// <summary>
	/// Settings for a game.
	/// </summary>
	public static class Settings
	{
		/// <summary>
		/// The MEMORYSIZE of a game.
		/// </summary>
		public static int MEMORYSIZE = 1000;

		/// <summary>
		/// Gets the initial position for a player's code.
		/// </summary>
		/// <returns>
		/// The initial position.
		/// </returns>
		/// <param name='player'>
		/// The number of the player.
		/// </param>
		public static int getInitialPosition (int player)
		{
			return (101*player)%MEMORYSIZE;
		}
	}
}

