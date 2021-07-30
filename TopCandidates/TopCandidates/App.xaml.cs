using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using TopCandidates.Models;
using TopCandidates.Views;
using Xamarin.Forms;

namespace TopCandidates
{
    public partial class App : Application
    {
        public string filepath;
        public App()
        {
            InitializeComponent();

            //Conecta à base de dados de acordco com a plataforma
            if (Device.RuntimePlatform == Device.iOS)
            {
                //iOS
                string libraryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library"); // Library folder instead
                filepath = Path.Combine(libraryPath, "candidates.csv");
                GlobalVar.databasePath = Path.Combine(libraryPath, "top_candidates.db3");
                GlobalVar.dataBase = new SQLiteConnection(GlobalVar.databasePath);
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                //Android
                filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "candidates.csv");
                GlobalVar.databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "top_candidates.db3");
                GlobalVar.dataBase = new SQLiteConnection(GlobalVar.databasePath);

            }

            if (!GlobalVar.dataBase.TableMappings.Any(m => m.MappedType.Name == typeof(Candidate).Name))
            {
                GlobalVar.dataBase.DropTable<Candidate>();
                GlobalVar.dataBase.CreateTable<Candidate>();
                GlobalVar.dataBase.DropTable<Experience>();
                GlobalVar.dataBase.CreateTable<Experience>();
                SyncCandidates();
            }

            if (!GlobalVar.dataBase.TableMappings.Any(m => m.MappedType.Name == typeof(Technologie).Name))
            {
                GlobalVar.dataBase.DropTable<Technologie>();
                GlobalVar.dataBase.CreateTable<Technologie>();
                SyncTechnologies();
            }

            MainPage = new NavigationPage(new Welcome());
        }

        public async void SyncCandidates()
        {
            try
            {
                //Conectando à API
                var httpClient = new HttpClient();

                //Definindo a API a ser chamada
                var response = await httpClient.GetStringAsync("https://app.ifs.aero/EternalBlue/api/candidates");

                //Recuperando os dados da API e deserializando
                var candidate = JsonConvert.DeserializeObject<List<Candidate>>(response);

                //Insere os dados retornados da API
                GlobalVar.dataBase.DeleteAll<Candidate>();
                GlobalVar.dataBase.InsertAll(candidate);

                var allcandidates = JsonConvert.DeserializeObject<List<AllCandidate>>(response);

                List<AllCandidate> candidates = new List<AllCandidate>();
                List<Experience> experiences = new List<Experience>();

                GlobalVar.dataBase.DeleteAll<Experience>();

                foreach (AllCandidate candits in allcandidates)
                {
                    if ((candits.experience).Count > 0)
                    {
                        foreach (Experience exp in candits.experience)
                        {
                            exp.candidateId = candits.candidateId;
                            exp.Candidate = candits.fullName;
                            experiences.Add(exp);
                           
                         }
                    }
                }
                GlobalVar.dataBase.InsertAll(experiences);

            }
            catch (HttpRequestException ex)
            {
                await MainPage.DisplayAlert("Synchronization error", "The following error was generated on synchronizing the candidates database: " + ex.Message + ".\nTry again later", "OK");
            }
        }

        public async void SyncTechnologies()
        {
            try
            {
                //Conectando à API
                var httpClient = new HttpClient();

                //Definindo a API a ser chamada
                var response = await httpClient.GetStringAsync("https://app.ifs.aero/EternalBlue/api/technologies");

                //Recuperando os dados da API e deserializando
                var tecnologie = JsonConvert.DeserializeObject<List<Technologie>>(response);

                var experience = JsonConvert.DeserializeObject<List<Experience>>(response);

                //Insere os dados retornados da API
                GlobalVar.dataBase.DeleteAll<Technologie>();
                GlobalVar.dataBase.InsertAll(tecnologie);
                                

            }
            catch (HttpRequestException ex)
            {
                await MainPage.DisplayAlert("Synchronization error", "The following error was generated on synchronizing the candidates database: " + ex.Message + ".\nTry again later", "OK");
            }
        }
               
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
