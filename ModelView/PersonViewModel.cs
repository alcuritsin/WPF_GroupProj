using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ModelView
{
    /// <summary>
    /// Класс представления.
    /// Посредник между представлением и моделью.
    /// Для поддержки связывания модель представления реализует интерфейс INotifyPropertyChanged
    /// Это код, который ожидается от Сергея
    /// </summary>
    class PersonViewModel : INotifyPropertyChanged
    {
        private Person _selectedPerson;
        public ObservableCollection<Person> Persons { get; set; }
        
        /// <summary>
        /// Выделенный человек в коллекции
        /// </summary>
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                OnPropertyChanged("SelectedPerson");
            }
        }

        public PersonViewModel()
        {
            Persons = new ObservableCollection<Person>();

        }

        /// <summary>
        /// Добавление нового человека в коллекцию
        /// </summary>
        public void AddPerson()
        {
            Person person = new Person();
            Persons.Insert(0, person);
            SelectedPerson = person;
        }

        /// <summary>
        /// Удаление выделенного человека из коллекции
        /// </summary>
        public void DeletePerson()
        {
            if(_selectedPerson !=null)
            {
                Persons.Remove(SelectedPerson);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
