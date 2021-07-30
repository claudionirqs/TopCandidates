using System;
using System.Collections.Generic;
using TopCandidates.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TopCandidates.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Technologies : ContentPage
    {
        public Technologies()
        {
            InitializeComponent();
            loadTechnologies();
        }

        private void sbFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Filtro do listview, o parâmetro vem do SearchBox e pode ser o número ou nome da propriedade ou o nome da supervisora
            var name = sbFilter.Text;
            List<Technologie> selectItems = GlobalVar.dataBase.Query<Technologie>("SELECT * FROM tabtechnologies WHERE name LIKE '%" + name + "%'");
            lvTechnologies.ItemsSource = selectItems;
            lblCounter.Text = "Showing " + selectItems.Count.ToString() + " Technologies";
        }

        private void Sync_Clicked(object sender, EventArgs args)
        {
            loadTechnologies();
            
        }

        public void loadTechnologies()
        {
            List<Technologie> listTechnology = GlobalVar.dataBase.Query<Technologie>("SELECT * FROM tabtechnologies");
            lvTechnologies.ItemsSource = listTechnology;

        }
    }
}