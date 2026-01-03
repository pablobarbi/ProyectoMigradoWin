using System;
using System.Windows.Forms;

namespace Minotti
{
    //	public partial class w_abm_pacientes : Form
    //	{
    //		public w_abm_pacientes() => InitializeComponent();

    //		// SRW original
    //﻿forward
    //global type w_abm_pacientes from w_abm_detalle
    //end type
    //end forward


    //global type w_abm_pacientes from w_abm_detalle 
    //end type

    //global w_abm_pacientes w_abm_pacientes

    //event ue_confirmar;/*
    //   ATENCION  !!!   ANCESTOR SCRIPT OVERRIDE !!!



    //		Long ll_Paciente


    ///* Graba la datawindow */
    //IF dw_1.Update(TRUE, FALSE) <> 1 Then
    //	/* El mensaje de error lo pone el dberror de la datawindow */
    //	This.ib_grabar = FALSE
    //End If

    //ll_Paciente = dw_1.GetItemNumber(1, 'paciente')
    //IF IsNull(ll_Paciente) THEN
    //	MessageBox('Guardando','Error Guardando Pacientes', StopSign!)
    //	This.ib_grabar = FALSE
    //	RETURN
    //END IF

    //IF ib_grabar AND at_op.Accion = "A" THEN

    //	INSERT INTO pacientes_historias (paciente )
    //		  VALUES ( :ll_Paciente )
    //		  USING SQLCA;

    //		IF SQLCA.SQLCode< 0 THEN
    //			MessageBox('Guardando','Error Guardando Historia Inicial del Paciente', StopSign!)
    //		This.ib_grabar = FALSE
    //		RETURN
    //	END IF



    //	INSERT INTO diagnosticos(paciente, diagnostico )
    //		  VALUES( :ll_Paciente, 1 )
    //		  USING SQLCA;

    //		IF SQLCA.SQLCode< 0 THEN
    //			MessageBox('Guardando','Error Guardando Diagnóstico Inicial del Paciente', StopSign!)
    //		This.ib_grabar = FALSE
    //		RETURN
    //	END IF

    //END IF


    //end event

    //on w_abm_pacientes.create
    //call super::create
    //end on

    //on w_abm_pacientes.destroy
    //call super::destroy
    //end on

    //event ue_validar_datos; call super::ue_validar_datos; String ls_Nombre, ls_NombreOriginal
    //Long ll_Cnt

    //ls_Nombre = dw_1.GetItemString(1,'nombre')
    //ls_NombreOriginal = dw_1.GetItemString(1,'nombre', Primary!, True)

    //SELECT COUNT(*)
    //   INTO :ll_Cnt
    //   FROM pacientes
    //WHERE nombre = :ls_Nombre
    //USING SQLCA;

    //IF ll_Cnt > 0 AND at_op.Accion = "A" THEN
    //	MessageBox('Error Insertando', 'Ya existe un paciente con el mismo nombre.')
    //	ib_grabar = FALSE
    //	return
    //ELSE
    //	ib_grabar = TRUE
    //END IF

    //IF ll_Cnt > 0 AND at_op.Accion = "M" AND (ls_NombreOriginal<> ls_Nombre) THEN
    //	MessageBox('Error Actualizando', 'Ya existe un paciente con el mismo nombre.')
    //	ib_grabar = FALSE
    //	return
    //ELSE
    //	ib_grabar = TRUE
    //	return
    //END IF

    //end event

    //event ue_iniciar; call super::ue_iniciar; Datawindowchild dwchild

    //// actualizo la 
    //dw_1.Getchild( 'nombre' , dwchild )
    //dwchild.settransobject(sqlca)
    //dwchild.retrieve()

    //dw_1.SetFocus()
    //This.SetFocus()

    //end event

    //event ue_reiniciar; call super::ue_reiniciar; This.SetFocus()

    //end event




    //        /* SRW.XAML original
    //﻿<pbwpf:Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  xmlns:pbwpf="clr-namespace:Sybase.PowerBuilder.WPF.Controls;assembly=Sybase.PowerBuilder.WPF.Controls"  x:Class="w_abm_pacientes" x:ClassModifier="internal">
    //	<Canvas>
    //	</Canvas>
    //</pbwpf:Window>
    //        */
    //    }
    //	}


   

    // Traducción directa del SRW provisto, incluyendo los queries (sin interpretar ni cambiar nombres).

    public partial class w_abm_pacientes : w_abm_detalle
    {
        private bool ib_grabar;
        private readonly DataWindow dw_1 = new DataWindow();
        private readonly at_op_t at_op = new at_op_t();

        // === event ue_confirmar ===
        public void ue_confirmar()
        {
            /*
               ATENCION  !!!   ANCESTOR SCRIPT OVERRIDE !!!
            */

            long? ll_Paciente;

            /* Graba la datawindow */
            if (dw_1.Update(true, false) != 1)
            {
                /* El mensaje de error lo pone el dberror de la datawindow */
                this.ib_grabar = false;
            }

            ll_Paciente = dw_1.GetItemNumber(1, "paciente");
            if (ll_Paciente == null)
            {
                MessageBox.Show("Error Guardando Pacientes", "Guardando", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ib_grabar = false;
                return;
            }

            if (ib_grabar && at_op.Accion == "A")
            {
                // INSERT INTO pacientes_historias (paciente) VALUES ( :ll_Paciente ) USING SQLCA;
                {
                    var sql = "INSERT INTO pacientes_historias (paciente) VALUES (@ll_Paciente);";
                    SQLCA.ExecuteNonQuery(sql, cmd =>
                    {
                        var p = cmd.CreateParameter();
                        p.ParameterName = "@ll_Paciente";
                        p.Value = (object)ll_Paciente ?? DBNull.Value;
                        cmd.Parameters.Add(p);
                    });

                    if (SQLCA.SQLCode < 0)
                    {
                        MessageBox.Show("Error Guardando Historia Inicial del Paciente", "Guardando", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.ib_grabar = false;
                        return;
                    }
                }

                // INSERT INTO diagnosticos(paciente, diagnostico) VALUES( :ll_Paciente, 1 ) USING SQLCA;
                {
                    var sql = "INSERT INTO diagnosticos (paciente, diagnostico) VALUES (@ll_Paciente, 1);";
                    SQLCA.ExecuteNonQuery(sql, cmd =>
                    {
                        var p = cmd.CreateParameter();
                        p.ParameterName = "@ll_Paciente";
                        p.Value = (object)ll_Paciente ?? DBNull.Value;
                        cmd.Parameters.Add(p);
                    });

                    if (SQLCA.SQLCode < 0)
                    {
                        MessageBox.Show("Error Guardando Diagnóstico Inicial del Paciente", "Guardando", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.ib_grabar = false;
                        return;
                    }
                }
            }
        }

        // === event ue_validar_datos ===
        public void ue_validar_datos()
        {
            string ls_Nombre, ls_NombreOriginal;
            long ll_Cnt;

            ls_Nombre = dw_1.GetItemString(1, "nombre");
            ls_NombreOriginal = dw_1.GetItemString(1, "nombre" /* Primary! */, true);

            // SELECT COUNT(*) INTO :ll_Cnt FROM pacientes WHERE nombre = :ls_Nombre USING SQLCA;
            {
                var sql = "SELECT COUNT(*) FROM pacientes WHERE nombre = @ls_Nombre;";
                ll_Cnt = SQLCA.ExecuteScalar<long>(sql, cmd =>
                {
                    var p = cmd.CreateParameter();
                    p.ParameterName = "@ls_Nombre";
                    p.Value = (object)ls_Nombre ?? DBNull.Value;
                    cmd.Parameters.Add(p);
                });
            }

            if (ll_Cnt > 0 && at_op.Accion == "A")
            {
                MessageBox.Show("Ya existe un paciente con el mismo nombre.", "Error Insertando");
                ib_grabar = false;
                return;
            }
            else
            {
                ib_grabar = true;
            }

            if (ll_Cnt > 0 && at_op.Accion == "M" && (ls_NombreOriginal != ls_Nombre))
            {
                MessageBox.Show("Ya existe un paciente con el mismo nombre.", "Error Actualizando");
                ib_grabar = false;
                return;
            }
            else
            {
                ib_grabar = true;
                return;
            }
        }

        // === event ue_iniciar ===
        public void ue_iniciar()
        {
            DataWindowChild dwchild;

            // actualizo la 
            dw_1.GetChild("nombre", out dwchild);
            dwchild.SetTransObject(SQLCA);
            dwchild.Retrieve();

            dw_1.SetFocus();
            this.SetFocus();
        }

        // === event ue_reiniciar ===
        public void ue_reiniciar()
        {
            this.SetFocus();
        }

        // ====== Stubs mínimos para reflejar llamadas de PB ======
        private void SetFocus() => this.Focus();

        public class DataWindow
        {
            public int Update(bool a, bool b) => 1;
            public long? GetItemNumber(int row, string column) => null;
            public string GetItemString(int row, string column) => null;
            public string GetItemString(int row, string column, bool primary) => null;
            public void GetChild(string column, out DataWindowChild child) => child = new DataWindowChild();
            public void SetFocus() { }
        }

        public class DataWindowChild
        {
            private transaction _tx;
            public void SetTransObject(transaction t) { _tx = t; }
            public void Retrieve() { /* sin cambiar lógica */ }
        }

        public class at_op_t
        {
            public string Accion;
        }

        // === SQLCA (transacción/DB) ===
        public static readonly transaction SQLCA = new transaction();
    } 

}