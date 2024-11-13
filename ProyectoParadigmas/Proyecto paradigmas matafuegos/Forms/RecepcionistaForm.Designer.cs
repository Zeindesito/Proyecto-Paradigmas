namespace Proyecto_paradigmas_matafuegos
{
    partial class RecepcionistaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonVenta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textApellido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textDni = new System.Windows.Forms.TextBox();
            this.ButtonAgregar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonVenta
            // 
            this.ButtonVenta.Location = new System.Drawing.Point(266, 272);
            this.ButtonVenta.Name = "ButtonVenta";
            this.ButtonVenta.Size = new System.Drawing.Size(154, 74);
            this.ButtonVenta.TabIndex = 1;
            this.ButtonVenta.Text = "Venta";
            this.ButtonVenta.UseVisualStyleBackColor = true;
            this.ButtonVenta.Click += new System.EventHandler(this.ButtonVenta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ingresar Nuevo Cliente:";
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(85, 54);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(131, 20);
            this.textNombre.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Apellido:";
            // 
            // textApellido
            // 
            this.textApellido.Location = new System.Drawing.Point(85, 80);
            this.textApellido.Name = "textApellido";
            this.textApellido.Size = new System.Drawing.Size(131, 20);
            this.textApellido.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "DNI:";
            // 
            // textDni
            // 
            this.textDni.Location = new System.Drawing.Point(85, 106);
            this.textDni.Name = "textDni";
            this.textDni.Size = new System.Drawing.Size(131, 20);
            this.textDni.TabIndex = 9;
            // 
            // ButtonAgregar
            // 
            this.ButtonAgregar.Location = new System.Drawing.Point(240, 54);
            this.ButtonAgregar.Name = "ButtonAgregar";
            this.ButtonAgregar.Size = new System.Drawing.Size(154, 74);
            this.ButtonAgregar.TabIndex = 12;
            this.ButtonAgregar.Text = "Agregar";
            this.ButtonAgregar.UseVisualStyleBackColor = true;
            this.ButtonAgregar.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(45, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 74);
            this.button1.TabIndex = 13;
            this.button1.Text = "Servicio";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(546, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(341, 302);
            this.dataGridView1.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(568, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(299, 24);
            this.label4.TabIndex = 15;
            this.label4.Text = "LISTA DE CLIENTES CARGADOS";
            // 
            // RecepcionistaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 375);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ButtonAgregar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textDni);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textApellido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonVenta);
            this.Name = "RecepcionistaForm";
            this.Text = "RecepcionistaForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonServicio;
        private System.Windows.Forms.Button ButtonVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textApellido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textDni;
        private System.Windows.Forms.Button ButtonAgregar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
    }
}