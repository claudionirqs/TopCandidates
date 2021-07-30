using TopCandidates.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TopCandidates
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


        }

        private void OpenCandidates_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Candidates());

        }

        private void OpenTechnologies_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Technologies());

        }

        private void OpenExperiences_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Experiences());

        }

        private void OpenAccepted_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Accepted());

        }
    }
}
