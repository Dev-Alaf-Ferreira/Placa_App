namespace Placa_App
{
    public partial class Main_menu : Form
    {
        public Main_menu()
        {
            InitializeComponent();
            CarregarImagem(pcbTimeA, lblNomeTimaA.Text);
            CarregarImagem(pcbTimeB, lblNomeTimaB.Text);
        }

        private void CarregarImagem(PictureBox pcbTime, string text)
        {
            if (text.Equals("Comando e Controle"))
                pcbTime.Image = Properties.Resources.ComandoControle;
            else if (text.Equals("Grupo de Apoio"))
                pcbTime.Image = Properties.Resources.Grupo_de_Apoio;
            else if (text.Equals("Licitac�es"))
                pcbTime.Image = Properties.Resources.Licitacoes;
            else if (text.Equals("Rancho"))
                pcbTime.Image = Properties.Resources.Rancho;
            else if (text.Equals("Sergenteac�o_FC"))
                pcbTime.Image = Properties.Resources.Sergenteacao;
            else if (text.Equals("Sub_Ten�ncia"))
                pcbTime.Image = Properties.Resources.Sub_Tenencia;

        }

        private void btnGolTimeA_Click(object sender, EventArgs e)
        {
            int resultado = int.Parse(lblTimeA.Text) + 1;
            lblTimeA.Text = resultado.ToString();
        }

        private void btnAnuladoTimeA_Click(object sender, EventArgs e)
        {
            int resultado = int.Parse(lblTimeA.Text);
            if (resultado > 0)
            {
                resultado--;
                lblTimeA.Text = resultado.ToString();
            }
        }

        private void btnGolTimeB_Click(object sender, EventArgs e)
        {
            int resultado = int.Parse(lblTimeB.Text) + 1;
            lblTimeB.Text = resultado.ToString();
        }

        private void btnAnuladoTimeB_Click(object sender, EventArgs e)
        {
            int resultado = int.Parse(lblTimeB.Text);
            if (resultado > 0)
            {
                resultado--;
                lblTimeB.Text = resultado.ToString();
            }

        }
        int min = 15; int seg = 55;
        private void cronometro_Tick(object sender, EventArgs e)
        {
            seg++;
            if (seg == 60)
            {
                min++;
                seg = 0;
            }
            string texto = "";
            if (min < 8)
                texto += "0" + min;
            else
                texto += min;

            if (seg < 8)
                texto += ":0" + seg;
            else
                texto += ":" + seg;
            lblCronometro.Text = texto;
            if (min < 8)
                lblTempo.Text = "1� Tempo";
            else
                lblTempo.Text = "2� Tempo";


            if ((min == 8 && seg == 0) || (min == 16))
            {
                cronometro.Enabled = false;
                btnComecar.Visible = true;
                DesativarBotoes();

                if (min == 8)
                    btnComecar.Text = "Come�ar 2� Tempo";
                else if (min == 16)
                    btnComecar.Text = "Come�ar Novo Jogo";
            }
        }

        private void btnComecar_Click(object sender, EventArgs e)
        {
            if (min == 16)
            {
                min = 0;
                seg = 0;
                lblCronometro.Text = "00:00";
                btnComecar.Text = "Come�ar jogo";
                lblTimeA.Text = "0";
                lblTimeB.Text = "0";
                lblTempo.Text = "1� Tempo";
            }
            else
            {
                cronometro.Enabled = true;
                btnComecar.Visible = false;
                AtivarBotoes();
            }
        }

        private void AtivarBotoes()
        {
            btnGolTimeA.Enabled = true;
            btnGolTimeB.Enabled = true;
            btnAnuladoTimeA.Enabled = true;
            btnAnuladoTimeB.Enabled = true;
        }
        private void DesativarBotoes()
        {
            btnGolTimeA.Enabled = false;
            btnGolTimeB.Enabled = false;
            btnAnuladoTimeA.Enabled = false;
            btnAnuladoTimeB.Enabled = false;
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            cronometro.Enabled = false;
        }
    }
}