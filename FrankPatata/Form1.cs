using Microsoft.VisualBasic;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FrankPatata
{
    public partial class Form1 : Form
    {
        //variables
        public static string username;
        public static string password;
        public static int userId;
        public static string token;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            //save data
            username = textBoxUsuario.Text;
            if(username!=null || (username.Length > 0))
            {
                password = textBoxContrasena.Text;
                if(password != null || (password.Length > 0))
                {
                    //user authentication
                    postUser();
                }
                else
                {
                    Interaction.MsgBox("Error, password is not correct");
                }
            }
            else
            {
                Interaction.MsgBox("Error, username is not correct");
            }
            
        }

        public async void postUser()
        {
            var UserDTO = new UserDTO
            {
                username = username,
                password = password,
                user_id = userId,
            };

            Uri RequestUri = new Uri("http://localhost:8080/auth/login");

            var client = new HttpClient();
            //serialize object
            string jsonString = JsonSerializer.Serialize(UserDTO);
            var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, content);
            //if its ok
            if (response.IsSuccessStatusCode)
            {
                string body = await response.Content.ReadAsStringAsync();
                
                var result = JsonConvert.DeserializeObject<ClassAuthResponse>(body);
                token = result.accessToken;
                userId=result.user_id;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Interaction.MsgBox("User is correct");
                    this.Hide();
                    //open application and close the present
                    menuApps app = new menuApps();
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
                Interaction.MsgBox("Error, something is wrong"); 
            }
        }

        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //open new form to sign in
            SignUp form = new SignUp();
            form.ShowDialog();
        }
    }
}