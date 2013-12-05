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

            public struct Argument
            {
                public char Specifier;
                public int Value;

                public Argument(char specifier, int value)
                {
                    if (!IsValidSpecifier(specifier))
                        throw new InvalidOperationException();
                    Specifier = specifier;
                    Value = value;
                }

                public static bool IsValidSpecifier(char specifier)
                {
                    return specifier == '$' || specifier == '#' || specifier == '@' || specifier == '<';
                }
            }

            /// <summary>
            /// Gets the first argument.
            /// </summary>
            /// <value>
            /// The first arg.
            /// </value>
            public Argument[] Arguments { get; private set; }

            public Cell()
            {
                Operation = "DAT";
                Arguments = new Argument[] { new Argument('$', 0), new Argument('$', 0) };
            }
            public Cell(string operation, Argument argument0, Argument argument1, params Argument[] arguments)
            {
                Operation = operation;
                Arguments = new Argument[2 + arguments.Length];
                Arguments[0] = argument0;
                Arguments[1] = argument1;
                for (int i = 0; i < arguments.Length; i++)
                    Arguments[2 + i] = arguments[i];
            }

            public override string ToString()
            {
                string s =  "( " + this.Operation;
                foreach (var item in Arguments)
                    s += " | " + item.Specifier + item.Value;
                s += " )";
                return s;
            }
        }
    }
}
