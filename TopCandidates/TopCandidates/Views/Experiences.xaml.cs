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
    public partial class Experiences : ContentPage
    {
        public Experiences()
        {
            InitializeComponent();
            loadExperiences();
        }

        private void sbFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Filtro do listview, o parâmetro vem do SearchBox e pode ser o número ou nome da propriedade ou o nome da supervisora
            var name = sbFilter.Text;
            var year = sbFilter2.Text;
            var q = GlobalVar.dataBase.Query<Experience>(@"select e.Candidate, t.name Technology, e.yearsOfExperience
            from tabexperiences e
            inner join tabtechnologies t on t.guid = e.technologyId
            where t.name like '%" + name + "%' and e.yearsOfExperience like '%" + year + "%' ORDER BY Candidate");
            lvExperiences.ItemsSource = q;
            lblCounter.Text = "Showing " + q.Count.ToString() + " Candidates";
        }

        public void loadExperiences()
        {
            var q = GlobalVar.dataBase.Query<Experience>(@"select e.Candidate, t.name Technology, e.yearsOfExperience
            from tabexperiences e 
            inner join tabtechnologies t on t.guid = e.technologyId
			order by e.Candidate"
        ).ToList();
            
            lvExperiences.ItemsSource = q;

        }
    }
}