using System;
using System.Collections.Generic;

namespace FireFizzler
{
    // Adapted from Mono Rocks

    abstract class Either<TA, TB>
            : IEquatable<Either<TA, TB>>
    {
        Either() { }

        public static Either<TA, TB> A(TA value) => new AImpl(value);
        public static Either<TA, TB> B(TB value) => new BImpl(value);

        public abstract override bool Equals(object obj);
        public abstract bool Equals(Either<TA, TB> obj);
        public abstract override int GetHashCode();
        public abstract override string ToString();
        public abstract TResult Fold<TResult>(Func<TA, TResult> a, Func<TB, TResult> b);
        public abstract TResult Fold<T, TResult>(T arg, Func<T, TA, TResult> a, Func<T, TB, TResult> b);

        sealed class AImpl : Either<TA, TB>
        {
            readonly TA _value;

            public AImpl(TA value) => _value = value;

            public override int GetHashCode() =>
                EqualityComparer<TA>.Default.GetHashCode(_value);

            public override bool Equals(object obj) => Equals(obj as AImpl);

            public override bool Equals(Either<TA, TB> obj) =>
                obj is AImpl a
                && EqualityComparer<TA>.Default.Equals(_value, a._value);

            public override TResult Fold<TResult>(Func<TA, TResult> a, Func<TB, TResult> b)
            {
                if (a == null) throw new ArgumentNullException(nameof(a));
                if (b == null) throw new ArgumentNullException(nameof(b));
                return a(_value);
            }

            public override TResult Fold<T, TResult>(T arg, Func<T, TA, TResult> a, Func<T, TB, TResult> b)
            {
                if (a == null) throw new ArgumentNullException(nameof(a));
                if (b == null) throw new ArgumentNullException(nameof(b));
                return a(arg, _value);
            }

            public override string ToString() =>
                _value?.ToString() ?? string.Empty;
        }

        sealed class BImpl : Either<TA, TB>
        {
            readonly TB _value;

            public BImpl(TB value) => _value = value;

            public override int GetHashCode() =>
                EqualityComparer<TB>.Default.GetHashCode(_value);

            public override bool Equals(object obj) => Equals(obj as BImpl);

            public override bool Equals(Either<TA, TB> obj) =>
                obj is BImpl b
                && EqualityComparer<TB>.Default.Equals(_value, b._value);

            public override TResult Fold<TResult>(Func<TA, TResult> a, Func<TB, TResult> b)
            {
                if (a == null) throw new ArgumentNullException(nameof(a));
                if (b == null) throw new ArgumentNullException(nameof(b));
                return b(_value);
            }

            public override TResult Fold<T, TResult>(T arg, Func<T, TA, TResult> a, Func<T, TB, TResult> b)
            {
                if (a == null) throw new ArgumentNullException(nameof(a));
                if (b == null) throw new ArgumentNullException(nameof(b));
                return b(arg, _value);
            }

            public override string ToString() =>
                _value?.ToString() ?? string.Empty;
        }
    }
}
