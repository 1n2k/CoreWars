using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace CoreWars
{
    namespace Engine{
        namespace IO
        {
            /// <summary>
            /// Compiler.
            /// </summary>
            public class Compiler
            {
                static int op(char c, int i1, int i2)
                {
                    switch (c)
                    {
                        case '+':
                            return i1 + i2;
                        case '-':
                            return i1 - i2;
                        case '*':
                            return i1 * i2;
                        case '/':
                            return i1 / i2;
                    }
                    return 1;
                }

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
                public static Simulator.Player ParseCodeFile(string path, Standard standard)
                {
                    using (StreamReader sr = new StreamReader(path))
                        return Compiler.ParseCodeFile(sr.ReadToEnd().Split('\n'), standard);
                }
                /// <summary>
                /// Parses the code file.
                /// </summary>
                /// <returns>
                /// The parsed code file.
                /// </returns>
                /// <param name='file'>
                /// The File.
                /// </param>
                /// <param name='standard'>
                /// The Standard.
                /// </param>
                /// <param name='playername'>
                /// The Playername.
                /// </param>
                public static Simulator.Player ParseCodeFile(string[] file, Standard standard ,string playername = "< Kein Name >")
                {
                    int startIndex = 0;
                    List<Simulator.Cell> code = new List<Simulator.Cell>();
                    Dictionary<string, string> labels = new Dictionary<string, string>();

                    int redcodestart = -1;
                    for (int i = 0; i < file.Length; i++)
                    {
                        if (file[i].StartsWith(";redcode"))
                        {
                            if (file[i] == ";redcode-94" && standard != Standard._94)
                                throw new InvalidOperationException("Der Code ist kein gültiger '88er Standard redcode File");
                            redcodestart = i;
                            break;
                        }
                    }

                    if (redcodestart == -1)
                        redcodestart = 0;

                    for (int linenum = redcodestart,cnt = 0; linenum < file.Length ; linenum++)
                    {
                        string ac = file[linenum];
                        ac = ac.Replace('\t', ' ').Replace(", ", ",").TrimStart(' ').TrimEnd(' ');

                        if (ac == "")
                            continue;
                        if(ac.ToUpper().Contains("EQU") && (!ac.Contains(';') || (ac.IndexOf("EQU") > ac.IndexOf(':'))))
                            labels[ac.Split(':')[0]] = ac.Substring(ac.ToUpper().IndexOf(':') + 5);
                        if (ac.Contains(':') && (!ac.Contains(';') || (ac.IndexOf(';') > ac.IndexOf(':'))))
                            labels[ac.Split(':')[0]] = "" + (cnt ++);
                    }

                    for (int linenum = redcodestart; linenum < file.Length; linenum++)
                    {
                        string ac = file[linenum];
                        ac = ac.Replace('\t', ' ').Replace("\r","").Replace(", ", ",").TrimStart(' ').TrimEnd(' ');

                        if (ac == "")
                            continue;
                        if (ac.Contains(':') && (!ac.Contains(';') || (ac.IndexOf(';') > ac.IndexOf(':'))))
                            ac = ac.Split(':')[1].TrimStart(' ').TrimEnd(' ');

                        if (ac[0] == ';') // Is Comment
                        {
                            if (ac.StartsWith(";author"))  //;name = NAME
                                playername = ac.Split('=')[1].TrimStart(' ');
                            continue;
                        }

                        foreach (string item in labels.Keys)
                            ac = ac.Replace(item, labels[item]);

                        //System.Diagnostics.Debug.WriteLine(ac);

                        foreach(char c in new []{'+','-','*','/'})
                            ac = Regex.Replace(ac, @"[0-9]+\" + c + @"[0-9]+", (Match M) =>
                                "" + op(c,Convert.ToInt32(M.Value.Split(c)[0]), Convert.ToInt32(M.Value.Split(c)[1])));
                        
                        //System.Diagnostics.Debug.WriteLine(ac);

                        int i = 0; //Position im string

                        string operation = "";
                        Simulator.Cell.Argument[] argument = new Simulator.Cell.Argument[2];
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

                        //System.Diagnostics.Debug.Assert(ac[i] == ' ');
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
                            if (Simulator.Cell.Argument.IsValidSpecifier(ac[++i], standard == Standard._94))
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
                            argument[o].Value = (Engine.Simulator.Settings.MEMORYSIZE + sgn * value) % Engine.Simulator.Settings.MEMORYSIZE;

                        }


                        if (operation == "org")
                        {
                            startIndex = argument[0].Value;
                            continue;
                        }
                        if(operation == "EQU")
                            continue;
                        //System.Diagnostics.Debug.WriteLine(new Simulator.Cell(operation, argument[0], argument[1]).ToString());
                        code.Add(new Simulator.Cell(operation.ToUpper(), argument[0], argument[1]));
                    }
                    return new Simulator.Player(playername, code, startIndex);
                }
            }
        }
    }
}