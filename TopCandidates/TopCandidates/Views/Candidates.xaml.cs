using MLToolkit.Forms.SwipeCardView;
using MLToolkit.Forms.SwipeCardView.Core;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Input;
using TopCandidates.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TopCandidates.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Candidates : ContentPage
    {
        public Candidates()
        {
            InitializeComponent();

            loadCandidates();

        }

        public void loadCandidates()
        {
            List<Candidate> listCandidate = GlobalVar.dataBase.Query<Candidate>("SELECT * FROM tabcandidates");
            SwipeCardView.ItemsSource = listCandidate;

        }

        public static Boolean TableExists(String tableName, SQLiteConnection connection)
        {
            SQLite.TableMapping map = new TableMapping(typeof(SqlDbType)); // Instead of mapping to a specific table just map the whole database type
            object[] ps = new object[0]; // An empty parameters object since I never worked out how to use it properly! (At least I'm honest)

            Int32 tableCount = connection.Query(map, "SELECT * FROM sqlite_master WHERE type = 'table' AND name = '" + tableName + "'", ps).Count; // Executes the query from which we can count the results
            if (tableCount == 0)
            {
                return false;
            }
            else if (tableCount == 1)
            {
                return true;
            }
            else
            {
                throw new Exception("More than one table by the name of " + tableName + " exists in the database.", null);
            }
        }

        private void OnDislikeClicked(object sender, EventArgs e)
        {
            SwipeCardView.InvokeSwipe((MLToolkit.Forms.SwipeCardView.Core.SwipeCardDirection)MLToolkit.Forms.SwipeCardView.Core.SwipeCardDirection.Left);
        }

        private void OnSuperLikeClicked(object sender, EventArgs e)
        {
            SwipeCardView.InvokeSwipe((MLToolkit.Forms.SwipeCardView.Core.SwipeCardDirection)MLToolkit.Forms.SwipeCardView.Core.SwipeCardDirection.Up);
        }

        private void OnLikeClicked(object sender, EventArgs e)
        {
            SwipeCardView.InvokeSwipe((MLToolkit.Forms.SwipeCardView.Core.SwipeCardDirection)MLToolkit.Forms.SwipeCardView.Core.SwipeCardDirection.Right);
        }

        private void OnSwiped(object sender, SwipedCardEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeCardDirection.None:
                    break;
                case SwipeCardDirection.Right: 
                    var item = (Candidate)e.Item;
                    var email = item.email;
                    
                    string updateQuery = "UPDATE tabcandidates SET status = 1 WHERE email = '"+ email +"'";
                    GlobalVar.dataBase.Execute(updateQuery);
                    break;
                case SwipeCardDirection.Left:
                    break;
                case SwipeCardDirection.Up:
                    break;
                case SwipeCardDirection.Down:
                    break;
            }
        }
        
    }
}