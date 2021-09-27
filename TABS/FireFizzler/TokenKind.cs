using System;
using System.Collections.Generic;
using System.Text;

namespace FireFizzler
{
    public enum TokenKind
    {
        /// <summary>
        /// Represents end of input/file/stream
        /// </summary>
        Eoi,

        /// <summary>
        /// Represents {ident}
        /// </summary>
        Ident,

        /// <summary>
        /// Represents "#" {name}
        /// </summary>
        Hash,

        /// <summary>
        /// Represents "~="
        /// </summary>
        Includes,

        /// <summary>
        /// Represents "|="
        /// </summary>
        DashMatch,

        /// <summary>
        /// Represents "^="
        /// </summary>
        PrefixMatch,

        /// <summary>
        /// Represents "$="
        /// </summary>
        SuffixMatch,

        /// <summary>
        /// Represents "*="
        /// </summary>
        SubstringMatch,

        /// <summary>
        /// Represents {string}
        /// </summary>
        String,

        /// <summary>
        /// Represents S* "+"
        /// </summary>
        Plus,

        /// <summary>
        /// Represents S* ">"
        /// </summary>
        Greater,

        /// <summary>
        /// Represents [ \t\r\n\f]+
        /// </summary>
        WhiteSpace,

        /// <summary>
        /// Represents {ident} "("
        /// </summary>
        Function,

        /// <summary>
        /// Represents ":"{N}{O}{T}"("
        /// </summary>
        Not,

        /// <summary>
        /// Represents [0-9]+
        /// </summary>
        Integer,

        /// <summary>
        /// Represents S* "~"
        /// </summary>
        Tilde,

        /// <summary>
        /// Represents an arbitrary character
        /// </summary>
        Char,
    }
}
