
namespace DeteccionObjetos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.org = new System.Windows.Forms.PictureBox();
            this.cargar = new System.Windows.Forms.Button();
            this.detectar = new System.Windows.Forms.Button();
            this.resultado = new System.Windows.Forms.PictureBox();
            this.objetosDataSet1 = new DeteccionObjetos.objetosDataSet();
            this.colorTableAdapter1 = new DeteccionObjetos.objetosDataSetTableAdapters.colorTableAdapter();
            this.objetoTableAdapter1 = new DeteccionObjetos.objetosDataSetTableAdapters.objetoTableAdapter();
            this.tipo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.org)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objetosDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // org
            // 
            this.org.Location = new System.Drawing.Point(12, 122);
            this.org.Name = "org";
            this.org.Size = new System.Drawing.Size(128, 81);
            this.org.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.org.TabIndex = 0;
            this.org.TabStop = false;
            // 
            // cargar
            // 
            this.cargar.Location = new System.Drawing.Point(12, 12);
            this.cargar.Name = "cargar";
            this.cargar.Size = new System.Drawing.Size(128, 33);
            this.cargar.TabIndex = 1;
            this.cargar.Text = "Cargar Imagen";
            this.cargar.UseVisualStyleBackColor = true;
            this.cargar.Click += new System.EventHandler(this.cargar_Click);
            // 
            // detectar
            // 
            this.detectar.Location = new System.Drawing.Point(12, 81);
            this.detectar.Name = "detectar";
            this.detectar.Size = new System.Drawing.Size(128, 35);
            this.detectar.TabIndex = 2;
            this.detectar.Text = "Detectar";
            this.detectar.UseVisualStyleBackColor = true;
            this.detectar.Click += new System.EventHandler(this.detectar_Click);
            // 
            // resultado
            // 
            this.resultado.Location = new System.Drawing.Point(146, 12);
            this.resultado.Name = "resultado";
            this.resultado.Size = new System.Drawing.Size(1097, 615);
            this.resultado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.resultado.TabIndex = 3;
            this.resultado.TabStop = false;
            // 
            // objetosDataSet1
            // 
            this.objetosDataSet1.DataSetName = "objetosDataSet";
            this.objetosDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // colorTableAdapter1
            // 
            this.colorTableAdapter1.ClearBeforeFill = true;
            // 
            // objetoTableAdapter1
            // 
            this.objetoTableAdapter1.ClearBeforeFill = true;
            // 
            // tipo
            // 
            this.tipo.FormattingEnabled = true;
            this.tipo.Items.AddRange(new object[] {
            "Satelites",
            "Ropa"});
            this.tipo.Location = new System.Drawing.Point(12, 51);
            this.tipo.Name = "tipo";
            this.tipo.Size = new System.Drawing.Size(128, 21);
            this.tipo.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 639);
            this.Controls.Add(this.tipo);
            this.Controls.Add(this.resultado);
            this.Controls.Add(this.detectar);
            this.Controls.Add(this.cargar);
            this.Controls.Add(this.org);
            this.Name = "Form1";
            this.Text = "Detectar Objetos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.org)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objetosDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox org;
        private System.Windows.Forms.Button cargar;
        private System.Windows.Forms.Button detectar;
        private System.Windows.Forms.PictureBox resultado;
        private objetosDataSet objetosDataSet1;
        private objetosDataSetTableAdapters.colorTableAdapter colorTableAdapter1;
        private objetosDataSetTableAdapters.objetoTableAdapter objetoTableAdapter1;
        private System.Windows.Forms.ComboBox tipo;
    }
}

