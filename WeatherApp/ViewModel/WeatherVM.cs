using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        private string query;

        public string Query
        {
            get { return query; }
            set 
            { 
                query = value; 
                OnPropertyChanged("Query");
            }
        }

        private CurrentCoditions currentCoditions;

        public CurrentCoditions CurrentCoditions
        {
            get { return currentCoditions; }
            set 
            { 
                currentCoditions = value; 
                OnPropertyChanged("CurrentCoditions"); ;
            }

        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set 
            { 
                selectedCity = value; 
                OnPropertyChanged("SelectedCity");
            }
        }

        public WeatherVM()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject())) {
                SelectedCity = new City
                {
                    LocalizedName = "New York"
                };
                CurrentCoditions = new CurrentCoditions
                {
                    WeatherText = "Partly Cloudy",
                    Temperature = new Temperature
                    {
                        Metric = new Units
                        {
                            Value = 22
                        }
                    }
                };
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
