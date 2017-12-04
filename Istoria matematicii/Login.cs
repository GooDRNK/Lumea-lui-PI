using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Istoria_matematicii
{
    public partial class Login : Form
    {
        #region Variabile/Functii
        public Login()
        {
            InitializeComponent();
        }
        public static string Parola_Login; //Aici se salveaza Parola introdusa.
        public static string User_Login; //Aici se salveaza Utilizatorul introdus.
        //Download String Start
        public static string reply = string.Empty;
        public static string DownloadString(string address)
        {
            try
            {

                WebClient client = new WebClient();
                reply = client.DownloadString(address);
                return reply.ToString();

            }
            catch { }
            return reply.ToString();
        }
        //Download String End
#endregion
        #region Regster Sistem
        private void iTalk_Button_22_Click(object sender, EventArgs e)
        {
            //Verifica daca toate campurile necesare sunt completate.
            if(iTalk_TextBox_Small2.Text!=string.Empty 
                && iTalk_TextBox_Small4.Text != string.Empty
                && iTalk_TextBox_Small1.Text != string.Empty
                && iTalk_TextBox_Small3.Text != string.Empty)
            {
                //Verifica daca parolele sunt identice.
                if(iTalk_TextBox_Small1.Text == iTalk_TextBox_Small3.Text)
                {
                    //Face request la API, pentru a inregistra contul, daca se poate, daca nu se poate se primeste un mesaj: "Numele de utilizator deja exista" / "Acest mail este deja utilizat.".
                   
                    MessageBox.Show(DownloadString("http://optimised.biz/registers/" + iTalk_TextBox_Small4.Text + "/" + iTalk_TextBox_Small1.Text + "/" + iTalk_TextBox_Small2.Text)) ;
                }
                else
                {
                    MessageBox.Show("Parolele nu corespund. Verifica respectivele campuri.");
                }

            }
            else
            {
                MessageBox.Show("Completeaza toate campurile necesare inregistrarii.");
            }
        }
        #endregion
        #region Login Sistem
        private void iTalk_Button_21_Click(object sender, EventArgs e)
        {
            //Verifica daca parola si numele de utilizator sunt introduse.
            if (Password.Text != string.Empty
               && User.Text != string.Empty   )
            {
                //Face request la api sa afle daca datele introduse sunt corecte.
                if (DownloadString("http://optimised.biz/pilogin/" + Password.Text + "/" + User.Text) == "Succes")
                {
                    this.Hide();
                    Parola_Login = Password.Text;
                    User_Login = User.Text;
                    PI pilesson = new PI();
                    pilesson.ShowDialog();
                }
                else
                {
                    MessageBox.Show(DownloadString("http://optimised.biz/pilogin/" + Password.Text + "/" + User.Text));
                }

            }
            else
            {
                MessageBox.Show("Completeaza toate campurile necesare login-ului.");
            }

        }
        #endregion
    }
}
