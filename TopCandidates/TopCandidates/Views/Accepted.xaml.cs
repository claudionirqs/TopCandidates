using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var q = GlobalVar.dataBase.Query<Candidates>(@"SELECT * FROM tabcandidates WHERE status = 1 ORDER BY fullName").ToList();

            lvCandidates.ItemsSource = q;

        }
    }
}