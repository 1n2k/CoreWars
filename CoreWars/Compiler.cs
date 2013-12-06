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
            public enum Standard
            {
                _88 = 0,
                _94 = 1
            }
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
