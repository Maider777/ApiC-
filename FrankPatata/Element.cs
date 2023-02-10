using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Text.RegularExpressions;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FrankPatata
{
    public partial class Element : Form
    {
        //variables
        public static ClassElement element;
        public static string genres;
        public static bool isButtonLike = false;
        public Element()
        {
            InitializeComponent();
            Image img = (Image)Properties.Resources.ResourceManager.GetObject("icons8-volver-50");
            buttonReturn.Image = img;

            Image img2 = (Image)Properties.Resources.ResourceManager.GetObject("envia2");
            buttonSend.Image = img2;
        }

        private void favsLoad() {
            //when you click the like button, show favorites from that app
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
                    //get id or name
                    if (menuApps.button1WasClicked)
                    {
                        string nameFav = array[i].ToString();
                        string nameElemento = App.elementName;
                        isButtonLike = false;
                        //if the item id of all items is equal to that of the response
                        if (nameElemento.Equals(nameFav))
                        {
                            Image img = (Image)Properties.Resources.ResourceManager.GetObject("me-gusta");
                            buttonLike.Image = img;

                            isButtonLike = true;
                            break;
                        }
                    }
                    else
                    {
                        int idSerieFav = (int)array[i];
                        //get the id of the element
                        int idElemento = App.elementId;
                        isButtonLike = false;
                        //if the item id of all items is equal to that of the response
                        if (idElemento.Equals(idSerieFav))
                        {
                            Image img = (Image)Properties.Resources.ResourceManager.GetObject("me-gusta");
                            buttonLike.Image = img;

                            isButtonLike = true;
                            break;
                        }
                    }

                }
            }
        }

        private void Element_Load(object sender, EventArgs e)
        {
            //strech return button
            buttonReturn.BackgroundImageLayout = ImageLayout.Stretch;
            //strect image
            imagePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            //strecth like button
            buttonLike.BackgroundImageLayout = ImageLayout.Stretch;
            //put image of dislike
            Image img = (Image)Properties.Resources.ResourceManager.GetObject("no-me-gusta");
            buttonLike.Image = img;

            favsLoad();

            //load element
            string url = "";
            if (menuApps.button1WasClicked)
            {
                url = "http://localhost:8080/main/dameElemento?api=" + menuApps.id2.ToString() + "&item=" + App.elementName;
            }
            if (menuApps.button2WasClicked)
            {
                url = "http://localhost:8080/main/dameElemento?api=" + menuApps.id1.ToString() + "&item=" + App.elementId;
            }
            if (menuApps.button3WasClicked)
            {
                url = "http://localhost:8080/main/dameElemento?api=" + menuApps.id3.ToString() + "&item=" + App.elementId;
            }
            
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(url);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", "Bearer " + Form1.token);

            RestResponse restResponse = restClient.Get(restRequest);

            if (restResponse == null)
            {
                Interaction.MsgBox("Error, something is wrong");
            }
            else
            {
                string responseContent = restResponse.Content;

                //get the data
                element = JsonConvert.DeserializeObject<ClassElement>(responseContent);

                try
                {
                    string name = element.name;
                    if(name == null)
                    {
                        nameApp.Text = "";
                    }
                    else
                    {
                        nameApp.Text = name;
                    }
                    string image = element.image;
                    if(image == null)
                    {
                        imagePic = null;
                    }
                    else
                    {
                        imagePic.Load(image);
                    }
                    
                    string description = element.description;
                    if(description == null)
                    {
                        descriptionLabel.Text = "";
                    }
                    else
                    {
                        description = StripHTML(description);
                        description = description.Replace(". ", ".\n");
                        descriptionLabel.Text = "\n" + description;
                    }
                    
                    string publisher = element.publisher;
                    if(publisher == null)
                    {
                        labelPublisher.Text = "";
                    }
                    else
                    {
                        labelPublisher.Text = publisher;
                    }
                    
                    string version = element.version;
                    if(version == null)
                    {
                        labelVersion.Text = "";
                    }
                    else
                    {
                        labelVersion.Text = version;
                    }
                    string genres = element.genero.Replace(";", "\n");
                    if (genres == null)
                    {
                        genres = "";
                    }
                    else
                    {
                        genres = element.genero.Replace(";", "\n");
                        labelGenres.Text = genres;
                    }
                    string username = Form1.username;
                    if (username == null)
                    {
                        labelUsername.Text = "";
                    }
                    else
                    {
                        labelUsername.Text = username;
                    }

                    if (menuApps.button1WasClicked)
                    {
                        //poke api
                        try
                        {
                            //get details
                            ClassDetailsDimensions dimensions = element.detalles.dimensiones;
                            if (dimensions == null)
                            {
                                dimensions.weight = "";
                                dimensions.height = "";
                            }
                            else
                            {
                                string weight = dimensions.weight;
                                if(weight == null)
                                {
                                    weight = "";
                                }
                                else
                                {
                                    string height = dimensions.height;
                                    if(height == null)
                                    {
                                        height = "";
                                    }
                                }
                            }
                            ClassDetailsStats stats = element.detalles.stats;
                            if (stats == null)
                            {
                                stats.special_attack=0;
                                stats.defense=0;
                                stats.attack=0;
                                stats.hp=0;
                                stats.special_defense=0;
                                stats.speed=0;
                            }
                            else
                            {
                                int special_attack = stats.special_attack;
                                int defense = stats.defense;
                                int attack = stats.attack;
                                int hp = stats.hp;
                                int special_defense = stats.special_defense;
                                int speed = stats.speed;
                            }
                            ElementDetails details = element.detalles;
                            if (details == null)
                            {
                                details.habilidades = null;
                            }
                            else
                            {
                                List<string> habilidades = new List<string>();
                                for (int i = 0; i < details.habilidades.Count; i++)
                                {
                                    habilidades.Add(details.habilidades[i]);
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            Interaction.MsgBox("Error: "+exception.Message);
                        }

                    }

                    if (menuApps.button2WasClicked)
                    {
                        try
                        {
                            //free to play
                            ElementDetails details = element.detalles;
                            if (details == null)
                            {
                                Interaction.MsgBox("Error, something is wrong");
                            }
                            else
                            {
                                string graphics = details.graphics;
                                string memory = details.memory;
                                string os = details.os;
                                string processor = details.processor;
                                string storage = details.storage;
                            }
                        }
                        catch (Exception exception)
                        {
                            Interaction.MsgBox("Error: "+exception.Message);
                        }

                    }

                    if (menuApps.button3WasClicked)
                    {
                        try
                        {
                            //netflix
                            ElementDetails details = element.detalles;
                            if (details == null)
                            {
                                Interaction.MsgBox("Error, something is wrong");
                            }
                            else
                            {
                                List<string> dias = new List<string>();
                                for (int i = 0; i < details.dias.Count; i++)
                                {
                                    dias.Add(details.dias[i]);
                                }
                                string duration = details.duracion;
                                string start = details.inicio;
                                string fin = details.fin;
                                string hour = details.hora;
                            }
                            
                        }
                        catch (Exception exception)
                        {
                            Interaction.MsgBox("Error, something is wrong");
                        }

                    }

                    //get comments
                    List<ElementComment> comments = element.comentarios.ToList();
                    for (int i = 0; i < comments.Count; i++)
                    {
                        labelComments.Text += "\n" + comments[i].username + " - " + comments[i].hora + "\n" + comments[i].comment_text + "\n";
                    }
                }
                catch (Exception error)
                {
                    Interaction.MsgBox("Error: "+error.Message);
                }
                
            }

            //tableLayoutPanel

            //poner detalles y titulo de app
            if (menuApps.button1WasClicked)
            {
                //pokeApi
                try
                {
                    labelMemory.Text = "Weight";
                    memory.Text = Element.element.detalles.dimensiones.weight;
                    labelOs.Text = "Height";
                    os.Text = Element.element.detalles.dimensiones.height;
                    labelGraphics.Text = "special_attack";
                    graphics.Text = Element.element.detalles.stats.special_attack.ToString();
                    labelStorage.Text = "Defense";
                    storage.Text = Element.element.detalles.stats.defense.ToString();
                    labelProcessor.Text = "Attack";
                    processor.Text = Element.element.detalles.stats.attack.ToString();
                    labelFin.Text = "Hp";
                    fin.Text = Element.element.detalles.stats.hp.ToString();
                    special_defense.Text = Element.element.detalles.stats.special_defense.ToString();
                    speed.Text = Element.element.detalles.stats.speed.ToString();
                }
                catch (Exception error)
                {
                    Interaction.MsgBox("Error: " + error.Message);
                    memory.Text = "";
                    os.Text = "";
                    graphics.Text = "";
                    storage.Text = "";
                    processor.Text = "";
                    fin.Text = "";
                    special_defense.Text = "";
                    speed.Text = "";
                }
                
            }
            if (menuApps.button2WasClicked)
            {
                //freeToPlay
                try
                {
                    memory.Text = Element.element.detalles.memory;
                    os.Text = Element.element.detalles.os;
                    graphics.Text = Element.element.detalles.graphics;
                    storage.Text = Element.element.detalles.storage;
                    processor.Text = Element.element.detalles.processor;
                    labelFin.Text = "";
                    fin.Text = "";
                    labelSpecial_defense.Text = "";
                    labelSpeed.Text = "";
                    special_defense.Text = "";
                    speed.Text = "";
                }
                catch (Exception error)
                {
                    Interaction.MsgBox("Error: "+error.Message);
                    memory.Text = "";
                    os.Text = "";
                    graphics.Text = "";
                    storage.Text = "";
                    processor.Text = "";
                    labelFin.Text = "";
                    fin.Text = "";
                    labelSpecial_defense.Text = "";
                    labelSpeed.Text = "";
                    special_defense.Text = "";
                    speed.Text = "";
                }
                
            }
            if (menuApps.button3WasClicked)
            {
                //netflix
                try
                {
                    labelMemory.Text = "Web";
                    memory.Text = Element.element.detalles.web;
                    labelOs.Text = "Hour";
                    os.Text = Element.element.detalles.hora;
                    labelGraphics.Text = "Days";
                    graphics.Text = string.Join(", ", Element.element.detalles.dias);
                    labelStorage.Text = "Duration";
                    storage.Text = Element.element.detalles.duracion;
                    labelProcessor.Text = "Start";
                    processor.Text = Element.element.detalles.inicio;
                    fin.Text = Element.element.detalles.fin;
                    labelSpecial_defense.Text = "";
                    labelSpeed.Text = "";
                    special_defense.Text = "";
                    speed.Text = "";
                }
                catch (Exception error)
                {
                    Interaction.MsgBox("Error: " + error.Message);

                }
                
            }
        }

        public static string StripHTML(string descripcion)
        {
            return Regex.Replace(descripcion, "<.*?>", String.Empty);
        }

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            //get comment and send
            string comment = textBoxComment.Text;
            if (comment != null || comment.Length > 0)
            {
                var CreateCommentElement = new CreateCommentElement
                {
                    comment_text = comment,
                    hora = DateTime.Now.ToString("hh:mm:ss"),
                    elemento_id = App.elementId.ToString(),
                    app_id = menuApps.appId.ToString(),
                };

                if (menuApps.button1WasClicked)
                {
                    CreateCommentElement = new CreateCommentElement
                    {
                        comment_text = comment,
                        hora = DateTime.Now.ToString("hh:mm:ss"),
                        elemento_id = App.elementName.ToString(),
                        app_id = menuApps.appId.ToString(),
                    };
                }

                Uri url = new Uri("http://localhost:8080/comentario/crearComentario");
                RestClient restClient = new RestClient();
                RestRequest restRequest = new RestRequest(url);
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddHeader("Authorization", "Bearer " + Form1.token);
                string jsonString = JsonSerializer.Serialize(CreateCommentElement);
                restRequest.AddBody(jsonString);
                RestResponse restResponse = restClient.Post(restRequest);

                string responseContent = restResponse.Content.ToString();
                //Interaction.MsgBox(responseContent);
                if(responseContent.Equals(false))
                {
                    Interaction.MsgBox("Error, something is wrong");
                }
                else
                {
                    //add comment to label
                    labelComments.Text += "\n" + Form1.username + " - " + CreateCommentElement.hora + "\n" + comment + "\n";
                }
            }
        }

        private void buttonLike_Click(object sender, EventArgs e)
        {
            //when clicking, change image to like

            //if the button is on like, give dislike
            if (isButtonLike)
            {
                //put image of dislike
                Image img = (Image)Properties.Resources.ResourceManager.GetObject("no-me-gusta");
                buttonLike.Image = img;

                //add to fav
                changeFavPost();

                isButtonLike = false;
            }
            else
            {
                //put image of like
                Image img = (Image)Properties.Resources.ResourceManager.GetObject("me-gusta");
                buttonLike.Image = img;

                //delete of favs
                changeFavPost();

                isButtonLike = true;
            }
        }

        private void changeFavPost()
        {
            var ChangeFav = new ChangeFav
            {
                //get the id of the clicked element, pass the one of the app it belongs to
                elemento_id = App.elementId.ToString(),
                app_id = menuApps.appId.ToString(),
            };

            if (menuApps.button1WasClicked)
            {
                ChangeFav = new ChangeFav
                {
                    //get the id of the clicked element, pass the one of the app it belongs to
                    elemento_id = App.elementName.ToString(),
                    app_id = menuApps.appId.ToString(),
                };
            }
            

            Uri url = new Uri("http://localhost:8080/favorito/cambiarFavorito");
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(url);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", "Bearer " + Form1.token);
            string jsonString = JsonSerializer.Serialize(ChangeFav);
            restRequest.AddBody(jsonString);
            RestResponse restResponse = restClient.Post(restRequest);

            string responseContent = restResponse.Content.ToString();
            //Interaction.MsgBox(responseContent);
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
