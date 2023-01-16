using Microsoft.VisualBasic;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FrankPatata
{
    public partial class Form1 : Form
    {
        string username;
        string password;
        public static string token;
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //abrir nueva ventana para registrarse
            Registro form = new Registro();
            form.ShowDialog();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            //guardar datos
            username = textBoxUsuario.Text;
            if(username==null || (username.Length < 0))
            {
                password = textBoxContrasena.Text;
                if(password == null || (password.Length < 0))
                {
                    //autenticacion de usuario
                    postUser();
                }
            }
            else
            {
                Interaction.MsgBox("Error, username not correct");
            }
            
        }

        public async void postUser()
        {
            var UserDTO = new UserDTO
            {
                username = username,
                password = password,
            };

            Uri RequestUri = new Uri("http://10.10.12.87:8080/auth/login");

            var client = new HttpClient();
            //serializar objeto
            string jsonString = JsonSerializer.Serialize(UserDTO);
            var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, content);
            //string responseContent = response.Content.ToString();
            //List<ClassSignIn> listMensajes = JsonConvert.DeserializeObject<List<ClassSignIn>>(responseContent);
            //Interaction.MsgBox(response.ToString());
            if (response.IsSuccessStatusCode)
            {
                string body = await response.Content.ReadAsStringAsync();
                //System.Diagnostics.Debug.WriteLine(body);
                var result = JsonConvert.DeserializeObject<ClassAuthResponse>(body);
                token = result.accessToken;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //System.Diagnostics.Debug.WriteLine(response.Content.ToString());
                    Interaction.MsgBox("User is correct");
                    //abrir aplicacion y cerrar la presente
                    Appcs app = new Appcs();
                    app.ShowDialog();
                }
                else
                {
                    Interaction.MsgBox("Error, something is wrong");
                }
            }
            else
            {
                //mostrar error
                Interaction.MsgBox(response.StatusCode); 
            }
        }

    }
}