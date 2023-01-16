using Microsoft.VisualBasic;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FrankPatata
{
    public partial class Registro : Form
    {
        string user;
        string email;
        string password;
        string newPassword;
        public Registro()
        {
            InitializeComponent();
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            //guardar datos, comprobar que no se han metido campos nulos
            user =textBoxUser.Text;
            if (user == null || (user.Length < 0))
            {
                Interaction.MsgBox("Error, user is not correct");
            }
            else
            {
                email = textBoxEmail.Text;
                if (email.Equals("") || !email.Contains("@") || !email.Contains("."))
                {
                    Interaction.MsgBox("Error, email is not correct");
                }
                else
                {
                    password = textBoxPassword.Text;
                    if (password.Equals(""))
                    {
                        Interaction.MsgBox("Error, password is not correct");
                    }
                    else
                    {
                        newPassword = textBoxConfPassword.Text;
                        //si es vacio o si no coincide con la contraseña anterior
                        if (newPassword.Equals("") || (!newPassword.Equals(password)))
                        {
                            Interaction.MsgBox("Error, confirm password is not correct");
                        }
                        else
                        {
                            //guardar datos en base de datos
                            postUser();
                        }
                    }
                }
            }
        }

        private async void postUser()
        {
            var User = new User
            {
                nombre = user,
                password = password,
                email = email,
            };

            Uri RequestUri = new Uri("http://10.10.12.87:8080/usuario/crearUsuario");

            var client = new HttpClient();
            //serializar objeto
            string jsonString = JsonSerializer.Serialize(User);
            //System.Diagnostics.Debug.WriteLine(jsonString);
            var content=new StringContent(jsonString,System.Text.Encoding.UTF8,"application/json");
            var response = await client.PostAsync(RequestUri, content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                System.Diagnostics.Debug.WriteLine(response.Content.ToString());
                Interaction.MsgBox("User is correctly created");
            }
            else
            {
                Interaction.MsgBox("Error, something is wrong");
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //cerrar ventana
            this.Close();
        }
    }
}
