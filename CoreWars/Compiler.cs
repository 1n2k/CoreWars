using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace CoreWars
{
    namespace IO
    {
        class Compiler
        {
			///The standards
            public enum Standard
            {
				/// <summary>
				/// The '88 Standard.
				/// </summary>
                _88 = 0,
				/// <summary>
				/// The '94 standard.
				/// </summary>
                _94 = 1
            }
			/// <summary>
			/// Parses the code file.
			/// </summary>
			/// <returns>
			/// The parsed code file.
			/// </returns>
			/// <param name='path'>
			/// The Path.
			/// </param>
			/// <param name='standard'>
			/// The Standard.
			/// </param>
            public static Engine.Player ParseCodeFile(string path, Standard standard)
            {
                string playername = "< Kein Name >";
                List<Engine.Cell> code = new List<Engine.Cell>();

                using (StreamReader sr = new StreamReader(path))
                    while (!sr.EndOfStream)
                    {
                        string ac = sr.ReadLine();
                        ac.TrimStart(' ');
                        if (ac == "")
                            continue;

                        if (ac[0] == ';') // Is Comment
                        {

                            continue;
                        }
                        Engine.Cell acCodeCell = new Engine.Cell();
                        //Additional Code here...

                    }

                return new Engine.Player(playername, code);
            }
        }
    }
}
