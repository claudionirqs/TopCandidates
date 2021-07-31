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
            List<Candidate> listCandidate = GlobalVar.dataBase.Query<Candidate>("select fullName, IFNULL(profilePicture, 'question.png') profilePicture, email from tabcandidates WHERE status = 0");
            lvCandidates.ItemsSource = listCandidate;

        }
    }
}