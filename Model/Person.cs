using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    /// <summary>
    /// Класс описывающий человека. Является моделью в нашем приложении.
    /// Для обеспечения возможности связывания,
    /// модель реализует интерфейс INotifyPropertyChanged (пространство имён System.ComponentModel)
    /// Это код, который ожидается от Арины
    /// </summary>
    public class Person : INotifyPropertyChanged
    {
        private int _id;
        private string _lastName;
        private string _firstName;
        private string _midleName;

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("ID");
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string MidleName
        {
            get { return _midleName; }
            set
            {
                _midleName = value;
                OnPropertyChanged("MidleName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
