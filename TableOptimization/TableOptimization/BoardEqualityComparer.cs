using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TableOptimization
{
    class BoardEqualityComparer : IEqualityComparer<Board>
    {
        public bool Equals([AllowNull] Board x, [AllowNull] Board y) => x?.Thickness == y?.Thickness;
        public int GetHashCode([DisallowNull] Board obj) => obj?.GetHashCode() ?? 0;
    }
}
