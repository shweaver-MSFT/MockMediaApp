using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MockMediaApp
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (propertyName != null && !EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        private ObservableCollection<ItemCollectionModel> _collections;
        public ObservableCollection<ItemCollectionModel> Collections
        {
            get => _collections;
            set => Set(ref _collections, value);
        }

        private ObservableCollection<ItemModel> _items;
        public ObservableCollection<ItemModel> Items
        {
            get => _items;
            set => Set(ref _items, value);
        }

        public MainPageViewModel()
        {
            Collections = new ObservableCollection<ItemCollectionModel>();
            Items = new ObservableCollection<ItemModel>();
            Load();
        }

        private void Load()
        {
            for(var i = 1; i <= 10; i++)
            {
                var collection = new ItemCollectionModel("Collection " + i);
                
                for(var n = 1; n <= 30; n++)
                {
                    var item = new ItemModel("Item " + n);
                    collection.Items.Add(item);
                }

                Collections.Add(collection);
            }

            for (var n = 1; n <= 30; n++)
            {
                var item = new ItemModel("Item " + n);
                Items.Add(item);
            }
        }
    }
}
