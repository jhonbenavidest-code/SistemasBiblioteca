namespace SistemasBiblioteca.CapaPresentacion
{
    partial class FormReportes
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
            this.lblTotalUsuarios = new System.Windows.Forms.Label();
            this.lblTotalTitulos = new System.Windows.Forms.Label();
            this.lblDisponibles = new System.Windows.Forms.Label();
            this.lblPrestamosActivos = new System.Windows.Forms.Label();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotalUsuarios
            // 
            this.lblTotalUsuarios.AutoSize = true;
            this.lblTotalUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalUsuarios.Location = new System.Drawing.Point(188, 56);
            this.lblTotalUsuarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalUsuarios.Name = "lblTotalUsuarios";
            this.lblTotalUsuarios.Size = new System.Drawing.Size(50, 20);
            this.lblTotalUsuarios.TabIndex = 0;
            this.lblTotalUsuarios.Text = "label1";
            // 
            // lblTotalTitulos
            // 
            this.lblTotalTitulos.AutoSize = true;
            this.lblTotalTitulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalTitulos.Location = new System.Drawing.Point(312, 56);
            this.lblTotalTitulos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalTitulos.Name = "lblTotalTitulos";
            this.lblTotalTitulos.Size = new System.Drawing.Size(50, 20);
            this.lblTotalTitulos.TabIndex = 1;
            this.lblTotalTitulos.Text = "label2";
            // 
            // lblDisponibles
            // 
            this.lblDisponibles.AutoSize = true;
            this.lblDisponibles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDisponibles.Location = new System.Drawing.Point(447, 56);
            this.lblDisponibles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDisponibles.Name = "lblDisponibles";
            this.lblDisponibles.Size = new System.Drawing.Size(50, 20);
            this.lblDisponibles.TabIndex = 2;
            this.lblDisponibles.Text = "label3";
            // 
            // lblPrestamosActivos
            // 
            this.lblPrestamosActivos.AutoSize = true;
            this.lblPrestamosActivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPrestamosActivos.Location = new System.Drawing.Point(598, 56);
            this.lblPrestamosActivos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrestamosActivos.Name = "lblPrestamosActivos";
            this.lblPrestamosActivos.Size = new System.Drawing.Size(50, 20);
            this.lblPrestamosActivos.TabIndex = 3;
            this.lblPrestamosActivos.Text = "label4";
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(196, 19);
            this.dgvHistorial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(852, 438);
            this.dgvHistorial.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPrestamosActivos);
            this.groupBox1.Controls.Add(this.lblDisponibles);
            this.groupBox1.Controls.Add(this.lblTotalTitulos);
            this.groupBox1.Controls.Add(this.lblTotalUsuarios);
            this.groupBox1.Location = new System.Drawing.Point(196, 496);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(852, 123);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reporte ";
            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 677);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvHistorial);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormReportes";
            this.Text = "FormReportes";
            this.Load += new System.EventHandler(this.FormReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTotalUsuarios;
        private System.Windows.Forms.Label lblTotalTitulos;
        private System.Windows.Forms.Label lblDisponibles;
        private System.Windows.Forms.Label lblPrestamosActivos;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}