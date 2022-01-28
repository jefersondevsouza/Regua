using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Regua
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.InitMove();
            this.InitResizeHorizontal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Tamanho da regua
        bool arrastar = false;
        int tamanho = 0;
        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastar)
            {
                this.Size = new Size((this.Size.Width + (e.Location.X - tamanho)), this.Size.Height);
                tamanho = e.Location.X;
                Application.DoEvents();
            }
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
           // arrastar = true;
            tamanho = e.Location.X;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            arrastar = false;
        } 
        #endregion

        #region Move

        private Point firstPoint = new Point();
        public void InitMove()
        {
            this.MoverControle(this);
            this.MoverControle(this.pictureBox1);
        }

        public void MoverControle(Control control)
        {
            control.MouseEnter += (ss, ee) =>
            {
                this.Cursor = Cursors.NoMove2D;
            };

            control.MouseLeave += (ss, ee) =>
            {
                this.Cursor = Cursors.Default;
            };

            control.MouseDown += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    firstPoint = Control.MousePosition;
                }
            };

            control.MouseMove += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    //criar um ponto temporario
                    Point temp = Control.MousePosition;
                    Point res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);
                    //aplica o valor ao objeto
                    this.Location = new Point(this.Location.X - res.X, this.Location.Y - res.Y);

                    //update firstPoint
                    firstPoint = temp;
                }
            };
        }
        #endregion

        int vertRigthInic = 0;
        private void InitResizeHorizontal()
        {
            button2.MouseEnter += (ss, ee) =>
            {
                this.Cursor = Cursors.SizeWE;
            };

            button2.MouseLeave += (ss, ee) =>
            {
                this.Cursor = Cursors.Default;
            };

            button2.MouseDown += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    vertRigthInic = Control.MousePosition.X;
                }
            };

            button2.MouseMove += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    //criar um ponto temporario
                    int temp = Control.MousePosition.X;
                    int res = vertRigthInic - temp;
                    //aplica o valor ao objeto
                    this.Size = new Size(this.Width - res, this.Height);
                    //update firstPoint
                    vertRigthInic = temp;
                }
            };
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
