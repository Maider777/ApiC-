using Newtonsoft.Json;
using RestSharp;

namespace FrankPatata
{
    public partial class PokeApi : Form
    {
        string imagen;
        public PokeApi()
        {
            InitializeComponent();
        }

        private void PokeApi_Load(object sender, EventArgs e)
        {
            //cargar listado de pokemon
            string url = "http://10.10.12.87:8080/main/dameListado?api=2";
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(url);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", "Bearer " + Form1.token);
            RestResponse restResponse = restClient.Get(restRequest);

            //si contiene algo
            if (restResponse != null)
            {
                //deserializar
                string responseContent = restResponse.Content.ToString();
                //obtener lista de pokemon
                List<ClassPokeApi> listPokemon = JsonConvert.DeserializeObject<List<ClassPokeApi>>(responseContent);

                //poner imagenes en pictureBox
                //hacer autoscroll automatico
                this.AutoScroll = true;

                PictureBox[] picturebox = new PictureBox[listPokemon.Count];
                int y = 220;
                //Interaction.MsgBox(listGames.Count);
                for (int i = 0; i < listPokemon.Count; i++)
                {
                    PictureBox box = new PictureBox();
                    box.Width = y;
                    box.Height = y;
                    imagen = listPokemon[i].imagen;
                    box.Load(imagen);
                    box.SizeMode = PictureBoxSizeMode.StretchImage;
                    box.Location = new Point(14, 17);
                    box.Size = new Size(box.Width, box.Height);
                    picturebox[i] = box;
                    picturebox[i].Name = listPokemon[i].name;
                    //crear flowlayout y añadir pokemons
                    flowLayoutPokemon.Controls.Add(box);
                }
            }
        }
    }
}
