using FrankPatata.Properties;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using RestSharp;
using System.Windows.Forms;

namespace FrankPatata
{
    public partial class Appcs : Form
    {
        List<ClassMediaPuntos> listaMediaPuntos;
        double[] mediaPuntos;
        public Appcs()
        {
            InitializeComponent();
        }

        private void pokeApi_pb_star1_Click(object sender, EventArgs e)
        {
            //poner en amarillo hasta la que se clicke
            pokeApi_pb_star1.Image = Resources.yellow_star;
            pokeApi_pb_star2.Image = Resources.white_star;
            pokeApi_pb_star3.Image = Resources.white_star;
            pokeApi_pb_star4.Image = Resources.white_star;
            pokeApi_pb_star5.Image = Resources.white_star;
        }

        private void pokeApi_pb_star2_Click(object sender, EventArgs e)
        {
            pokeApi_pb_star1.Image = Resources.yellow_star;
            pokeApi_pb_star2.Image = Resources.yellow_star;
            pokeApi_pb_star3.Image = Resources.white_star;
            pokeApi_pb_star4.Image = Resources.white_star;
            pokeApi_pb_star5.Image = Resources.white_star;
        }

        private void pokeApi_pb_star3_Click(object sender, EventArgs e)
        {
            pokeApi_pb_star1.Image = Resources.yellow_star;
            pokeApi_pb_star2.Image = Resources.yellow_star;
            pokeApi_pb_star3.Image = Resources.yellow_star;
            pokeApi_pb_star4.Image = Resources.white_star;
            pokeApi_pb_star5.Image = Resources.white_star;
        }

        private void pokeApi_pb_star4_Click(object sender, EventArgs e)
        {
            pokeApi_pb_star1.Image = Resources.yellow_star;
            pokeApi_pb_star2.Image = Resources.yellow_star;
            pokeApi_pb_star3.Image = Resources.yellow_star;
            pokeApi_pb_star4.Image = Resources.yellow_star;
            pokeApi_pb_star5.Image = Resources.white_star;
        }

        private void pokeApi_pb_star5_Click(object sender, EventArgs e)
        {
            pokeApi_pb_star1.Image = Resources.yellow_star;
            pokeApi_pb_star2.Image = Resources.yellow_star;
            pokeApi_pb_star3.Image = Resources.yellow_star;
            pokeApi_pb_star4.Image = Resources.yellow_star;
            pokeApi_pb_star5.Image = Resources.yellow_star;
        }

        private void freeToPlay_pb_star1_Click(object sender, EventArgs e)
        {
            freeToPlay_pb_star1.Image = Resources.yellow_star;
            freeToPlay_pb_star2.Image = Resources.white_star;
            freeToPlay_pb_star3.Image = Resources.white_star;
            freeToPlay_pb_star4.Image = Resources.white_star;
            freeToPlay_pb_star5.Image = Resources.white_star;
        }

        private void freeToPlay_pb_star2_Click(object sender, EventArgs e)
        {
            freeToPlay_pb_star1.Image = Resources.yellow_star;
            freeToPlay_pb_star2.Image = Resources.yellow_star;
            freeToPlay_pb_star3.Image = Resources.white_star;
            freeToPlay_pb_star4.Image = Resources.white_star;
            freeToPlay_pb_star5.Image = Resources.white_star;
        }

        private void freeToPlay_pb_star3_Click(object sender, EventArgs e)
        {
            freeToPlay_pb_star1.Image = Resources.yellow_star;
            freeToPlay_pb_star2.Image = Resources.yellow_star;
            freeToPlay_pb_star3.Image = Resources.yellow_star;
            freeToPlay_pb_star4.Image = Resources.white_star;
            freeToPlay_pb_star5.Image = Resources.white_star;
        }

        private void freeToPlay_pb_star4_Click(object sender, EventArgs e)
        {
            freeToPlay_pb_star1.Image = Resources.yellow_star;
            freeToPlay_pb_star2.Image = Resources.yellow_star;
            freeToPlay_pb_star3.Image = Resources.yellow_star;
            freeToPlay_pb_star4.Image = Resources.yellow_star;
            freeToPlay_pb_star5.Image = Resources.white_star;
        }

        private void freeToPlay_pb_star5_Click(object sender, EventArgs e)
        {
            freeToPlay_pb_star1.Image = Resources.yellow_star;
            freeToPlay_pb_star2.Image = Resources.yellow_star;
            freeToPlay_pb_star3.Image = Resources.yellow_star;
            freeToPlay_pb_star4.Image = Resources.yellow_star;
            freeToPlay_pb_star5.Image = Resources.yellow_star;
        }

        private void netflix_pb_star1_Click(object sender, EventArgs e)
        {
            netflix_pb_star1.Image = Resources.yellow_star;
            netflix_pb_star2.Image = Resources.white_star;
            netflix_pb_star3.Image = Resources.white_star;
            netflix_pb_star4.Image = Resources.white_star;
            netflix_pb_star5.Image = Resources.white_star;
        }

        private void netflix_pb_star2_Click(object sender, EventArgs e)
        {
            netflix_pb_star1.Image = Resources.yellow_star;
            netflix_pb_star2.Image = Resources.yellow_star;
            netflix_pb_star3.Image = Resources.white_star;
            netflix_pb_star4.Image = Resources.white_star;
            netflix_pb_star5.Image = Resources.white_star;
        }

        private void netflix_pb_star3_Click(object sender, EventArgs e)
        {
            netflix_pb_star1.Image = Resources.yellow_star;
            netflix_pb_star2.Image = Resources.yellow_star;
            netflix_pb_star3.Image = Resources.yellow_star;
            netflix_pb_star4.Image = Resources.white_star;
            netflix_pb_star5.Image = Resources.white_star;
        }

        private void netflix_pb_star4_Click(object sender, EventArgs e)
        {
            netflix_pb_star1.Image = Resources.yellow_star;
            netflix_pb_star2.Image = Resources.yellow_star;
            netflix_pb_star3.Image = Resources.yellow_star;
            netflix_pb_star4.Image = Resources.yellow_star;
            netflix_pb_star5.Image = Resources.white_star;
        }

        private void netflix_pb_star5_Click(object sender, EventArgs e)
        {
            netflix_pb_star1.Image = Resources.yellow_star;
            netflix_pb_star2.Image = Resources.yellow_star;
            netflix_pb_star3.Image = Resources.yellow_star;
            netflix_pb_star4.Image = Resources.yellow_star;
            netflix_pb_star5.Image = Resources.yellow_star;
        }

        private void comments1_Click(object sender, EventArgs e)
        {
            //comentarios de pokeApi, nueva ventana
            DetailsApp1 details1=new DetailsApp1();
            details1.Show();
        }

        private void comments2_Click(object sender, EventArgs e)
        {
            //comentarios de FreeToPlay
            DetailsApp2 details2=new DetailsApp2();
            details2.Show();
        }

        private void comments3_Click(object sender, EventArgs e)
        {
            //comentarios de Netflix
            DetailsApp3 detailsApp3 = new DetailsApp3();
            detailsApp3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //abrir app de pokeApi
            PokeApi pokeApi = new PokeApi();
            pokeApi.Show();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            //abrir app de freeToPlay
            FreeToPlay freeToPlay = new FreeToPlay();
            freeToPlay.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //abrir app de netflix
            Netflix netflix = new Netflix();
            netflix.Show();
        }

        private void Appcs_Load(object sender, EventArgs e)
        {
            //poner medias de las apps
        
            string url = "http://10.10.12.87:8080/main/dameApps";
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(url);
            restRequest.AddHeader("Content-Type", "application/json");
            //Interaction.MsgBox(Form1.token);
            restRequest.AddHeader("Authorization", "Bearer " + Form1.token);

            RestResponse restResponse = restClient.Get(restRequest);

            //si contiene algo
            if (restResponse != null)
            {
                //deserializar
                string responseContent = restResponse.Content.ToString();
                
                //obtener media de puntos
                listaMediaPuntos = JsonConvert.DeserializeObject<List<ClassMediaPuntos>>(responseContent);

                mediaPuntos = new double[listaMediaPuntos.Count];
                for(int i = 0; i < listaMediaPuntos.Count; i++)
                {
                    ClassMediaPuntos item = listaMediaPuntos[i];
                    mediaPuntos[i] = listaMediaPuntos[i].mediaPuntos;
                    //Interaction.MsgBox(item.mediaPuntos);
                }

                //poner datos
                double mP1=mediaPuntos[0];
                string smP1 = mP1.ToString();
                ratinglblPokeApi.Text=smP1;

                double mP2 = mediaPuntos[1];
                string smP2 = mP2.ToString();
                ratinglblFreeToPlay.Text = smP2;

                double mP3 = mediaPuntos[2];
                string smP3 = mP3.ToString();
                ratinglblNetflix.Text = smP3;
            }
        }
    }
}
