using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Istoria_matematicii
{
    public partial class PI : Form
    {
        #region Variabile/Functii
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
        string Parola; //Aici se salveaza Parola.
        string Username; //Aici se salveaza Utilizatorul.
        public PI()
        {
            InitializeComponent();
            timer1.Interval=1000;
            timer1.Start();
            iTalk_HeaderLabel21.Text =
                "■ Prima contribuție europeană majoră de după Arhimede a fost cea a " + Environment.NewLine +
                " matematicianului german Ludolph van Ceulen (1540–1610), care a " + Environment.NewLine +
                " folosit o metodă geometrică de calcul a 35 de zecimale ale lui π. El a" + Environment.NewLine +
                " fost atât de mândru de calculul său, căruia i-a dedicat o mare parte" + Environment.NewLine +
                " din viața sa, încât a cerut ca cifrele să-i fie gravate pe piatra de mormânt.";
            iTalk_HeaderLabel22.Text = "În aceeași perioadă, în Europa au început să apară metodele " + Environment.NewLine +
                "analizei matematice și pentru determinarea seriilor și produselor" + Environment.NewLine +
                " infinite pentru cantități geometrice. Prima astfel de reprezentare a" + Environment.NewLine +
                " fost formula lui Viète";
            iTalk_HeaderLabel25.Text = "■ Descoperit de John Wallis în 1655. Isaac Newton a calculat și el o serie pentru π și a" + Environment.NewLine +
                " calculat 15 cifre, deși ulterior a mărturisit: „Mi-e rușine să vă spun la câte cifre am " + Environment.NewLine +
                "ajuns cu calculele, neavând altceva de făcut atunci.”";
            iTalk_HeaderLabel28.Text = "■ Apariția calculatoarelor numerice în secolul al XX-lea au dus la o creștere a recordurilor de" + Environment.NewLine +
                " calcul al lui π. John von Neumann a folosit ENIAC pentru a calcula 2037 de cifre ale lui π în" + Environment.NewLine +
                " 1949, un calcul care a durat 70 de ore.Alte mii de zecimale s-au obținut în următoarele decenii" + Environment.NewLine +
                " și milionul de cifre a fost depășit în 1973. Progresele nu s-au datorat doar hardware-ului mai" + Environment.NewLine +
                " rapid, ci și apariției unor noi algoritmi. Una dintre cele mai semnificative realizări a fost" + Environment.NewLine +
                " descoperirea transformatei Fourier rapide (FFT) în anii 1960, algoritm ce permite" + Environment.NewLine +
                " calculatoarelor să efectueze rapid operațiuni aritmetice pe numere extrem de mari.";
            iTalk_HeaderLabel30.Text = " ■ 1900-1650 i.Hr. Egiptenii si babilonienii au estimat pi ca fiind 3,1605, respectiv 3,125." + Environment.NewLine +
                " ■ 287 i.Hr. S-a nascut matematicianul Arhimede din Siracuza. El a descoperit " + Environment.NewLine +
                " legatura dintre aria cercului si circumferinta sa." + Environment.NewLine +
                " ■ 429 S-a nascut astronomul si matematicianul chinez Zu Chongzhi. El l-a estimat pe " + Environment.NewLine +
                " pi ca fiind 355/113,ceea ce ramane cea mai buna aproximare pentru urmatorii 1.000 " + Environment.NewLine +
                " de ani. " + Environment.NewLine +
                " ■ 1579 Francezul François Viete il calculeaza pe pi pana la a noua zecimala." + Environment.NewLine +
                " ■ 1610 Ludolph van Ceulen, din Germania, calculeaza pi pana la a 35-a zecimala. " + Environment.NewLine +
                " Moare in acelasi an si are valoarea lui pi gravata pe piatra sa de mormant." + Environment.NewLine +
                " ■ 1706 Simbolul lui pi (π) este folosit pentru prima data de matematicianul galez " + Environment.NewLine +
                " William Jones, pentru a reprezenta raportul dintre circumferinta unui cerc si " + Environment.NewLine +
                " diametrul sau. " + Environment.NewLine +
                " ■ 1761 Matematicianul germano-elvetian, Johann Heinrich Lambert, aduce prima " + Environment.NewLine +
                " dovada stiintifica potrivit careia pi e numar irational." + Environment.NewLine +
                " ■ 1794 Francezul Adrien-Marie Legendre dovedeste ca π2 e si el irational.";
            iTalk_HeaderLabel31.Text = " ■ 1897 Fizicianul american Edward Johnston Goodwin incearca sa estimeze " + Environment.NewLine +
                "cu precizie valoarea lui pi si sa o inregistreze, astfel incat sa-i fie platite " + Environment.NewLine +
                "drepturi de autor. Ideea esueaza dupa ce opinia publica se revolta." + Environment.NewLine +
                " ■ 1937 Tavanul Salii 31 a Palatului Découverte din Paris este decorat cu " + Environment.NewLine +
                "zecimalele lui pi.A 528 - a zecimala este gresita si va fi corectata in 1949." + Environment.NewLine +
                " ■1988 Se celebreaza, pentru prima data, Ziua Pi, pe 14 martie, in San " + Environment.NewLine +
                "Francisco." + Environment.NewLine +
                " ■ 2005 Studentul chinez Chao Lu il recita pe pi din memorie pana la" + Environment.NewLine +
                "a 67.890 - a zecimala, stabilind un nou record mondial." + Environment.NewLine +
                " ■ 2009 Congresul SUA recunoaste, in mod oficial, Ziua Nationala Pi,14" + Environment.NewLine +
                "martie.";
            iTalk_HeaderLabel33.Text = " – Pi este aproximat ca fractia 22/7." + Environment.NewLine +
                " – Matematicianul britanic William Shanks (1812-1882) a aflat, in 15 ani, 707" + Environment.NewLine +
                " zecimale ale lui pi. El a facut o eroare la zecimala 528, eroare care a fost detectata" + Environment.NewLine +
                " abia in 1945." + Environment.NewLine +
                " Chiar cu mult timp înainte ca valoarea lui π să fie evaluată de calculatoarele" + Environment.NewLine +
                " electronice, memorarea unui număr record de cifre a devenit o obsesie a" + Environment.NewLine +
                " unor oameni. În 2006, Akira Haraguchi, un inginer japonez pensionar, s-a" + Environment.NewLine +
                " lăudat cu reținerea a 100.000 de zecimale exacte. ";
            iTalk_HeaderLabel34.Text= " Aceasta nu a fost însă verificată de Guinness World Records." + Environment.NewLine +
                " Recordul înregistrat de Guinness la memorarea cifrelor lui π este" + Environment.NewLine +
                " de 67.890 de cifre, deținut de Lu Chao, un student de 24 de ani" + Environment.NewLine +
                " din China.I-a luat 24 de ore și 4 minute să recite fără greșeală" + Environment.NewLine +
                " până la a 67.890-a cifră zecimală a lui π.";
            iTalk_HeaderLabel35.Text = " – De 90 de zile au avut nevoie Shigeru Kondo, un inginer de sistem din " + Environment.NewLine +
                " Japonia, si Alexander Yee, un student la informatica din SUA, pentru" + Environment.NewLine +
                " a  scrie, in 2010, 5.000 de miliarde de zecimale ale lui pi" + Environment.NewLine +
                " pe ecranul unui singur computer." + Environment.NewLine +
                " – In primul milion al zecimalelor lui pi, numarul 5 apare cel mai des," + Environment.NewLine +
                " 100.359 de aparitii." + Environment.NewLine +
                " – Cei care memoreaza numarul pi adauga, zilnic, 10 sau 15 zecimale in" + Environment.NewLine +
                " memoria lor. Englezul Daniel Tammet a estimat ca i-au trebuit 14 zile" + Environment.NewLine +
                " pentru a memora primele 22.514 zecimale ale lui pi. Le-a recitat la" + Environment.NewLine +
                " Universitatea Oxford, pe 14 martie 2004. ";
            iTalk_HeaderLabel36.Text = " ■ Există mai multe moduri de memorare a lui π, printre care și utilizarea de" + Environment.NewLine +
                " „pieme”, poezii care reprezintă numărul π astfel încât lungimea fiecărui" + Environment.NewLine +
                " cuvânt (în litere) reprezintă o cifră. Un astfel de exemplu de piemă, compus" + Environment.NewLine +
                " de Sir James Jeans: How I need (sau: want) a drink, alcoholic in nature" + Environment.NewLine +
                " (sau: of course), after the heavy lectures (sau: chapters) involving quantum" + Environment.NewLine +
                " mechanics.Primul cuvânt are 3 litere, al doilea are una, al treilea are 4, al" + Environment.NewLine +
                " patrulea 1, al cincilea 5, și așa mai departe. Echivalent, în limba română" + Environment.NewLine +
                " există fraza: „Așa e bine a scrie renumitul și utilul număr”.Cadaeic Cadenza" + Environment.NewLine +
                " conține în acest fel primele 3834 de cifre ale lui π.Piemele fac parte din" + Environment.NewLine +
                " întregul domeniu de studiu al mnemotehnicilor pentru reținerea cifrelor lui π.";
            iTalk_HeaderLabel37.Text = " ■ Poezia lui pi „Piemele“ sunt poeme inspirate de pi, in care lungimea fiecarui cuvant" + Environment.NewLine +
                " (in litere) reprezinta o zecimala a lui pi. De exemplu: „Asa e bine a scrie renumitul si utilul" + Environment.NewLine +
                " numar“. Versurile reprezinta numarul 3.14159265. Piemele au fost create pentru a" + Environment.NewLine +
                " ajuta oamenii sa retina zecimalele lui pi. Acum exista chiar carti de pieme cu" + Environment.NewLine +
                " 10.000 de cuvinte. Pingleza, o varianta a limbii engleze, urmeaza aceeasi regula in" + Environment.NewLine +
                " povestiri scurte, puzzle-uri si piese de teatru. ";
            iTalk_HeaderLabel38.Text = " In limba romana performanata de a creea un poem" + Environment.NewLine +
                " pentru a putea memora zecimalele numarului pi" + Environment.NewLine +
                " este de 25 de zecimale, data de urmatoarea" + Environment.NewLine +
                " poezie: ";
            iTalk_HeaderLabel39.Text = "“Dar o stim e numar important ce trebuie iubit" + Environment.NewLine +
                "" + Environment.NewLine +
                "Din toate numerele insemnate diamant" + Environment.NewLine +
                "" + Environment.NewLine +
                "neasemuit" + Environment.NewLine +
                "" + Environment.NewLine +
                "Cei ce vor temeinic asta pretui" + Environment.NewLine +
                "" + Environment.NewLine +
                "Ei vesnic bine vor trai!“";
            //iTalk_HeaderLabel43.Text = " Pentru a te juca cu un cerc ai nevoie" + Environment.NewLine +
            //    " de cele de mai jos. In partea din stanga in functiie" + Environment.NewLine +
            //    " de parametrii adaugati programul o sa deseneze" + Environment.NewLine +
            //    " un cerc cu aproximarile dimensiunilor introduse";
            
        }
#endregion
        #region Optimizare App
        //Optimizare
        [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);
        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }    
        private void timer1_Tick(object sender, EventArgs e)
        {
            FlushMemory();
        }
        //Optimizare
#endregion
        #region FormAction
        //Form Action
        private void PI_Load(object sender, EventArgs e)
        {
            Parola = Login.Parola_Login;
            Username = Login.User_Login;
            iTalk_ThemeContainer1.Text = Username + " - Bine ai venit in lumea lui PI";
            backgroundWorker1.RunWorkerAsync();

        }
        private void PI_FormClosing(object sender, FormClosingEventArgs e)
        {
            var proc = Process.GetCurrentProcess().ProcessName;
            foreach (var process in Process.GetProcessesByName(proc))
            {
                process.Kill();
            }
        }
        //Form Action
        #endregion
        #region Draw Circle
        //Draw Circle
        public void DrawCircle(Graphics g, Pen pen, double centerX, double centerY, double radius)
        {       
            g.Clear(Color.LightCyan);
            g.DrawEllipse(pen, (float)(centerX - radius), (float)(centerY - radius), (float)(radius + radius), (float)(radius + radius));
            Brush aBrush = (Brush)Brushes.Red;
            
            const double angleOfLineInDegrees = 360;
            const double angleOfLineInRadians = (angleOfLineInDegrees / 180) * Math.PI;

         
            var cirleCenter = new PointF(((float)Width / 2), ((float)Height / 2));

            var lineVector = new PointF((float)Math.Cos(angleOfLineInRadians) * (float)radius, (float)Math.Sin(angleOfLineInRadians) * (float)radius);

            var lineEndPoint = new PointF((float)centerX + lineVector.X, (float)centerY + lineVector.Y);
            Pen pens = new Pen(Color.Green, 5);
            g.DrawLine(pens, (float)centerX, (float)centerY, lineEndPoint.X,lineEndPoint.Y);
            g.FillRectangle(aBrush, (float)centerX, (float)centerY, 4, 4);
            g.Dispose();
        }
        double radius;
        double diametru;
        double aria;
        double circumferinta;
        Pen pen = new Pen(Color.Black, 7);
        private void iTalk_Button_21_Click(object sender, EventArgs e)
        {
            Graphics paper = pictureBox14.CreateGraphics();
            if (iTalk_CheckBox1.Checked)
            {
                if (textBox3.Text != string.Empty && Convert.ToDouble(textBox3.Text) <= 2198 && Convert.ToDouble(textBox3.Text) >= 6.28f)
                {
                    radius = (Convert.ToDouble(textBox3.Text) / (double)Math.PI) / (double)2;
                    diametru = Convert.ToDouble(textBox3.Text) / (double)Math.PI;
                    aria = (double)Math.Pow(radius, 2) * (double)Math.PI;
                    textBox2.Text = diametru.ToString();
                    textBox1.Text = radius.ToString();
                    textBox4.Text = aria.ToString();
                    double centerX = pictureBox14.Size.Width / 2.0f;
                    double centerY = pictureBox14.Size.Height / 2.0f;           
                    DrawCircle(paper, pen, centerX, centerY, radius);
                }
                else
                {
                    MessageBox.Show("Nu uita sa introduci dimensiunea pentru circumferinta cercului dorit intre 6.28 si 2198.");
                    return;
                }
                }
            
            if (iTalk_CheckBox2.Checked )
            {
                if (textBox2.Text != string.Empty && Convert.ToDouble(textBox2.Text) <= 700 && Convert.ToDouble(textBox2.Text) >= 2.0f)
                {
                    circumferinta = (Convert.ToDouble(textBox2.Text) * (double)Math.PI);
                    radius = Convert.ToDouble(textBox2.Text) / (double)2;
                    aria = (double)Math.Pow(radius, 2) * (double)Math.PI;
                    textBox3.Text = circumferinta.ToString();
                    textBox1.Text = radius.ToString();
                    textBox4.Text = aria.ToString();
                    double centerX = pictureBox14.Size.Width / 2.0f;
                    double centerY = pictureBox14.Size.Height / 2.0f;
                    DrawCircle(paper, pen, centerX, centerY, radius);
                }
                else
                {
                    MessageBox.Show("Nu uita sa introduci dimensiunea pentru diametrul cercului dorit intre 2 si 700."); return;
                }
            }
            
            if (iTalk_CheckBox3.Checked )
            {
                if (textBox1.Text != string.Empty && Convert.ToDouble(textBox1.Text) <= 350 && Convert.ToDouble(textBox1.Text) >= 1.0f)
                {
                    radius = Convert.ToDouble(textBox1.Text);
                    diametru = Convert.ToDouble(textBox1.Text) * (double)2;
                    circumferinta = (double)(diametru * Math.PI);
                    aria = (double)Math.Pow(Convert.ToDouble(textBox1.Text), 2) * (double)Math.PI;
                    textBox3.Text = circumferinta.ToString();
                    textBox2.Text = diametru.ToString();
                    textBox4.Text = aria.ToString();
                    double centerX = pictureBox14.Size.Width / 2.0f;
                    double centerY = pictureBox14.Size.Height / 2.0f;
                    DrawCircle(paper, pen, centerX, centerY, radius);
                }
                else
                {
                    MessageBox.Show("Nu uita sa introduci dimensiunea pentru raza cercului dorit intre 1 si 350."); return;
                }
            }
            
            if (iTalk_CheckBox4.Checked && Convert.ToDouble(textBox4.Text) <= 331662.5 && Convert.ToDouble(textBox4.Text) >= 3.14f)
            {
                if (textBox4.Text != string.Empty )
                {
                    radius = (double)Math.Sqrt(Convert.ToDouble(textBox4.Text) / Math.PI);
                    diametru = radius * 2;
                    circumferinta = ((double)diametru * (double)Math.PI);
                    textBox3.Text = circumferinta.ToString();
                    textBox2.Text = diametru.ToString();
                    textBox1.Text = radius.ToString();
                    double centerX = pictureBox14.Size.Width / 2.0f;
                    double centerY = pictureBox14.Size.Height / 2.0f;
                    //Graphics paper;
                    //paper = pictureBox14.CreateGraphics();
                    DrawCircle(paper, pen, centerX, centerY, radius);
                }
                else
                {
                    MessageBox.Show("Nu uita sa introduci dimensiunea pentru aria cercului dorit intre 3.14 si 331662.5."); return;
                }
            }
            
        }
        //Draw Circle
        #endregion
        #region Draw Circle Params
        private void iTalk_CheckBox1_CheckedChanged(object sender)
        {
            if(iTalk_CheckBox1.Checked==true)
            {
                iTalk_CheckBox2.Checked = false;
                iTalk_CheckBox3.Checked = false;
                iTalk_CheckBox4.Checked = false;
            }
        }

        private void iTalk_CheckBox2_CheckedChanged(object sender)
        {
            if (iTalk_CheckBox2.Checked == true)
            {
                iTalk_CheckBox1.Checked = false;
                iTalk_CheckBox3.Checked = false;
                iTalk_CheckBox4.Checked = false;
            }
        }

        private void iTalk_CheckBox3_CheckedChanged(object sender)
        {
            if (iTalk_CheckBox3.Checked == true)
            {
                iTalk_CheckBox1.Checked = false;
                iTalk_CheckBox2.Checked = false;
                iTalk_CheckBox4.Checked = false;
            }
        }

        private void iTalk_CheckBox4_CheckedChanged(object sender)
        {
            if (iTalk_CheckBox4.Checked == true)
            {
                iTalk_CheckBox1.Checked = false;
                iTalk_CheckBox2.Checked = false;
                iTalk_CheckBox3.Checked = false;           
            }
        }
        #endregion
        #region Detect Input Params
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && textBox1.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && textBox4.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && textBox2.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && textBox3.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        #endregion
        #region Clear Params For Circle
        private void iTalk_Button_22_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
        }
#endregion
        #region Send Answer
        private void iTalk_Button_23_Click(object sender, EventArgs e)
        {
            if (Rs1 == string.Empty || Rs2 == string.Empty || Rs3 == string.Empty || Rs4 == string.Empty ||
               Rs5 == string.Empty || Rs6 == string.Empty || Rs7 == string.Empty || Rs8 == string.Empty ||
               Rs9 == string.Empty || Rs10 == string.Empty)
            {
                MessageBox.Show("Nu uita sa raspunzi la toate intrebarile.");
            }
            else
            {
                MessageBox.Show("Ai obtinut un punctaj de: " + DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/" + Rs1 + "/" + Rs2 + "/" + Rs3 + "/" + Rs4 + "/" + Rs5 + "/" + Rs6 + "/" + Rs7 + "/" + Rs8 + "/" + Rs9 + "/" + Rs10) + " puncte.");
            }
        }
        #endregion
        #region Get Questions
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            intrebare1.Invoke((MethodInvoker)delegate {
                intrebare1.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/1");
            });
            Thread.Sleep(10);
            intrebare2.Invoke((MethodInvoker)delegate {
                intrebare2.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/2");
            });
            Thread.Sleep(10);
            intrebare3.Invoke((MethodInvoker)delegate {
                intrebare3.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/3");
            }); Thread.Sleep(10);
            intrebare4.Invoke((MethodInvoker)delegate {
                intrebare4.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/4");
            }); Thread.Sleep(10);
            intrebare5.Invoke((MethodInvoker)delegate {
                intrebare5.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/5");
            }); Thread.Sleep(10);
            intrebare6.Invoke((MethodInvoker)delegate {
                intrebare6.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/6");
            }); Thread.Sleep(10);
            intrebare7.Invoke((MethodInvoker)delegate {
                intrebare7.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/7");
            }); Thread.Sleep(10);
            intrebare8.Invoke((MethodInvoker)delegate {
                intrebare8.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/8");
            }); Thread.Sleep(10);
            intrebare9.Invoke((MethodInvoker)delegate {
                intrebare9.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/9");
            }); Thread.Sleep(10);
            intrebare10.Invoke((MethodInvoker)delegate {
                intrebare10.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/10");
            }); Thread.Sleep(10);


            checkBox1.Invoke((MethodInvoker)delegate {
                checkBox1.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/1/1/");
            }); Thread.Sleep(10);
            checkBox2.Invoke((MethodInvoker)delegate {
                checkBox2.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/1/2/");
            }); Thread.Sleep(10);
            checkBox3.Invoke((MethodInvoker)delegate {
                checkBox3.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/1/3/");
            }); Thread.Sleep(10);
            checkBox4.Invoke((MethodInvoker)delegate {
                checkBox4.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/2/1/");
            }); Thread.Sleep(10);
            checkBox5.Invoke((MethodInvoker)delegate {
                checkBox5.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/2/2/");
            }); Thread.Sleep(10);
            checkBox6.Invoke((MethodInvoker)delegate {
                checkBox6.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/2/3/");
            }); Thread.Sleep(10);
            checkBox7.Invoke((MethodInvoker)delegate {
                checkBox7.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/3/1/");
            }); Thread.Sleep(10);
            checkBox8.Invoke((MethodInvoker)delegate {
                checkBox8.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/3/2/");
            }); Thread.Sleep(10);
            checkBox9.Invoke((MethodInvoker)delegate {
                checkBox9.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/3/3/");
            }); Thread.Sleep(10);
            checkBox10.Invoke((MethodInvoker)delegate {
                checkBox10.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/4/1/");
            }); Thread.Sleep(10);
            checkBox11.Invoke((MethodInvoker)delegate {
                checkBox11.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/4/2/");
            }); Thread.Sleep(10);
            checkBox12.Invoke((MethodInvoker)delegate {
                checkBox12.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/4/3/");
            }); Thread.Sleep(10);
            checkBox13.Invoke((MethodInvoker)delegate {
                checkBox13.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/5/1/");
            }); Thread.Sleep(10);
            checkBox14.Invoke((MethodInvoker)delegate {
                checkBox14.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/5/2/");
            }); Thread.Sleep(10);
            checkBox15.Invoke((MethodInvoker)delegate {
                checkBox15.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/5/3/");
            }); Thread.Sleep(10);
            checkBox16.Invoke((MethodInvoker)delegate {
                checkBox16.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/6/1/");
            }); Thread.Sleep(10);
            checkBox17.Invoke((MethodInvoker)delegate {
                checkBox17.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/6/2/");
            }); Thread.Sleep(10);
            checkBox18.Invoke((MethodInvoker)delegate {
                checkBox18.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/6/3/");
            }); Thread.Sleep(10);
            checkBox19.Invoke((MethodInvoker)delegate {
                checkBox19.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/7/1/");
            }); Thread.Sleep(10);
            checkBox20.Invoke((MethodInvoker)delegate {
                checkBox20.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/7/2/");
            }); Thread.Sleep(10);
            checkBox21.Invoke((MethodInvoker)delegate {
                checkBox21.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/7/3/");
            }); Thread.Sleep(10);
            checkBox22.Invoke((MethodInvoker)delegate {
                checkBox22.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/8/1/");
            }); Thread.Sleep(10);
            checkBox23.Invoke((MethodInvoker)delegate {
                checkBox23.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/8/2/");
            }); Thread.Sleep(10);
            checkBox24.Invoke((MethodInvoker)delegate {
                checkBox24.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/8/3/");
            }); Thread.Sleep(10);
            checkBox25.Invoke((MethodInvoker)delegate {
                checkBox25.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/9/1/");
            }); Thread.Sleep(10);
            checkBox26.Invoke((MethodInvoker)delegate {
                checkBox26.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/9/2/");
            }); Thread.Sleep(10);
            checkBox27.Invoke((MethodInvoker)delegate {
                checkBox27.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/9/3/");
            }); Thread.Sleep(10);
            checkBox28.Invoke((MethodInvoker)delegate {
                checkBox28.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/10/1/");
            }); Thread.Sleep(100);
            checkBox29.Invoke((MethodInvoker)delegate {
                checkBox29.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/10/2/");
            }); Thread.Sleep(10);
            checkBox30.Invoke((MethodInvoker)delegate {
                checkBox30.Text = DownloadString("http://optimised.biz/quiz/" + Parola + "/" + Username + "/10/3/");
            }); Thread.Sleep(10);
            this.Refresh();
        }
#endregion
        #region Detect Select Answer
        string Rs1 = string.Empty,Rs2 = string.Empty, Rs3 = string.Empty, Rs4 = string.Empty, Rs5 = string.Empty, Rs6 = string.Empty, Rs7 = string.Empty, Rs8 = string.Empty, Rs9 = string.Empty, Rs10 = string.Empty;

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                checkBox11.Checked = false;
                checkBox10.Checked = false;
                Rs4 = checkBox12.Text;
            }
            else
            {
                Rs4 = string.Empty;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                
                checkBox12.Checked = false;
                checkBox10.Checked = false;
                Rs4 = checkBox12.Text;
            }
            else
            {
                Rs4 = string.Empty;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
             
                checkBox12.Checked = false;
                checkBox11.Checked = false;
                Rs4 = checkBox10.Text;
            }
            else
            {
                Rs4 = string.Empty;
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked)
            {
               
                checkBox13.Checked = false;
                checkBox14.Checked = false;
                Rs5 = checkBox15.Text;
            }
            else
            {
                Rs5 = string.Empty;
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked)
            {
               
                checkBox13.Checked = false;
                checkBox15.Checked = false;
                Rs5 = checkBox14.Text;
            }
            else
            {
                Rs5 = string.Empty;
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked)
            {
             
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                Rs5 = checkBox13.Text;
            }
            else
            {
                Rs5 = string.Empty;
            }
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox30.Checked)
            {
                
                checkBox28.Checked = false;
                checkBox29.Checked = false;
                Rs10 = checkBox30.Text;
            }
            else
            {
                Rs10 = string.Empty;
            }
        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox29.Checked)
            {
              
                checkBox28.Checked = false;
                checkBox30.Checked = false;
                Rs10 = checkBox29.Text;
            }
            else
            {
                Rs10 = string.Empty;
            }
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox28.Checked)
            {
               
                checkBox29.Checked = false;
                checkBox30.Checked = false;
                Rs10 = checkBox28.Text;
            }
            else
            {
                Rs10 = string.Empty;
            }
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox25.Checked)
            {
                
                checkBox26.Checked = false;
                checkBox27.Checked = false;
                Rs9 = checkBox25.Text;
            }
            else
            {
                Rs9 = string.Empty;
            }
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox26.Checked)
            {
                checkBox27.Checked = false;
                checkBox25.Checked = false;

                Rs9 = checkBox26.Text;
            }
            else
            {
                Rs9 = string.Empty;
            }
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox27.Checked)
            {
                
                checkBox26.Checked = false;
                checkBox25.Checked = false;
                Rs9 = checkBox27.Text;
            }
            else
            {
                Rs9 = string.Empty;
            }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked)
            {
               
                checkBox23.Checked = false;
                checkBox24.Checked = false;
                Rs8 = checkBox22.Text;
            }
            else
            {
                Rs8 = string.Empty;
            }
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked)
            {
               
                checkBox22.Checked = false;
                checkBox24.Checked = false;
                Rs8 = checkBox23.Text;
            }
            else
            {
                Rs8 = string.Empty;
            }
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox24.Checked)
            {
               
                checkBox22.Checked = false;
                checkBox23.Checked = false;
                Rs8 = checkBox24.Text;
            }
            else
            {
                Rs8 = string.Empty;
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked)
            {
               
                checkBox20.Checked = false;
                checkBox21.Checked = false;
                Rs7 = checkBox19.Text;
            }
            else
            {
                Rs7 = string.Empty;
            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked)
            {
               
                checkBox19.Checked = false;
                checkBox21.Checked = false;
                Rs7 = checkBox20.Text;
            }
            else
            {
                Rs7 = string.Empty;
            }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked)
            {
               
                checkBox19.Checked = false;
                checkBox20.Checked = false;
                Rs7 = checkBox21.Text;
            }
            else
            {
                Rs7 = string.Empty;
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked)
            {
              
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                Rs6 = checkBox16.Text;
            }
            else
            {
                Rs6 = string.Empty;
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked)
            {
                
                checkBox16.Checked = false;
                checkBox18.Checked = false;
                Rs6 = checkBox17.Text;
            }
            else
            {
                Rs6 = string.Empty;
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked)
            {
              
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                Rs6 = checkBox18.Text;
            }
            else
            {
                Rs6 = string.Empty;
            }
        }

        private void iTalk_HeaderLabel45_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/GooDRNK/Lumea-lui-PI");
        }

        private void iTalk_HeaderLabel46_Click(object sender, EventArgs e)
        {
            Process.Start("https://liceulteoreticioncantacuzino.ro/");
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                Rs3 = checkBox7.Text;
            }
            else
            {
                Rs3 = string.Empty;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
               
                checkBox7.Checked = false;
                checkBox9.Checked = false;
                Rs3 = checkBox8.Text;
            }
            else
            {
                Rs3 = string.Empty;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
               
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                Rs3 = checkBox9.Text;
            }
            else
            {
                Rs3 = string.Empty;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
              
                checkBox5.Checked = false;
                checkBox4.Checked = false;
                Rs2 = checkBox6.Text;
            }
            else
            {
                Rs2 = string.Empty;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
               
                checkBox4.Checked = false;
                checkBox6.Checked = false;
                Rs2 = checkBox5.Text;
            }
            else
            {
                Rs2 = string.Empty;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
               
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                Rs2 = checkBox4.Text;
            }
            else
            {
                Rs2 = string.Empty;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
               
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                Rs1 = checkBox1.Text;
            }
            else
            {
                Rs1 = string.Empty;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
              
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                Rs1 = checkBox2.Text;
            }
            else
            {
                Rs1 = string.Empty;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
             
                checkBox2.Checked = false;
                checkBox1.Checked = false;
                Rs1 = checkBox3.Text;
            }
            else
            {
                Rs1 = string.Empty;
            }
        }
#endregion
    }
}
