using FrankPatata.Properties;
using Newtonsoft.Json;
using RestSharp;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FrankPatata
{
    public partial class menuApps : Form
    {
        //variables
        List<AveragePoints> listaMediaPuntos;
        List<ClassLoadRanking> rankings;
        public static double ranking;
        public static int appId;
        public static int id1;
        public static int id2;
        public static int id3;
        public static double mP1;
        public static double mP2;
        public static double mP3;
        public static bool button1WasClicked = false;
        public static bool button2WasClicked = false;
        public static bool button3WasClicked = false;
        public static bool buttonDetails1Clicked = false;
        public static bool buttonDetails2Clicked = false;
        public static bool buttonDetails3Clicked = false;

        public menuApps()
        {
            InitializeComponent();
            Image img = (Image)Properties.Resources.ResourceManager.GetObject("icons8-salir-redondeado-50");
            buttonLogOut.Image = img;

            //load images
            Image img1 = (Image)Properties.Resources.ResourceManager.GetObject("pokeApi");
            pbPokeApi.Image = img1;

            Image img2 = (Image)Properties.Resources.ResourceManager.GetObject("freeToPlay");
            pbFreeToPlay.Image = img2;

            Image img3 = (Image)Properties.Resources.ResourceManager.GetObject("netflix");
            pbNetflix.Image = img3;
        }

        private async void postRanking(double ranking, int appId)
        {
            //get description and comments
            string url = "http://localhost:8080/ranking/crearRanking";
            ClassRanking objeto = new ClassRanking
            {
                app_id = appId.ToString(),
                puntos = ranking.ToString(),
            };

            //serialize object
            string jsonString = JsonSerializer.Serialize(objeto);

            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(url);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", "Bearer " + Form1.token);
            restRequest.AddBody(jsonString);
            RestResponse restResponse = restClient.Post(restRequest);

            string responseContent = restResponse.Content.ToString();
        }

        private void pokeApi_pb_star1_Click(object sender, EventArgs e)
        {
            //fill star until clicked
            pokeApi_pb_star1.Image = Resources.yellow_star;
            pokeApi_pb_star2.Image = Resources.white_star;
            pokeApi_pb_star3.Image = Resources.white_star;
            pokeApi_pb_star4.Image = Resources.white_star;
            pokeApi_pb_star5.Image = Resources.white_star;

            //get and send user score
            //post method
            ranking = 1;
            appId = id2;
            postRanking(ranking,appId);
        }


        private void pokeApi_pb_star2_Click(object sender, EventArgs e)
        {
            pokeApi_pb_star1.Image = Resources.yellow_star;
            pokeApi_pb_star2.Image = Resources.yellow_star;
            pokeApi_pb_star3.Image = Resources.white_star;
            pokeApi_pb_star4.Image = Resources.white_star;
            pokeApi_pb_star5.Image = Resources.white_star;

            ranking = 2;
            appId = id2;
            postRanking(ranking, appId);
        }

        private void pokeApi_pb_star3_Click(object sender, EventArgs e)
        {
            pokeApi_pb_star1.Image = Resources.yellow_star;
            pokeApi_pb_star2.Image = Resources.yellow_star;
            pokeApi_pb_star3.Image = Resources.yellow_star;
            pokeApi_pb_star4.Image = Resources.white_star;
            pokeApi_pb_star5.Image = Resources.white_star;

            ranking = 3;
            appId = id2;
            postRanking(ranking, appId);
        }

        private void pokeApi_pb_star4_Click(object sender, EventArgs e)
        {
            pokeApi_pb_star1.Image = Resources.yellow_star;
            pokeApi_pb_star2.Image = Resources.yellow_star;
            pokeApi_pb_star3.Image = Resources.yellow_star;
            pokeApi_pb_star4.Image = Resources.yellow_star;
            pokeApi_pb_star5.Image = Resources.white_star;

            ranking = 4;
            appId = id2;
            postRanking(ranking, appId);
        }

        private void pokeApi_pb_star5_Click(object sender, EventArgs e)
        {
            pokeApi_pb_star1.Image = Resources.yellow_star;
            pokeApi_pb_star2.Image = Resources.yellow_star;
            pokeApi_pb_star3.Image = Resources.yellow_star;
            pokeApi_pb_star4.Image = Resources.yellow_star;
            pokeApi_pb_star5.Image = Resources.yellow_star;

            ranking = 5;
            appId = id2;
            postRanking(ranking, appId);
        }

        private void freeToPlay_pb_star1_Click(object sender, EventArgs e)
        {
            freeToPlay_pb_star1.Image = Resources.yellow_star;
            freeToPlay_pb_star2.Image = Resources.white_star;
            freeToPlay_pb_star3.Image = Resources.white_star;
            freeToPlay_pb_star4.Image = Resources.white_star;
            freeToPlay_pb_star5.Image = Resources.white_star;

            ranking = 1;
            appId = id1;
            postRanking(ranking, appId);
        }

        private void freeToPlay_pb_star2_Click(object sender, EventArgs e)
        {
            freeToPlay_pb_star1.Image = Resources.yellow_star;
            freeToPlay_pb_star2.Image = Resources.yellow_star;
            freeToPlay_pb_star3.Image = Resources.white_star;
            freeToPlay_pb_star4.Image = Resources.white_star;
            freeToPlay_pb_star5.Image = Resources.white_star;

            ranking = 2;
            appId = id1;
            postRanking(ranking, appId);
        }

        private void freeToPlay_pb_star3_Click(object sender, EventArgs e)
        {
            freeToPlay_pb_star1.Image = Resources.yellow_star;
            freeToPlay_pb_star2.Image = Resources.yellow_star;
            freeToPlay_pb_star3.Image = Resources.yellow_star;
            freeToPlay_pb_star4.Image = Resources.white_star;
            freeToPlay_pb_star5.Image = Resources.white_star;

            ranking = 3;
            appId = id1;
            postRanking(ranking, appId);
        }

        private void freeToPlay_pb_star4_Click(object sender, EventArgs e)
        {
            freeToPlay_pb_star1.Image = Resources.yellow_star;
            freeToPlay_pb_star2.Image = Resources.yellow_star;
            freeToPlay_pb_star3.Image = Resources.yellow_star;
            freeToPlay_pb_star4.Image = Resources.yellow_star;
            freeToPlay_pb_star5.Image = Resources.white_star;

            ranking = 4;
            appId = id1;
            postRanking(ranking, appId);
        }

        private void freeToPlay_pb_star5_Click(object sender, EventArgs e)
        {
            freeToPlay_pb_star1.Image = Resources.yellow_star;
            freeToPlay_pb_star2.Image = Resources.yellow_star;
            freeToPlay_pb_star3.Image = Resources.yellow_star;
            freeToPlay_pb_star4.Image = Resources.yellow_star;
            freeToPlay_pb_star5.Image = Resources.yellow_star;

            ranking = 5;
            appId = id1;
            postRanking(ranking, appId);
        }

        private void netflix_pb_star1_Click(object sender, EventArgs e)
        {
            netflix_pb_star1.Image = Resources.yellow_star;
            netflix_pb_star2.Image = Resources.white_star;
            netflix_pb_star3.Image = Resources.white_star;
            netflix_pb_star4.Image = Resources.white_star;
            netflix_pb_star5.Image = Resources.white_star;

            ranking = 1;
            appId = id3;
            postRanking(ranking, appId);
        }

        private void netflix_pb_star2_Click(object sender, EventArgs e)
        {
            netflix_pb_star1.Image = Resources.yellow_star;
            netflix_pb_star2.Image = Resources.yellow_star;
            netflix_pb_star3.Image = Resources.white_star;
            netflix_pb_star4.Image = Resources.white_star;
            netflix_pb_star5.Image = Resources.white_star;

            ranking = 2;
            appId = id3;
            postRanking(ranking, appId);
        }

        private void netflix_pb_star3_Click(object sender, EventArgs e)
        {
            netflix_pb_star1.Image = Resources.yellow_star;
            netflix_pb_star2.Image = Resources.yellow_star;
            netflix_pb_star3.Image = Resources.yellow_star;
            netflix_pb_star4.Image = Resources.white_star;
            netflix_pb_star5.Image = Resources.white_star;

            ranking = 3;
            appId = id3;
            postRanking(ranking, appId);
        }

        private void netflix_pb_star4_Click(object sender, EventArgs e)
        {
            netflix_pb_star1.Image = Resources.yellow_star;
            netflix_pb_star2.Image = Resources.yellow_star;
            netflix_pb_star3.Image = Resources.yellow_star;
            netflix_pb_star4.Image = Resources.yellow_star;
            netflix_pb_star5.Image = Resources.white_star;

            ranking = 4;
            appId = id3;
            postRanking(ranking, appId);
        }

        private void netflix_pb_star5_Click(object sender, EventArgs e)
        {
            netflix_pb_star1.Image = Resources.yellow_star;
            netflix_pb_star2.Image = Resources.yellow_star;
            netflix_pb_star3.Image = Resources.yellow_star;
            netflix_pb_star4.Image = Resources.yellow_star;
            netflix_pb_star5.Image = Resources.yellow_star;

            ranking = 5;
            appId = id3;
            postRanking(ranking, appId);
        }

        private void buttonNetflix_Click(object sender, EventArgs e)
        {
            //open netflix
            button1WasClicked = false;
            button2WasClicked = false;
            button3WasClicked = true;
            App app = new App();
            appId = id3;
            app.Show();
        }

        private void rankingLoad()
        {
            //put given ranking of apps
            string url = "http://localhost:8080/ranking/dameRankings";
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(url);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", "Bearer " + Form1.token);

            RestResponse restResponse = restClient.Get(restRequest);

            //if isnt null
            if (restResponse != null)
            {
                //deserialize
                string responseContent = restResponse.Content.ToString();
                //get average points
                rankings = JsonConvert.DeserializeObject<List<ClassLoadRanking>>(responseContent);

                if (restResponse != null)
                {
                    string puntos1 = rankings[0].puntos.Substring(0, 1);
                    int puntos1Int = int.Parse(puntos1);
                    if(puntos1Int.Equals(1))
                    {
                        //1-freeToPlay
                        freeToPlay_pb_star1.Image = Resources.yellow_star;
                    }else if (puntos1Int.Equals(2))
                    {
                        freeToPlay_pb_star1.Image = Resources.yellow_star;
                        freeToPlay_pb_star2.Image = Resources.yellow_star;
                    }else if (puntos1Int.Equals(3))
                    {
                        freeToPlay_pb_star1.Image = Resources.yellow_star;
                        freeToPlay_pb_star2.Image = Resources.yellow_star;
                        freeToPlay_pb_star3.Image = Resources.yellow_star;
                    }else if (puntos1Int.Equals(4))
                    {
                        freeToPlay_pb_star1.Image = Resources.yellow_star;
                        freeToPlay_pb_star2.Image = Resources.yellow_star;
                        freeToPlay_pb_star3.Image = Resources.yellow_star;
                        freeToPlay_pb_star4.Image = Resources.yellow_star;
                    }else if (puntos1Int.Equals(5))
                    {
                        freeToPlay_pb_star1.Image = Resources.yellow_star;
                        freeToPlay_pb_star2.Image = Resources.yellow_star;
                        freeToPlay_pb_star3.Image = Resources.yellow_star;
                        freeToPlay_pb_star4.Image = Resources.yellow_star;
                        freeToPlay_pb_star5.Image = Resources.yellow_star;
                    }
                    //2-PokeApi
                    string puntos2 = rankings[1].puntos.Substring(0,1);
                    int puntos2Int = int.Parse(puntos2);
                    if (puntos2Int.Equals(1))
                    {
                        pokeApi_pb_star1.Image = Resources.yellow_star;
                    }
                    else if (puntos2Int.Equals(2))
                    {
                        pokeApi_pb_star1.Image = Resources.yellow_star;
                        pokeApi_pb_star2.Image = Resources.yellow_star;
                    }
                    else if (puntos2Int.Equals(3))
                    {
                        pokeApi_pb_star1.Image = Resources.yellow_star;
                        pokeApi_pb_star2.Image = Resources.yellow_star;
                        pokeApi_pb_star3.Image = Resources.yellow_star;
                    }
                    else if (puntos2Int.Equals(4))
                    {
                        pokeApi_pb_star1.Image = Resources.yellow_star;
                        pokeApi_pb_star2.Image = Resources.yellow_star;
                        pokeApi_pb_star3.Image = Resources.yellow_star;
                        pokeApi_pb_star4.Image = Resources.yellow_star;
                    }
                    else if (puntos2Int.Equals(5))
                    {
                        pokeApi_pb_star1.Image = Resources.yellow_star;
                        pokeApi_pb_star2.Image = Resources.yellow_star;
                        pokeApi_pb_star3.Image = Resources.yellow_star;
                        pokeApi_pb_star4.Image = Resources.yellow_star;
                        pokeApi_pb_star5.Image = Resources.yellow_star;
                    }
                    //3-Netflix
                    string puntos3 = rankings[2].puntos.Substring(0,1);
                    int puntos3Int = int.Parse(puntos3);
                    if (puntos3Int.Equals(1))
                    {
                        netflix_pb_star1.Image = Resources.yellow_star;
                    }else if (puntos3Int.Equals(2))
                    {
                        netflix_pb_star1.Image = Resources.yellow_star;
                        netflix_pb_star2.Image = Resources.yellow_star;
                    }else if (puntos3Int.Equals(3))
                    {
                        netflix_pb_star1.Image = Resources.yellow_star;
                        netflix_pb_star2.Image = Resources.yellow_star;
                        netflix_pb_star3.Image = Resources.yellow_star;
                    }else if (puntos3Int.Equals(4))
                    {
                        netflix_pb_star1.Image = Resources.yellow_star;
                        netflix_pb_star2.Image = Resources.yellow_star;
                        netflix_pb_star3.Image = Resources.yellow_star;
                        netflix_pb_star4.Image = Resources.yellow_star;
                    }else if (puntos3Int.Equals(5))
                    {
                        netflix_pb_star1.Image = Resources.yellow_star;
                        netflix_pb_star2.Image = Resources.yellow_star;
                        netflix_pb_star3.Image = Resources.yellow_star;
                        netflix_pb_star4.Image = Resources.yellow_star;
                        netflix_pb_star5.Image = Resources.yellow_star;
                    }

                    string appId1 = rankings[0].app_id;
                    string appId2 = rankings[1].app_id;
                    string appId3 = rankings[2].app_id;
                }
            }
        }

        private void Appcs_Load(object sender, EventArgs e)
        {
            //strecth image logOut
            buttonLogOut.BackgroundImageLayout = ImageLayout.Stretch;
            rankingLoad();
            //average
            string url = "http://localhost:8080/app/dameApps";
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(url);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", "Bearer " + Form1.token);

            RestResponse restResponse = restClient.Get(restRequest);

            //if isnt null
            if (restResponse != null)
            {
                //deserialize
                string responseContent = restResponse.Content.ToString();
                //get average
                listaMediaPuntos = JsonConvert.DeserializeObject<List<AveragePoints>>(responseContent);

                //put average of the app
                mP1 = listaMediaPuntos[0].mediaPuntos;
                id1 = listaMediaPuntos[0].app_id;
                string smP1 = mP1.ToString();
                if (smP1.Length > 4)
                {
                    smP1 = smP1.Substring(0, 4);
                }
                rating_lbl_FreeToPlay.Text = smP1;
                

                mP2 = listaMediaPuntos[1].mediaPuntos;
                id2 = listaMediaPuntos[1].app_id;
                string smP2 = mP2.ToString();
                if (smP2.Length > 4)
                {
                    smP2 = smP2.Substring(0, 4);
                }
                rating_lbl_PokeApi.Text = smP2;

                mP3 = listaMediaPuntos[2].mediaPuntos;
                id3 = listaMediaPuntos[2].app_id;
                string smP3 = mP3.ToString();
                if (smP3.Length > 4)
                {
                    smP3 = smP3.Substring(0, 4);
                }
                rating_lbl_Netflix.Text = smP3;
            }
        }

        private void buttonPokeApi_Click(object sender, EventArgs e)
        {
            //open pokeApi
            button1WasClicked = true;
            button2WasClicked = false;
            button3WasClicked = false;
            App app = new App();
            appId = id2;
            app.Show();
        }

        private void buttonFreeToPlay_Click(object sender, EventArgs e)
        {
            //open FreeToPlay
            button1WasClicked = false;
            button2WasClicked = true;
            button3WasClicked = false;
            App app = new App();
            appId = id1;
            app.Show();
        }

        private void buttonDetails1_Click(object sender, EventArgs e)
        {
            //pokeApi comments, new window
            buttonDetails1Clicked = true;
            buttonDetails2Clicked = false;
            buttonDetails3Clicked = false;
            appId = id2;
            DetailsApp details1 = new DetailsApp();
            details1.Show();
        }

        private void buttonDetails2_Click(object sender, EventArgs e)
        {
            //FreeToPlay comments, new window
            buttonDetails1Clicked = false;
            buttonDetails2Clicked = true;
            buttonDetails3Clicked = false;
            appId = id1;
            DetailsApp details = new DetailsApp();
            details.Show();
        }

        private void buttonDetails3_Click(object sender, EventArgs e)
        {
            //Netflix comments, new window
            buttonDetails1Clicked = false;
            buttonDetails2Clicked = false;
            buttonDetails3Clicked = true;
            appId = id3;
            DetailsApp detailsApp = new DetailsApp();
            detailsApp.Show();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            //log out button
            this.Close();
            Form1.username = "";
            Form1.password = "";
            Form1.userId = 0;
            Form1.token = "";
        //go to sign in form
        Form1 form = new Form1();
            form.Show();
        }
    }
}
