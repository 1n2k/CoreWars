using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace CoreWars
{
    namespace IO
    {
        public class Compiler
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
                        ac = ac.Replace('\t', ' ').Replace(", ", ",").TrimStart(' ').TrimEnd(' ');

                        if (ac == "")
                            continue;

                        if (ac[0] == ';') // Is Comment
                        {
                            if (ac.StartsWith(";name"))  //;name = NAME
                                playername = ac.Split('=')[1].TrimStart(' ');
                            continue;
                        }
                        int i = 0; //Position im string

                        string operation = "";
                        Engine.Cell.Argument[] argument = new Engine.Cell.Argument[2];
                        for (; i < 3; i++)
                            operation += ac[i];

                        string modifier = "";
                        if (ac[i] == '.')
                        {
                            if (standard != Standard._94)
                                throw new InvalidOperationException("You're stupid! This file is not a valid '88 standard RedCode file!");
                            ++i;
                            modifier += ac[i++];
                            if (ac[i++] != ' ')
                                modifier += ac[i++];
                        }

                        System.Diagnostics.Debug.Assert(ac[i] == ' ');
                        for (int o = 0; o < 2; ++o)
                        {
                            if (i == ac.Length)
                            {
                                for (int u = o; u < 2; ++u)
                                {
                                    argument[u].Specifier = '#';
                                    argument[u].Value = 0;
                                }
                                break;
                            }
                            if (Engine.Cell.Argument.IsValidSpecifier(ac[++i], standard == Standard._94))
                                argument[o].Specifier = ac[i];
                            else
                            {
                                argument[o].Specifier = '$';
                                --i;
                            }

                            int value = 0;
                            int sgn = 1;
                            if (ac[++i] == '-')
                                sgn = -1;
                            else
                                --i;
                            while (++i < ac.Length && ac[i] != ',' && Char.IsDigit(ac[i]))
                            {
                                value *= 10;
                                value += ac[i] - '0';
                            }
                            argument[o].Value = (Engine.Settings.MEMORYSIZE+  sgn * value) % Engine.Settings.MEMORYSIZE;

                        }

                        code.Add(new Engine.Cell(operation, argument[0], argument[1]));
                    }

                return new Engine.Player(playername, code);
            }
        }
    }
}
