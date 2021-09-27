using System;

namespace FireFizzler
{
    /// <summary>
    /// An <see cref="ISelectorGenerator"/> implementation that generates
    /// human-readable description of the selector.
    /// </summary>
    public class HumanReadableSelectorGenerator : ISelectorGenerator
    {
        int _chainCount;

        /// <summary>
        /// Initializes the text.
        /// </summary>
        public virtual void OnInit() => Text = null;

        /// <summary>
        /// Gets the generated human-readable description text.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Generates human-readable for a selector in a group.
        /// </summary>
        public virtual void OnSelector()
        {
            if (string.IsNullOrEmpty(Text))
                Text = "Take all";
            else
                Text += " and select them. Combined with previous, take all";
        }

        /// <summary>
        /// Concludes the text.
        /// </summary>
        public virtual void OnClose()
        {
            Text = Text.Trim();
            Text += " and select them.";
        }

        /// <summary>
        /// Adds to the generated human-readable text.
        /// </summary>
        protected void Add(string selector) =>
            Text += selector ?? throw new ArgumentNullException(nameof(selector));

        /// <summary>
        /// Generates human-readable text of this type selector.
        /// </summary>
        public void Type(NamespacePrefix prefix, string type) =>
            Add($" <{type}> elements");

        /// <summary>
        /// Generates human-readable text of this universal selector.
        /// </summary>
        public void Universal(NamespacePrefix prefix) =>
            Add(" elements");

        /// <summary>
        /// Generates human-readable text of this ID selector.
        /// </summary>
        public void Id(string id) =>
            Add($" with an ID of '{id}'");

        /// <summary>
        /// Generates human-readable text of this class selector.
        /// </summary>
        void ISelectorGenerator.Class(string clazz) =>
            Add($" with a class of '{clazz}'");

        /// <summary>
        /// Generates human-readable text of this attribute selector.
        /// </summary>
        public void AttributeExists(NamespacePrefix prefix, string name) =>
            Add($" which have attribute {name} defined");

        /// <summary>
        /// Generates human-readable text of this attribute selector.
        /// </summary>
        public void AttributeExact(NamespacePrefix prefix, string name, string value) =>
            Add($" which have attribute {name} with a value of '{value}'");

        /// <summary>
        /// Generates human-readable text of this attribute selector.
        /// </summary>
        public void AttributeIncludes(NamespacePrefix prefix, string name, string value) =>
            Add($" which have attribute {name} that includes the word '{value}'");

        /// <summary>
        /// Generates human-readable text of this attribute selector.
        /// </summary>
        public void AttributeDashMatch(NamespacePrefix prefix, string name, string value) =>
            Add($" which have attribute {name} with a hyphen separated value matching '{value}'");

        /// <summary>
        /// Generates human-readable text of this attribute selector.
        /// </summary>
        public void AttributePrefixMatch(NamespacePrefix prefix, string name, string value) =>
            Add($" which have attribute {name} whose value begins with '{value}'");

        /// <summary>
        /// Generates human-readable text of this attribute selector.
        /// </summary>
        public void AttributeSuffixMatch(NamespacePrefix prefix, string name, string value) =>
            Add($" which have attribute {name} whose value ends with '{value}'");

        /// <summary>
        /// Generates human-readable text of this attribute selector.
        /// </summary>
        public void AttributeSubstring(NamespacePrefix prefix, string name, string value) =>
            Add($" which have attribute {name} whose value contains '{value}'");

        /// <summary>
        /// Generates human-readable text of this pseudo-class selector.
        /// </summary>
        public void FirstChild() =>
            Add(" which are the first child of their parent");

        /// <summary>
        /// Generates human-readable text of this pseudo-class selector.
        /// </summary>
        public void LastChild() =>
            Add(" which are the last child of their parent");

        /// <summary>
        /// Generates human-readable text of this pseudo-class selector.
        /// </summary>
        public void NthChild(int a, int b) =>
            Add($" where the element has {a}n+{b}-1 sibling before it");

        /// <summary>
        /// Generates human-readable text of this pseudo-class selector.
        /// </summary>
        public void OnlyChild() =>
            Add(" where the element is the only child");

        /// <summary>
        /// Generates human-readable text of this pseudo-class selector.
        /// </summary>
        public void Empty() =>
            Add(" where the element is empty");

        /// <summary>
        /// Generates human-readable text of this combinator.
        /// </summary>
        public void Child() =>
            Add(", then take their immediate children which are");

        /// <summary>
        /// Generates human-readable text of this combinator.
        /// </summary>
        public void Descendant()
        {
            if (_chainCount > 0)
            {
                Add(". With those, take only their descendants which are");
            }
            else
            {
                Add(", then take their descendants which are");
                _chainCount++;
            }
        }

        /// <summary>
        /// Generates human-readable text of this combinator.
        /// </summary>
        public void Adjacent() =>
            Add(", then take their immediate siblings which are");

        /// <summary>
        /// Generates a <a href="http://www.w3.org/TR/css3-selectors/#combinators">combinator</a>,
        /// which separates two sequences of simple selectors. The elements represented
        /// by the two sequences share the same parent in the document tree and the
        /// element represented by the first sequence precedes (not necessarily
        /// immediately) the element represented by the second one.
        /// </summary>
        public void GeneralSibling() =>
            Add(", then take their siblings which are");

        /// <summary>
        /// Generates human-readable text of this combinator.
        /// </summary>
        public void NthLastChild(int a, int b) =>
            Add($" where the element has {a}n+{b}-1 sibling after it");
    }
}
