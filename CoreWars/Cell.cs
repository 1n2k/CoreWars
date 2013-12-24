using System;

namespace CoreWars
{
    namespace Engine
	{
		namespace Simulator
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
	            /// <summary>
	            /// Gets the operation modifier.
	            /// </summary>
	            /// <value>
	            /// The operation modifier.
	            /// </value>
	            public string Modifier { get; private set; }

	            ///An argument that an <see cref="CoreWars.Engine.Cell"/> holds.
	            public struct Argument
	            {
	                /// <summary>
	                /// The specifier.
	                /// </summary>
	                public char Specifier;
	                /// <summary>
	                /// The value.
	                /// </summary>
	                public int Value;

	                /// <summary>
	                /// Initializes a new instance of the <see cref="CoreWars.Engine.Cell.Argument"/> struct.
	                /// </summary>
	                /// <param name='specifier'>
	                /// Specifier.
	                /// </param>
	                /// <param name='value'>
	                /// Value.
	                /// </param>
	                /// <param name='newStandard'>
	                /// Specifies whether the new standard's rules should apply.
	                /// </param>
	                public Argument(char specifier, int value, bool newStandard = false)
	                {
	                    if (!IsValidSpecifier(specifier, newStandard))
	                        throw new InvalidOperationException("Invalid Specifier");
	                    Specifier = specifier;
	                    Value = value;
	                }

	                /// <summary>
	                /// Determines whether the given specifier is valid in the given standard.
	                /// </summary>
	                /// <returns>
	                /// <c>true</c> if specifier is valid specifier; otherwise, <c>false</c>.
	                /// </returns>
	                /// <param name='specifier'>
	                /// The specifier.
	                /// </param>
	                /// <param name='newStandard'>
	                /// Specifies whether the new standard's rules should apply.
	                /// </param>
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

	            /// <summary>
	            /// Initializes a new instance of the <see cref="CoreWars.Engine.Cell"/> class.
	            /// </summary>
	            /// <param name='newStandard'>
	            /// Specifies whether the new standard's rules should apply.
	            /// </param>
	            public Cell(bool newStandard = false)
	            {
	                Operation = "DAT";
	                if (newStandard)
	                    Modifier = "F";
	                Arguments = new Argument[] { new Argument('$', 0), new Argument('$', 0) };
	            }
	            /// <summary>
	            /// Initializes a new instance of the <see cref="CoreWars.Engine.Cell"/> class.
	            /// </summary>
	            /// <param name='operation'>
	            /// Operation.
	            /// </param>
	            /// <param name='argument0'>
	            /// Argument0.
	            /// </param>
	            /// <param name='argument1'>
	            /// Argument1.
	            /// </param>
	            /// <param name='arguments'>
	            /// Arguments.
	            /// </param>
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
	            /// <summary>
	            /// Initializes a new instance of the <see cref="CoreWars.Engine.Cell"/> class.
	            /// </summary>
	            /// <param name='operation'>
	            /// Operation.
	            /// </param>
	            /// <param name='modifier'>
	            /// Modifier.
	            /// </param>
	            /// <param name='argument0'>
	            /// Argument0.
	            /// </param>
	            /// <param name='argument1'>
	            /// Argument1.
	            /// </param>
	            /// <param name='arguments'>
	            /// Arguments.
	            /// </param>
	            public Cell(string operation, string modifier, Argument argument0, Argument argument1, params Argument[] arguments)
	                : this(operation, argument0, argument1, arguments)
	            {
	                Modifier = modifier;
	            }

	            /// <summary>
	            /// Returns a <see cref="System.String"/> that represents the current <see cref="CoreWars.Engine.Cell"/>.
	            /// </summary>
	            /// <returns>
	            /// A <see cref="System.String"/> that represents the current <see cref="CoreWars.Engine.Cell"/>.
	            /// </returns>
	            public override string ToString()
	            {
	                string s = this.Operation + (this.Modifier != "" ? "." + this.Modifier + " " : " ");
	                for (int i = 0; i < Arguments.Length; ++i)
	                    if (i != 0)
	                        s += (", " + Arguments[i].Specifier) + Arguments[i].Value;
	                    else
	                        s += "" + Arguments[i].Specifier + Arguments[i].Value;
	                return s;
	            }
	        }
	    }
	}
}