using Minotti.Views;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Minotti.WinForms.Views
{
    internal partial class w_coneccion_sepad : w_coneccion
    {
        // ------------------------------------------------------------
        // Equivalente a: type variables / instancia PB
        // ------------------------------------------------------------
        // String nro_serie
        private string nro_serie = string.Empty;

        // Si en PB ya existían estas variables en el ancestro, dejá solo las referencias
        // y eliminá estas declaraciones.
        private int fallidos;   // cuenta intentos
        private int Intentos;   // cantidad máxima de intentos
        private int Retorno;    // retorno de ue_cargar_usuario

        // ------------------------------------------------------------
        // P/Invoke GetVolumeInformationA (PB -> C#)
        //
        // function long GetVolumeInformationA(
        //   ref string ls_RootPath,
        //   ref string ls_VolName,
        //   long ll_VolLen,
        //   ref string ls_volserial,
        //   long ll_maxcomplen,
        //   long ll_systemflags,
        //   ref string ls_SystemName,
        //   long ll_SystemLen ) Library 'kernel32'
        // ------------------------------------------------------------
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool GetVolumeInformation(
            string lpRootPathName,
            StringBuilder lpVolumeNameBuffer,
            int nVolumeNameSize,
            out uint lpVolumeSerialNumber,
            out uint lpMaximumComponentLength,
            out uint lpFileSystemFlags,
            StringBuilder lpFileSystemNameBuffer,
            int nFileSystemNameSize);

        // ------------------------------------------------------------
        // public subroutine wf_centrar_response ()
        // ------------------------------------------------------------
        public void wf_centrar_response()
        {
            // /* Centra la ventana de response */
            // environment env
            // real Y_desviacion = 1
            // real X_desviacion = 1
            //
            // If GetEnvironment(env) = 1 Then
            //   this.x = int ((PixelsToUnits(env.ScreenWidth, XPixelsToUnits!) - this.Width) / 2 * X_desviacion)
            //   this.y = int ((PixelsToUnits(env.ScreenHeight, YPixelsToUnits!) - this.Height) / 2 * Y_desviacion)
            // End If 

            double Y_desviacion = 1.0;
            double X_desviacion = 1.0;

            var screen = Screen.FromControl(this);
            var bounds = screen.WorkingArea;

            this.Left = (int)((bounds.Width - this.Width) / 2.0 * X_desviacion) + bounds.Left;
            this.Top = (int)((bounds.Height - this.Height) / 2.0 * Y_desviacion) + bounds.Top;
        }

        // ------------------------------------------------------------
        // public function boolean wf_validar_clave (string as_nro_serie)
        // ------------------------------------------------------------
        public bool wf_validar_clave(string as_nro_serie)
        {
            // String ls_Array[], ls_Usuario
            // Long   ll_Cnt, ll_Valor

            if (string.IsNullOrEmpty(as_nro_serie))
                return false;

            string[] ls_Array = new string[as_nro_serie.Length + 1]; // 1-based como PB
            long ll_Valor = 0;

            for (int ll_Cnt = 1; ll_Cnt <= as_nro_serie.Length; ll_Cnt++)
            {
                string ch = as_nro_serie.Substring(ll_Cnt - 1, 1);
                ls_Array[ll_Cnt] = ch;

                // IF IsNumber(ls_Array[ll_Cnt]) THEN
                //   ll_Valor = ll_Valor + Long(ls_Array[ll_Cnt])
                // END IF
                if (char.IsDigit(ch[0]))
                {
                    ll_Valor += (long)char.GetNumericValue(ch[0]);
                }
            }

            // ls_Usuario = sle_usuario_aplicacion.text
            string ls_Usuario = sle_usuario_aplicacion.Text;

            // Toda la cadena de IFs exactamente igual
            if (ll_Valor == 1 && ls_Usuario != "usuario1") return false;
            if (ll_Valor == 2 && ls_Usuario != "usuario2") return false;
            if (ll_Valor == 3 && ls_Usuario != "usuario3") return false;
            if (ll_Valor == 4 && ls_Usuario != "usuario4") return false;
            if (ll_Valor == 5 && ls_Usuario != "usuario5") return false;
            if (ll_Valor == 6 && ls_Usuario != "usuario6") return false;
            if (ll_Valor == 7 && ls_Usuario != "usuario7") return false;
            if (ll_Valor == 8 && ls_Usuario != "usuario8") return false;
            if (ll_Valor == 9 && ls_Usuario != "usuario9") return false;
            if (ll_Valor == 10 && ls_Usuario != "usuario10") return false;
            if (ll_Valor == 11 && ls_Usuario != "usuario11") return false;
            if (ll_Valor == 12 && ls_Usuario != "usuario12") return false;
            if (ll_Valor == 13 && ls_Usuario != "usuario13") return false;
            if (ll_Valor == 14 && ls_Usuario != "usuario14") return false;
            if (ll_Valor == 15 && ls_Usuario != "usuario15") return false;
            if (ll_Valor == 16 && ls_Usuario != "usuario16") return false;
            if (ll_Valor == 17 && ls_Usuario != "usuario17") return false;
            if (ll_Valor == 18 && ls_Usuario != "usuario18") return false;
            if (ll_Valor == 19 && ls_Usuario != "usuario19") return false;
            if (ll_Valor == 20 && ls_Usuario != "usuario20") return false;
            if (ll_Valor == 21 && ls_Usuario != "usuario21") return false;
            if (ll_Valor == 22 && ls_Usuario != "usuario22") return false;
            if (ll_Valor == 23 && ls_Usuario != "usuario23") return false;
            if (ll_Valor == 24 && ls_Usuario != "usuario24") return false;
            if (ll_Valor == 25 && ls_Usuario != "usuario25") return false;
            if (ll_Valor == 26 && ls_Usuario != "usuario26") return false;
            if (ll_Valor == 27 && ls_Usuario != "usuario27") return false;
            if (ll_Valor == 28 && ls_Usuario != "usuario28") return false;
            if (ll_Valor == 29 && ls_Usuario != "usuario29") return false;
            if (ll_Valor == 30 && ls_Usuario != "usuario30") return false;
            if (ll_Valor == 31 && ls_Usuario != "usuario31") return false;
            if (ll_Valor == 32 && ls_Usuario != "usuario32") return false;
            if (ll_Valor == 33 && ls_Usuario != "usuario33") return false;
            if (ll_Valor == 34 && ls_Usuario != "usuario34") return false;
            if (ll_Valor == 35 && ls_Usuario != "usuario35") return false;
            if (ll_Valor == 36 && ls_Usuario != "usuario36") return false;
            if (ll_Valor == 37 && ls_Usuario != "usuario37") return false;
            if (ll_Valor == 38 && ls_Usuario != "usuario38") return false;
            if (ll_Valor == 39 && ls_Usuario != "usuario39") return false;
            if (ll_Valor == 40 && ls_Usuario != "usuario40") return false;
            if (ll_Valor == 41 && ls_Usuario != "usuario41") return false;
            if (ll_Valor == 42 && ls_Usuario != "usuario42") return false;
            if (ll_Valor == 43 && ls_Usuario != "usuario43") return false;
            if (ll_Valor == 44 && ls_Usuario != "usuario44") return false;
            if (ll_Valor == 45 && ls_Usuario != "usuario45") return false;
            if (ll_Valor == 46 && ls_Usuario != "usuario46") return false;
            if (ll_Valor == 47 && ls_Usuario != "usuario47") return false;
            if (ll_Valor == 48 && ls_Usuario != "usuario48") return false;
            if (ll_Valor == 49 && ls_Usuario != "usuario49") return false;
            if (ll_Valor == 50 && ls_Usuario != "usuario50") return false;
            if (ll_Valor == 51 && ls_Usuario != "usuario51") return false;
            if (ll_Valor == 52 && ls_Usuario != "usuario52") return false;
            if (ll_Valor == 53 && ls_Usuario != "usuario53") return false;
            if (ll_Valor == 54 && ls_Usuario != "usuario54") return false;
            if (ll_Valor == 55 && ls_Usuario != "usuario55") return false;
            if (ll_Valor == 56 && ls_Usuario != "usuario56") return false;
            if (ll_Valor == 57 && ls_Usuario != "usuario57") return false;
            if (ll_Valor == 58 && ls_Usuario != "usuario58") return false;
            if (ll_Valor == 59 && ls_Usuario != "usuario59") return false;
            if (ll_Valor == 60 && ls_Usuario != "usuario60") return false;
            if (ll_Valor == 61 && ls_Usuario != "usuario61") return false;
            if (ll_Valor == 62 && ls_Usuario != "usuario62") return false;
            if (ll_Valor == 63 && ls_Usuario != "usuario63") return false;
            if (ll_Valor == 64 && ls_Usuario != "usuario64") return false;
            if (ll_Valor == 65 && ls_Usuario != "usuario65") return false;
            if (ll_Valor == 66 && ls_Usuario != "usuario66") return false;
            if (ll_Valor == 67 && ls_Usuario != "usuario67") return false;
            if (ll_Valor == 68 && ls_Usuario != "usuario68") return false;
            if (ll_Valor == 69 && ls_Usuario != "usuario69") return false;
            if (ll_Valor == 70 && ls_Usuario != "usuario70") return false;
            if (ll_Valor == 71 && ls_Usuario != "usuario71") return false;
            if (ll_Valor == 72 && ls_Usuario != "usuario72") return false;
            if (ll_Valor == 73 && ls_Usuario != "usuario73") return false;
            if (ll_Valor == 74 && ls_Usuario != "usuario74") return false;
            if (ll_Valor == 75 && ls_Usuario != "usuario75") return false;
            if (ll_Valor == 76 && ls_Usuario != "usuario76") return false;
            if (ll_Valor == 77 && ls_Usuario != "usuario77") return false;
            if (ll_Valor == 78 && ls_Usuario != "usuario78") return false;
            if (ll_Valor == 79 && ls_Usuario != "usuario79") return false;
            if (ll_Valor == 80 && ls_Usuario != "usuario80") return false;
            if (ll_Valor == 81 && ls_Usuario != "usuario81") return false;
            if (ll_Valor == 82 && ls_Usuario != "usuario82") return false;
            if (ll_Valor == 83 && ls_Usuario != "usuario83") return false;
            if (ll_Valor == 84 && ls_Usuario != "usuario84") return false;
            if (ll_Valor == 85 && ls_Usuario != "usuario85") return false;
            if (ll_Valor == 86 && ls_Usuario != "usuario86") return false;
            if (ll_Valor == 87 && ls_Usuario != "usuario87") return false;
            if (ll_Valor == 88 && ls_Usuario != "usuario88") return false;
            if (ll_Valor == 89 && ls_Usuario != "usuario89") return false;
            if (ll_Valor == 90 && ls_Usuario != "usuario90") return false;
            if (ll_Valor == 91 && ls_Usuario != "usuario91") return false;
            if (ll_Valor == 92 && ls_Usuario != "usuario92") return false;
            if (ll_Valor == 93 && ls_Usuario != "usuario93") return false;
            if (ll_Valor == 94 && ls_Usuario != "usuario94") return false;
            if (ll_Valor == 95 && ls_Usuario != "usuario95") return false;
            if (ll_Valor == 96 && ls_Usuario != "usuario96") return false;
            if (ll_Valor == 97 && ls_Usuario != "usuario97") return false;
            if (ll_Valor == 98 && ls_Usuario != "usuario98") return false;
            if (ll_Valor == 99 && ls_Usuario != "usuario99") return false;
            if (ll_Valor == 100 && ls_Usuario != "usuario100") return false;

            return true;
        }

        // ------------------------------------------------------------
        // public subroutine wf_nro_serie ()
        // ------------------------------------------------------------
        public void wf_nro_serie()
        {
            // String ls_Volume, cunidad, cserial
            // String ls_Drive, ls_FileSys, ls_Flags, ls_Serial, ls_Array[]
            // Long ll_Max, ll_Flags, ll_RC, ll_FileSys 
            // Long ll_Volume, ll_Cnt, ll_Valor

            nro_serie = string.Empty;

            string ls_Volume;
            string cserial;
            string ls_Drive;
            string[] ls_Array;

            long ll_Valor = 0;

            // ls_Drive = "c:\"
            ls_Drive = @"C:\";

            var volumeName = new StringBuilder(32);
            var fileSystemName = new StringBuilder(32);
            uint serialNumber;
            uint maxComponentLength;
            uint fileSystemFlags;

            bool ll_RC = GetVolumeInformation(
                ls_Drive,
                volumeName,
                volumeName.Capacity,
                out serialNumber,
                out maxComponentLength,
                out fileSystemFlags,
                fileSystemName,
                fileSystemName.Capacity);

            if (!ll_RC)
            {
                ls_Volume = string.Empty;
            }
            else
            {
                ls_Volume = volumeName.ToString().TrimEnd('\0', ' ');
            }

            // En PB: cserial = ls_Serial
            // Acá usamos el número de serie devuelto por la API.
            cserial = serialNumber.ToString();

            // nalargo = len(trim(cserial))
            int nalargo = cserial.Trim().Length;
            int[] NoSerie = new int[nalargo + 1]; // 1-based como PB

            int posi;

            // FOR posi = 1 TO nalargo
            //   NoSerie[ (nalargo + 1) - posi] = ASC(string(mid (cserial , posi,1) ) )
            // NEXT
            for (posi = 1; posi <= nalargo; posi++)
            {
                char ch = cserial[posi - 1];
                NoSerie[(nalargo + 1) - posi] = (int)ch;
            }

            // FOR posi = 1 TO nalargo
            //   nro_serie+= f_longtohex(NoSerie[ posi ],2)
            //   if posi=2 then nro_serie+="-"
            // NEXT
            for (posi = 1; posi <= nalargo; posi++)
            {
                nro_serie += f_longtohex(NoSerie[posi], 2);
                if (posi == 2)
                {
                    nro_serie += "-";
                }
            }

            // muestro el numero en la ventana: se hace más abajo con el valor
            // st_serial.Text = st_serial.Text + nro_serie

            // FOR ll_Cnt = 1 TO Len(nro_serie)
            //   ls_Array[ll_Cnt] = Mid(nro_serie, ll_Cnt, 1)
            //   IF IsNumber(ls_Array[ll_Cnt]) THEN
            //     ll_Valor = ll_Valor + Long(ls_Array[ll_Cnt])
            //   END IF
            // NEXT

            ls_Array = new string[nro_serie.Length + 1];
            for (int ll_Cnt = 1; ll_Cnt <= nro_serie.Length; ll_Cnt++)
            {
                string ch = nro_serie.Substring(ll_Cnt - 1, 1);
                ls_Array[ll_Cnt] = ch;

                if (char.IsDigit(ch[0]))
                {
                    ll_Valor += (long)char.GetNumericValue(ch[0]);
                }
            }

            // st_serial.Text = st_serial.Text + " (" + String(ll_Valor) + ")"
            st_serial.Text = st_serial.Text + ll_Valor.ToString();
        }

        // Helper que replica f_longtohex(Long,2)
        private static string f_longtohex(int value, int width)
        {
            // Long a hex con ancho fijo
            return value.ToString("X" + width);
        }

        // ------------------------------------------------------------
        // event open (PB) -> Load del Form en C#
        // ------------------------------------------------------------
        private void w_coneccion_sepad_Load(object sender, EventArgs e)
        {
            // /* Centra la ventana de splah */
            wf_centrar_response();

            // // pruebo si me trae el nro. de serie del disco.
            wf_nro_serie();
        }

        // ------------------------------------------------------------
        // event ue_conectar
        // ------------------------------------------------------------
        public void ue_conectar()
        {
            // /*
            //   ATENCION !!!  ANCESTOR SCRIPT OVERRIDE !!!
            // */
            Cursor.Current = Cursors.WaitCursor;

            // This.TriggerEvent("ue_leer")
            // >>> acá llamá al método que represente ese trigger en tu port
            // ue_leer(); // por ejemplo, si lo definiste así

            // IF NOT wf_validar_clave(nro_serie) THEN
            if (!wf_validar_clave(nro_serie))
            {
                MessageBox.Show(
                    "Problemas al intentar conectarse al sistema.",
                    "Error en Conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                /* Cuenta los intentos fallidos y, después de la cantidad definida, cierra la ventana */
                fallidos += 1;
                if (fallidos == Intentos)
                {
                    // Halt Close
                    Application.Exit();
                }

                // SetNull(at_usuario.usuario)
                // en C#, equivalente a null
                at_usuario.usuario = null;

                sle_usuario_base.Focus();
                return;
            }

            /* Se conecta a la base de datos */
            // Connect using SQLCA;
            // Acá llamá a tu método de conexión que envuelve SQLCA
            // Ej: SqlHelper.Connect(SQLCA);

            // If SQLCA.SqlCode = -1  Then
            if (SQLCA.SqlCode == -1)
            {
                MessageBox.Show(
                    "Problemas al intentar conectarse a la base de datos\r\n" + SQLCA.SqlErrText,
                    "Error en Conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                /* Cuenta los intentos fallidos y, después de la cantidad definida, cierra la ventana */
                fallidos += 1;
                if (fallidos == Intentos)
                {
                    // Halt Close
                    Application.Exit();
                }

                at_usuario.usuario = null;
                sle_usuario_base.Focus();
                return;
            }

            // This.TriggerEvent("ue_cargar_usuario")
            // If Retorno <> 1 Then
            //   ...
            // End If

            // Acá asumimos que ue_cargar_usuario devuelve int (Retorno)
            Retorno = ue_cargar_usuario();
            if (Retorno != 1)
            {
                /* Cuenta los intentos fallidos y, después de la cantidad definida, cierra la ventana */
                fallidos += 1;
                if (fallidos == Intentos)
                {
                    // Halt Close
                    Application.Exit();
                }

                sle_usuario_base.Focus();

                // Disconnect using SQLCA;
                // Llamá a tu helper / wrapper para desconectar
                // SqlHelper.Disconnect(SQLCA);

                return;
            }

            // This.PostEvent("Close")
            this.Close();
        }

        // ------------------------------------------------------------
        // Placeholders de cosas que ya deberías tener portadas
        // ------------------------------------------------------------

        // En PB: This.TriggerEvent("ue_cargar_usuario") y usa Retorno.
        // Acá lo dejo como método para que lo implementes/enganches según tu port.
        private int ue_cargar_usuario()
        {
            // TODO: implementar según tu lógica de PB ya migrada
            return Retorno;
        }

        // En PB: SQLCA es el transaction object. Acá lo supongo como propiedad/objeto
        // que vos ya definiste en la clase base w_coneccion o a nivel global.
        private dynamic SQLCA => /* TODO: tu objeto de conexión */ null;

        // En PB: at_usuario.usuario
        // Acá supongo que ya tenés una clase con esa propiedad.
        private dynamic at_usuario => /* TODO: tu objeto de usuario */ null;
    }
}
