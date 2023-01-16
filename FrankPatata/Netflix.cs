using Newtonsoft.Json;
using RestSharp;

namespace FrankPatata
{
    public partial class Netflix : Form
    {
        string imagen;
        string[] names;
        int id;
        List<ClassNetflix> listSeries;
        PictureBox[] picturebox;
        PictureBox box;
        
        public Netflix()
        {
            InitializeComponent();
        }

        private void Netflix_Load(object sender, EventArgs e)
        {
            cargarItems();
        }

        public void cargarItems() {

            //cargar listado de series
            string url = "http://10.10.12.87:8080/main/dameListado?api=3";
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
                //obtener lista de juegos
                listSeries = JsonConvert.DeserializeObject<List<ClassNetflix>>(responseContent);

                //poner imagenes y nombres en pictureBox
                //hacer autoscroll automatico
                this.AutoScroll = true;

                picturebox = new PictureBox[listSeries.Count];
                names = new string[listSeries.Count];

                int y = 220;
                //Interaction.MsgBox(listGames.Count);
                for (int i = 0; i < listSeries.Count; i++)
                {
                    box = new PictureBox();
                    box.Width = y;
                    box.Height = y;
                    imagen = listSeries[i].imagen;
                    //guardar id
                    id = listSeries[i].id;
                    box.Load(imagen);
                    box.SizeMode = PictureBoxSizeMode.StretchImage;
                    box.Location = new Point(14, 17);
                    box.Size = new Size(box.Width, box.Height);
                    picturebox[i] = box;
                    picturebox[i].Name = listSeries[i].name;
                    //añadir nombres de juegos a array
                    names[i] = listSeries[i].name;
                    //crear flowlayout y añadir juegos
                    flowLayoutSeries.Controls.Add(box);

                    //añadir campos a domainupdown
                    domainUpDown1.Items.Add(names[i]);
                }
            }
        }

        public void filtroItems(string serie)
        {
            picturebox = new PictureBox[listSeries.Count];
            flowLayoutSeries.Controls.Clear();
            for (int i = 0; i < listSeries.Count; i++)
            {
                string nombreSerie = listSeries[i].name;
                for(int j = 0; j < serie.Length; j++)
                {
                    if (nombreSerie.StartsWith(serie[j]))
                    {
                        //Interaction.MsgBox(serie);
                        int y = 220;
                        box = new PictureBox();
                        box.Width = y;
                        box.Height = y;
                        imagen = listSeries[i].imagen;
                        box.Load(imagen);
                        box.SizeMode = PictureBoxSizeMode.StretchImage;
                        box.Location = new Point(14, 17);
                        box.Size = new Size(box.Width, box.Height);
                        picturebox[i] = box;
                        picturebox[i].Name = listSeries[i].name;
                        //añadir nombres de juegos a array
                        names[i] = listSeries[i].name;
                        //crear flowlayout y añadir juegos
                        flowLayoutSeries.Controls.Add(box);
                        break;
                    }
                }
                
            }
        }

        private void domainUpDown1_SelectedItemChanged_1(object sender, EventArgs e)
        {
            //obtener nombre y mostrar
            string serie = domainUpDown1.Text;
            filtroItems(serie);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //buscar serie, obtener texto y buscar y mostrar
            string serie = textBox1.Text;
            filtroItems(serie);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //mostrar todos los items
            cargarItems();
        }
    }
}
