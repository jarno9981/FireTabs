﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace FireFizzler
{
    public static class SelectorsCachingCompiler
    {
        /// <summary>
        /// Creates a caching selectors compiler on top on an existing compiler.
        /// </summary>
        public static Func<string, T> Create<T>(Func<string, T> compiler) =>
            Create(compiler, null);

        /// <summary>
        /// Creates a caching selectors compiler on top on an existing compiler.
        /// An addition parameter specified a dictionary to use as the cache.
        /// </summary>
        /// <remarks>
        /// If <paramref name="cache"/> is <c>null</c> then this method uses a
        /// the <see cref="Dictionary{TKey,TValue}"/> implementation with an
        /// ordinally case-insensitive selectors text comparer.
        /// </remarks>
        public static Func<string, T> Create<T>(Func<string, T> compiler, IDictionary<string, T> cache)
        {
            if (compiler == null) throw new ArgumentNullException(nameof(compiler));
            return CreateImpl(compiler, cache ?? new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase));
        }

        static Func<string, T> CreateImpl<T>(Func<string, T> compiler, IDictionary<string, T> cache)
        {
            Debug.Assert(compiler != null);
            Debug.Assert(cache != null);

            return selector =>
                cache.TryGetValue(selector, out var compiled)
                ? compiled
                : cache[selector] = compiler(selector);
        }
    }
}
