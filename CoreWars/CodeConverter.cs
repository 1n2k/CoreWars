using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace CoreWars
{
    namespace CodeGen
    {
        class CodeConverter
        {
            public static Engine.Player ParseCodeFile(string filename)
            {
                string playername = "< Kein Name >";
                List<Engine.Cell> code = new List<Engine.Cell>();

                using (StreamReader sr = new StreamReader(filename))
                {
                    while (!sr.EndOfStream)
                    {
                        string ac = sr.ReadLine();
                        ac.TrimStart(' ');
                        if (ac == "")
                            continue;

                        if (ac[0] == ';') // Ist Kommentar
                        {
                        }
                    }
                }

                return new Engine.Player(playername, code);
            }
        }
    }
}
