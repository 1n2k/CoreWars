using System;

namespace CoreWars
{
    namespace Engine
    {
        /// <summary>
        /// A memory cell.
        /// </summary>
        public class Cell
        {
            /// <summary>
            /// Gets the opcode.
            /// </summary>
            /// <value>
            /// The opcode.
            /// </value>
            public string Operation { get; private set; }
            public string Modifier { get; private set; }

            public struct Argument
            {
                public char Specifier;
                public int Value;

                public Argument(char specifier, int value, bool newStandard = false)
                {
                    if (!IsValidSpecifier(specifier, newStandard))
                        throw new InvalidOperationException("Invalid Specifier");
                    Specifier = specifier;
                    Value = value;
                }

                public static bool IsValidSpecifier(char specifier, bool newStandard)
                {
                    if (!newStandard)
                        return specifier == '$' || specifier == '#' || specifier == '@' || specifier == '<';
                    else
                        return specifier == '$' || specifier == '#' || specifier == '@' || specifier == '<' ||
                            specifier == '>' || specifier == '*' || specifier == '{' || specifier == '}';
                }
            }

            /// <summary>
            /// Gets the first argument.
            /// </summary>
            /// <value>
            /// The first arg.
            /// </value>
            public Argument[] Arguments { get; private set; }

            public Cell(bool newStandard = false)
            {
                Operation = "DAT";
                if (newStandard)
                    Modifier = "F";
                Arguments = new Argument[] { new Argument('$', 0), new Argument('$', 0) };
            }
            public Cell(string operation, Argument argument0, Argument argument1, params Argument[] arguments)
            {
                Operation = operation;
                Modifier = "";

                Arguments = new Argument[2 + arguments.Length];
                Arguments[0] = argument0;
                Arguments[1] = argument1;
                for (int i = 0; i < arguments.Length; i++)
                    Arguments[2 + i] = arguments[i];
            }
            public Cell(string operation, string modifier, Argument argument0, Argument argument1, params Argument[] arguments)
                : this(operation,argument0,argument1,arguments)
            {
                Modifier = modifier;
            }

            public override string ToString()
            {
                string s = "( " + this.Operation + "." + this.Modifier;
                foreach (var item in Arguments)
                    s += " | " + item.Specifier + item.Value;
                s += " )";
                return s;
            }
        }
    }
}
