using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLib.Exceptions
{
    public abstract class DBException: Exception
    {
        public TypeException TypeException { get; protected set; }
        public string TableName { get; protected set; }

        protected DBException(TypeException typeException, string tableName)
        {
            TypeException = typeException;
            TableName = tableName;
        }

        protected DBException(string? message, TypeException typeException, string tableName) : base (message)
        {
            TypeException = typeException;
            TableName = tableName;
        }
    }
}
