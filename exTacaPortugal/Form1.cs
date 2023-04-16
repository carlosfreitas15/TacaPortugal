using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace exTacaPortugal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<string> equipasMeias = new List<string>();
        private List<string> equipasFinal = new List<string>();

        private void btnEquipasOitavos_Click(object sender, EventArgs e)
        {
            lstEquipasOitavos.Items.Add("Famalicao");
            lstEquipasOitavos.Items.Add("Braga");
            lstEquipasOitavos.Items.Add("Porto");
            lstEquipasOitavos.Items.Add("Gil");
            lstEquipasOitavos.Items.Add("Sporting");
            lstEquipasOitavos.Items.Add("Benfica");
            lstEquipasOitavos.Items.Add("Vitoria");
            lstEquipasOitavos.Items.Add("Portimonense");
            lstEquipasOitavos.Items.Add("Arouca");
            lstEquipasOitavos.Items.Add("CasaPia");
            lstEquipasOitavos.Items.Add("Estoril");
            lstEquipasOitavos.Items.Add("Vizela");
            lstEquipasOitavos.Items.Add("SantaClara");
            lstEquipasOitavos.Items.Add("Paços");
            lstEquipasOitavos.Items.Add("Maritimo");
            lstEquipasOitavos.Items.Add("Chaves");

            btnEquipasOitavos.Enabled = false;
            btnEquipasQuartos.Enabled = true;
        }

        private void btnEquipasQuartos_Click(object sender, EventArgs e)
        {
            List<string> equipasSorteadas = new List<string>();

            Random rand = new Random();

            while (equipasSorteadas.Count < 8)
            {
                int rnd = rand.Next(0, 16);
                string name = lstEquipasOitavos.Items[rnd].ToString();
                if (!equipasSorteadas.Contains(name)) equipasSorteadas.Add(name);
            }



            foreach (string equipas in equipasSorteadas)
            {
                lstEquipasQuartos.Items.Add(equipas);
            }

            btnEquipasQuartos.Enabled = false;
            btnJogosQuartos.Enabled = true;
        }

        private void btnJogosQuartos_Click(object sender, EventArgs e)
        {
            List<string> equipasSorteadas1 = new List<string>();
            List<string> equipasSorteadas2 = new List<string>();



            Random rand = new Random();

            while (equipasSorteadas1.Count < 4)
            {
                int rnd = rand.Next(0, 8);
                string equipa1 = lstEquipasQuartos.Items[rnd].ToString();
                // string equipa2 = lstEquipasQuartos.Items[rnd].ToString();


                if ((!equipasSorteadas1.Contains(equipa1)) && (!equipasSorteadas2.Contains(equipa1))) equipasSorteadas1.Add(equipa1);
                // if ((!equipasSorteadas2.Contains(equipa2)) && (!equipasSorteadas2.Contains(equipa2))) equipasSorteadas2.Add(equipa2);
            }

            while (equipasSorteadas2.Count < 4)
            {
                int rnd = rand.Next(0, 8);
                string equipa2 = lstEquipasQuartos.Items[rnd].ToString();

                if ((!equipasSorteadas1.Contains(equipa2)) && (!equipasSorteadas2.Contains(equipa2))) equipasSorteadas2.Add(equipa2);
            }

            for (int i = 0; i < 4; i++)
            {
                int index1 = rand.Next(equipasSorteadas1.Count);
                string equipe1 = equipasSorteadas1[index1];
                equipasSorteadas1.RemoveAt(index1);

                int index2 = rand.Next(equipasSorteadas2.Count);
                string equipe2 = equipasSorteadas2[index2];
                equipasSorteadas2.RemoveAt(index2);

                lstJogosQuartos.Items.Add($"{equipe1} - {equipe2}\n");
            }





            btnJogosQuartos.Enabled = false;
            btnResultadosQuartos.Enabled = true;
        }

        private void btnResultadosQuartos_Click(object sender, EventArgs e)
        {
            Random rand = new Random();



            int resultadoEquipe1 = 0; // Gera um número aleatório entre 1 e 5
            int resultadoEquipe2 = 0;

            string equipe1 = "";
            string equipe2 = "";


            for (int i = 0; i < lstJogosQuartos.Items.Count; i++)
            {
                // Obtenha o item da primeira ListBox
                string item = lstJogosQuartos.Items[i].ToString();

                // Separe a string do confronto em partes usando o espaço como delimitador
                string[] partes = item.Split(' ');

                // Obtenha as equipes e o resultado do confronto
                equipe1 = partes[0];
                equipe2 = partes[2];

                resultadoEquipe1 = rand.Next(0, 4); // Gera um número aleatório entre 1 e 5

                do
                {
                    resultadoEquipe2 = rand.Next(0, 4);
                } while (resultadoEquipe2 == resultadoEquipe1); // Repete até que o resultado da equipe 2 seja diferente da equipe 1


                // Adicione os resultados ao item
                string itemComResultado = $"{equipe1} {resultadoEquipe1} - {resultadoEquipe2} {equipe2}";

                // Adicione o item atualizado na segunda ListBox
                lstResultadosQuartos.Items.Add(itemComResultado);

                if (resultadoEquipe1 > resultadoEquipe2)
                {
                    equipasMeias.Add(equipe1);
                }

                else
                {
                    equipasMeias.Add(equipe2);
                }
            }



            btnResultadosQuartos.Enabled = false;
            btnEquipasMeias.Enabled = true;
        }

        private void btnEquipasMeias_Click(object sender, EventArgs e)
        {
            foreach (var equipa in equipasMeias)
            {
                lstEquipasMeias.Items.Add(equipa);
            }

            btnEquipasMeias.Enabled = false;
            btnJogosMeias.Enabled = true;
        }

        private void btnJogosMeias_Click(object sender, EventArgs e)
        {
            List<string> equipasSorteadas1 = new List<string>();
            List<string> equipasSorteadas2 = new List<string>();



            Random rand = new Random();

            while (equipasSorteadas1.Count < 2)
            {
                int rnd = rand.Next(0, 4);
                string equipa1 = lstEquipasMeias.Items[rnd].ToString();
                // string equipa2 = lstEquipasQuartos.Items[rnd].ToString();


                if ((!equipasSorteadas1.Contains(equipa1)) && (!equipasSorteadas2.Contains(equipa1))) equipasSorteadas1.Add(equipa1);
                // if ((!equipasSorteadas2.Contains(equipa2)) && (!equipasSorteadas2.Contains(equipa2))) equipasSorteadas2.Add(equipa2);
            }

            while (equipasSorteadas2.Count < 2)
            {
                int rnd = rand.Next(0, 4);
                string equipa2 = lstEquipasMeias.Items[rnd].ToString();

                if ((!equipasSorteadas1.Contains(equipa2)) && (!equipasSorteadas2.Contains(equipa2))) equipasSorteadas2.Add(equipa2);
            }

            for (int i = 0; i < 2; i++)
            {
                int index1 = rand.Next(equipasSorteadas1.Count);
                string equipe1 = equipasSorteadas1[index1];
                equipasSorteadas1.RemoveAt(index1);

                int index2 = rand.Next(equipasSorteadas2.Count);
                string equipe2 = equipasSorteadas2[index2];
                equipasSorteadas2.RemoveAt(index2);

                lstJogosMeias.Items.Add($"{equipe1} - {equipe2}\n");
            }





            btnJogosMeias.Enabled = false;
            btnResultadosMeias.Enabled = true;
        }

        private void btnResultadosMeias_Click(object sender, EventArgs e)
        {
            Random rand = new Random();



            int resultadoEquipe1 = 0; // Gera um número aleatório entre 1 e 5
            int resultadoEquipe2 = 0;

            string equipe1 = "";
            string equipe2 = "";


            for (int i = 0; i < lstJogosMeias.Items.Count; i++)
            {
                // Obtenha o item da primeira ListBox
                string item = lstJogosMeias.Items[i].ToString();

                

                // Separe a string do confronto em partes usando o espaço como delimitador
                string[] partes = item.Split(' ');

                // Obtenha as equipes e o resultado do confronto
                equipe1 = partes[0];
                equipe2 = partes[2];

                resultadoEquipe1 = rand.Next(0, 4); // Gera um número aleatório entre 1 e 5

                do
                {
                    resultadoEquipe2 = rand.Next(0, 4);
                } while (resultadoEquipe2 == resultadoEquipe1); // Repete até que o resultado da equipe 2 seja diferente da equipe 1


                // Adicione os resultados ao item
                string itemComResultado = $"{equipe1} {resultadoEquipe1} - {resultadoEquipe2} {equipe2}";

                // Adicione o item atualizado na segunda ListBox
                lstResultadosMeias.Items.Add(itemComResultado);

                if (resultadoEquipe1 > resultadoEquipe2)
                {
                    equipasFinal.Add(equipe1);
                }

                else
                {
                    equipasFinal.Add(equipe2);
                }
            }



            btnResultadosMeias.Enabled = false;
            btnFinalistas.Enabled = true;
        }

        private void btnFinalistas_Click(object sender, EventArgs e)
        {
            foreach (var equipa in equipasFinal)
            {
                lstFinalistas.Items.Add(equipa);
            }

            btnFinalistas.Enabled = false;
            btnResultadoFinal.Enabled = true;
        }

        private void btnResultadoFinal_Click(object sender, EventArgs e)
        {
            List<string> equipasSorteadas1 = new List<string>();
            List<string> equipasSorteadas2 = new List<string>();



            Random rand = new Random();

            while (equipasSorteadas1.Count < 1)
            {
                int rnd = rand.Next(0, 2);
                string equipa1 = lstFinalistas.Items[rnd].ToString();
                // string equipa2 = lstEquipasQuartos.Items[rnd].ToString();


                if ((!equipasSorteadas1.Contains(equipa1)) && (!equipasSorteadas2.Contains(equipa1))) equipasSorteadas1.Add(equipa1);
                // if ((!equipasSorteadas2.Contains(equipa2)) && (!equipasSorteadas2.Contains(equipa2))) equipasSorteadas2.Add(equipa2);
            }

            while (equipasSorteadas2.Count < 1)
            {
                int rnd = rand.Next(0, 2);
                string equipa2 = lstFinalistas.Items[rnd].ToString();

                if ((!equipasSorteadas1.Contains(equipa2)) && (!equipasSorteadas2.Contains(equipa2))) equipasSorteadas2.Add(equipa2);
            }








            string equipe1 = "";
            string equipe2 = "";



            for (int i = 0; i < 1; i++)
            {
                int index1 = equipasSorteadas1.Count;
                equipe1 = equipasSorteadas1[index1 - 1];
                equipasSorteadas1.RemoveAt(index1 -1);

                int index2 = equipasSorteadas2.Count;
                equipe2 = equipasSorteadas2[index2 -1];
                equipasSorteadas2.RemoveAt(index2 - 1);

                
            }

            int resultadoEquipe1 = 0; // Gera um número aleatório entre 1 e 5
            int resultadoEquipe2 = 0;

            


            for (int i = 0; i < 1; i++)
            {
               

                resultadoEquipe1 = rand.Next(0, 4); // Gera um número aleatório entre 1 e 5

                do
                {
                    resultadoEquipe2 = rand.Next(0, 4);
                } while (resultadoEquipe2 == resultadoEquipe1); // Repete até que o resultado da equipe 2 seja diferente da equipe 1


                // Adicione os resultados ao item
                string itemComResultado = $"{equipe1} {resultadoEquipe1} - {resultadoEquipe2} {equipe2}";

                // Adicione o item atualizado na segunda ListBox
                lstResultadoFinal.Items.Add(itemComResultado);

                if (resultadoEquipe1 > resultadoEquipe2)
                {
                    txtVencedor.Text = equipe1;
                }

                else
                {
                    txtVencedor.Text = equipe2;
                }
            }

            btnResultadoFinal.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnEquipasOitavos.Enabled = true;
            btnEquipasQuartos.Enabled = false;
            btnJogosQuartos.Enabled = false;
            btnResultadosQuartos.Enabled = false;
            btnEquipasMeias.Enabled = false;
            btnJogosMeias.Enabled = false;
            btnResultadosMeias.Enabled = false;
            btnFinalistas.Enabled = false;
            btnResultadoFinal.Enabled = false;

        }
    }    
}
