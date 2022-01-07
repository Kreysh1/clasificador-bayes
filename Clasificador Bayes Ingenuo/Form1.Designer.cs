
namespace Clasificador_Bayes_Ingenuo
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_dataset = new System.Windows.Forms.TextBox();
            this.cmd_path = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Validacion = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_Entrenamiento = new System.Windows.Forms.TextBox();
            this.txt_rutaprueba = new System.Windows.Forms.TextBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.DialogoArchivo = new System.Windows.Forms.OpenFileDialog();
            this.txt_clase = new System.Windows.Forms.NumericUpDown();
            this.dgvDataset = new System.Windows.Forms.DataGridView();
            this.txt_intervalo = new System.Windows.Forms.NumericUpDown();
            this.TablaConfusion = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dvgEvaluacion = new System.Windows.Forms.DataGridView();
            this.Categorias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_accuracy = new System.Windows.Forms.TextBox();
            this.DatasetDensidad = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.DialogoPruebas = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_clase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_intervalo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablaConfusion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEvaluacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatasetDensidad)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cargar dataset:";
            // 
            // txt_dataset
            // 
            this.txt_dataset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dataset.Location = new System.Drawing.Point(150, 85);
            this.txt_dataset.Name = "txt_dataset";
            this.txt_dataset.Size = new System.Drawing.Size(317, 22);
            this.txt_dataset.TabIndex = 1;
            // 
            // cmd_path
            // 
            this.cmd_path.Location = new System.Drawing.Point(473, 85);
            this.cmd_path.Name = "cmd_path";
            this.cmd_path.Size = new System.Drawing.Size(75, 23);
            this.cmd_path.TabIndex = 2;
            this.cmd_path.Text = "Ruta...";
            this.cmd_path.UseVisualStyleBackColor = true;
            this.cmd_path.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(473, 42);
            this.label2.TabIndex = 3;
            this.label2.Text = "Clasificador Bayes Ingenuo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(602, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pruebas:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Tomato;
            this.groupBox1.Controls.Add(this.Validacion);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txt_Entrenamiento);
            this.groupBox1.Controls.Add(this.txt_rutaprueba);
            this.groupBox1.Controls.Add(this.radioButton6);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(682, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 133);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // Validacion
            // 
            this.Validacion.AutoSize = true;
            this.Validacion.Checked = true;
            this.Validacion.Font = new System.Drawing.Font("Palatino Linotype", 9.75F);
            this.Validacion.Location = new System.Drawing.Point(17, 14);
            this.Validacion.Name = "Validacion";
            this.Validacion.Size = new System.Drawing.Size(133, 22);
            this.Validacion.TabIndex = 10;
            this.Validacion.TabStop = true;
            this.Validacion.Text = "Validacion simple";
            this.Validacion.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Validacion.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(371, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Ruta...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txt_Entrenamiento
            // 
            this.txt_Entrenamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Entrenamiento.Location = new System.Drawing.Point(218, 16);
            this.txt_Entrenamiento.Name = "txt_Entrenamiento";
            this.txt_Entrenamiento.Size = new System.Drawing.Size(60, 22);
            this.txt_Entrenamiento.TabIndex = 7;
            // 
            // txt_rutaprueba
            // 
            this.txt_rutaprueba.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_rutaprueba.Location = new System.Drawing.Point(17, 90);
            this.txt_rutaprueba.Name = "txt_rutaprueba";
            this.txt_rutaprueba.Size = new System.Drawing.Size(317, 22);
            this.txt_rutaprueba.TabIndex = 9;
            this.txt_rutaprueba.TextChanged += new System.EventHandler(this.txt_rutaprueba_TextChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Font = new System.Drawing.Font("Palatino Linotype", 9.75F);
            this.radioButton6.Location = new System.Drawing.Point(20, 62);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(195, 22);
            this.radioButton6.TabIndex = 0;
            this.radioButton6.Text = "Archivo de pruebas externo:";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(687, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "Intervalo de discretización:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1042, 231);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Análisis";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DialogoArchivo
            // 
            this.DialogoArchivo.FileName = "openFileDialog1";
            // 
            // txt_clase
            // 
            this.txt_clase.Location = new System.Drawing.Point(150, 124);
            this.txt_clase.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_clase.Name = "txt_clase";
            this.txt_clase.Size = new System.Drawing.Size(62, 20);
            this.txt_clase.TabIndex = 13;
            this.txt_clase.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dgvDataset
            // 
            this.dgvDataset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataset.Location = new System.Drawing.Point(16, 299);
            this.dgvDataset.Name = "dgvDataset";
            this.dgvDataset.Size = new System.Drawing.Size(563, 291);
            this.dgvDataset.TabIndex = 14;
            // 
            // txt_intervalo
            // 
            this.txt_intervalo.Location = new System.Drawing.Point(898, 234);
            this.txt_intervalo.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.txt_intervalo.Name = "txt_intervalo";
            this.txt_intervalo.Size = new System.Drawing.Size(62, 20);
            this.txt_intervalo.TabIndex = 15;
            this.txt_intervalo.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // TablaConfusion
            // 
            this.TablaConfusion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TablaConfusion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaConfusion.Location = new System.Drawing.Point(16, 617);
            this.TablaConfusion.Name = "TablaConfusion";
            this.TablaConfusion.Size = new System.Drawing.Size(567, 270);
            this.TablaConfusion.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 21);
            this.label7.TabIndex = 17;
            this.label7.Text = "Dataset";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 22);
            this.label8.TabIndex = 18;
            this.label8.Text = "Columna de clase:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 594);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 21);
            this.label6.TabIndex = 19;
            this.label6.Text = "Matriz de Confusión";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(590, 593);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 21);
            this.label9.TabIndex = 20;
            this.label9.Text = "Matriz de Evaluacion";
            // 
            // dvgEvaluacion
            // 
            this.dvgEvaluacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgEvaluacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgEvaluacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Categorias,
            this.Precision,
            this.Recall,
            this.F1});
            this.dvgEvaluacion.Location = new System.Drawing.Point(594, 617);
            this.dvgEvaluacion.Name = "dvgEvaluacion";
            this.dvgEvaluacion.Size = new System.Drawing.Size(613, 270);
            this.dvgEvaluacion.TabIndex = 21;
            // 
            // Categorias
            // 
            this.Categorias.HeaderText = "Categorias";
            this.Categorias.Name = "Categorias";
            // 
            // Precision
            // 
            this.Precision.HeaderText = "Precision";
            this.Precision.Name = "Precision";
            // 
            // Recall
            // 
            this.Recall.HeaderText = "Recall";
            this.Recall.Name = "Recall";
            // 
            // F1
            // 
            this.F1.HeaderText = "F1";
            this.F1.Name = "F1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(957, 900);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 21);
            this.label10.TabIndex = 22;
            this.label10.Text = "Accuracy:";
            // 
            // txt_accuracy
            // 
            this.txt_accuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_accuracy.Location = new System.Drawing.Point(1044, 900);
            this.txt_accuracy.Name = "txt_accuracy";
            this.txt_accuracy.Size = new System.Drawing.Size(60, 22);
            this.txt_accuracy.TabIndex = 10;
            // 
            // DatasetDensidad
            // 
            this.DatasetDensidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatasetDensidad.Location = new System.Drawing.Point(589, 299);
            this.DatasetDensidad.Name = "DatasetDensidad";
            this.DatasetDensidad.Size = new System.Drawing.Size(622, 291);
            this.DatasetDensidad.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(585, 275);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 21);
            this.label11.TabIndex = 24;
            this.label11.Text = "Densidad";
            // 
            // DialogoPruebas
            // 
            this.DialogoPruebas.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tomato;
            this.ClientSize = new System.Drawing.Size(1215, 895);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.DatasetDensidad);
            this.Controls.Add(this.txt_accuracy);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dvgEvaluacion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TablaConfusion);
            this.Controls.Add(this.txt_intervalo);
            this.Controls.Add(this.dgvDataset);
            this.Controls.Add(this.txt_clase);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmd_path);
            this.Controls.Add(this.txt_dataset);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Clasificador Bayes Ingenuo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_clase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_intervalo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablaConfusion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEvaluacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatasetDensidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_dataset;
        private System.Windows.Forms.Button cmd_path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_Entrenamiento;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_rutaprueba;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog DialogoArchivo;
        private System.Windows.Forms.NumericUpDown txt_clase;
        private System.Windows.Forms.DataGridView dgvDataset;
        private System.Windows.Forms.NumericUpDown txt_intervalo;
        private System.Windows.Forms.DataGridView TablaConfusion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dvgEvaluacion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_accuracy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categorias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precision;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recall;
        private System.Windows.Forms.DataGridViewTextBoxColumn F1;
        private System.Windows.Forms.DataGridView DatasetDensidad;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton Validacion;
        private System.Windows.Forms.OpenFileDialog DialogoPruebas;
    }
}

