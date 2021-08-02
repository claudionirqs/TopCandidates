using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopCandidates.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TopCandidates.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Accepted : ContentPage
    {
        public Accepted()
        {
            InitializeComponent();
            loadCandidates();
        }

        public void loadCandidates()
        {
            List<Candidate> listCandidate = GlobalVar.dataBase.Query<Candidate>("select * from tabcandidates WHERE status = 1");
            lvCandidates.ItemsSource = listCandidate;

        }

        private void sbFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Filtro do listview, o parâmetro vem do SearchBox e pode ser o número ou nome da propriedade ou o nome da supervisora
            var name = sbFilter.Text;
            List<Candidate> selectItems = GlobalVar.dataBase.Query<Candidate>("SELECT * FROM tabcandidates WHERE status = 1 AND (fullName LIKE '%" + name + "%' OR email LIKE '%" + name + "%')");
            lvCandidates.ItemsSource = selectItems;
        }
    }
}