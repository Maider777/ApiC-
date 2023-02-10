using Newtonsoft.Json;
using RestSharp;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FrankPatata
{
    public partial class DetailsApp : Form
    {
        ClassDetails clase;
        string comment="";
        public DetailsApp()
        {
            InitializeComponent();
            Image img = (Image)Properties.Resources.ResourceManager.GetObject("icons8-volver-50");
            buttonReturn.Image = img;

            Image img2 = (Image)Properties.Resources.ResourceManager.GetObject("envia2");
            buttonSend.Image = img2;
        }

        private void DetailsApp1_Load(object sender, EventArgs e)
        {
            //strecth image
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            //strecth return button
            buttonReturn.BackgroundImageLayout = ImageLayout.Stretch;
            //set app score
            averageScore.Text = menuApps.mP3.ToString();
            comments.Text = "";

            //get description and comments
            string url = "";
            if (menuApps.buttonDetails1Clicked)
            {
                url = "http://localhost:8080/app/dameApp?app_id=2";
                labelTitle.Text = "Poke Api";
                Image img = (Image)Properties.Resources.ResourceManager.GetObject("pokeApi");
                pictureBox1.Image = img;

            }
            if (menuApps.buttonDetails2Clicked)
            {
                url = "http://localhost:8080/app/dameApp?app_id=1";
                labelTitle.Text = "Free To Play";
                Image img = (Image)Properties.Resources.ResourceManager.GetObject("freeToPlay");
                pictureBox1.Image = img;
            }
            if (menuApps.buttonDetails3Clicked)
            {
                url = "http://localhost:8080/app/dameApp?app_id=3";
                labelTitle.Text = "Netflix";
                Image img = (Image)Properties.Resources.ResourceManager.GetObject("netflix");
                pictureBox1.Image = img;
            }

            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(url);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", "Bearer " + Form1.token);

            RestResponse restResponse = restClient.Get(restRequest);

            if (restResponse != null)
            {
                //deserialize
                string responseContent = restResponse.Content.ToString();
                //get data
                clase = JsonConvert.DeserializeObject<ClassDetails>(responseContent);
                description.Text = clase.descripcion;
                for (int i = 0; i < clase.listaComentarios.Count; i++)
                {
                    comments.Text += "\n" + clase.listaComentarios[i].username + " - " + clase.listaComentarios[i].hora + "\n" + clase.listaComentarios[i].comment_text + "\n";
                }

            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            //get comment and send
            string comment = textBoxComment.Text;
            if (comment != null || comment.Length > 0)
            {
                var CreateAppComment = new CreateAppComment
                {
                    comment_text = comment,
                    hora = DateTime.Now.ToString("hh:mm:ss"),
                    app_id = menuApps.appId.ToString(),
                };

                Uri url = new Uri("http://localhost:8080/comentarioApp/crearComentarioApp");
                RestClient restClient = new RestClient();
                RestRequest restRequest = new RestRequest(url);
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddHeader("Authorization", "Bearer " + Form1.token);
                string jsonString = JsonSerializer.Serialize(CreateAppComment);
                restRequest.AddBody(jsonString);
                RestResponse restResponse = restClient.Post(restRequest);
                String hourMinute = DateTime.Now.ToString("HH:mm");

                string responseContent = restResponse.Content.ToString();
                //if its ok
                comment = textBoxComment.Text;
                comments.Text += "\n" + "Username:" + Form1.username + "\n" + "Hour:" + hourMinute + "\n" + comment + "\n";
                
            }
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            //return
            this.Close();
        }
    }
}
