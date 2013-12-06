using System;

namespace CoreWars
{
    namespace Engine
    {
        /// <summary>
        /// Core.
        /// </summary>
        public class Core
        {
            /// <summary>
            /// The owner.
            /// </summary>
            public readonly Player Owner;

            private int Position;

            /// <summary>
            /// Initializes a new instance of the <see cref="CoreWars.Core"/> class.
            /// </summary>
            /// <param name='player'>
            /// The owning player.
            /// </param>
            /// <param name='startposition'>
            /// The startposition of the core.
            /// </param>
            public Core(Player player, int startposition)
            {
                this.Owner = player;
                this.Position = startposition;
            }

            /// <summary>
            /// Runs the cell the core is pointing at.
            /// </summary>
            /// <returns>
            /// True if the core survived.
            /// </returns>
            public bool RunActualCell()
            {
                Game game = Game.GetGame;

                //Normalise A-Field
                int AField = (this.Position + game[this.Position].Arguments[0].Value + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;
                if (game[this.Position].Arguments[0].Specifier == '@')
                    AField = (this.Position + game[AField].Arguments[1].Value + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;
                else if (game[this.Position].Arguments[0].Specifier == '<')
                    AField = (this.Position + --game[AField].Arguments[1].Value + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;
                //'94Std:
                else if (game[this.Position].Arguments[0].Specifier == '{')
                    AField = (this.Position + --game[AField].Arguments[0].Value + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;
                else if (game[this.Position].Arguments[0].Specifier == '>')
                    AField = (this.Position + game[AField].Arguments[1].Value++ + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;
                else if (game[this.Position].Arguments[0].Specifier == '}')
                    AField = (this.Position + game[AField].Arguments[0].Value++ + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;

                else if (game[this.Position].Arguments[0].Specifier == '*')
                    AField = (this.Position + game[AField].Arguments[0].Value + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;

                //Normalise B-Field
                int BField = (this.Position + game[this.Position].Arguments[1].Value + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;
                if (game[this.Position].Arguments[1].Specifier == '@')
                    BField = (this.Position + game[BField].Arguments[1].Value + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;
                else if (game[this.Position].Arguments[1].Specifier == '<')
                    BField = (this.Position + --game[BField].Arguments[1].Value + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;
                //'94Std:
                else if (game[this.Position].Arguments[0].Specifier == '{')
                    BField = (this.Position + --game[BField].Arguments[0].Value + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;
                else if (game[this.Position].Arguments[0].Specifier == '>')
                    BField = (this.Position + game[BField].Arguments[1].Value++ + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;
                else if (game[this.Position].Arguments[0].Specifier == '}')
                    BField = (this.Position + game[BField].Arguments[0].Value++ + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;

                else if (game[this.Position].Arguments[0].Specifier == '*')
                    BField = (this.Position + game[BField].Arguments[0].Value + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;


                switch (game[this.Position].Operation)
                {
                    //opcodes here
                    case "DAT":
                        return false;
                    case "MOV":
                        if (game[this.Position].Arguments[0].Specifier == '#')
                            game[BField].Arguments[1] = game[this.Position].Arguments[0];
                        else
                            game[BField] = game[AField];
                        break;
                    case "ADD":
                        if (game[this.Position].Arguments[0].Specifier == '#')
                            game[BField].Arguments[1].Value += game[this.Position].Arguments[0].Value;
                        else
                            foreach (int i in new[] { 0, 1 })
                                game[BField].Arguments[i].Value += game[AField].Arguments[i].Value;
                        break;
                    case "SUB":
                        if (game[this.Position].Arguments[0].Specifier == '#')
                            game[BField].Arguments[1].Value -= game[this.Position].Arguments[0].Value;
                        else
                            foreach (int i in new[] { 0, 1 })
                                game[BField].Arguments[i].Value -= game[AField].Arguments[i].Value;
                        break;
                    case "JMP":
                        this.Position = AField;
                        return true;
                    case "JMZ":
                        if (game[BField].Arguments[1].Value == 0)
                            this.Position = AField;
                        return true;
                    case "JMN":
                        if (game[BField].Arguments[1].Value != 0)
                            this.Position = AField;
                        return true;
                    case "CMP":
                        if (game[this.Position].Arguments[0].Specifier == '#')
                        {
                            if (game[BField].Arguments[1].Value == game[this.Position].Arguments[0].Value)
                                this.Position++;
                        }
                        else
                            if (game[BField] == game[AField])
                                this.Position++;
                        break;
                    case "SLT":
                        if (game[this.Position].Arguments[0].Specifier == '#')
                        {
                            if (game[BField].Arguments[1].Value > game[this.Position].Arguments[0].Value)
                                this.Position++;
                        }
                        else
                            if (game[BField].Arguments[1].Value > game[AField].Arguments[1].Value)
                                this.Position++;
                        break;
                    case "DJN":
                        if (game[this.Position].Arguments[1].Specifier == '#')
                        {
                            if (game[this.Position].Arguments[1].Value > 1)
                                this.Position = AField;
                        }
                        else
                            if (game[BField].Arguments[1].Value > 1)
                                this.Position = AField;
                        return true;
                    case "SPL":
                        if (game[this.Position].Arguments[0].Specifier != '#')
                        {
                            if (this.Owner.CoreCount < Settings.MAXCORESPERPLAYER - 1)
                                this.Owner.StartCore(game[AField].Arguments[0].Value);
                        }
                        break;
                    case "NOP":
                        break;

                    //'94:
                    //case "MUL":
                    //    if (game[this.Position].Arguments[1].Specifier == '\0' && game[this.Position].Arguments[0].Specifier == '\0')
                    //        game[this.Position].Arguments[1].Value *= game[this.Position].Arguments[0].Value;
                    //    break;
                    //case "DIV":
                    //    if (game[this.Position].Arguments[1].Specifier == '\0' && game[this.Position].Arguments[0].Specifier == '\0')
                    //        game[this.Position].Arguments[1].Value /= game[this.Position].Arguments[0].Value;
                    //    break;
                    //case "MOD":
                    //    if (game[this.Position].Arguments[1].Specifier == '\0' && game[this.Position].Arguments[0].Specifier == '\0')
                    //        game[this.Position].Arguments[1].Value %= game[this.Position].Arguments[0].Value;
                    //    break;

                    default:
                        break;
                }
                this.Position = (this.Position + 1) % Settings.MAXCORESPERPLAYER;
                return true;
            }
        }
    }
}