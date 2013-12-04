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
                switch (game[this.Position].Operation)
                {
                    //opcodes here
                    case "DAT":
                        return false;
                    case "MOV":
                        game[(this.Position + game[this.Position].Arguments[0].Value) % Settings.MEMORYSIZE] = game[this.Position];
                        break;
                    case "ADD":
                        if (game[this.Position].Arguments[1].Specifier == '#' && game[this.Position].Arguments[0].Specifier == '#')
                            game[this.Position].Arguments[1].Value += game[this.Position].Arguments[0].Value;
                        break;
                    case "SUB":
                        if (game[this.Position].Arguments[1].Specifier == '#' && game[this.Position].Arguments[0].Specifier == '#')
                            game[this.Position].Arguments[1].Value -= game[this.Position].Arguments[0].Value;
                        break;
                    case "JMP":
                        this.Position = (this.Position + game[this.Position].Arguments[0].Value) % Settings.MEMORYSIZE;
                        return true;
                    case "JMZ":
                        if (game[this.Position].Arguments[1].Value == 0)
                            this.Position = (this.Position + game[this.Position].Arguments[0].Value) % Settings.MEMORYSIZE;
                        return true;
                    case "JMN":
                        if (game[this.Position].Arguments[1].Value != 0)
                            this.Position = (this.Position + game[this.Position].Arguments[0].Value) % Settings.MEMORYSIZE;
                        return true;
                    case "CMP":
                        if (game[this.Position].Arguments[1].Value == game[this.Position].Arguments[0].Value)
                            this.Position++;
                        break;
                    case "SLT":
                        if (game[this.Position].Arguments[1].Value > game[this.Position].Arguments[0].Value)
                            this.Position++;
                        break;
                    case "DJN":
                        if (--game[this.Position].Arguments[1].Value != 0)
                            this.Position = (this.Position + game[this.Position].Arguments[0].Value) % Settings.MEMORYSIZE;
                        return true;
                    case "SPL":
                        if (game[this.Position].Arguments[0].Specifier == '\0')
                        {
                            this.Owner.StartCore(game[this.Position].Arguments[0].Value);
                            if (this.Owner.CoreCount == Settings.MAXCORESPERPLAYER)
                                return false;
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
                this.Position++;
                return true;
            }
        }
    }
}