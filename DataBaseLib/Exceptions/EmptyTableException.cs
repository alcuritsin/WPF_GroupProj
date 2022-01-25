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
