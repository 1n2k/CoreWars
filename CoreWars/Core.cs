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
            /// Initializes a new instance of the <see cref="CoreWars.Engine.Core"/> class.
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
            /// If the Cell's opcode does not contain a specifier, no conversion takes place;
            /// instead the '88 standard's rules are being used to evaluate the expression.
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
                    AField = (this.Position -1 + game[AField].Arguments[1].Value + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;
                //'94Std:
                else if (game[this.Position].Arguments[0].Specifier == '{')
                    AField = (this.Position - 1 + game[AField].Arguments[0].Value + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;
                else if (game[this.Position].Arguments[0].Specifier == '>')
                    AField = (this.Position + game[AField].Arguments[1].Value+1 + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;
                else if (game[this.Position].Arguments[0].Specifier == '}')
                    AField = (this.Position + game[AField].Arguments[0].Value+1 + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;

                else if (game[this.Position].Arguments[0].Specifier == '*')
                    AField = (this.Position + game[AField].Arguments[0].Value + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;

                //Normalise B-Field
                int BField = (this.Position + game[this.Position].Arguments[1].Value + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;
                if (game[this.Position].Arguments[1].Specifier == '@')
                    BField = (this.Position + game[BField].Arguments[1].Value + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;
                else if (game[this.Position].Arguments[1].Specifier == '<')
                    BField = (this.Position - 1 +game[BField].Arguments[1].Value + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;
                //'94Std:
                else if (game[this.Position].Arguments[0].Specifier == '{')
                    BField = (this.Position - 1 +game[BField].Arguments[0].Value + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;
                else if (game[this.Position].Arguments[0].Specifier == '>')
                    BField = (this.Position + game[BField].Arguments[1].Value+1 + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;
                else if (game[this.Position].Arguments[0].Specifier == '}')
                    BField = (this.Position + game[BField].Arguments[0].Value+1 + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;

                else if (game[this.Position].Arguments[0].Specifier == '*')
                    BField = (this.Position + game[BField].Arguments[0].Value + Settings.MEMORYSIZE) % Settings.MEMORYSIZE;

                //System.Diagnostics.Debug.WriteLine("AField {0}, BField {1}, @Position {2}", AField, BField, this.Position);

                switch (game[this.Position].Operation)
                {
                    //opcodes here
                    case "DAT":
                        return false;
                    #region MOV
                    case "MOV":
                        if (game[this.Position].Modifier == "")
                        {
                            if (game[this.Position].Arguments[0].Specifier == '#')
                                game[BField].Arguments[1] = game[this.Position].Arguments[0];
                            else
                                game[BField] = game[AField];
                        }
                        else if(game[this.Position].Modifier == "A" || game[this.Position].Modifier == "F"){						
                            if (game[this.Position].Arguments[0].Specifier == '#')
                                game[BField].Arguments[0] = game[this.Position].Arguments[0];
                            else
                                game[BField].Arguments[0] = game[AField].Arguments[0];
                        }
                        else if(game[this.Position].Modifier == "B" || game[this.Position].Modifier == "F"){					
                            if (game[this.Position].Arguments[1].Specifier == '#')
                                game[BField].Arguments[1] = game[this.Position].Arguments[1];
                            else
                                game[BField].Arguments[1] = game[AField].Arguments[1];
                        }
                        else if(game[this.Position].Modifier == "AB" || game[this.Position].Modifier == "X"){											
                            if (game[this.Position].Arguments[0].Specifier == '#')
                                game[BField].Arguments[1] = game[this.Position].Arguments[0];
                            else
                                game[BField].Arguments[1] = game[AField].Arguments[0];
                        }
                        else if(game[this.Position].Modifier == "BA" || game[this.Position].Modifier == "X"){					
                            if (game[this.Position].Arguments[1].Specifier == '#')
                                game[BField].Arguments[0] = game[this.Position].Arguments[1];
                            else
                                game[BField].Arguments[0] = game[AField].Arguments[1];
                        }
                        else if(game[this.Position].Modifier == "I"){
                            game[BField] = game[AField];
                        }
                        break;
                    #endregion
                    case "JMP":
                        this.Position = AField;
                        return true;
                    #region JMZ
                    case "JMZ":
                        if (game[this.Position].Modifier == "" || game[this.Position].Modifier == "B" || game[this.Position].Modifier == "AB")
                        {
                            if (game[BField].Arguments[1].Value == 0){
                                this.Position = AField;
                                return true;
                            }
                        }
                        else if (game[this.Position].Modifier == "A" || game[this.Position].Modifier == "BA")
                        {
                            if (game[BField].Arguments[0].Value == 0){
                                this.Position = AField;
                                return true;
                            }
                        }
                        else if (game[this.Position].Modifier == "F" || game[this.Position].Modifier == "X" || game[this.Position].Modifier == "I")
                        {
                            if (game[BField].Arguments[0].Value == 0 && game[BField].Arguments[1].Value == 0){
                                this.Position = AField;
                                return true;
                            }
                        }
                        break;
                    #endregion
                    #region JMN
                    case "JMN":
                        if (game[this.Position].Modifier == "" || game[this.Position].Modifier == "B" || game[this.Position].Modifier == "AB")
                        {
                            if (game[BField].Arguments[1].Value != 0){
                                this.Position = AField;
                                return true;
                            }
                        }
                        else if (game[this.Position].Modifier == "A" || game[this.Position].Modifier == "BA")
                        {
                            if (game[BField].Arguments[0].Value != 0){
                                this.Position = AField;
                                return true;
                            }
                        }
                        else if (game[this.Position].Modifier == "F" || game[this.Position].Modifier == "X" || game[this.Position].Modifier == "I")
                        {
                            if ((game[BField].Arguments[0].Value != 0) || (game[BField].Arguments[1].Value != 0)){
                                this.Position = AField;
                                return true;
                            }
                        }
                        break;
                    #endregion
                    #region CMP / SEQ
                    case "CMP":
                        goto case "SEQ";
                    case "SEQ":
                        if (game[this.Position].Modifier == "")
                        {
                            if (game[this.Position].Arguments[0].Specifier == '#')
                            {
                                if (game[BField].Arguments[1].Value == game[this.Position].Arguments[0].Value)
                                    this.Position++;
                            }
                            else
                                if (game[BField] == game[AField])
                                    this.Position++;
                        }
                        else if (game[this.Position].Modifier == "A")
                        {
                            if (game[this.Position].Arguments[0].Specifier == '#')
                            {
                                if (game[BField].Arguments[0].Value == game[this.Position].Arguments[0].Value)
                                    this.Position++;
                            }
                            else
                                if (game[BField].Arguments[0].Value == game[AField].Arguments[0].Value)
                                    this.Position++;
                        }
                        else if (game[this.Position].Modifier == "B")
                        {
                            if (game[this.Position].Arguments[1].Specifier == '#')
                            {
                                if (game[BField].Arguments[1].Value == game[this.Position].Arguments[1].Value)
                                    this.Position++;
                            }
                            else
                                if (game[BField].Arguments[1].Value == game[AField].Arguments[1].Value)
                                    this.Position++;
                        }
                        else if (game[this.Position].Modifier == "AB")
                        {
                            if (game[this.Position].Arguments[0].Specifier == '#')
                            {
                                if (game[BField].Arguments[1].Value == game[this.Position].Arguments[0].Value)
                                    this.Position++;
                            }
                            else
                                if (game[BField].Arguments[1].Value == game[AField].Arguments[0].Value)
                                    this.Position++;
                        }					
                        else if (game[this.Position].Modifier == "BA")
                        {
                            if (game[this.Position].Arguments[1].Specifier == '#')
                            {
                                if (game[BField].Arguments[0].Value == game[this.Position].Arguments[1].Value)
                                    this.Position++;
                            }
                            else
                                if (game[BField].Arguments[0].Value == game[AField].Arguments[1].Value)
                                    this.Position++;
                        }
                        else if (game[this.Position].Modifier == "F")
                        {
                            if (game[this.Position].Arguments[0].Specifier != '#')
                                if (game[BField].Arguments[0].Value == game[AField].Arguments[0].Value && 
                                    game[BField].Arguments[1].Value == game[AField].Arguments[1].Value)
                                    this.Position++;
                        }
                        else if (game[this.Position].Modifier == "X")
                        {
                            if (game[this.Position].Arguments[0].Specifier != '#')
                                if (game[BField].Arguments[0].Value == game[AField].Arguments[1].Value && 
                                    game[BField].Arguments[1].Value == game[AField].Arguments[0].Value)
                                    this.Position++;
                        }
                        else if (game[this.Position].Modifier == "I")
                        {
                            if (game[BField] == game[AField])
                                this.Position++;
                        }
                        break;
                    #endregion
                    #region SNE
                    case "SNE":
                        if (game[this.Position].Modifier == "")
                        {
                            if (game[this.Position].Arguments[0].Specifier == '#')
                            {
                                if (game[BField].Arguments[1].Value != game[this.Position].Arguments[0].Value)
                                    this.Position++;
                            }
                            else
                                if (game[BField].Arguments[1].Value > game[AField].Arguments[1].Value)
                                    this.Position++;
                        }
                        else if (game[this.Position].Modifier == "A")
                        {
                            if (game[this.Position].Arguments[0].Specifier == '#')
                            {
                                if (game[BField].Arguments[0].Value != game[this.Position].Arguments[0].Value)
                                    this.Position++;
                            }
                            else
                                if (game[BField].Arguments[0].Value != game[AField].Arguments[0].Value)
                                    this.Position++;
                        }
                        else if (game[this.Position].Modifier == "B")
                        {
                            if (game[this.Position].Arguments[1].Specifier == '#')
                            {
                                if (game[BField].Arguments[1].Value != game[this.Position].Arguments[1].Value)
                                    this.Position++;
                            }
                            else
                                if (game[BField].Arguments[1].Value != game[AField].Arguments[1].Value)
                                    this.Position++;
                        }
                        else if (game[this.Position].Modifier == "AB")
                        {
                            if (game[this.Position].Arguments[0].Specifier == '#')
                            {
                                if (game[BField].Arguments[1].Value != game[this.Position].Arguments[0].Value)
                                    this.Position++;
                            }
                            else
                                if (game[BField].Arguments[1].Value != game[AField].Arguments[0].Value)
                                    this.Position++;
                        }					
                        else if (game[this.Position].Modifier == "BA")
                        {
                            if (game[this.Position].Arguments[1].Specifier == '#')
                            {
                                if (game[BField].Arguments[0].Value != game[this.Position].Arguments[1].Value)
                                    this.Position++;
                            }
                            else
                                if (game[BField].Arguments[0].Value != game[AField].Arguments[1].Value)
                                    this.Position++;
                        }
                        else if (game[this.Position].Modifier == "F")
                        {
                            if (game[this.Position].Arguments[0].Specifier != '#')
                                if (game[BField].Arguments[0].Value != game[AField].Arguments[0].Value || 
                                    game[BField].Arguments[1].Value != game[AField].Arguments[1].Value)
                                    this.Position++;
                        }
                        else if (game[this.Position].Modifier == "X")
                        {
                            if (game[this.Position].Arguments[0].Specifier != '#')
                                if (game[BField].Arguments[0].Value != game[AField].Arguments[1].Value || 
                                    game[BField].Arguments[1].Value != game[AField].Arguments[0].Value)
                                    this.Position++;
                        }
                        else if (game[this.Position].Modifier == "I")
                        {
                            if (game[BField] != game[AField])
                                this.Position++;
                        }
                        break;
                    #endregion
                    #region SLT
                    case "SLT":
                        if (game[this.Position].Modifier == "")
                        {
                            if (game[this.Position].Arguments[0].Specifier == '#')
                            {
                                if (game[BField].Arguments[1].Value > game[this.Position].Arguments[0].Value)
                                    this.Position++;
                            }
                            else
                                if (game[BField].Arguments[1].Value > game[AField].Arguments[1].Value)
                                    this.Position++;
                        }
                        else if (game[this.Position].Modifier == "A")
                        {
                            if (game[this.Position].Arguments[0].Specifier == '#')
                            {
                                if (game[BField].Arguments[0].Value > game[this.Position].Arguments[0].Value)
                                    this.Position++;
                            }
                            else
                                if (game[BField].Arguments[0].Value > game[AField].Arguments[0].Value)
                                    this.Position++;
                        }
                        else if (game[this.Position].Modifier == "B")
                        {
                            if (game[this.Position].Arguments[1].Specifier == '#')
                            {
                                if (game[BField].Arguments[1].Value > game[this.Position].Arguments[1].Value)
                                    this.Position++;
                            }
                            else
                                if (game[BField].Arguments[1].Value > game[AField].Arguments[1].Value)
                                    this.Position++;
                        }
                        else if (game[this.Position].Modifier == "AB")
                        {
                            if (game[this.Position].Arguments[0].Specifier == '#')
                            {
                                if (game[BField].Arguments[1].Value > game[this.Position].Arguments[0].Value)
                                    this.Position++;
                            }
                            else
                                if (game[BField].Arguments[1].Value > game[AField].Arguments[0].Value)
                                    this.Position++;
                        }					
                        else if (game[this.Position].Modifier == "BA")
                        {
                            if (game[this.Position].Arguments[1].Specifier == '#')
                            {
                                if (game[BField].Arguments[0].Value > game[this.Position].Arguments[1].Value)
                                    this.Position++;
                            }
                            else
                                if (game[BField].Arguments[0].Value > game[AField].Arguments[1].Value)
                                    this.Position++;
                        }
                        else if (game[this.Position].Modifier == "F" || game[this.Position].Modifier == "I")
                        {
                            if (game[this.Position].Arguments[0].Specifier != '#')
                                if (game[BField].Arguments[0].Value > game[AField].Arguments[0].Value && 
                                    game[BField].Arguments[1].Value > game[AField].Arguments[1].Value)
                                    this.Position++;
                        }
                        else if (game[this.Position].Modifier == "X")
                        {
                            if (game[this.Position].Arguments[0].Specifier != '#')
                                if (game[BField].Arguments[0].Value > game[AField].Arguments[1].Value && 
                                    game[BField].Arguments[1].Value > game[AField].Arguments[0].Value)
                                    this.Position++;
                        }
                        break;
                    #endregion
                    #region DJN
                    case "DJN":
                        if (game[this.Position].Modifier == "" || game[this.Position].Modifier == "B" || game[this.Position].Modifier == "AB")
                        {
                            if (--game[BField].Arguments[1].Value != 0){
                                this.Position = AField;
                                return true;
                            }
                        }
                        else if (game[this.Position].Modifier == "A" || game[this.Position].Modifier == "BA")
                        {
                            if (--game[BField].Arguments[0].Value != 0){
                                this.Position = AField;
                                return true;
                            }
                        }
                        else if (game[this.Position].Modifier == "F" || game[this.Position].Modifier == "X" || game[this.Position].Modifier == "I")
                        {
                            if ((--game[BField].Arguments[0].Value != 0) | (--game[BField].Arguments[1].Value != 0)){
                                this.Position = AField;
                                return true;
                            }
                        }
                        return true;
                    #endregion
                    #region SPL
                    case "SPL":
                        if (game[this.Position].Arguments[0].Specifier != '#'
                            && this.Owner.CoreCount < Settings.MAXCORESPERPLAYER - 1)
                        {
                            this.Owner.StartCore(this.Position + 1);
                            this.Position = game[AField].Arguments[0].Value;
                            return true;
                        }
                        break;
                    #endregion
                    case "NOP":
                        break;

                    //'94:
                    #region ADD
                    case "ADD":
                        if (game[this.Position].Modifier == "")
                        {
                            if (game[this.Position].Arguments[0].Specifier == '#')
                                game[BField].Arguments[1].Value += game[this.Position].Arguments[0].Value;
                            else
                                foreach (int i in new[] { 0, 1 })
                                    game[BField].Arguments[i].Value += game[AField].Arguments[i].Value;
                        }
                        if (game[this.Position].Modifier == "A" || game[this.Position].Modifier == "F")
                        {
                            if (game[this.Position].Arguments[0].Specifier == '#')
                                game[BField].Arguments[0].Value += game[this.Position].Arguments[0].Value;
                            else
                                game[BField].Arguments[0].Value += game[AField].Arguments[0].Value;
                        }
                        if (game[this.Position].Modifier == "B" || game[this.Position].Modifier == "F")
                        {
                            if (game[this.Position].Arguments[1].Specifier == '#')
                                game[BField].Arguments[1].Value += game[this.Position].Arguments[1].Value;
                            else
                                game[BField].Arguments[1].Value += game[AField].Arguments[1].Value;
                        }
                        if (game[this.Position].Modifier == "AB" || game[this.Position].Modifier == "X")
                        {
                            if (game[this.Position].Arguments[1].Specifier == '#')
                                game[BField].Arguments[0].Value += game[this.Position].Arguments[1].Value;
                            else
                                game[BField].Arguments[0].Value += game[AField].Arguments[1].Value;
                        }
                        if (game[this.Position].Modifier == "BA" || game[this.Position].Modifier == "X")
                        {
                            if (game[this.Position].Arguments[0].Specifier == '#')
                                game[BField].Arguments[1].Value += game[this.Position].Arguments[0].Value;
                            else
                                game[BField].Arguments[1].Value += game[AField].Arguments[0].Value;
                        }
                        break;
                    #endregion
                    #region SUB
                    case "SUB":
                        if (game[this.Position].Modifier == "")
                        {
                            if (game[this.Position].Arguments[0].Specifier == '#')
                                game[BField].Arguments[1].Value -= game[this.Position].Arguments[0].Value;
                            else
                                foreach (int i in new[] { 0, 1 })
                                    game[BField].Arguments[i].Value -= game[AField].Arguments[i].Value;
                        } 
                        if (game[this.Position].Modifier == "A" || game[this.Position].Modifier == "F")
                        {
                            if (game[this.Position].Arguments[0].Specifier == '#')
                                game[BField].Arguments[0].Value -= game[this.Position].Arguments[0].Value;
                            else
                                game[BField].Arguments[0].Value -= game[AField].Arguments[0].Value;
                        }
                        if (game[this.Position].Modifier == "B" || game[this.Position].Modifier == "F")
                        {
                            if (game[this.Position].Arguments[1].Specifier == '#')
                                game[BField].Arguments[1].Value -= game[this.Position].Arguments[1].Value;
                            else
                                game[BField].Arguments[1].Value -= game[AField].Arguments[1].Value;
                        }
                        if (game[this.Position].Modifier == "AB" || game[this.Position].Modifier == "X")
                        {
                            if (game[this.Position].Arguments[1].Specifier == '#')
                                game[BField].Arguments[0].Value -= game[this.Position].Arguments[1].Value;
                            else
                                game[BField].Arguments[0].Value -= game[AField].Arguments[1].Value;
                        }
                        if (game[this.Position].Modifier == "BA" || game[this.Position].Modifier == "X")
                        {
                            if (game[this.Position].Arguments[0].Specifier == '#')
                                game[BField].Arguments[1].Value -= game[this.Position].Arguments[0].Value;
                            else
                                game[BField].Arguments[1].Value -= game[AField].Arguments[0].Value;
                        }
                        break;

                    #endregion
                    #region MUL
                    case "MUL":
                        if (game[this.Position].Modifier == "")
                        {
                            if (game[this.Position].Arguments[0].Specifier == '#')
                                game[BField].Arguments[1].Value *= game[this.Position].Arguments[0].Value;
                            else
                                foreach (int i in new[] { 0, 1 })
                                    game[BField].Arguments[i].Value *= game[AField].Arguments[i].Value;
                        }
                        if (game[this.Position].Modifier == "A" || game[this.Position].Modifier == "F")
                        {
                            if (game[this.Position].Arguments[0].Specifier == '#')
                                game[BField].Arguments[0].Value *= game[this.Position].Arguments[0].Value;
                            else
                                game[BField].Arguments[0].Value *= game[AField].Arguments[0].Value;
                        }
                        if (game[this.Position].Modifier == "B" || game[this.Position].Modifier == "F")
                        {
                            if (game[this.Position].Arguments[1].Specifier == '#')
                                game[BField].Arguments[1].Value *= game[this.Position].Arguments[1].Value;
                            else
                                game[BField].Arguments[1].Value *= game[AField].Arguments[1].Value;
                        }
                        if (game[this.Position].Modifier == "AB" || game[this.Position].Modifier == "X")
                        {
                            if (game[this.Position].Arguments[1].Specifier == '#')
                                game[BField].Arguments[0].Value *= game[this.Position].Arguments[1].Value;
                            else
                                game[BField].Arguments[0].Value *= game[AField].Arguments[1].Value;
                        }
                        if (game[this.Position].Modifier == "BA" || game[this.Position].Modifier == "X")
                        {
                            if (game[this.Position].Arguments[0].Specifier == '#')
                                game[BField].Arguments[1].Value *= game[this.Position].Arguments[0].Value;
                            else
                                game[BField].Arguments[1].Value *= game[AField].Arguments[0].Value;
                        }
                        break;

                    #endregion
                    #region DIV
                    case "DIV":
                        try
                        {
                            if (game[this.Position].Modifier == "A" || game[this.Position].Modifier == "F")
                            {
                                if (game[this.Position].Arguments[0].Specifier == '#')
                                    game[BField].Arguments[0].Value /= game[this.Position].Arguments[0].Value;
                                else
                                    game[BField].Arguments[0].Value /= game[AField].Arguments[0].Value;
                            }
                            if (game[this.Position].Modifier == "B" || game[this.Position].Modifier == "F")
                            {
                                if (game[this.Position].Arguments[1].Specifier == '#')
                                    game[BField].Arguments[1].Value /= game[this.Position].Arguments[1].Value;
                                else
                                    game[BField].Arguments[1].Value /= game[AField].Arguments[1].Value;
                            }
                            if (game[this.Position].Modifier == "AB" || game[this.Position].Modifier == "X")
                            {
                                if (game[this.Position].Arguments[1].Specifier == '#')
                                    game[BField].Arguments[0].Value /= game[this.Position].Arguments[1].Value;
                                else
                                    game[BField].Arguments[0].Value /= game[AField].Arguments[1].Value;
                            }
                            if (game[this.Position].Modifier == "BA" || game[this.Position].Modifier == "X")
                            {
                                if (game[this.Position].Arguments[0].Specifier == '#')
                                    game[BField].Arguments[1].Value /= game[this.Position].Arguments[0].Value;
                                else
                                    game[BField].Arguments[1].Value /= game[AField].Arguments[0].Value;
                            }
                        }
                        catch (DivideByZeroException)
                        {
                            return false;
                        }
                        break;
                    #endregion
                    #region MOD
                    case "MOD":
                        try
                        {
                            if (game[this.Position].Modifier == "A" || game[this.Position].Modifier == "F")
                            {
                                if (game[this.Position].Arguments[0].Specifier == '#')
                                    game[BField].Arguments[0].Value %= game[this.Position].Arguments[0].Value;
                                else
                                    game[BField].Arguments[0].Value %= game[AField].Arguments[0].Value;
                            }
                            if (game[this.Position].Modifier == "B" || game[this.Position].Modifier == "F")
                            {
                                if (game[this.Position].Arguments[1].Specifier == '#')
                                    game[BField].Arguments[1].Value %= game[this.Position].Arguments[1].Value;
                                else
                                    game[BField].Arguments[1].Value %= game[AField].Arguments[1].Value;
                            }
                            if (game[this.Position].Modifier == "AB" || game[this.Position].Modifier == "X")
                            {
                                if (game[this.Position].Arguments[1].Specifier == '#')
                                    game[BField].Arguments[0].Value %= game[this.Position].Arguments[1].Value;
                                else
                                    game[BField].Arguments[0].Value %= game[AField].Arguments[1].Value;
                            }
                            if (game[this.Position].Modifier == "BA" || game[this.Position].Modifier == "X")
                            {
                                if (game[this.Position].Arguments[0].Specifier == '#')
                                    game[BField].Arguments[1].Value %= game[this.Position].Arguments[0].Value;
                                else
                                    game[BField].Arguments[1].Value %= game[AField].Arguments[0].Value;
                            }
                        }
                        catch (DivideByZeroException)
                        {
                            return false;
                        }
                        break;

                    #endregion
                    default:
                        break;
                }
                this.Position = (this.Position + 1) % Settings.MEMORYSIZE;
                return true;
            }
        }
    }
}