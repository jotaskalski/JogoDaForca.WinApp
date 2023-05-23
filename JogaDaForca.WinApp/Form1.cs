namespace JogaDaForca.WinApp
{
    public partial class Form1 : Form
    {
        private Forca jogoDaForca;
        public Form1()
        {
            InitializeComponent();

            RegistrarEventos();

            jogoDaForca = new Forca();

            ObterPalavraParcial();

            ObterDicaPalavra();

            lblMensagemFinal.Text = "";

        }
        private void RegistrarEventos()
        {
            foreach (Button botao in pnlBotoes.Controls)
            {
                botao.Click += DarPalpite;
                botao.Click += AtualizarBotoesPainel;
            }

            btnReset.Click += ReiniciarJogo;
        }

        #region Eventos

        private void DarPalpite(object? sender, EventArgs e)
        {
            Button botaoClicado = (Button)sender;

            char palpite = botaoClicado.Text[0];

            if (jogoDaForca.JogadorAcertou(palpite) || jogoDaForca.JogadorPerdeu())
                FinalizarJogo();

            ObterPalavraParcial();

            AtualizarForca();
        }

        private void ReiniciarJogo(object? sender, EventArgs e)
        {
            jogoDaForca = new Forca();

            ObterPalavraParcial();

            ObterDicaPalavra();

            AtualizarForca();

            lblMensagemFinal.Text = "";

            pnlBotoes.Enabled = true;

            foreach (Button botao in pnlBotoes.Controls)
                botao.Enabled = true;
        }

        private void AtualizarBotoesPainel(object? sender, EventArgs e)
        {
            Button botaoClicado = (Button)sender;

            botaoClicado.Enabled = false;
        }

        #endregion

        private void FinalizarJogo()
        {

            bool jogadorPerdeu = jogoDaForca.JogadorPerdeu();

            if (jogadorPerdeu)
                lblMensagemFinal.ForeColor = Color.Red;
            else
                lblMensagemFinal.ForeColor = Color.Green;

            pnlBotoes.Enabled = false;

            lblMensagemFinal.Text = jogoDaForca.mensagemFinal;
        }

        private void AtualizarForca()
        {
            switch (jogoDaForca.Erros)
            {
                case 1: pbImagemForca.Image = Properties.Resources._2; break;
                case 2: pbImagemForca.Image = Properties.Resources._3; break;
                case 3: pbImagemForca.Image = Properties.Resources._4; break;
                case 4: pbImagemForca.Image = Properties.Resources._5; break;
                case 5: pbImagemForca.Image = Properties.Resources._6; break;
                case 6: pbImagemForca.Image = Properties.Resources._7; break;
                case 7: pbImagemForca.Image = Properties.Resources._8; break;

                default:
                    pbImagemForca.Image = Properties.Resources._1;
                    break;
            }
        }

        private void ObterPalavraParcial()
        {
            lblPalavraSecreta.Text = jogoDaForca.PalavraParcial;
        }

        private void ObterDicaPalavra()
        {
            lblDica.Text = jogoDaForca.QuantidadeLetras + " letras";
        }
    }
}