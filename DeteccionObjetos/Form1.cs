using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeteccionObjetos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bmpInicial;
        Bitmap bmpFinal;
        private void cargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.ShowDialog();
            string imagen = dia.FileName;
            org.Image = Image.FromFile(imagen);
            bmpInicial = new Bitmap(Image.FromFile(imagen));
            bmpFinal = new Bitmap(Image.FromFile(imagen));
        }

        private void detectar_Click(object sender, EventArgs e)
        {
            int w = bmpInicial.Width;
            int h = bmpInicial.Height;
            Color c = new Color();
            int st = 10;
            foreach (DataRow obj in objetosDataSet1.objeto.Rows)
            {
                switch (tipo.SelectedIndex)
                {
                    case 0:
                        if (obj[0].ToString() != "1")
                        {
                            continue;
                        }
                        break;
                    case 1:
                        if (obj[0].ToString() == "1")
                        {
                            continue;
                        }
                        break;
                    default:
                        break;
                }
                int[,] seccion = new int[st, st];
                for (int i = 0; i < st; i++)
                {
                    for (int j = 0; j < st; j++)
                    {
                        bool[,] subSeccion = new bool[(w / st), (h / st)];
                        int positivos = 0;

                        for (int k = (i * (w / st)); k < (i * (w / st)) + (w / st) - 10; k++)
                        {
                            for (int l = (j * (h / st)); l < (j * (h / st)) + (h / st) - 10; l++)
                            {
                                int cRto = 0, cGto = 0, cBto = 0;
                                for (int m = k; m < k + 10; m++)
                                {
                                    for (int n = l; n < l + 10; n++)
                                    {
                                        c = bmpInicial.GetPixel(k, l);
                                        cRto = c.R + cRto; cGto = c.G + cGto; cBto = c.B + cBto;
                                    }
                                }
                                cRto = cRto / 100;
                                cGto = cGto / 100;
                                cBto = cBto / 100;
                                foreach (DataRow color in objetosDataSet1.color.Rows)
                                {
                                    if (obj[0].ToString() == color[4].ToString())
                                    {
                                        int cR = int.Parse(color[1].ToString());
                                        int cG = int.Parse(color[2].ToString());
                                        int cB = int.Parse(color[3].ToString());

                                        if (((cR - 15 <= cRto) && (cRto <= cR + 15)) && ((cGto - 15 <= cG) && (cG <= cGto + 15)) && ((cBto - 15 <= cB) && (cB <= cBto + 15)))
                                        {
                                            for (int x = k % (w / st); x < k % (w / st) + 10; x++)
                                            {
                                                for (int y = l % (h / st); y < l % (h / st) + 10; y++)
                                                {
                                                    subSeccion[x, y] = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                        for (int x = 0; x < (w / st); x++)
                        {
                            for (int y = 0; y < (h / st); y++)
                            {
                                positivos += ((subSeccion[x, y]) ? 1 : 0);
                            }
                        }
                        float porcetaje = ((float)positivos / (float)((w / st) * (h / st))) * 100;
                        if (porcetaje > 50.00)
                        {
                            seccion[i, j] = 1;
                        }
                    }
                }
                //MessageBox.Show(obj[1]+"");
                List<int[]> cuadrados = new List<int[]>();
                for (int i = 1; i < st - 1; i++)
                {
                    for (int j = 1; j < st - 1; j++)
                    {
                        if (seccion[i, j] == 1)
                        {
                            int x = i, y = j;
                            int[] aux = new int[4] { i, j, 1, 1 };
                            while (x != st)
                            {
                                seccion[x, y] = 2;
                                if (seccion[x, y + 1] == 1)
                                {
                                    aux[3]++;
                                    seccion[x, y + 1] = 2;
                                }
                                if (seccion[x, y - 1] == 1)
                                {
                                    aux[1]--;
                                    aux[3]++;
                                    seccion[x, y - 1] = 2;
                                }
                                if ((x + 1) == st)
                                {
                                    break;
                                }
                                if (seccion[x + 1, y] == 1)
                                {
                                    aux[2]++;
                                    x++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            cuadrados.Add(aux);
                        }
                    }
                }
                Pen lp1 = new Pen(Color.Red, 3);
                Pen lp2 = new Pen(Color.Red);
                Brush br = Brushes.Red;
                if (obj[0].ToString() == "3")
                {
                    lp1 = new Pen(Color.Green, 3);
                    lp2 = new Pen(Color.Green);
                    br = Brushes.Green;
                }
                if (obj[0].ToString() == "4")
                {
                    lp1 = new Pen(Color.Blue, 3);
                    lp2 = new Pen(Color.Blue);
                    br = Brushes.Blue;
                }
                foreach (int[] cuad in cuadrados)
                {
                    using (Graphics g = Graphics.FromImage(bmpFinal))
                    {
                        g.DrawRectangle(lp1, new Rectangle(cuad[0] * (w / st), cuad[1] * (h / st), cuad[2] * (w / st), cuad[3] * (h / st)));
                        Size sizeOfText = TextRenderer.MeasureText(obj[1].ToString(), new Font("Arial", 8, FontStyle.Bold));
                        Rectangle rect = new Rectangle(cuad[0] * (w / st), cuad[1] * (h / st), sizeOfText.Width, sizeOfText.Height);
                        g.DrawRectangle(lp2, rect);
                        g.FillRectangle(br, rect);
                        g.DrawString(obj[1].ToString(), new Font("Arial", 8), new SolidBrush(Color.White), cuad[0] * (w / st), cuad[1] * (h / st));
                    }
                }
            }
            resultado.Image = bmpFinal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.colorTableAdapter1.Fill(this.objetosDataSet1.color);
            this.objetoTableAdapter1.Fill(this.objetosDataSet1.objeto);
        }
    }
}
