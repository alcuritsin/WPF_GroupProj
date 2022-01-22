using Model;
using DataBaseLib.Exceptions;
using System.Collections.ObjectModel;

namespace DataBaseLib
{
    class DBPerson
    {
        private DataBase _db;

        public DBPerson()
        {
            _db = new DataBase();
            _db.Init();
        }

        public ObservableCollection<Person> Persons()
        {
            #region Init_Const
            const string _TABLE_NAME = "table_person";
            const string _ID = "id";
            const string _LAST_NAME = "last_name";
            const string _FIRST_NAME = "first_name";
            const string _MIDLE_NAME = "midle_name";
            #endregion

            var sql = $"SELECT * FROM {_TABLE_NAME}";
            var res = _db.ExecuteSelect(in sql, out var outputData);

            if (!res)
            {
                throw new NoAnswerException(
                    typeException: TypeException.NoAnswer,
                    tableName: _TABLE_NAME,
                    message: "Ответ из базы данных не был получен.");
            }

            if (!outputData.HasRows)
            {
                throw new EmptyTableException(
                    typeException: TypeException.EmptyTable,
                    tableName: _TABLE_NAME,
                    message: "Результат запроса вернул пустую таблицу.");
            }

            var persons = new ObservableCollection<Person>();

            while (outputData.Read())
            {
                persons.Add(new Person
                {
                    ID = outputData.GetInt32(_ID),
                    LastName = outputData.GetString(_LAST_NAME),
                    FirstName = outputData.GetString(_FIRST_NAME),
                    MidleName = outputData.GetString(_MIDLE_NAME),
                });
            }
            _db.Close();
            return persons;
        }
    }
}

