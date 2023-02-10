using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Windows.Forms.VisualStyles;

namespace FrankPatata
{
    public partial class App : Form
    {
        static string image;
        string[] names;
        public static List<ClassApp> listItems;
        public static string responseContent;
        public static PictureBox[] picturebox;
        public static PictureBox box;
        public static int elementId;
        public static string elementName;
        public static int index;
        string genre;
        string[] genres;
        int pages = 1;
        
        public App()
        {
            InitializeComponent();
            Image img = (Image)Properties.Resources.ResourceManager.GetObject("no-me-gusta");
            buttonLike.Image = img;
            Image img2 = (Image)Properties.Resources.ResourceManager.GetObject("icons8-volver-50");
            buttonReturn.Image = img2;

        }

        private void App_Load(object sender, EventArgs e)
        {
            //strecth return button
            buttonReturn.BackgroundImageLayout = ImageLayout.Stretch;
            //stretch fav button
            buttonLike.BackgroundImageLayout = ImageLayout.Stretch;
            loadItems();
            
        }

        public void loadGenres()
        {
            //load genres
            string url = "";
            if (menuApps.button1WasClicked)
            {
                url = "http://10.10.12.82:8080/app/dameGeneros?app_id=" + menuApps.id2.ToString();
                label1.Text = "Poke Api";
            }
            if (menuApps.button2WasClicked)
            {
                url = "http://localhost:8080/app/dameGeneros?app_id=" + menuApps.id1.ToString();
                label1.Text = "Free To Play";
            }
            if (menuApps.button3WasClicked)
            {
                url = "http://localhost:8080/app/dameGeneros?app_id=" + menuApps.id3.ToString();
                label1.Text = "Netflix";
            }

            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(url);
            restRequest.AddHeader("Content-Type", "*/*");
            restRequest.AddHeader("Authorization", "Bearer " + Form1.token);

            RestResponse restResponse = restClient.Get(restRequest);

            //if isnt null
            if (restResponse != null)
            {
                string responseContent = restResponse.Content.ToString();
                JArray array = JArray.Parse(responseContent);
                for(int i = 0; i < array.Count; i++)
                {
                    //get genre
                    genre = array[i].ToString();
                    //add to the list of genres
                    domainUpDown1.Items.Add(genre);
                }
            }
        }

        public void loadItems() 
        {
            //load items
            string url = "";
            if (menuApps.button1WasClicked)
            {
                url = "http://localhost:8080/main/dameListado?api="+menuApps.id2.ToString();
            }
            if (menuApps.button2WasClicked)
            {
                url = "http://localhost:8080/main/dameListado?api="+menuApps.id1.ToString();
            }
            if (menuApps.button3WasClicked)
            {
                url = "http://localhost:8080/main/dameListado?api="+menuApps.id3.ToString();
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
                responseContent = restResponse.Content.ToString();
                listItems = JsonConvert.DeserializeObject<List<ClassApp>>(responseContent);

                //put images
                //autoscroll is true
                this.AutoScroll = true;

                picturebox = new PictureBox[listItems.Count];
                names = new string[listItems.Count];

                int y = 220;
                for (int i = 0; i < listItems.Count; i++)
                {
                    
                    if (i >= pages * 12)
                    {
                        pages++;
                        break;
                    }
                    
                    //get data
                    box = new PictureBox();
                    box.Width = y;
                    box.Height = y;
                    image = listItems[i].imagen;
                    genres = listItems[i].genres.Split(";");
                    if (menuApps.button1WasClicked)
                    {
                        box.Tag = listItems[i].id + "$" + listItems[i].name;
                    }
                    else
                    {
                        box.Tag = listItems[i].id;
                    }
                    box.Load(image);
                    box.SizeMode = PictureBoxSizeMode.StretchImage;
                    box.Location = new Point(14, 17);
                    box.Size = new Size(box.Width, box.Height);
                    picturebox[i] = box;
                    picturebox[i].Name = listItems[i].name;
                    names[i] = listItems[i].name;
                    flowLayoutSeries.Controls.Add(box);
                    //get id
                    elementId = listItems[i].id;
                    //if you click in the pictureBox
                    picturebox[i].Click += new EventHandler(this.PictureClick);
                    
                }
                loadGenres();
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
            //load new form
            Element elemento = new Element();
            elemento.ShowDialog();
        }

        public void searchByFilters()
        {
            //get the string that we write in the textbox
            string serieIntro = textBox1.Text.ToLower();
            //clear all
            flowLayoutSeries.Controls.Clear();
            List<PictureBox> pictureBoxList = new List<PictureBox>();

            for (int i = 0; i < listItems.Count; i++)
            {
                //get the name
                string nombreSerie = listItems[i].name.ToLower();
                //if starts with or is the same
                if (nombreSerie.StartsWith(serieIntro) || nombreSerie.Contains(serieIntro))
                {
                    //show
                    box = new PictureBox();
                    box.Width = 220;
                    box.Height = 220;
                    image = listItems[i].imagen;
                    //get the id
                    //get the id
                    if (menuApps.button1WasClicked)
                    {
                        box.Tag = listItems[i].id + "$" + listItems[i].name;
                    }
                    else
                    {
                        box.Tag = listItems[i].id;
                    }
                    box.Load(image);
                    box.SizeMode = PictureBoxSizeMode.StretchImage;
                    box.Location = new Point(14, 17);
                    box.Size = new Size(box.Width, box.Height);
                    pictureBoxList.Add(box);
                    flowLayoutSeries.Controls.Add(box);
                    elementId = listItems[i].id;
                    pictureBoxList[pictureBoxList.Count - 1].Click += new EventHandler(this.PictureClick);
                }
            }

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            //get string of the clicked filter
            string genreFilter = domainUpDown1.Text;
            //clear
            flowLayoutSeries.Controls.Clear();
            for (int i = 0; i < listItems.Count; i++)
            {
                genres = listItems[i].genres.Split(";");
                //get the genres
                for (int j = 0; j < genres.Length; j++)
                {
                    //if is the same, show element
                    int y = 220;
                    //si el genero es igual al del filtro,mostrar
                    if (genres[j].Equals(genreFilter))
                    {
                        //show element
                        box = new PictureBox();
                        box.Width = 220;
                        box.Height = 220;
                        image = listItems[i].imagen;
                        //get the id
                        if (menuApps.button1WasClicked)
                        {
                            box.Tag = listItems[i].id + "$" + listItems[i].name;
                        }
                        else
                        {
                            box.Tag = listItems[i].id;
                        }
                        box.Load(image);
                        box.SizeMode = PictureBoxSizeMode.StretchImage;
                        box.Location = new Point(14, 17);
                        box.Size = new Size(box.Width, box.Height);
                        picturebox[i] = box;
                        flowLayoutSeries.Controls.Add(box);
                        elementId = listItems[i].id;
                        picturebox[i].Click += new EventHandler(this.PictureClick);
                    }
                }
            }
        }

        private void buttonLike_Click(object sender, EventArgs e)
        {
            //open favs form
            Favs favs= new Favs();
            favs.Show();
        }

        private void buttonLoadMore_Click(object sender, EventArgs e)
        {
            //load more items
            nextPage();
        }

        public void nextPage()
        {
            //load more items when button is clicked
            for (int i = (pages - 1) * 12; i < pages * 12; i++)
            {
                try
                {
                    box = new PictureBox();
                    box.Width = 220;
                    box.Height = 220;
                    image = listItems[i].imagen;
                    genres = listItems[i].genres.Split(";");
                    //get the id
                    if (menuApps.button1WasClicked)
                    {
                        box.Tag = listItems[i].id + "$" + listItems[i].name;
                    }
                    else
                    {
                        box.Tag = listItems[i].id;
                    }
                    box.Load(image);
                    box.SizeMode = PictureBoxSizeMode.StretchImage;
                    box.Location = new Point(14, 17);
                    box.Size = new Size(box.Width, box.Height);
                    picturebox[i] = box;
                    picturebox[i].Name = listItems[i].name;
                    names[i] = listItems[i].name;
                    flowLayoutSeries.Controls.Add(box);
                    elementId = listItems[i].id;
                    //click in the element
                    picturebox[i].Click += new EventHandler(this.PictureClick);
                }
                catch (Exception e)
                {
                    break;
                }
            }
            pages++;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //search by filters
            searchByFilters();
        }

        private void resetFiltersButton_Click_1(object sender, EventArgs e)
        {
            //clear the filters and the panel
            flowLayoutSeries.Controls.Clear();
            textBox1.Text = "";
            domainUpDown1.Text = "";
            //show the items
            loadItems();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
