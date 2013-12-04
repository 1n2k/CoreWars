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
            public string opcode { get; private set; }
            /// <summary>
            /// Gets the first argument.
            /// </summary>
            /// <value>
            /// The first arg.
            /// </value>
            public Tuple<char,int>[] args { get; private set; }

			public Cell (string _opcode, Tuple<char,int> _arg0, params Tuple<char,int>[] _args)
			{
				opcode = _opcode;
				args = new Tuple<char,int>[1 + _args.Length];
				args[0] = _arg0;
				for (int i = 0; i < _args.Length; i++)
					args[1+i] = _args[i];
			}
			public Cell (string Line)
			{

			}
        }
    }
}
