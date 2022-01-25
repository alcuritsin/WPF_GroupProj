using Model;
using DataBaseLib.Exceptions;
using System.Collections.ObjectModel;

namespace DataBaseLib
{
    class DBPerson
    {
        private DataBase _db;

        #region Init_Const
        const string _TABLE_NAME = "table_person";
        const string _ID = "id";
        const string _LAST_NAME = "last_name";
        const string _FIRST_NAME = "first_name";
        const string _MIDLE_NAME = "midle_name";
        #endregion


        public DBPerson()
        {
            _db = new DataBase();
            _db.Init();
        }

        /// <summary>
        /// Получение всех персон из базы данных
        /// </summary>
        /// <returns>Обзорная коллекция персон</returns>
        public ObservableCollection<Person> GetAllPersons()
        {
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

        /// <summary>
        /// Вставить новую запись в базу данных
        /// </summary>
        /// <param name="person">Принимает 'персону'</param>
        public void InsertPersonToDB(Person person)
        {
            var sql = $"INSERT INTO {_TABLE_NAME}({_ID}, {_LAST_NAME}, {_FIRST_NAME}, {_MIDLE_NAME}) VALUES(null, '{person.LastName}', '{person.FirstName}', '{person.MidleName}');";
            var res = _db.ExecuteNotSelect(in sql, out var countRows);

            if (!res)
            {
                throw new NoChengedExeption
                    (
                        typeException: TypeException.NoChenged,
                        tableName: _TABLE_NAME,
                        message: "Результат запроса не изменил базу данных.");
            }
        }

        /// <summary>
        /// Удалает строку по указанной персоне.
        /// </summary>
        /// <param name="person">Принимает 'персону'</param>
        public void DeletePersonFromDB(Person person)
        {
            var sql = $"DELETE FROM {_TABLE_NAME} WHERE {_ID} = '{person.ID}'; ";
            var res = _db.ExecuteNotSelect(in sql, out var countRows);

            if (!res)
            {
                throw new NoChengedExeption
                    (
                        typeException: TypeException.NoChenged,
                        tableName: _TABLE_NAME,
                        message: "Результат запроса не изменил базу данных.");
            }
        }

        /// <summary>
        /// Обновляет данные о персоне в базе данных
        /// </summary>
        /// <param name="person">Принимает 'персону'</param>
        public void UpdatePersonFromDB(Person person)
        {
            var sql = $"UPDATE {_TABLE_NAME} SET {_LAST_NAME}={person.LastName}, {_FIRST_NAME}={person.FirstName}, {_MIDLE_NAME}={person.MidleName} WHERE {_ID}={person.ID};";
            var res = _db.ExecuteNotSelect(in sql, out var countRows);

            if (!res)
            {
                throw new NoChengedExeption
                    (
                        typeException: TypeException.NoChenged,
                        tableName: _TABLE_NAME,
                        message: "Результат запроса не изменил базу данных.");
            }
        }
    }
}

