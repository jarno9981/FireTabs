using System;
using System.Diagnostics.Contracts;

namespace FireFizzler
{
    [Serializable]
    public struct NamespacePrefix
    {
        /// <summary>
        /// Represents a name from either the default or any namespace
        /// in a target document, depending on whether a default namespace is
        /// in effect or not.
        /// </summary>
        public static readonly NamespacePrefix None = new NamespacePrefix(null);

        /// <summary>
        /// Represents an empty namespace.
        /// </summary>
        public static readonly NamespacePrefix Empty = new NamespacePrefix(string.Empty);

        /// <summary>
        /// Represents any namespace.
        /// </summary>
        public static readonly NamespacePrefix Any = new NamespacePrefix("*");

        /// <summary>
        /// Initializes an instance with a namespace prefix specification.
        /// </summary>
        public NamespacePrefix(string text) : this() => Text = text;

        /// <summary>
        /// Gets the raw text value of this instance.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Indicates whether this instance represents a name
        /// from either the default or any namespace in a target
        /// document, depending on whether a default namespace is
        /// in effect or not.
        /// </summary>
        public bool IsNone => Text == null;

        /// <summary>
        /// Indicates whether this instance represents a name
        /// from any namespace (including one without one)
        /// in a target document.
        /// </summary>
        public bool IsAny => !IsNone && Text.Length == 1 && Text[0] == '*';

        /// <summary>
        /// Indicates whether this instance represents a name
        /// without a namespace in a target document.
        /// </summary>
        public bool IsEmpty => !IsNone && Text.Length == 0;

        /// <summary>
        /// Indicates whether this instance represents a name from a
        /// specific namespace or not.
        /// </summary>
        public bool IsSpecific => !IsNone && !IsAny;

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        public override bool Equals(object obj) =>
            obj is NamespacePrefix prefix && Equals(prefix);

        /// <summary>
        /// Indicates whether this instance and another are equal.
        /// </summary>
        [Pure] public bool Equals(NamespacePrefix other) => Text == other.Text;

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        public override int GetHashCode() => IsNone ? 0 : Text.GetHashCode();

        /// <summary>
        /// Returns a string representation of this instance.
        /// </summary>
        public override string ToString() => IsNone ? "(none)" : Text;

        /// <summary>
        /// Formats this namespace together with a name.
        /// </summary>
        [Pure]
        public string Format(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (name.Length == 0) throw new ArgumentException(null, nameof(name));

            return Text + (IsNone ? null : "|") + name;
        }
    }
}
