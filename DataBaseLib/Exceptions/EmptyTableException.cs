using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLib.Exceptions
{
    public class EmptyTableException: DBException
    {
        public EmptyTableException(TypeException typeException, string tableName)
            : base(typeException, tableName) { }
        public EmptyTableException(string? message, TypeException typeException, string tableName)
            : base(message, typeException, tableName) { }

    }
}
