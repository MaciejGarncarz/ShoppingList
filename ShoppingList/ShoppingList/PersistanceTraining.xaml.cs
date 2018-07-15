using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using SQLite;

namespace ShoppingList
{
    public class Person
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersistanceTraining : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Person> _persons;
        public PersistanceTraining()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Person>();

            var persons =  await _connection.Table<Person>().ToListAsync();
            _persons = new ObservableCollection<Person>(persons);
            personsListView.ItemsSource = _persons;

            base.OnAppearing();
        }

        async void OnAdd(object sender, System.EventArgs e)
        {
            var person = new Person { Name = "Hello there" };
            await _connection.InsertAsync(person);

            _persons.Add(person);
        }

        async void OnUpdate(object sender, System.EventArgs e)
        {
            var person = _persons[0];
            person.Name += "Po update";
            await _connection.UpdateAsync(person);
        }

        async void OnDelete(object sender, System.EventArgs e)
        {
            var person = _persons[0];
            await _connection.DeleteAsync(person);
            _persons.Remove(person);
        }
    }
}