namespace DataBaseLib.Exceptions
{
    public class NoChengedExeption : DBException
    {
        public NoChengedExeption(TypeException typeException, string tableName)
            : base(typeException, tableName) { }

        public NoChengedExeption(string? message, TypeException typeException, string tableName)
            : base(message, typeException, tableName) { }
    }
}
