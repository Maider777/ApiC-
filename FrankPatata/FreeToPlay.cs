using RestSharp;
using Newtonsoft.Json;

namespace FrankPatata
{
    public partial class FreeToPlay : Form
    {
        string imagen;
        public FreeToPlay()
        {
            InitializeComponent();
        }

        private async void FreeToPlay_Load(object sender, EventArgs e)
        {
            
            //cargar listado de juegos
            string url = "http://10.10.12.87:8080/main/dameListado?api=1";
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
                //obtener lista de juegos
                List<ClassFreeToPlay> listGames = JsonConvert.DeserializeObject<List<ClassFreeToPlay>>(responseContent);

                //poner imagenes en pictureBox
                //hacer autoscroll automatico
                this.AutoScroll = true;

                PictureBox[] picturebox = new PictureBox[listGames.Count];
                int y = 220;
                //Interaction.MsgBox(listGames.Count);
                for (int i = 0; i < listGames.Count; i++)
                {
                    PictureBox box = new PictureBox();
                    box.Width = y;
                    box.Height = y;
                    imagen = listGames[i].imagen;
                    box.Load(imagen);
                    box.SizeMode = PictureBoxSizeMode.StretchImage;
                    box.Location = new Point(14, 17);
                    box.Size = new Size(box.Width, box.Height);
                    picturebox[i] = box;
                    picturebox[i].Name = listGames[i].name;
                    //crear flowlayout y añadir juegos
                    flowLayoutGames.Controls.Add(box);
                }
            }
            
        }
    }
}
