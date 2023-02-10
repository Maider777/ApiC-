using Newtonsoft.Json.Linq;
using RestSharp;
using static FrankPatata.App;

namespace FrankPatata
{
    public partial class Favs : Form
    {
        string image;
        //list to add favs
        PictureBox[] favs;
        public Favs()
        {
            InitializeComponent();
            Image img = (Image)Properties.Resources.ResourceManager.GetObject("icons8-volver-50");
            buttonReturn.Image = img;
        }

        public void Favs_Load(object sender, EventArgs e)
        {
            //strecht return button
            buttonReturn.BackgroundImageLayout = ImageLayout.Stretch;
            //clicking, show the favs
            string url = "";
            if (menuApps.button1WasClicked)
            {
                url = "http://localhost:8080/favorito/dameFavoritos?app_id=" + menuApps.id2.ToString();
                //poke api
            }
            if (menuApps.button2WasClicked)
            {
                url = "http://localhost:8080/favorito/dameFavoritos?app_id=" + menuApps.id1.ToString();
                //free to play
            }
            if (menuApps.button3WasClicked)
            {
                url = "http://localhost:8080/favorito/dameFavoritos?app_id=" + menuApps.id3.ToString();
                //netflix
            }

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
                JArray array = JArray.Parse(responseContent);
                for (int i = 0; i < array.Count; i++)
                {

                    if (menuApps.button1WasClicked)
                    {
                        string nameFav = array[i].ToString();
                        for (int j = 0; j < listItems.Count; j++)
                        {
                            box = new PictureBox();
                            favs = new PictureBox[array.Count];
                            //get the id
                            box.Tag = listItems[j].id + "$" + listItems[j].name;
                            string[] element = box.Tag.ToString().Split("$");
                            string name = element[1];
                            //if is the same, show
                            if (name.Equals(nameFav))
                            {
                                box.Width = 220;
                                box.Height = 220;
                                image = listItems[j].imagen;
                                picturebox = new PictureBox[array.Count];
                                //id = (int)box.Tag;
                                box.Load(image);
                                box.SizeMode = PictureBoxSizeMode.StretchImage;
                                box.Location = new Point(14, 17);
                                box.Size = new Size(box.Width, box.Height);
                                picturebox[i] = box;
                                favs[i] = picturebox[i];
                                //create flowlayout and add items
                                flowLayoutSeries.Controls.Add(box);
                                //obtener id
                                elementId = listItems[j].id;
                                //click in the element
                                picturebox[i].Click += new EventHandler(this.PictureClick);
                                break;
                            }
                        }
                    }
                    else
                    {
                        //get the id
                        int idFav = (int)array[i];
                        for (int j = 0; j < listItems.Count; j++)
                        {
                            box = new PictureBox();
                            favs = new PictureBox[array.Count];
                            //get the id
                            box.Tag = listItems[j].id;
                            //if is the same show
                            if (box.Tag.Equals(idFav))
                            {
                                box.Width = 220;
                                box.Height = 220;
                                image = listItems[j].imagen;
                                picturebox = new PictureBox[array.Count];
                                //id = (int)box.Tag;
                                box.Load(image);
                                box.SizeMode = PictureBoxSizeMode.StretchImage;
                                box.Location = new Point(14, 17);
                                box.Size = new Size(box.Width, box.Height);
                                picturebox[i] = box;
                                favs[i] = picturebox[i];
                                flowLayoutSeries.Controls.Add(box);
                                //get the id
                                elementId = listItems[j].id;
                                //clicking in the element
                                picturebox[i].Click += new EventHandler(this.PictureClick);
                                break;
                            }
                        }
                    }

                    
                }
            }
        }

        private void PictureClick(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            //get the id and the name of the clicked element
            if (menuApps.button1WasClicked)
            {
                string[] nameEle = box.Tag.ToString().Split("$");
                elementId = Convert.ToInt32(nameEle[0]);
                elementName = nameEle[1];
            }
            else
            {
                //get the id of the clicked element
                elementId = (int)box.Tag;
            }
            Element elemento = new Element();
            elemento.ShowDialog();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
